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

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the Default form of the Admin section.
	/// </summary>
	public partial class _Default : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(SessionAdapter.HasSystemActionRight(ActionRights.SystemManagement))
			{
				// can perform system management tasks. Visualize menu
				phSections.Visible=true;
				phForums.Visible=true;
				phSystem.Visible=true;
			}
			
			if(SessionAdapter.HasSystemActionRight(ActionRights.UserManagement))
			{
				// can perform user management tasks, visualize menu
				phUsers.Visible=true;
			}
			
			if(SessionAdapter.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				// can perform security management tasks, visualize menu.
				phSecurity.Visible=true;
			}

			// switch off the link back to the admin menu as this page holds the admin menu.
			SD.HnD.GUI.Admin.Header pageHeader = (SD.HnD.GUI.Admin.Header)Master.FindControl("_pageHeader");
			pageHeader.MenuReturnLinkVisible = false;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
