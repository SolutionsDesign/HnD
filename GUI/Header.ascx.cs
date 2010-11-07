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
namespace SD.HnD.GUI
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SD.HnD.BL;
	using System.Collections.Generic;

	/// <summary>
	///	code-behind of Header control
	/// </summary>
	public partial class Header : System.Web.UI.UserControl
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				// Check some credentials/properties and decide then which controls to show.
				// enable/disable the controls for logged in visitors.
				phNotLoggedIn.Visible = !Request.IsAuthenticated;
				phLoggedIn.Visible = Request.IsAuthenticated;
				phLoggedInBottom.Visible = Request.IsAuthenticated;
				phAdministrate.Visible = SessionAdapter.CanAdministrate();
				phSupportQueues.Visible = SessionAdapter.HasSystemActionRight(ActionRights.QueueContentManagement);

				// check if the user has the action right to approve attachments on some forum. If so, show the menu item
				List<int> forumsWithApprovalRight = SessionAdapter.GetForumsWithActionRight(ActionRights.ApproveAttachment);
				phAttachmentApproval.Visible = ((forumsWithApprovalRight != null) && (forumsWithApprovalRight.Count > 0));
			}
		}
	}
}
