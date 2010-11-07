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
using System.IO;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind for the Register form.
	/// </summary>
	public partial class Register : System.Web.UI.Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				// Get the user's IP number
				lblIPNumber.Text = Request.UserHostAddress.ToString();
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
			this.btnRegister.ServerClick += new System.EventHandler(this.btnRegister_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		/// <summary>
		/// Handles the click event on the register button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRegister_ServerClick(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				string nickName = HttpUtility.HtmlEncode(tbxNickName.Value);

				// check if the nickname is already taken.
				bool nickNameAlreadyExists = UserGuiHelper.CheckIfNickNameExists(nickName);
				if(nickNameAlreadyExists)
				{
					// already exists
					lblNickNameError.Visible=true;
				}
				else
				{
					// doesn't exist. Form is valid, so write the data into the database.
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

					if(tbxDateOfBirth.Value.Length > 0)
					{
						try
						{
							dateOfBirth = System.DateTime.Parse(tbxDateOfBirth.Value, CultureInfo.InvariantCulture.DateTimeFormat);
						}
						catch(FormatException)
						{
							// format exception, date invalid, ignore, will resolve to the default : null
						}
					}

					emailAddress = tbxEmailAddress.Value;
					emailAddressIsPublic = !chkEmailAddressIsHidden.Checked;
					if(tbxIconURL.Value.Length > 0)
					{
						iconURL = tbxIconURL.Value;
					}
					ipNumber = lblIPNumber.Text;
					if(tbxLocation.Value.Length > 0)
					{
						location = tbxLocation.Value;
					}
					if(tbxOccupation.Value.Length > 0)
					{
						occupation = tbxOccupation.Value;
					}
					
					if(tbxSignature.Value.Length > 0)
					{
						signature = tbxSignature.Value;
					}
					if(tbxWebsite.Value.Length > 0)
					{
						website = tbxWebsite.Value;
					}

                    //Preferences
                    autoSubscribeThreads = chkAutoSubscribeToThread.Checked;
                    if (tbxDefaultNumberOfMessagesPerPage.Value.Length > 0)
                    {
                        defaultMessagesPerPage = HnDGeneralUtils.TryConvertToShort(tbxDefaultNumberOfMessagesPerPage.Value);
                    }
					
					// add it
                    string mailTemplate = ApplicationAdapter.GetEmailTemplate(EmailTemplate.RegistrationReply);
					int userID = UserManager.RegisterNewUser(nickName, dateOfBirth, emailAddress, emailAddressIsPublic, iconURL, ipNumber, location,
							occupation, signature, website, mailTemplate, ApplicationAdapter.GetEmailData(), ApplicationAdapter.GetParserData(), autoSubscribeThreads, defaultMessagesPerPage);

					Response.Redirect("registrationsuccessful.aspx", true);
				}
			}
		}
	}
}
