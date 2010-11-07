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
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind of DeleteMessage form. 
	/// </summary>
	public partial class DeleteMessage : System.Web.UI.Page
	{
		private	int _deleteMessageID;
		private ThreadEntity _thread;
		private bool _userMayDeleteMessages;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			int threadID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ThreadID"]);
			_deleteMessageID=HnDGeneralUtils.TryConvertToInt(Request.QueryString["MessageID"]);

			_thread = ThreadGuiHelper.GetThread(threadID);
			if(_thread==null)

			{
				// not found, return to default page
				Response.Redirect("default.aspx", true);
			}

			// Check if the current user is allowed to delete the message. If not, don't continue.
			_userMayDeleteMessages = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.EditDeleteOtherUsersMessages);
			if(!_userMayDeleteMessages)
			{
				// is not allowed to delete the message
				Response.Redirect("Messages.aspx?ThreadID=" + threadID, true);
			}

			// check if the user can view this thread. If not, don't continue.
			if((_thread.StartedByUserID != SessionAdapter.GetUserID()) &&
				!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!_thread.IsSticky)
			{
				// can't view this thread, it isn't visible to the user
				Response.Redirect("default.aspx", true);
			}

			// check if the message is the first message in the thread. If so, delete isn't allowed.
			if(ThreadGuiHelper.CheckIfMessageIsFirstInThread(threadID, _deleteMessageID))
			{
				// is first in thread, don't proceed. Caller has fabricated the url manually.
				Response.Redirect("default.aspx", true);
			}

			// Get the message
			MessageEntity message = MessageGuiHelper.GetMessage(_deleteMessageID);

			// User may delete current message. 
			if(!Page.IsPostBack)
			{
				if(message!=null)
				{
					// message is found.
					ForumEntity forum = CacheManager.GetForum(_thread.ForumID);
					if(forum == null)
					{
						// Orphaned thread
						Response.Redirect("default.aspx", true);
					}
					lblForumName_Header.Text = forum.ForumName;
					lblMessageBody.Text = message.MessageTextAsHTML;
					lblPostingDate.Text = message.PostingDate.ToString(@"dd-MMM-yyyy HH:mm:ss");
				}
				else
				{
					btnYes.Visible = false;
				}
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
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNo_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID, true);
		}

		private void btnYes_Click(object sender, System.EventArgs e)
		{
			if(_userMayDeleteMessages)
			{
				bool result = MessageManager.DeleteMessage(_deleteMessageID);
				Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID, true);
			}
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

