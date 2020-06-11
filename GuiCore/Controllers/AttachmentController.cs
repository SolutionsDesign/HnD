﻿using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	public class AttachmentController : Controller
	{
		private IMemoryCache _cache;

		public AttachmentController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		[HttpGet]
		public ActionResult Get(int messageId = 0, int attachmentId = 0)
		{
			// loads Message and related thread based on the attachmentId
			var relatedMessage = MessageGuiHelper.GetMessageWithAttachmentLogic(attachmentId);
			if(relatedMessage == null || relatedMessage.MessageID!=messageId)
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
			var attachmentToStream = MessageGuiHelper.GetAttachment(messageId, attachmentId);
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
		public ActionResult Unapproved()
		{
			var forumsWithApprovalRight = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ApproveAttachment);
			var accessableForums = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum);
			if(((forumsWithApprovalRight == null) || (forumsWithApprovalRight.Count <= 0)) ||
			   ((accessableForums == null) || (accessableForums.Count <= 0)))
			{
				// no, this user doesn't have the right to approve attachments or doesn't have access to any forums.
				return RedirectToAction("Index", "Home");
			}

			var messageIDsWithUnaprovedAttachments = MessageGuiHelper
														.GetAllMessagesIDsWithUnapprovedAttachments(accessableForums, forumsWithApprovalRight,
																									this.HttpContext.Session.GetForumsWithActionRight(
																												ActionRights.ViewNormalThreadsStartedByOthers), 
																									this.HttpContext.Session.GetUserID());
			return View(new UnapprovedAttachmentsData() {MessageIdsWithUnapprovedAttachments = messageIDsWithUnaprovedAttachments});
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Add(int messageId = 0)
		{
			MessageEntity message = null;
			if(!GetMessageAndThread(messageId, out message))
			{
				return Json(new { success = false, responseMessage = "Upload failed." });
			}
			var forum = _cache.GetForum(message.Thread.ForumID);
			if(forum == null)
			{
				return Json(new { success = false, responseMessage = "Upload failed." });
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
				return Json(new { success = false, responseMessage = "Upload failed." });
			}
			bool userMayAddAttachment = forum.MaxNoOfAttachmentsPerMessage > 0 && 
										this.HttpContext.Session.CanPerformForumActionRight(forum.ForumID, ActionRights.AddAttachment) && 
										this.HttpContext.Session.GetUserID() == message.PostedByUserID &&
										MessageGuiHelper.GetTotalNumberOfAttachmentsOfMessage(messageId) < forum.MaxNoOfAttachmentsPerMessage;
			if(!userMayAddAttachment)
			{
				return Json(new { success = false, responseMessage = "Upload failed." });
			}
			try
			{
				if(this.Request.Form.Files.Count <= 0)
				{
					return Json(new { success = false, responseMessage="No file attached!" });
				}
				var fileContent = this.Request.Form.Files[0];
				if(fileContent == null || fileContent.Length <= 0)
				{
					return Json(new { success = false, responseMessage = "The file uploaded is empty (0KB)."});
				}
				var fileLengthInKB = fileContent.Length / 1024;
				if(fileLengthInKB > forum.MaxAttachmentSize)
				{
					return Json(new {success = false, responseMessage = $"The file uploaded is too large ({fileLengthInKB}KB). The max. file size is {forum.MaxAttachmentSize}KB"});
				}

				// all is well, save the attachment!
				var fileData = new byte[fileContent.Length];
				using(var reader = fileContent.OpenReadStream())
				{
					reader.Read(fileData, 0, (int)fileContent.Length);
				}
				MessageManager.AddAttachment(messageId, fileContent.FileName, fileData,
											 this.HttpContext.Session.CanPerformForumActionRight(forum.ForumID, ActionRights.GetsAttachmentsApprovedAutomatically));
				ApplicationAdapter.InvalidateCachedNumberOfUnapprovedAttachments();
				return Json(new {success = true, responseMessage = string.Empty});
			}
			catch(Exception)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { success = false, responseMessage = "Upload failed." });
			}
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int messageId=0, int attachmentId=0)
		{
			MessageEntity message = null;
			if(!GetMessageAndThread(messageId, out message))
			{
				return RedirectToAction("Index", "Home");
			}
			var forum = _cache.GetForum(message.Thread.ForumID);
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
			MessageManager.DeleteAttachment(messageId, attachmentId);
			ApplicationAdapter.InvalidateCachedNumberOfUnapprovedAttachments();
			// redirect to the message, using the message controller
			return RedirectToAction("Goto", "Message", new {id = messageId});
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ToggleApproval(int messageId = 0, int attachmentId = 0)
		{
			MessageEntity message = null;
			if(!GetMessageAndThread(messageId, out message))
			{
				return Json(new { success = false });
			}
			var forum = _cache.GetForum(message.Thread.ForumID);
			if(forum == null)
			{
				return Json(new { success = false });
			}
			bool userCanApproveAttachments = this.HttpContext.Session.CanPerformForumActionRight(forum.ForumID, ActionRights.ApproveAttachment);
			if(!userCanApproveAttachments)
			{
				return Json(new { success = false });
			}

			int userIdForAuditing = this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditApproveAttachment) ? this.HttpContext.Session.GetUserID() : -1;
			bool newState = false;
			bool result = MessageManager.ToggleAttachmentApproval(messageId, attachmentId, userIdForAuditing, out newState);
			if(result)
			{
				ApplicationAdapter.InvalidateCachedNumberOfUnapprovedAttachments();
			}
			return Json(new { success = result, newstate = newState });
		}
		

		private bool GetMessageAndThread(int id, out MessageEntity message)
		{
			message = null;
			if(id <= 0)
			{
				return false;
			}

			message = MessageGuiHelper.GetMessage(id, prefetchThread: true);
			return message != null && message.Thread != null;
		}
	}
}