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
using System.Collections.Generic;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind page for the form which allows an administrator to remove users from a given role.
	/// </summary>
	public partial class RemoveUsersFromRole : System.Web.UI.Page
	{
		#region Class Member Declarations
		private string _roleDescription;
		private int _roleID;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// If the user doesn't have any access rights to management stuff, the user should
			// be redirected to the default of the global system. 
            if (!SessionAdapter.HasSystemActionRights())
            {
				// doesn't have system rights. redirect.
				Response.Redirect("../Default.aspx",true);
			}
			
			// Check if the user has the right systemright
			bool hasAccess = SessionAdapter.HasSystemActionRight(ActionRights.SecurityManagement);
			if(!hasAccess)
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx",true);
			}
			
			_roleID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["RoleID"]);

			if(!Page.IsPostBack)
			{
				// Get Role
				RoleEntity role = SecurityGuiHelper.GetRole(_roleID);
				if(role != null)
				{
					_roleDescription = role.RoleDescription;
				}
				else
				{
					_roleDescription = "Not found";
				}

				// bind the users listbox to an entity collection with all users in the role
				UserCollection users = UserGuiHelper.GetAllUsersInRole(_roleID);
				lbxUsers.DataSource = users;
				lbxUsers.DataTextField = "NickName";
				lbxUsers.DataValueField = "UserID";
				lbxUsers.DataBind();
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
			this.btnRemoveUsers.ServerClick += new System.EventHandler(this.btnRemoveUsers_ServerClick);
			this.btnCancel.ServerClick += new System.EventHandler(this.btnCancel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnRemoveUsers_ServerClick(object sender, System.EventArgs e)
		{
			// Delete all selected users from the role
			List<int> userIDsToRemove = new List<int>();

			for(int i=0;i<lbxUsers.Items.Count;i++)
			{
				ListItem userItem = lbxUsers.Items[i];
				if(userItem.Selected)
				{
					userIDsToRemove.Add(Convert.ToInt32(userItem.Value));
				}
			}

			// Remove them
			bool result = SecurityManager.RemoveUsersFromRole(userIDsToRemove, _roleID);

			// enough for now
			Response.Redirect("ManageUsersInRole.aspx", true);
		}

		private void btnCancel_ServerClick(object sender, System.EventArgs e)
		{
			// Do nothing, just go back to the parent menu page
			Response.Redirect("ManageUsersInRole.aspx", true);
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the role description of the active role.
		/// </summary>
		protected string RoleDescription
		{
			get { return _roleDescription; }
		}
		#endregion
	}
}
