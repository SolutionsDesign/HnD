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
using SD.HnD.DAL.EntityClasses;
using SD.HnD.BL;
using SD.HnD.Utility;
using SD.HnD.DAL.CollectionClasses;
using System.IO;
using System.Collections.Generic;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind file for the ApproveAttachments form 
	/// </summary>
	public partial class ApproveAttachments : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// check if the calling user is able to approve attachments in 1 or more forums
			List<int> forumsWithApprovalRight = SessionAdapter.GetForumsWithActionRight(ActionRights.ApproveAttachment);
			List<int> accessableForums = SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum);
			if(((forumsWithApprovalRight == null) || (forumsWithApprovalRight.Count <= 0))||
				((accessableForums== null) || (accessableForums.Count <= 0)))
			{
				// no, this user doesn't have the right to approve attachments or doesn't have access to any forums.
				Response.Redirect("default.aspx", true);
			}

			List<int> forumsWithAttachmentDeleteRight = SessionAdapter.GetForumsWithActionRight(ActionRights.ManageOtherUsersAttachments);
			phAttachmentDelete.Visible = ((forumsWithAttachmentDeleteRight!=null) && (forumsWithAttachmentDeleteRight.Count>0));

			if(!Page.IsPostBack)
			{
				// get all attachments which aren't approved yet as a dataview. 
				DataView allAttachmentsToApprove = MessageGuiHelper.GetAllAttachmentsToApproveAsDataView(accessableForums, 
													forumsWithApprovalRight, SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), 
													SessionAdapter.GetUserID());
				rpAttachments.DataSource = allAttachmentsToApprove;
				rpAttachments.DataBind();
			}
		}


		/// <summary>
		/// Handles the ItemCommand event of the rpAttachments control.
		/// </summary>
		/// <param name="source">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterCommandEventArgs"/> instance containing the event data.</param>
		protected void rpAttachments_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			int attachmentID = HnDGeneralUtils.TryConvertToInt((string)e.CommandArgument);

			switch(e.CommandName)
			{
				case "Approve":
					// if auditing is required, we've to do this now.
					if(SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditApproveAttachment))
					{
						SecurityManager.AuditApproveAttachment(SessionAdapter.GetUserID(), attachmentID);
					}
					MessageManager.ModifyAttachmentApproval(attachmentID, true);
					break;
				case "Delete":
					MessageManager.DeleteAttachment(attachmentID);
					break;
			}

			// done, refresh through redirect to self
			Response.Redirect("ApproveAttachments.aspx", true);
		}
	}
}