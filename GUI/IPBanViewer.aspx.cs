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
using SD.HnD.DAL.EntityClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	/// General IP Ban viewer. This viewer enlists the first matching IP ban entity. This form is shown when the user is banned 
	/// via one or more IP Bans. 
	/// </summary>
	public partial class IPBanViewer : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string banComplainAddress = ApplicationAdapter.GetIPBanComplainEmailAddress();
				lnkBanComplaintEmailAddress.Text = banComplainAddress;
				lnkBanComplaintEmailAddress.NavigateUrl += banComplainAddress;

				// get the set of IP-bans for the given IP address
				string ipAddressUser = Request.UserHostAddress;
				IPBanEntity matchingBan = SecurityGuiHelper.GetIPBanMatchingUserIPAddress(CacheManager.GetAllIPBans(), ipAddressUser);

				if(matchingBan!=null)
				{
					// has to match a ban
					lblIPBanDate.Text = matchingBan.IPBanSetOn.ToString("dd-MMM-yyyy HH:mm:ss");
					lblIPBanRange.Text = string.Format("{0}.{1}.{2}.{3} / {4}", matchingBan.IPSegment1, matchingBan.IPSegment2, matchingBan.IPSegment3,
												matchingBan.IPSegment4, matchingBan.Range);
					lblIPBanReason.Text = matchingBan.Reason;
				}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
