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
using System.Web.Security;
using SD.HnD.BL;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind for the login form
	/// </summary>
	public partial class Login : System.Web.UI.Page
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
			this.btnLogin.ServerClick += new System.EventHandler(this.btnLogin_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLogin_ServerClick(object sender, System.EventArgs e)
		{
			// try to authenticate the user
            UserEntity user = null;
			SecurityManager.AuthenticateResult result = SecurityManager.AuthenticateUser(tbxUserName.Value, tbxPassword.Value, out user);
			
			switch(result)
			{
				case SecurityManager.AuthenticateResult.AllOk:
					// authenticated
					// Save session cacheable data
                    SessionAdapter.LoadUserSessionData(user);
					// update last visit date in db
					UserManager.UpdateLastVisitDateForUser(user.UserID);
					// done
					FormsAuthentication.RedirectFromLoginPage(tbxUserName.Value, chkPersistentLogin.Checked);
                    
                    // Audit the login action, if it was defined to be logged for this role.
                    if (SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditLogin))
                    {
                        SecurityManager.AuditLogin(SessionAdapter.GetUserID());
                    }
					break;
				case SecurityManager.AuthenticateResult.IsBanned:
					lblErrorMessage.Text = "You are banned. Login won't work for you.";
					break;
				case SecurityManager.AuthenticateResult.WrongUsernamePassword:
					lblErrorMessage.Text = "You specified a wrong User name - Password combination. Try again.";
					break;
			}
		}
	}
}
