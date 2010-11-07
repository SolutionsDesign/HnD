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
using System.IO;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind for the ResetPassword form.
	/// </summary>
	public partial class ResetPassword : System.Web.UI.Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.btnResetPassword.ServerClick += new System.EventHandler(this.btnResetPassword_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnResetPassword_ServerClick(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				try
				{
					// user has filled in all fields, let's reset the password.
                    string mailTemplate = ApplicationAdapter.GetEmailTemplate(EmailTemplate.RegistrationReply);
					bool result = UserManager.ResetPassword(tbxNickName.Value, tbxEmailAddress.Value, mailTemplate, ApplicationAdapter.GetEmailData());
					if(result)
					{
						// ok
						Response.Redirect("ResetPasswordSuccessful.aspx",true);
					}
					// not ok
					lblErrorMessage.Text = "Something went wrong with the reset action. Please try again.";
				}
				catch(NickNameNotFoundException ex)
				{
					lblErrorMessage.Text = ex.Message;
				}
				catch(EmailAddressDoesntMatchException ex)
				{
					lblErrorMessage.Text = ex.Message;
				}
				// bubble up others. 
			}
		}
	}
}
