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

namespace SD.HnD.GUI
{
	/// <summary>
	/// General class for profile editing
	/// </summary>
	public partial class EditProfile : System.Web.UI.Page
	{
		private int _userID;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// use the UserID from the session, so it's impossible to edit another user. 
			_userID = SessionAdapter.GetUserID();
			if(_userID <= 0)
			{
				// anonymous
				Response.Redirect("default.aspx");
			}

			if(!Page.IsPostBack)
			{
				
				// load the user entity from the db.
				UserEntity user = UserGuiHelper.GetUser(_userID);
				
				// fill in the form with data
				lblNickname.Text = user.NickName;
				tbxEmailAddress.Value = user.EmailAddress;
				tbxIconURL.Value = user.IconURL;
				if(user.DateOfBirth.HasValue)
				{
					DateTime dateOfBirth = user.DateOfBirth.Value;
					tbxDateOfBirth.Value =  dateOfBirth.Month.ToString("0#") + "/" + dateOfBirth.Day.ToString("0#") + "/" + dateOfBirth.Year.ToString("####"); 
				}
				tbxOccupation.Value = user.Occupation;
				tbxLocation.Value = user.Location;
				tbxWebsite.Value = user.Website;
				tbxSignature.Value = user.Signature;
				if(user.EmailAddressIsPublic.HasValue)
				{
					chkEmailAddressIsHidden.Checked = !user.EmailAddressIsPublic.Value;
				}
				else
				{
					chkEmailAddressIsHidden.Checked = false;
				}

                chkAutoSubscribeToThread.Checked = user.AutoSubscribeToThread;
                tbxDefaultNumberOfMessagesPerPage.Value = user.DefaultNumberOfMessagesPerPage.ToString();
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
			this.btnUpdate.ServerClick += new System.EventHandler(this.btnUpdate_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_ServerClick(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				// user has filled in the right values, update the user's data.
				string nickName = string.Empty;
				DateTime? dateOfBirth = null;
				string emailAddress = string.Empty;
				bool emailAddressIsPublic = false;
				string iconURL = string.Empty;
				string ipNumber = string.Empty;
				string location = string.Empty;
				string occupation = string.Empty;
				string password = string.Empty;
				string signature = string.Empty;
				string website = string.Empty;
                bool autoSubscribeThreads = true;
                short defaultMessagesPerPage = 10; 

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

				emailAddressIsPublic = !chkEmailAddressIsHidden.Checked;
				location = tbxLocation.Value;
				occupation = tbxOccupation.Value;
				signature = tbxSignature.Value;
				website = tbxWebsite.Value;

                //Preferences
                autoSubscribeThreads = chkAutoSubscribeToThread.Checked;
                if (tbxDefaultNumberOfMessagesPerPage.Value.Length > 0)
                {
                    defaultMessagesPerPage = HnDGeneralUtils.TryConvertToShort(tbxDefaultNumberOfMessagesPerPage.Value);
                }

                bool result = UserManager.UpdateUserProfile(SessionAdapter.GetUserID(), dateOfBirth, emailAddress, emailAddressIsPublic, iconURL, location, occupation, password,
						signature, website, SessionAdapter.GetUserTitleID(), ApplicationAdapter.GetParserData(), autoSubscribeThreads, defaultMessagesPerPage);
				
				if(result)
				{
					// get user back and update session object.
					UserEntity user = UserGuiHelper.GetUser(SessionAdapter.GetUserID());
					if(user != null)
					{
						SessionAdapter.AddUserObject(user);
					}
					// all ok
					Response.Redirect("EditProfileSuccessful.aspx",true);
				}
			}
		}
	}
}
