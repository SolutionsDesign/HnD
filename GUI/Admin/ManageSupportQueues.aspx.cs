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

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the ManageSupportQueues form.
	/// </summary>
	public partial class ManageSupportQueues : System.Web.UI.Page
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
			bool userHasAccess = SessionAdapter.HasSystemActionRight(ActionRights.SystemManagement);
			if(!userHasAccess)
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx", true);
			}
		}


		/// <summary>
		/// Handles the PerformSelect event of the _supportQueueDS control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SD.LLBLGen.Pro.ORMSupportClasses.PerformSelectEventArgs"/> instance containing the event data.</param>
		protected void _supportQueueDS_PerformSelect(object sender, SD.LLBLGen.Pro.ORMSupportClasses.PerformSelectEventArgs e)
		{
			_supportQueueDS.EntityCollection = SupportQueueGuiHelper.GetAllSupportQueues();
		}


		/// <summary>
		/// Handles the PerformWork event of the _supportQueueDS control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SD.LLBLGen.Pro.ORMSupportClasses.PerformWorkEventArgs"/> instance containing the event data.</param>
		protected void _supportQueueDS_PerformWork(object sender, SD.LLBLGen.Pro.ORMSupportClasses.PerformWorkEventArgs e)
		{
			SupportQueueManager.PersistSupportQueueUnitOfWork(e.Uow);

			// invalidate cache
			CacheManager.InvalidateCachedItem(CacheKeys.AllSupportQueues);
		}


		/// <summary>
		/// Handles the Click event of the _switchViewButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void _switchViewButton_Click(object sender, EventArgs e)
		{
			switch(_supportQueueFormView.CurrentMode)
			{
				case FormViewMode.Edit:
					_supportQueueFormView.ChangeMode(FormViewMode.Insert);
					break;
				case FormViewMode.Insert:
					_supportQueueFormView.ChangeMode(FormViewMode.Edit);
					break;
			}
		}

		/// <summary>
		/// Handles the Click event of the _deleteSelectedButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void _deleteSelectedButton_Click(object sender, EventArgs e)
		{
			int index = _supportQueuesGrid.SelectedIndex;
			if(index < 0)
			{
				return;
			}
			_supportQueuesGrid.DeleteRow(index);
		}


		/// <summary>
		/// Handles the SelectedIndexChanged event of the _supportQueuesGrid control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void _supportQueuesGrid_SelectedIndexChanged(object sender, EventArgs e)
		{
			_supportQueueFormView.PageIndex = _supportQueuesGrid.SelectedIndex;
			_deleteSelectedButton.Visible = (_supportQueuesGrid.SelectedIndex >= 0);
		}
	}
}