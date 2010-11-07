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

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind file for the Attachments form 
	/// </summary>
	public partial class Attachments : System.Web.UI.Page
	{
		#region Class Member Declarations
		private int _sourceType, _numberOfAttachments;
		private MessageEntity _message;
		private ThreadEntity _thread;
		private ForumEntity _forum;
		private bool _userCanApproveAttachments, _userCanAddAttachments, _userMayManageAttachments;
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			int messageID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["MessageID"]);
			_message = MessageGuiHelper.GetMessage(messageID);
			if(_message == null)
			{
				// not found
				Response.Redirect("default.aspx", true);
			}

			_sourceType = HnDGeneralUtils.TryConvertToInt(Request.QueryString["SourceType"]);
			switch(_sourceType)
			{
				case 1:
					// new message, or message view, for now no action needed
					break;
				case 2:
					// new thread, for now no action needed
					break;
				default:
					// unknown, redirect
					Response.Redirect("default.aspx", true);
					break;
			}

			// We could have used Lazy loading here, but for the sake of separation, we use the BL method.
			_thread = ThreadGuiHelper.GetThread(_message.ThreadID);
			if(_thread == null)
			{
				// not found. Orphaned message.
				Response.Redirect("default.aspx", true);
			}

			_forum = CacheManager.GetForum(_thread.ForumID);
			if(_forum == null)
			{
				// not found. 
				Response.Redirect("default.aspx", true);
			}

			// check if this forum accepts attachments.
			if(_forum.MaxNoOfAttachmentsPerMessage <= 0)
			{
				// no, so no right to be here nor is the user here via a legitimate route.
				Response.Redirect("default.aspx", true);
			}

			// Check credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				Response.Redirect("default.aspx", true);
			}

			// check if the user can view this thread. If not, don't continue.
			if((_thread.StartedByUserID != SessionAdapter.GetUserID()) &&
				!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!_thread.IsSticky)
			{
				// can't view this thread, it isn't visible to the user
				Response.Redirect("default.aspx", true);
			}

			// Check if the current user is allowed to manage attachments of this message, and other rights.
			_userMayManageAttachments = ((_message.PostedByUserID==SessionAdapter.GetUserID())||
										SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ManageOtherUsersAttachments));
			_userCanAddAttachments = (((_message.PostedByUserID==SessionAdapter.GetUserID()) ||
										SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ManageOtherUsersAttachments)) && 
										SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAttachment));
			_userCanApproveAttachments = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ApproveAttachment);

			phAttachmentLimits.Visible = _userMayManageAttachments;

			if(!Page.IsPostBack)
			{
				// fill the page's content
				lnkThreads.Text = HttpUtility.HtmlEncode(_forum.ForumName);
				lnkThreads.NavigateUrl += "?ForumID=" + _thread.ForumID;
				lblSectionName.Text = CacheManager.GetSectionName(_forum.SectionID);
				lnkMessages.NavigateUrl += _message.ThreadID;
				lnkMessages.Text = HttpUtility.HtmlEncode(_thread.Subject);

				lblMaxFileSize.Text = String.Format("{0} KB", _forum.MaxAttachmentSize);
				lblMaxNoOfAttachmentsPerMessage.Text = _forum.MaxNoOfAttachmentsPerMessage.ToString();
				lnkMessage.Text += messageID.ToString();
				lnkMessage.NavigateUrl += String.Format("MessageID={0}&ThreadID={1}", messageID, _thread.ThreadID);

				phAddNewAttachment.Visible = _userCanAddAttachments;

				BindAttachments();
			}
			else
			{
				object numberOfAttachments = ViewState["numberOfAttachments"];
				if(numberOfAttachments != null)
				{
					_numberOfAttachments = (int)numberOfAttachments;
				}
			}
		}


		/// <summary>
		/// Binds the attachments.
		/// </summary>
		private void BindAttachments()
		{
			// get all attachments for the given message and bind them to the repeater
			DataView attachments = MessageGuiHelper.GetAttachmentsAsDataView(_message.MessageID);

			rpAttachments.DataSource = attachments;
			rpAttachments.DataBind();

			// if max number of attachments has been reached, disable the add attachment placeholder
			if(_forum.MaxNoOfAttachmentsPerMessage <= attachments.Count)
			{
				// maximum has been reached
				phAddNewAttachment.Visible = false;
			}
			else
			{
				phAddNewAttachment.Visible = _userCanAddAttachments;
			}

			_numberOfAttachments = attachments.Count;
			ViewState["numberOfAttachments"] = _numberOfAttachments;
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
					if(_userCanApproveAttachments)
					{
						// if auditing is required, we've to do this now.
						if(SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditApproveAttachment))
						{
							SecurityManager.AuditApproveAttachment(SessionAdapter.GetUserID(), attachmentID);
						}
						MessageManager.ModifyAttachmentApproval(attachmentID, true);
					}
					break;
				case "Revoke":
					if(_userCanApproveAttachments)
					{
						MessageManager.ModifyAttachmentApproval(attachmentID, false);
					}
					break;
				case "Delete":
					if(_userMayManageAttachments)
					{
						MessageManager.DeleteAttachment(attachmentID);
					}
					break;
			}

			phUploadResult.Visible = false;

			// rebind attachments.
			BindAttachments();
		}


		/// <summary>
		/// Handles the Click event of the btnUploadAttachment control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void btnUploadAttachment_Click(object sender, EventArgs e)
		{
			if(!_userCanAddAttachments)
			{
				// can't add attachments
				return;
			}
			
			if(!phAddNewAttachment.Visible)
			{
				// custom http put request, deny
				return;
			}

			if(_numberOfAttachments>=_forum.MaxNoOfAttachmentsPerMessage)
			{
				// # of attachments is already on maximum. Deny
				phUploadResult.Visible = true;
				lblError.Visible = true;
				lblSuccess.Visible=false;
				lblError.Text = String.Format("You can't add another attachment to this message. Maximum # of attachments per message: {0}. Current # of attachments: {1}", _forum.MaxNoOfAttachmentsPerMessage, _numberOfAttachments);
				return;
			}

			byte[] fileContents = fuUploader.FileBytes;
			int lengthInKB = fileContents.Length / 1024;
			if(_forum.MaxAttachmentSize < (lengthInKB))
			{
				// attachment is too big
				phUploadResult.Visible = true;
				lblError.Visible = true;
				lblSuccess.Visible=false;
				lblError.Text = String.Format("The attachment is too big. Maximum size: {0} KB. Attachment size: {1} KB", _forum.MaxAttachmentSize, lengthInKB);
				return;
			}

			if(fileContents.Length <= 0)
			{
				// file is empty
				phUploadResult.Visible = true;
				lblError.Visible = true;
				lblSuccess.Visible = false;
				lblError.Text = "The attachment is empty, the size is 0 bytes.";
				return;
			}

			string fileName = Path.GetFileName(fuUploader.FileName);

			if(fileName.Length > 255)
			{
				// too big, chop off
				fileName = fileName.Substring(fileName.Length - 200);
			}

			MessageManager.AddAttachment(_message.MessageID, fileName, fileContents, SessionAdapter.CanPerformForumActionRight(_forum.ForumID, ActionRights.GetsAttachmentsApprovedAutomatically));
			phUploadResult.Visible = true;
			lblError.Visible = false;
			lblSuccess.Visible = true;
			lblSuccess.Text = string.Format("Upload of attachment '{0}' with size {1} was successful.", fileName, fileContents.Length.ToString("N0"));

			BindAttachments();
		}


		/// <summary>
		/// Handles the Click event of the btnContinue control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void btnContinue_Click(object sender, EventArgs e)
		{
			// depending on the sourcetype, we're going to redirect to a different page. 
			switch(_sourceType)
			{
				case 1:
					// message list oriented, redirect to the message set
					Response.Redirect(String.Format("GotoMessage.aspx?MessageID={0}&ThreadID={1}", _message.MessageID, _message.ThreadID), true);
					break;
				case 2:
					// thread list oriented, redirect to thread list
					Response.Redirect("Threads.aspx?ForumID=" + _forum.ForumID, true);
					break;
				default:
					// unknown
					Response.Redirect("default.aspx", true);
					break;
			}
		}

		
		#region Class Property Declarations
		/// <summary>
		/// Gets a value indicating whether [user can approve attachments].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [user can approve attachments]; otherwise, <c>false</c>.
		/// </value>
		protected bool UserCanApproveAttachments
		{
			get { return _userCanApproveAttachments; }
		}

		/// <summary>
		/// Gets a value indicating whether [user may manage attachments].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [user may manage attachments]; otherwise, <c>false</c>.
		/// </value>
		protected bool UserMayManageAttachments
		{
			get { return _userMayManageAttachments; }
		}
		#endregion
	}
}