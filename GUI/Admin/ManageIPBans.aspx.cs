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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SD.HnD.BL;
using SD.HnD.GUI;
using SD.HnD.DAL.EntityClasses;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind for the form to manage IP bans.
	/// </summary>
	public partial class ManageIPBans : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// If the user doesn't have any access rights to management stuff, the user should
			// be redirected to the default of the global system. 
			if(!SessionAdapter.HasSystemActionRights())
			{
				// doesn't have system rights. redirect.
				Response.Redirect("../Default.aspx", true);
			}

			// Check if the user has the right systemright
			bool userHasAccess = SessionAdapter.HasSystemActionRight(ActionRights.UserManagement);
			if(!userHasAccess)
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx", true);
			}

			// set these form variables to their required values, so the InsertParameters of the datasource control can pick them up when a new ip ban
			// entity is inserted.
			_userID.Value = SessionAdapter.GetUserID().ToString();
			_currentDate.Value = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
		}

		
		/// <summary>
		/// Handles the PerformGetDbCount event of the _ipBanDS control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SD.LLBLGen.Pro.ORMSupportClasses.PerformGetDbCountEventArgs"/> instance containing the event data.</param>
		protected void _ipBanDS_PerformGetDbCount(object sender, SD.LLBLGen.Pro.ORMSupportClasses.PerformGetDbCountEventArgs e)
		{
			e.DbCount = SecurityGuiHelper.GetTotalIPBanCount();
		}


		/// <summary>
		/// Handles the PerformSelect event of the _ipBanDS control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SD.LLBLGen.Pro.ORMSupportClasses.PerformSelectEventArgs"/> instance containing the event data.</param>
		protected void _ipBanDS_PerformSelect(object sender, SD.LLBLGen.Pro.ORMSupportClasses.PerformSelectEventArgs e)
		{
			// fetch the page requested, using a BL method. We'll receive a collection from the BL method and will set the collection of the control to the
			// collection we'll receive. Specify that the user entity is prefetched into the IPBan entity.
			_ipBanDS.EntityCollection = SecurityGuiHelper.GetAllIPBans(e.PageNumber, e.PageSize, true);
		}


		/// <summary>
		/// Handles the PerformWork event of the _ipBanDS control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SD.LLBLGen.Pro.ORMSupportClasses.PerformWorkEventArgs"/> instance containing the event data.</param>
		protected void _ipBanDS_PerformWork(object sender, SD.LLBLGen.Pro.ORMSupportClasses.PerformWorkEventArgs e)
		{
			// the event args contain the UnitOfWork to persist. Pass it on to the BL method
			SecurityManager.PersistIPBanUnitOfWork(e.Uow);

			// invalidate cache
			CacheManager.InvalidateCachedItem(CacheKeys.AllIPBans);
		}


		protected void _switchViewButton_Click(object sender, EventArgs e)
		{
			switch(_ipBanFormView.CurrentMode)
			{
				case FormViewMode.Edit:
					_ipBanFormView.ChangeMode(FormViewMode.Insert);
					break;
				case FormViewMode.Insert:
					_ipBanFormView.ChangeMode(FormViewMode.Edit);
					break;
			}
		}

		protected void _deleteSelectedButton_Click(object sender, EventArgs e)
		{
			int index = _ipBansGrid.SelectedIndex;
			if(index < 0)
			{
				return;
			}
			_ipBansGrid.DeleteRow(index);
		}

		protected void _ipBansGrid_SelectedIndexChanged(object sender, EventArgs e)
		{
			_ipBanFormView.PageIndex = _ipBansGrid.SelectedIndex;
			_deleteSelectedButton.Visible = (_ipBansGrid.SelectedIndex >= 0);
		}
	}
}