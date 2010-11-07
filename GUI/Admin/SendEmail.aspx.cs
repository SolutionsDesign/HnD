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

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.BL;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Utility;
using System.Collections.Generic;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the SendEmail form to send an email to one or more users.
	/// </summary>
	public partial class SendEmail : System.Web.UI.Page
	{
		#region Class Member Declarations
		private UserCollection _selectedUsers = new UserCollection();
		#endregion


		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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
			bool userHasAccess = SessionAdapter.HasSystemActionRight(ActionRights.UserManagement);
			if(!userHasAccess)
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx",true);
			}

			if(Page.IsPostBack)
			{
				GetViewState();
				SetToNames();
			}
			else
			{
				SetViewState();
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
			this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// Sets the names for the TO: element of an emailmessage
		/// </summary>
		private void SetToNames()
		{
			lblToNames.Text=string.Empty;
			for (int i = 0; i < _selectedUsers.Count; i++)
			{
				if(i>0)
				{
					lblToNames.Text+=", ";
				}
				lblToNames.Text+=string.Format("{0} ({1})", _selectedUsers[i].EmailAddress, _selectedUsers[i].NickName);
			}
		}

		/// <summary>
		/// stores the selected users in the viewstate
		/// </summary>
		private void SetViewState()
		{
			ViewState.Add("selectedUsers", _selectedUsers);
		}

		/// <summary>
		/// retrieves the selected users from the viewstate.
		/// </summary>
		private void GetViewState()
		{
			_selectedUsers = (UserCollection)ViewState["selectedUsers"];
		}


		/// <summary>
		/// Handler for the selectclicked event of the finduser control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectClickedHandler(object sender, System.EventArgs e)
		{
			List<int> selectedUserIDs = userFinder.SelectedUserIDs;
			phEmailConstruction.Visible = (selectedUserIDs.Count>0);
			if(selectedUserIDs.Count <= 0)
			{
				// nothing selected, return
				return;
			}

			_selectedUsers = UserGuiHelper.GetAllUsersInRange(selectedUserIDs);
			SetViewState();
			SetToNames();
			userFinder.Visible=false;
		}

		private void btnPost_Click(object sender, System.EventArgs e)
		{
			if(!Page.IsValid)
			{
				return;
			}

			string[] toAddresses = new string[_selectedUsers.Count];

			for (int i = 0; i < _selectedUsers.Count; i++)
			{
				toAddresses[i] = _selectedUsers[i].EmailAddress;
			}

			bool result = HnDGeneralUtils.SendEmail(tbxSubject.Value, tbxMessage.Text, tbxFrom.Value, toAddresses, ApplicationAdapter.GetEmailData(), false);
			if(result)
			{
				phEmailConstruction.Visible=false;
				phResult.Visible=true;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			userFinder.Visible=true;
			phEmailConstruction.Visible=false;
			phResult.Visible=false;
		}
	}
}
