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
using SD.HnD.Utility;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind for GotoMessage form, which redirects a user to the right page in a thread based on the messageID to view. 
	/// It's a small utility form which allows redirection to a message without first calculating on which page it is located. 
	/// </summary>
	public partial class GotoMessage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			int	threadID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ThreadID"]);
			int messageID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["MessageID"]);
            int startAtMessage = ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThread(threadID, messageID, SessionAdapter.GetUserDefaultNumberOfMessagesPerPage());
			Response.Redirect("Messages.aspx?ThreadID=" + threadID + "&StartAtMessage=" + startAtMessage + "&#" + messageID, true);
		}

		private void Page_PreInit(object sender, EventArgs e)
		{
			// switch off theming as the EnableTheming option on the page level doesn't work 
			Page.Theme = "";
		} 
	}
}
