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
	/// Code behind file for the DeleteThread form.
	/// </summary>
	public partial class DeleteThread : System.Web.UI.Page
	{
		#region Class Member Declarations
		private ThreadEntity _thread;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			int threadID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ThreadID"]);

			_thread = ThreadGuiHelper.GetThread(threadID);
			if(_thread == null)
			{
				// not found, return to default page
				Response.Redirect("default.aspx", true);
			}

			// Check credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				Response.Redirect("default.aspx");
			}

			bool userMayDeleteThread = SessionAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement);
			if(!userMayDeleteThread)
			{
				// doesn't have the right to delete a thread. redirect
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

			if(!Page.IsPostBack)
			{
				// fill the page's content
				ForumEntity forum = CacheManager.GetForum(_thread.ForumID);
				if(forum == null)
				{
					// Orphaned thread
					Response.Redirect("default.aspx", true);
				}
				lblForumName.Text = forum.ForumName;
				lblThreadSubject.Text = HttpUtility.HtmlEncode(_thread.Subject);
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
			this.btnDelete.ServerClick += new System.EventHandler(this.btnDelete_ServerClick);
			this.btnKeep.ServerClick += new System.EventHandler(this.btnKeep_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDelete_ServerClick(object sender, System.EventArgs e)
		{
			// delete the thread
			bool result = ThreadManager.DeleteThread(_thread.ThreadID);
			// done
			Response.Redirect("Threads.aspx?ForumID=" + _thread.ForumID, true);
		}

		private void btnKeep_ServerClick(object sender, System.EventArgs e)
		{
			// do nothing
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID, true);
		}
	}
}
