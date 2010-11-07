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
using SD.HnD.Utility;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.BL;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind file of the filestreamer form, which is actually empty, and is used to send an attachment to the requesting browser.
	/// </summary>
	public partial class FileStreamer : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			int attachmentID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["AttachmentID"]);

			MessageEntity relatedMessage = MessageGuiHelper.GetMessageWithAttachmentLogic(attachmentID);
			if(relatedMessage == null)
			{
				// not found
				Response.Redirect("default.aspx", true);
			}

			// thread has been loaded into the related message object as well. This is needed for the forum access right check
			if(!SessionAdapter.CanPerformForumActionRight(relatedMessage.Thread.ForumID, ActionRights.AccessForum))
			{
				// user can't access this forum
				Response.Redirect("default.aspx", true);
			}
			
			// Check if the thread is sticky, or that the user can see normal threads started
			// by others. If not, the user isn't allowed to view the thread the message is in, and therefore is denied access.
			if((relatedMessage.Thread.StartedByUserID != SessionAdapter.GetUserID()) &&
					!SessionAdapter.CanPerformForumActionRight(relatedMessage.Thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
					!relatedMessage.Thread.IsSticky)
			{
				// user can't view the thread the message is in, because:
				// - the thread isn't sticky
				// AND
				// - the thread isn't posted by the calling user and the user doesn't have the right to view normal threads started by others
				Response.Redirect("default.aspx", true);
			}

			AttachmentEntity toStream = MessageGuiHelper.GetAttachment(attachmentID);
			if(toStream == null)
			{
				// not found
				Response.Redirect("default.aspx", true);
			}

			if(!toStream.Approved && !SessionAdapter.CanPerformForumActionRight(relatedMessage.Thread.ForumID, ActionRights.ApproveAttachment))
			{
				// the attachment hasn't been approved yet, and the caller isn't entitled to approve attachments, so deny. 
				// approval of attachments requires to be able to load the attachment without the attachment being approved
				Response.Redirect("default.aspx", true);
			}

			// all set, load stream the attachment data to the browser
			// create header
			Response.ClearHeaders();
			Response.ClearContent();
			Response.AddHeader("Content-Type", "application/unknown");
			Response.AddHeader("Content-length", toStream.Filecontents.Length.ToString()); 
			Response.AddHeader("Content-Disposition", "attachment; filename=" + toStream.Filename.Replace(" ", "_"));
			Response.AddHeader("Content-Transfer-Encoding", "Binary");
			// stream the data
			Response.BinaryWrite(toStream.Filecontents);
			Response.Flush();
			Response.End();
		}

		
		private void Page_PreInit(object sender, EventArgs e)
		{
			// switch off theming as the EnableTheming option on the page level doesn't work 
			Page.Theme = "";
		} 
	}
}