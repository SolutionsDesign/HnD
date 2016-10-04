using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;
using SD.HnD.Utility;

namespace SD.HnD.Gui.Controllers
{
	public class MessageController : Controller
	{
		[HttpGet]
		public ActionResult Goto(int id = 0)
		{
			var message = MessageGuiHelper.GetMessage(id);
			if(message == null)
			{
				return RedirectToAction("Index", "Home");
			}
			return CalculateRedirectToMessage(message);
		}


		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Delete(int id = 0)
		{
			if(LoggedInUserAdapter.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var message = MessageGuiHelper.GetMessage(id);
			if(message == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var thread = ThreadGuiHelper.GetThread(message.ThreadID);
			if(thread == null)
			{
				return RedirectToAction("Index", "Home");
			}

			// Only delete if the message isn't the first in the thread (as that's not allowed), and whether the user is allowed to delete messages in that forum at all. 
			if(!ThreadGuiHelper.CheckIfMessageIsFirstInThread(thread.ThreadID, id) &&
			   LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages))
			{
				MessageManager.DeleteMessage(id);
			}
			return RedirectToAction("Index", "Thread", new {id = thread.ThreadID, pageNo = 1});
		}


		/// <summary>
		/// Method which handles the default HttpGet on a message/edit url. View is the editor, if allowed. 
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[Authorize]
		[HttpGet]
		public ActionResult Edit(int id = 0)
		{
			if(LoggedInUserAdapter.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var message = MessageGuiHelper.GetMessage(id);
			if(message == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var thread = ThreadGuiHelper.GetThread(message.ThreadID);
			if(thread == null)
			{
				return RedirectToAction("Index", "Home");
			}
			if(!LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return RedirectToAction("Index", "Home");
			}
			var userMayEditMessages = MessageController.PerformEditMessageSecurityChecks(thread, message);
			if(!userMayEditMessages)
			{
				return RedirectToAction("Index", "Home");
			}
			var forum = CacheManager.GetForum(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

			// user has access, let's edit!
			var messageData = new MessageData()
							  {
								  MessageText = message.MessageText,
								  CurrentUserID = LoggedInUserAdapter.GetUserID(),
								  ForumID = forum.ForumID,
								  ThreadID = thread.ThreadID,
								  ForumName = forum.ForumName,
								  SectionName = CacheManager.GetSectionName(forum.SectionID),
								  ThreadSubject = thread.Subject,
							  };
			return View(messageData);
		}



		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "MessageText")] MessageData messageData, string submitButton, int id = 0)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
#warning CLONE OF CODE WHICH IS ALSO PRESENT IN 'Delete'. 
			if(LoggedInUserAdapter.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var message = MessageGuiHelper.GetMessage(id);
			if(message == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var thread = ThreadGuiHelper.GetThread(message.ThreadID);
			if(thread == null)
			{
				return RedirectToAction("Index", "Home");
			}
			if(!LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return RedirectToAction("Index", "Home");
			}
			var userMayEditMessages = MessageController.PerformEditMessageSecurityChecks(thread, message);
			if(!userMayEditMessages)
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitButton == "Post")
			{
				// allowed, proceed
				// parse message text to html
				var messageAsHtml = TextParser.TransformMarkdownToHtml(messageData.MessageText);
				var result = MessageManager.UpdateEditedMessage(LoggedInUserAdapter.GetUserID(), message.MessageID, messageData.MessageText, messageAsHtml, Request.UserHostAddress, string.Empty);
				if(AuditingAdapter.CheckIfNeedsAuditing(AuditActions.AuditAlteredMessage))
				{
					SecurityManager.AuditAlteredMessage(LoggedInUserAdapter.GetUserID(), message.MessageID);
				}
			}
			return CalculateRedirectToMessage(message);
		}


		/// <summary>
		/// Performs the edit message security checks. Returns true if the user may edit the message, false otherwise
		/// </summary>
		/// <param name="thread">The thread.</param>
		/// <param name="message">The message.</param>
		/// <returns>true if the user may edit the message, false otherwise</returns>
		private static bool PerformEditMessageSecurityChecks(ThreadEntity thread, MessageEntity message)
		{
			var userMayEditMessages = false;
			if(!thread.IsClosed)
			{
				userMayEditMessages = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID,
																					 thread.IsSticky ? ActionRights.AddAndEditMessageInSticky : ActionRights.AddAndEditMessage);
			}

			// User has the right to generally edit messages. Check if the user has the right to edit other peoples messages
			// and if not, if the user is the poster of this message. If not, no can do.
			if(!LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages))
			{
				// cannot edit other people's messages. Check if this message is posted by the current user.
				if(message.PostedByUserID != LoggedInUserAdapter.GetUserID())
				{
					// not allowed
					userMayEditMessages = false;
				}
			}

			// check if the user can view the thread the message is in. If not, don't continue.
			if((thread.StartedByUserID != LoggedInUserAdapter.GetUserID()) &&
			   !LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers))
			{
				// can't edit this message, it's in a thread which isn't visible to the user
				userMayEditMessages = false;
			}
			return userMayEditMessages;
		}


		/// <summary>
		/// Calculates the redirect to message specified. This is a response to the index action on the thread controller, with the proper page and '#' id redirect.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		private ActionResult CalculateRedirectToMessage(MessageEntity message)
		{
			var maxAmountMessagesPerPage = LoggedInUserAdapter.GetUserDefaultNumberOfMessagesPerPage();
			int startAtMessageNo = ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThread(message.ThreadID, message.MessageID, maxAmountMessagesPerPage);
			int currentPageNo = (startAtMessageNo / maxAmountMessagesPerPage) + 1;
			return Redirect(this.Url.Action("Index", "Thread", new { id = message.ThreadID, pageNo = currentPageNo }) + "#" + message.MessageID);
		}

	}
}