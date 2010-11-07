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
	/// Code behind for EditThreadProperties form, which allows an admin to alter properties of a thread. 
	/// </summary>
	public partial class EditThreadProperties : System.Web.UI.Page
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

			// Check access credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			bool userMayDoThreadManagement = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ForumSpecificThreadManagement)||
						SessionAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement);
			if(!userHasAccess || !userMayDoThreadManagement)
			{
				// doesn't have access to this forum or may not alter the thread's properties. redirect
				Response.Redirect("default.aspx");
			}

			if(!Page.IsPostBack)
			{
				chkIsClosed.Checked = _thread.IsClosed;
				chkIsSticky.Checked = _thread.IsSticky;
				tbxSubject.Value = _thread.Subject;
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
			this.btnUpdate.ServerClick += new System.EventHandler(this.btnUpdate_ServerClick);
			this.btnCancel.ServerClick += new System.EventHandler(this.btnCancel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_ServerClick(object sender, System.EventArgs e)
		{
			// do nothing
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID);
		}

		private void btnUpdate_ServerClick(object sender, System.EventArgs e)
		{
			// user wants the data to be updated. 
            bool result = ThreadManager.ModifyThreadProperties(_thread.ThreadID, tbxSubject.Value, chkIsSticky.Checked, chkIsClosed.Checked);

			// ignore returnvalue for now
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID);
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
