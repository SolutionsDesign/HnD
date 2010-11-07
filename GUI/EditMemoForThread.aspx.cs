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
	/// Edit memo for thread.
	/// </summary>
	public partial class EditMemoForThread : System.Web.UI.Page
	{
		#region Class Member Declarations
		private int _startAtMessage;
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
			if(_thread==null)
			{
				// not found, return to default page
				Response.Redirect("default.aspx", true);
			}

			_startAtMessage = HnDGeneralUtils.TryConvertToInt(Request.QueryString["StartAtMessage"]);

			// Check credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
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
				
			// Check if the current user is allowed to edit the memo
			if(!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.EditThreadMemo))
			{
				// is not allowed to edit the memo
				Response.Redirect("Messages.aspx?ThreadID=" + threadID, true);
			}
			
			// User may edit memo, proceed
			if(!Page.IsPostBack)
			{
				// fill the page's content
				ForumEntity forum = CacheManager.GetForum(_thread.ForumID);
				if(forum == null)
				{
					// Orphaned thread
					Response.Redirect("default.aspx", true);
				}
				lnkThreads.Text = HttpUtility.HtmlEncode(forum.ForumName);
				lnkThreads.NavigateUrl += "?ForumID=" + _thread.ForumID;
				meMessageEditor.ForumName = forum.ForumName;
				meMessageEditor.ThreadSubject = "Memo for thread: " + HttpUtility.HtmlEncode(_thread.Subject);
				lblSectionName.Text = CacheManager.GetSectionName(forum.SectionID);
				lnkMessages.NavigateUrl+=threadID;
				lnkMessages.Text = HttpUtility.HtmlEncode(_thread.Subject);

				string memoText = _thread.Memo;
                memoText += string.Format("{2}[b]-----------------------------------------------------------------{2}{1} [color value=\"0000AA\"]{0}[/color] wrote:[/b] ", SessionAdapter.GetUserNickName(), DateTime.Now.ToString(@"dd-MMM-yyyy HH:mm:ss"), Environment.NewLine);
				meMessageEditor.OriginalMessageText=memoText;
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
            ThreadManager.UpdateMemo(_thread.ThreadID, meMessageEditor.MessageText);
			if(SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditEditMemo))
			{
                SecurityManager.AuditEditMemo(SessionAdapter.GetUserID(), _thread.ThreadID);
			}

			// all ok, redirect to thread list
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startAtMessage, false);
		}

		protected void CancelActionHandler(object sender, System.EventArgs e)
		{
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startAtMessage, true);
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
