/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SD.HnD.BL;
using SD.HnD.Utility;
using SD.HnD.DAL.EntityClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind file for the CloseThread form
	/// </summary>
	public partial class CloseThread : System.Web.UI.Page
	{
		#region Class Member Declarations
		private int _startAtMessageIndex;
		private ThreadEntity _thread;
		#endregion

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			int threadID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ThreadID"]);
			_thread = ThreadGuiHelper.GetThread(threadID);
			if(_thread == null)
			{
				// not found, return to default page
				Response.Redirect("default.aspx", true);
			}

			_startAtMessageIndex = HnDGeneralUtils.TryConvertToInt(Request.QueryString["StartAtMessage"]);

			if(_thread.IsClosed)
			{
				// is already closed
				Response.Redirect("default.aspx", true);
			}

			// Check access credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			bool userMayDoThreadManagement = SessionAdapter.HasSystemActionRight(ActionRights.ForumSpecificThreadManagement)||
								SessionAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement);

			if(!userHasAccess || !userMayDoThreadManagement)
			{
				// doesn't have access to this forum or may not alter the thread's properties. redirect
				Response.Redirect("default.aspx", true);
			}

			// check if the user can view this thread. If not, don't continue.
			if((_thread.StartedByUserID != SessionAdapter.GetUserID()) &&
				!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!_thread.IsSticky)
			{
				// can't view this thread, it isn't visible to the user
				Response.Redirect("default.aspx", true);
			}

			bool userMayAddNewMessages = false;
			if(!_thread.IsClosed)
			{
				if(_thread.IsSticky)
				{
					if(SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessageInSticky))
					{
						userMayAddNewMessages = true;
					}
				}
				else
				{
					if(SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessage))
					{
						userMayAddNewMessages = true;
					}
				}
			}

			if(!userMayAddNewMessages)
			{
				// is not allowed to post a new message. This forum allows the user to add a new message and close the thread at the same time. 
				// deny.
				Response.Redirect("default.aspx", true);
			}

			if(!Page.IsPostBack)
			{
				// fill the page's content
				ForumEntity forum = CacheManager.GetForum(_thread.ForumID);
				if(forum == null)
				{
					// Orphaned thread
					Response.Redirect("default.aspx", true);
				}
				meMessageEditor.ForumName = forum.ForumName;
				meMessageEditor.ThreadSubject = _thread.Subject;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void PostMessageHandler(object sender, System.EventArgs e)
		{
			string mailTemplate = ApplicationAdapter.GetEmailTemplate(EmailTemplate.ThreadUpdatedNotification);
			// store the new message in the given thread and close it directly.
            int messageID = ThreadManager.CreateNewMessageInThreadAndCloseThread(_thread.ThreadID, SessionAdapter.GetUserID(), meMessageEditor.MessageText,
					meMessageEditor.MessageTextHTML, Request.UserHostAddress.ToString(), meMessageEditor.MessageTextXML, 
					mailTemplate, ApplicationAdapter.GetEmailData(), CacheManager.GetSystemData().SendReplyNotifications);	

			// all ok, redirect to message list
			int startAtMessageID = ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThread(_thread.ThreadID, messageID, SessionAdapter.GetUserDefaultNumberOfMessagesPerPage());
            Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + startAtMessageID + "&#" + messageID, true);
		}

		protected void CancelActionHandler(object sender, System.EventArgs e)
		{
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startAtMessageIndex, true);
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the thread subject.
		/// </summary>
		/// <value>The thread subject.</value>
		protected string ThreadSubject
		{
			get
			{
				string toReturn = string.Empty;
				if(_thread != null)
				{
					toReturn = _thread.Subject;
				}
				return toReturn;
			}
		}
		#endregion
	}
}
