/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
    https://www.llblgen.com
	http:s//www.sd.nl

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
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Message Attachment related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class AttachmentController : Controller
	{
		private IMemoryCache _cache;


		public AttachmentController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[HttpGet]
		public async Task<ActionResult> Get(int messageId = 0, int attachmentId = 0)
		{
			// loads Message and related thread based on the attachmentId
			var relatedMessage = await MessageGuiHelper.GetMessageWithAttachmentLogicAsync(attachmentId);
			if(relatedMessage == null || relatedMessage.MessageID != messageId)
			{
				return RedirectToAction("Index", "Home");
			}

			if(!this.HttpContext.Session.CanPerformForumActionRight(relatedMessage.Thread.ForumID, ActionRights.AccessForum))
			{
				return RedirectToAction("Index", "Home");
			}

			// Check if the thread is sticky, or that the user can see normal threads started
			// by others. If not, the user isn't allowed to view the thread the message is in, and therefore is denied access.
			if((relatedMessage.Thread.StartedByUserID != this.HttpContext.Session.GetUserID()) &&
			   !this.HttpContext.Session.CanPerformForumActionRight(relatedMessage.Thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
			   !relatedMessage.Thread.IsSticky)
			{
				// user can't view the thread the message is in, because:
				// - the thread isn't sticky
				// AND
				// - the thread isn't posted by the calling user and the user doesn't have the right to view normal threads started by others
				return RedirectToAction("Index", "Home");
			}

			var attachmentToStream = await MessageGuiHelper.GetAttachmentAsync(messageId, attachmentId);
			if(attachmentToStream == null)
			{
				return RedirectToAction("Index", "Home");
			}

			if(!attachmentToStream.Approved && !this.HttpContext.Session.CanPerformForumActionRight(relatedMessage.Thread.ForumID, ActionRights.ApproveAttachment))
			{
				// the attachment hasn't been approved yet, and the caller isn't entitled to approve attachments, so deny. 
				// approval of attachments requires to be able to load the attachment without the attachment being approved
				return RedirectToAction("Index", "Home");
			}

			// all good, return the file contents.
			return File(attachmentToStream.Filecontents, "application/unknown", attachmentToStream.Filename);
		}


		[Authorize]
		[HttpGet]
		public async Task<ActionResult> Unapproved()
		{
			var forumsWithApprovalRight = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ApproveAttachment);
			var accessableForums = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum);
			if(forumsWithApprovalRight == null || forumsWithApprovalRight.Count <= 0 || accessableForums == null || accessableForums.Count <= 0)
			{
				// no, this user doesn't have the right to approve attachments or doesn't have access to any forums.
				return RedirectToAction("Index", "Home");
			}

			var messageIDsWithUnaprovedAttachments = await MessageGuiHelper.GetAllMessagesIDsWithUnapprovedAttachments(accessableForums, forumsWithApprovalRight,
																			   this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
																			   this.HttpContext.Session.GetUserID());
			return View(new UnapprovedAttachmentsData() {MessageIdsWithUnapprovedAttachments = messageIDsWithUnaprovedAttachments});
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Add(int messageId = 0)
		{
			var (messageGetResult, message) = await GetMessageAndThreadAsync(messageId);
			if(!messageGetResult)
			{
				return Json(new {success = false, responseMessage = "Upload failed."});
			}

			var forum = await _cache.GetForumAsync(message.Thread.ForumID);
			if(forum == null)
			{
				return Json(new {success = false, responseMessage = "Upload failed."});
			}

			// Check if the thread is sticky, or that the user can see normal threads started
			// by others. If not, the user isn't allowed to view the thread the message is in, and therefore is denied access.
			if((message.Thread.StartedByUserID != this.HttpContext.Session.GetUserID()) &&
			   !this.HttpContext.Session.CanPerformForumActionRight(message.Thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
			   !message.Thread.IsSticky)
			{
				// user can't view the thread the message is in, because:
				// - the thread isn't sticky
				// AND
				// - the thread isn't posted by the calling user and the user doesn't have the right to view normal threads started by others
				return Json(new {success = false, responseMessage = "Upload failed."});
			}

			var totalNumberOfAttachmentsOfMessage = await MessageGuiHelper.GetTotalNumberOfAttachmentsOfMessageAsync(messageId);
			bool userMayAddAttachment = forum.MaxNoOfAttachmentsPerMessage > 0 &&
										this.HttpContext.Session.CanPerformForumActionRight(forum.ForumID, ActionRights.AddAttachment) &&
										this.HttpContext.Session.GetUserID() == message.PostedByUserID &&
										totalNumberOfAttachmentsOfMessage < forum.MaxNoOfAttachmentsPerMessage;
			if(!userMayAddAttachment)
			{
				return Json(new {success = false, responseMessage = "Upload failed."});
			}

			try
			{
				if(this.Request.Form.Files.Count <= 0)
				{
					return Json(new {success = false, responseMessage = "No file attached!"});
				}

				var fileContent = this.Request.Form.Files[0];
				if(fileContent == null || fileContent.Length <= 0)
				{
					return Json(new {success = false, responseMessage = "The file uploaded is empty (0KB)."});
				}

				var fileLengthInKB = fileContent.Length / 1024;
				if(fileLengthInKB > forum.MaxAttachmentSize)
				{
					return Json(new {success = false, responseMessage = $"The file uploaded is too large ({fileLengthInKB}KB). The max. file size is {forum.MaxAttachmentSize}KB"});
				}

				// all is well, save the attachment!
				var fileData = new byte[fileContent.Length];
				await using(var reader = fileContent.OpenReadStream())
				{
					await reader.ReadAsync(fileData, 0, (int)fileContent.Length);
				}

				await MessageManager.AddAttachmentAsync(messageId, fileContent.FileName, fileData,
														this.HttpContext.Session.CanPerformForumActionRight(forum.ForumID, ActionRights.GetsAttachmentsApprovedAutomatically));
				ApplicationAdapter.InvalidateCachedNumberOfUnapprovedAttachments();
				return Json(new {success = true, responseMessage = string.Empty});
			}
			catch(Exception)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new {success = false, responseMessage = "Upload failed."});
			}
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int messageId = 0, int attachmentId = 0)
		{
			var (messageGetResult, message) = await GetMessageAndThreadAsync(messageId);
			if(!messageGetResult)
			{
				return RedirectToAction("Index", "Home");
			}

			var forum = await _cache.GetForumAsync(message.Thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

			bool userMayManageAttachments = message.PostedByUserID == this.HttpContext.Session.GetUserID() ||
											this.HttpContext.Session.CanPerformForumActionRight(forum.ForumID, ActionRights.ManageOtherUsersAttachments);
			if(!userMayManageAttachments)
			{
				return RedirectToAction("Index", "Home");
			}

			await MessageManager.DeleteAttachmentAsync(messageId, attachmentId);
			ApplicationAdapter.InvalidateCachedNumberOfUnapprovedAttachments();

			// redirect to the message, using the message controller
			return RedirectToAction("Goto", "Message", new {id = messageId});
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ToggleApproval(int messageId = 0, int attachmentId = 0)
		{
			var (messageGetResult, message) = await GetMessageAndThreadAsync(messageId);
			if(!messageGetResult)
			{
				return Json(new {success = false});
			}

			var forum = await _cache.GetForumAsync(message.Thread.ForumID);
			if(forum == null)
			{
				return Json(new {success = false});
			}

			bool userCanApproveAttachments = this.HttpContext.Session.CanPerformForumActionRight(forum.ForumID, ActionRights.ApproveAttachment);
			if(!userCanApproveAttachments)
			{
				return Json(new {success = false});
			}

			int userIdForAuditing = this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditApproveAttachment) ? this.HttpContext.Session.GetUserID() : -1;
			var (toggleResult, newState) = await MessageManager.ToggleAttachmentApprovalAsync(messageId, attachmentId, userIdForAuditing);
			if(toggleResult)
			{
				ApplicationAdapter.InvalidateCachedNumberOfUnapprovedAttachments();
			}

			return Json(new {success = toggleResult, newstate = newState});
		}


		private async Task<(bool fetchResult, MessageEntity message)> GetMessageAndThreadAsync(int id)
		{
			if(id <= 0)
			{
				return (false, null);
			}

			var message = await MessageGuiHelper.GetMessageAsync(id, prefetchThread: true);
			return (message?.Thread != null, message);
		}
	}
}