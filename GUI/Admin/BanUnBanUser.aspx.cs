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
using SD.HnD.GUI;
using SD.HnD.BL;
using System.Collections.Generic;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// The code behind file for the form to ban / unban a single user account
	/// </summary>
	public partial class BanUnbanUser : System.Web.UI.Page
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
		}


		/// <summary>
		/// Handler for the selectclicked event of the finduser control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectClickedHandler(object sender, System.EventArgs e)
		{
			phToggleResult.Visible = false;

			List<int> selectedUserIDs = userFinder.SelectedUserIDs;
			if(selectedUserIDs.Count < 0)
			{
				// nothing selected, return
				return;
			}

			// just use the first selected user
			int selectedUserID = selectedUserIDs[0];
			if((selectedUserID == 0) || (selectedUserID == SessionAdapter.GetUserID()))
			{
				// can't ban anonymous coward or him/herself
				return;
			}

			UserEntity user = UserGuiHelper.GetUser(selectedUserID);
			lblNickname.Text = user.NickName;
			lblUserID.Text = user.UserID.ToString();
			if(user.IsBanned)
			{
				lblBanStatus.Text = "banned";
			}
			else
			{
				lblBanStatus.Text = "not banned";
			}

			phUserInfo.Visible = true;
		}


		protected void btnYes_Click(object sender, EventArgs e)
		{
			bool newBanFlagValue = false;
			bool result = UserManager.ToggleBanFlagValue(HnDGeneralUtils.TryConvertToInt(lblUserID.Text), out newBanFlagValue);
			phToggleResult.Visible = result;
			phUserInfo.Visible = !result;
			if(newBanFlagValue)
			{
				// add the user to be logged out by force.
				ApplicationAdapter.AddUserToListToBeLoggedOutByForce(lblNickname.Text);
			}
		}


		protected void btnNo_Click(object sender, EventArgs e)
		{
			phToggleResult.Visible = false;
			phUserInfo.Visible = false;
		}
	}
}