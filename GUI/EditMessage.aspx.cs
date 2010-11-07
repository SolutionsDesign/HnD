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
	/// Edit message editor class
	/// </summary>
	public partial class EditMessage : System.Web.UI.Page
	{
		#region Class Member Declarations
		private	int			_editMessageID, _startAtMessageIndex;
		private MessageEntity _message;
		private ThreadEntity _thread;
		#endregion

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			_editMessageID=HnDGeneralUtils.TryConvertToInt(Request.QueryString["MessageID"]);
			_message = MessageGuiHelper.GetMessage(_editMessageID);
			if(_message==null)
			{
				// not found
				Response.Redirect("default.aspx");
			}

			// We could have used Lazy loading here, but for the sake of separation, we use the BL method.
			_thread = ThreadGuiHelper.GetThread(_message.ThreadID);
			if(_thread==null)
			{
				// not found. Orphaned message.
				Response.Redirect("default.aspx");
			}

			// Check credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				Response.Redirect("default.aspx", true);
			}

			// Check if the current user is allowed to edit the message.
			bool userMayEditMessages=false;
			if(!_thread.IsClosed)
			{
				if(_thread.IsSticky)
				{
					userMayEditMessages = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessageInSticky);
				}
				else
				{
					userMayEditMessages = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessage);
				}
			}

			// User has the right to generally edit messages. Check if the user has the right to edit other peoples messages
			// and if not, if the user is the poster of this message. If not, no can do.
			if(!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.EditDeleteOtherUsersMessages))
			{
				// cannot edit other people's messages. Check if this message is posted by the current user.
                if(_message.PostedByUserID != SessionAdapter.GetUserID())
				{
					// not allowed
					userMayEditMessages=false;
				}
			}
			if(!userMayEditMessages)
			{
				// is not allowed to edit the message
				Response.Redirect("Messages.aspx?ThreadID=" + _message.ThreadID, true);
			}

			// use BL class. We could have used Lazy loading, though for the sake of separation, we'll call into the BL class. 
			ForumEntity forum = CacheManager.GetForum(_thread.ForumID);
			if(forum == null)
			{
				// orphaned thread
				Response.Redirect("default.aspx");
			}

			// check if the user can view the thread the message is in. If not, don't continue.
			if((_thread.StartedByUserID != SessionAdapter.GetUserID()) &&
				!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers))
			{
				// can't edit this message, it's in a thread which isn't visible to the user
				Response.Redirect("default.aspx", true);
			}
			
			_startAtMessageIndex = HnDGeneralUtils.TryConvertToInt(Request.QueryString["StartAtMessage"]);

			// User may edit current message. 
			if(!Page.IsPostBack)
			{
				// fill the page's content
				lnkThreads.Text = HttpUtility.HtmlEncode(forum.ForumName);
				lnkThreads.NavigateUrl += "?ForumID=" + _thread.ForumID;
				meMessageEditor.ForumName = forum.ForumName;
				meMessageEditor.ThreadSubject = _thread.Subject;
				lblSectionName.Text = CacheManager.GetSectionName(forum.SectionID);
				lnkMessages.NavigateUrl+=_message.ThreadID;
				lnkMessages.Text = HttpUtility.HtmlEncode(_thread.Subject);

				meMessageEditor.OriginalMessageText = _message.MessageText;
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
            int userID = SessionAdapter.GetUserID();
            bool result = MessageManager.UpdateEditedMessage(userID, _editMessageID, meMessageEditor.MessageText, meMessageEditor.MessageTextHTML, Request.UserHostAddress, meMessageEditor.MessageTextXML);

            if(SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditAlteredMessage))
			{
                SecurityManager.AuditAlteredMessage(userID, _editMessageID);
			}

			// all ok, redirect to thread list
			int startAtMessageID = ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThread(_thread.ThreadID, _editMessageID, SessionAdapter.GetUserDefaultNumberOfMessagesPerPage());
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + startAtMessageID + "&#" + _editMessageID, false);
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
				if(_thread != null)
				{
					return _thread.Subject;
				}
				else
				{
					return string.Empty;
				}
			}
		}

		#endregion
	}
}
