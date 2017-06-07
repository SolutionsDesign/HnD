using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;

namespace SD.HnD.Gui.Controllers
{
	public class AttachmentController : Controller
	{
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
			var forum = CacheManager.GetForum(message.Thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

			bool userMayManageAttachments = message.PostedByUserID == LoggedInUserAdapter.GetUserID() ||
											 LoggedInUserAdapter.CanPerformForumActionRight(forum.ForumID, ActionRights.ManageOtherUsersAttachments);
			if(!userMayManageAttachments)
			{
				return RedirectToAction("Index", "Home");
			}
			MessageManager.DeleteAttachment(messageId, attachmentId);
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
			var forum = CacheManager.GetForum(message.Thread.ForumID);
			if(forum == null)
			{
				return Json(new { success = false });
			}
			bool userCanApproveAttachments = LoggedInUserAdapter.CanPerformForumActionRight(forum.ForumID, ActionRights.ApproveAttachment);
			if(!userCanApproveAttachments)
			{
				return Json(new { success = false });
			}

			int userIdForAuditing = AuditingAdapter.CheckIfNeedsAuditing(AuditActions.AuditApproveAttachment) ? LoggedInUserAdapter.GetUserID() : -1;
			bool newState = false;
			bool result = MessageManager.ToggleAttachmentApproval(messageId, attachmentId, userIdForAuditing, out newState);
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