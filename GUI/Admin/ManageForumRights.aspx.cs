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
	/// code behind file for the ManageForumRights form
	/// </summary>
	public partial class ManageForumRights : System.Web.UI.Page
	{
		private string _roleDescription;
		private int _roleID, _forumID;

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
				// get the role and show the description
				RoleEntity role = SecurityGuiHelper.GetRole(_roleID);
				if(!role.IsNew)
				{
					_roleDescription = role.RoleDescription;
				}

				// store in viewstate.
				ViewState.Add("sRoleDescription", _roleDescription);

				// Get all sections, which do have a forum.
				DataView sections = SectionGuiHelper.GetAllSectionsWStatisticsAsDataView(true);

				cbxSections.DataSource = sections;
				cbxSections.DataTextField = "SectionName";
				cbxSections.DataValueField = "SectionID";
				cbxSections.DataBind();

				if(cbxSections.Items.Count > 0)
				{
					cbxSections.Items[0].Selected=true;
				}

				FillForumList();

				// get the forum action rights
				ActionRightCollection actionRights = SecurityGuiHelper.GetAllActionRightsApplybleToAForum();

				cblForumRights.DataSource = actionRights;
				cblForumRights.DataTextField = "ActionRightDescription";
				cblForumRights.DataValueField = "ActionRightID";
				cblForumRights.DataBind();

				// Reflect action rights for current selected forum for this role
				ReflectCurrentActionRights();
			}
			else
			{
				// read role description from viewstate
				_roleDescription = ViewState["sRoleDescription"].ToString();
				_forumID = HnDGeneralUtils.TryConvertToInt(cbxForums.SelectedItem.Value);
			}
		}


		/// <summary>
		/// Reads all actionrights for the current selected forum and shows these settings in the form
		/// </summary>
		private void ReflectCurrentActionRights()
		{	
			ForumRoleForumActionRightCollection  actionRights = SecurityGuiHelper.GetForumActionRightRolesFoForumRole(_roleID, _forumID);

			foreach(ForumRoleForumActionRightEntity currentEntity in actionRights)
			{
				cblForumRights.Items.FindByValue(currentEntity.ActionRightID.ToString()).Selected=true;
			}
		}


		/// <summary>
		/// Fills in the forum list based on the selected Section in cbxSections
		/// </summary>
		private void FillForumList()
		{
			// clear list first
			cbxForums.Items.Clear();

			int currentSectionID = Convert.ToInt32(cbxSections.SelectedItem.Value);
			ForumCollection forums = ForumGuiHelper.GetAllForumsInSection(currentSectionID);

			cbxForums.DataSource = forums;
			cbxForums.DataTextField = "ForumName";
			cbxForums.DataValueField = "ForumID";
			cbxForums.DataBind();

			cbxForums.Items[0].Selected=true;
			_forumID = Convert.ToInt32(cbxForums.SelectedItem.Value);
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
			this.cbxSections.SelectedIndexChanged += new System.EventHandler(this.cbxSections_SelectedIndexChanged);
			this.cbxForums.SelectedIndexChanged += new System.EventHandler(this.cbxForums_SelectedIndexChanged);
			this.btnSave.ServerClick += new System.EventHandler(this.btnSave_ServerClick);
			this.btnCancel.ServerClick += new System.EventHandler(this.btnCancel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cbxSections_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillForumList();
			cblForumRights.ClearSelection();
			ReflectCurrentActionRights();
			phSaveResult.Visible=false;
		}

		private void cbxForums_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cblForumRights.ClearSelection();
			ReflectCurrentActionRights();
			phSaveResult.Visible=false;
		}

		private void btnSave_ServerClick(object sender, System.EventArgs e)
		{
			// read checked action rights
			List<int> checkedActionRightIDs = new List<int>();

			for(int i=0;i<cblForumRights.Items.Count;i++)
			{
				if(cblForumRights.Items[i].Selected)
				{
					checkedActionRightIDs.Add(Convert.ToInt32(cblForumRights.Items[i].Value));
				}
			}

			// save the actionrights 
			bool result = SecurityManager.SaveForumActionRightsForForumRole(checkedActionRightIDs, _roleID, _forumID);
			phSaveResult.Visible=result;
		}

		private void btnCancel_ServerClick(object sender, System.EventArgs e)
		{
			// do nothing
			Response.Redirect("ManageRoleForumRights.aspx", true);
		}
		

		#region Class Property Declarations
		/// <summary>
		/// Gets the role description of the active role.
		/// </summary>
		/// <value>The role description.</value>
		protected string RoleDescription
		{
			get { return _roleDescription; }
		}
		#endregion
	}
}
