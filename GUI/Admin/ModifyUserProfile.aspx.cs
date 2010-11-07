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
using System.Globalization;

using SD.HnD.BL;
using SD.HnD.Utility;
using SD.HnD.DAL.EntityClasses;
using System.Collections.Generic;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// General class for profile editing by administrators.
	/// </summary>
	public partial class ModifyUserProfile : System.Web.UI.Page
	{
		private int _selectedUserID;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// If the user doesn't have any access rights to management stuff, the user should
			// be redirected to the default of the global system. 
			if(!SessionAdapter.HasSystemActionRights())
			{
				// doesn't have system rights. redirect.
				Response.Redirect("../Default.aspx", true);
			}

			// Check if the user has the right systemright
			if(!SessionAdapter.HasSystemActionRight(ActionRights.UserManagement))
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx", true);
			}

			if(!Page.IsPostBack)
			{

				cmbUserTitle.DataSource = UserGuiHelper.GetAllUserTitles();
				cmbUserTitle.DataTextField = "UserTitleDescription";
				cmbUserTitle.DataValueField = "UserTitleID";
				cmbUserTitle.DataBind();
			}
		}


		/// <summary>
		/// Store the page state into the viewstate.
		/// </summary>
		private void SetViewstate()
		{
			ViewState.Add("_selectedUserID", _selectedUserID);
		}


		/// <summary>
		/// Gets the state of the page from the viewstate
		/// </summary>
		private void GetViewState()
		{
			object value = ViewState["_selectedUserID"];
			if(value != null)
			{
				_selectedUserID = (int)value;
			}
		}


		/// <summary>
		/// Handler for the selectclicked event of the finduser control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectClickedHandler(object sender, System.EventArgs e)
		{
			phModifyResult.Visible = false;

			List<int> selectedUserIDs = userFinder.SelectedUserIDs;
			if(selectedUserIDs.Count < 0)
			{
				// nothing selected, return
				return;
			}

			// just use the first selected user
			_selectedUserID  = selectedUserIDs[0];
			UserEntity user = UserGuiHelper.GetUser(_selectedUserID);

			if(user == null)
			{
				// not found
				return;
			}

			phFindUserArea.Visible = false;
			phProfileEditArea.Visible = true;

			// fill in the form with data
			lblNickname.Text = string.Format("{0}  (UserId: {1})", user.NickName, user.UserID);
			tbxEmailAddress.Value = user.EmailAddress;
			tbxIconURL.Value = user.IconURL;
			if(user.DateOfBirth.HasValue)
			{
				DateTime dateOfBirth = user.DateOfBirth.Value;
				tbxDateOfBirth.Value = dateOfBirth.Month.ToString("0#") + "/" + dateOfBirth.Day.ToString("0#") + "/" + dateOfBirth.Year.ToString("####");
			}
			tbxOccupation.Value = user.Occupation;
			tbxLocation.Value = user.Location;
			tbxWebsite.Value = user.Website;
			tbxSignature.Value = user.Signature;
			if(user.EmailAddressIsPublic.HasValue)
			{
				_emailAddressIsVisible.Value = user.EmailAddressIsPublic.Value.ToString().ToLowerInvariant();
			}
			else
			{
				_emailAddressIsVisible.Value = "true";
			}
			_defaultNumberOfMessagesPerPage.Value = user.DefaultNumberOfMessagesPerPage.ToString();
			_autoSubscribeToThread.Value = user.AutoSubscribeToThread.ToString().ToLowerInvariant();
			cmbUserTitle.SelectedValue = user.UserTitleID.ToString();
			SetViewstate();
		}


		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				GetViewState();

				// user has filled in the right values, update the user's data.
				string nickName = string.Empty;
				DateTime? dateOfBirth = null;
				string emailAddress = string.Empty;
				string iconURL = string.Empty;
				string ipNumber = string.Empty;
				string location = string.Empty;
				string occupation = string.Empty;
				string password = string.Empty;
				string signature = string.Empty;
				string website = string.Empty;

				if(tbxPassword1.Value.Length > 0)
				{
					password = tbxPassword1.Value;
				}
				
				emailAddress = tbxEmailAddress.Value;
				iconURL = tbxIconURL.Value;
				
				if(tbxDateOfBirth.Value.Length > 0)
				{
					try
					{
						dateOfBirth = System.DateTime.Parse(tbxDateOfBirth.Value, CultureInfo.InvariantCulture.DateTimeFormat);
					}
					catch(FormatException)
					{
						// format exception, date invalid, ignore, will resolve to default.
					}
				}

				location = tbxLocation.Value;
				occupation = tbxOccupation.Value;
				signature = tbxSignature.Value;
				website = tbxWebsite.Value;

				bool result = UserManager.UpdateUserProfile(_selectedUserID, dateOfBirth, emailAddress, (_emailAddressIsVisible.Value == "true"), iconURL, location, occupation, password,
						signature, website, HnDGeneralUtils.TryConvertToInt(cmbUserTitle.SelectedValue), ApplicationAdapter.GetParserData()
						, (_autoSubscribeToThread.Value=="true"), HnDGeneralUtils.TryConvertToShort(_defaultNumberOfMessagesPerPage.Value));
				
				if(result)
				{
					// all ok
					phModifyResult.Visible = true;
					phFindUserArea.Visible = false;
					phProfileEditArea.Visible = false;
				}
			}
		}
	}
}
