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
using SD.HnD.Utility;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the ModifySystemParameters form.
	/// </summary>
	public partial class ModifySystemParameters : System.Web.UI.Page
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
			if(!SessionAdapter.HasSystemActionRight(ActionRights.SystemManagement))
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx",true);
			}

			if(!Page.IsPostBack)
			{
				// load the data into the dropdown boxes.
				RoleCollection allRoles = SecurityGuiHelper.GetAllRoles();

				cbxDefaultRoleNewUsers.DataSource = allRoles;
				cbxDefaultRoleNewUsers.DataTextField = "RoleDescription";
				cbxDefaultRoleNewUsers.DataValueField = "RoleID";
				cbxDefaultRoleNewUsers.DataBind();

				cbxAnonymousUserRole.DataSource = allRoles;
				cbxAnonymousUserRole.DataTextField = "RoleDescription";
				cbxAnonymousUserRole.DataValueField = "RoleID";
				cbxAnonymousUserRole.DataBind();

				UserTitleCollection userTitles = UserGuiHelper.GetAllUserTitles();

				cbxDefaultUserTitleNewUsers.DataSource = userTitles;
				cbxDefaultUserTitleNewUsers.DataTextField = "UserTitleDescription";
				cbxDefaultUserTitleNewUsers.DataValueField = "UserTitleID";
				cbxDefaultUserTitleNewUsers.DataBind();

				// preselect the current values of the system parameters.
				SystemDataEntity systemData = CacheManager.GetSystemData();

				cbxDefaultRoleNewUsers.SelectedValue = systemData.DefaultRoleNewUser.ToString();
				cbxAnonymousUserRole.SelectedValue = systemData.AnonymousRole.ToString();
				cbxDefaultUserTitleNewUsers.SelectedValue = systemData.DefaultUserTitleNewUser.ToString();

				tbxActiveThreadsThreshold.Text = systemData.HoursThresholdForActiveThreads.ToString();
				tbxMinNumberOfNonStickyVisibleThreads.Text = systemData.MinNumberOfNonStickyVisibleThreads.ToString();
				tbxMinNumberOfThreadsToFetch.Text = systemData.MinNumberOfThreadsToFetch.ToString();
				tbxPageSizeInSearchResults.Text = systemData.PageSizeSearchResults.ToString();

				chkSendReplyNotifications.Checked = systemData.SendReplyNotifications;

				ViewState.Add("ID", systemData.ID);
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
			this.btnCancel.ServerClick += new System.EventHandler(this.btnCancel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_ServerClick(object sender, System.EventArgs e)
		{
			// store the new settings in the database, refresh Application Object's cache when succeeded.
			int ID = (int)ViewState["ID"];

			short activeThreadsThreshold = HnDGeneralUtils.TryConvertToShort(tbxActiveThreadsThreshold.Text);
			if(activeThreadsThreshold <= 0)
			{
				activeThreadsThreshold = 48;
			}

			short pageSizeSearchResults = HnDGeneralUtils.TryConvertToShort(tbxPageSizeInSearchResults.Text);
			if(pageSizeSearchResults <= 0)
			{
				pageSizeSearchResults = 50;
			}

			short minNumberOfThreadsToFetch = HnDGeneralUtils.TryConvertToShort(tbxMinNumberOfThreadsToFetch.Text);
			if(minNumberOfThreadsToFetch <= 0)
			{
				minNumberOfThreadsToFetch = 25;
			}

			short minNumberOfNonStickyVisibleThreads = HnDGeneralUtils.TryConvertToShort(tbxMinNumberOfNonStickyVisibleThreads.Text);
			if(minNumberOfNonStickyVisibleThreads <= 0)
			{
				minNumberOfNonStickyVisibleThreads = 5;
			}

			bool result = SystemManager.StoreNewSystemSettings(ID, 
					Convert.ToInt32(cbxDefaultRoleNewUsers.SelectedItem.Value),
					Convert.ToInt32(cbxAnonymousUserRole.SelectedItem.Value),
					Convert.ToInt32(cbxDefaultUserTitleNewUsers.SelectedItem.Value), activeThreadsThreshold, pageSizeSearchResults, 
						minNumberOfThreadsToFetch, minNumberOfNonStickyVisibleThreads, chkSendReplyNotifications.Checked);

			if(result)
			{
				// invalidate cache
				CacheManager.InvalidateCachedItem(CacheKeys.SystemData);
			}

			// ignore result for now
			Response.Redirect("Default.aspx",true);
		}

		private void btnCancel_ServerClick(object sender, System.EventArgs e)
		{
			// do nothing
			Response.Redirect("Default.aspx",true);
		}
	}
}
