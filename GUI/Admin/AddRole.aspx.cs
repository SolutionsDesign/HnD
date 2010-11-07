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

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the AddRole form.
	/// </summary>
	public partial class AddRole : System.Web.UI.Page
	{
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
			if(!SessionAdapter.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx",true);
			}

			if(!Page.IsPostBack)
			{
				// bind the Roles repeater to a dataview with all sections.
				DataView rolesWithStatistics = SecurityGuiHelper.GetAllRolesWithStatisticsAsDataView();

				rpRoles.DataSource = rolesWithStatistics;
				rpRoles.DataBind();
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
			this.btnSave.ServerClick += new System.EventHandler(this.btnSave_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_ServerClick(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				// Save the new role.
				int roleID = SecurityManager.CreateNewRole(tbxRoleDescription.Text);

				if(roleID > 0)
				{
					// succeeded
					Response.Redirect("AddRole.aspx", true);
				}
				else
				{
					// same description error
					lblDuplicateRoleDescription.Visible=true;
				}
			}
		}
	}
}
