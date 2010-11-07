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
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using System.Collections.Generic;
using SD.HnD.Utility;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the ManageAditActionsPerRole form.
	/// </summary>
	public partial class ManageAuditActionsPerRole : System.Web.UI.Page
	{
		private int	_roleID;

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

			_roleID = 0;

			if(!Page.IsPostBack)
			{
				// Get all roles
				RoleCollection roles = SecurityGuiHelper.GetAllRoles();

				cbxRoles.DataSource = roles;
				cbxRoles.DataTextField = "RoleDescription";
				cbxRoles.DataValueField = "RoleID";
				cbxRoles.DataBind();

				if(cbxRoles.Items.Count > 0)
				{
					cbxRoles.Items[0].Selected = true;
					_roleID = HnDGeneralUtils.TryConvertToInt(cbxRoles.SelectedItem.Value);
				}

				// get the audit actions
				AuditActionCollection auditActions = SecurityGuiHelper.GetAllAuditActions();

				cblAuditActions.DataSource = auditActions;
				cblAuditActions.DataTextField = "AuditActionDescription";
				cblAuditActions.DataValueField = "AuditActionID";
				cblAuditActions.DataBind();

				// Reflect action rights for current selected forum for this role
				ReflectCurrentAuditActions();
			}
			else
			{
				_roleID = HnDGeneralUtils.TryConvertToInt(cbxRoles.SelectedItem.Value);
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
			this.cbxRoles.SelectedIndexChanged += new System.EventHandler(this.cbxRoles_SelectedIndexChanged);
			this.btnSave.ServerClick += new System.EventHandler(this.btnSave_ServerClick);
			this.btnCancel.ServerClick += new System.EventHandler(this.btnCancel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		

		/// <summary>
		/// Reads all audit actions for the current selected role and shows these settings in the form
		/// </summary>
		private void ReflectCurrentAuditActions()
		{	
			RoleAuditActionCollection roleAuditActions = SecurityGuiHelper.GetAllAuditActionsForRole(_roleID);

			// check the checkboxes in the cblAuditActions list if the value matches an object in the collection
			foreach(RoleAuditActionEntity roleAuditAction in roleAuditActions)
			{
				cblAuditActions.Items.FindByValue(roleAuditAction.AuditActionID.ToString()).Selected=true;
			}
		}

		private void cbxRoles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cblAuditActions.ClearSelection();
			ReflectCurrentAuditActions();
			phSaveResult.Visible=false;
		}

		private void btnSave_ServerClick(object sender, System.EventArgs e)
		{
			// read checked audit actions
			List<int> checkedAuditActions = new List<int>();

			for(int i=0;i<cblAuditActions.Items.Count;i++)
			{
				if(cblAuditActions.Items[i].Selected)
				{
					checkedAuditActions.Add(Convert.ToInt32(cblAuditActions.Items[i].Value));
				}
			}

			// save the actionrights 
			bool result = SecurityManager.SaveAuditActionsForRole(checkedAuditActions, _roleID);
			phSaveResult.Visible=result;
		}

		private void btnCancel_ServerClick(object sender, System.EventArgs e)
		{
			Response.Redirect("Default.aspx", true);
		}
	}
}
