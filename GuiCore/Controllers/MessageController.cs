using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;
using SD.HnD.Utility;

namespace SD.HnD.Gui.Controllers
{
	public class MessageController : Controller
	{
		private IMemoryCache _cache;

		public MessageController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		[HttpGet]
		public ActionResult Goto(int id = 0)
		{
			var message = MessageGuiHelper.GetMessage(id);
			if(message == null)
			{
				return RedirectToAction("Index", "Home");
			}
			return CalculateRedirectToMessage(message.ThreadID, message.MessageID);
		}


		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Delete(int id = 0)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
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
			   this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages))
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
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			MessageEntity message;
			var userMayEditMessages = PerformEditMessageSecurityChecks(id, out message);
			if(!userMayEditMessages)
			{
				return RedirectToAction("Index", "Home");
			}
			var thread = message.Thread;
			var forum = _cache.GetForum(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

			// user has access, let's edit!
			var messageData = new MessageData()
							  {
								  MessageText = message.MessageText,
								  CurrentUserID = this.HttpContext.Session.GetUserID(),
								  ForumID = forum.ForumID,
								  ThreadID = thread.ThreadID,
								  ForumName = forum.ForumName,
								  SectionName = _cache.GetSectionName(forum.SectionID),
								  ThreadSubject = thread.Subject,
								  PageNo = 1,
							  };
			return View(messageData);
		}


		[Authorize]
		[HttpGet]
		public ActionResult Add(int threadId = 0, int messageIdToQuote=0)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			ThreadEntity thread;
			var userMayAddMessages = PerformAddMessageSecurityChecks(threadId, out thread);
			if(!userMayAddMessages)
			{
				return RedirectToAction("Index", "Home");
			}
			MessageEntity messageToQuote = null;
			UserEntity userOfMessageToQuote = null;
			if(messageIdToQuote > 0)
			{
				messageToQuote = MessageGuiHelper.GetMessage(messageIdToQuote);
				if(messageToQuote == null || messageToQuote.ThreadID!=threadId)
				{
					// doesn't exist, or is in another thread, ignore.
					return RedirectToAction("Index", "Home");
				}
				userOfMessageToQuote = UserGuiHelper.GetUser(messageToQuote.PostedByUserID);
				if(userOfMessageToQuote == null)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			var forum = _cache.GetForum(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}
			string messageTextForEditor = messageToQuote == null ? string.Empty
																 : string.Format("@quote {0}{1}{2}{1}@end{1}", userOfMessageToQuote.NickName, Environment.NewLine, messageToQuote.MessageText);
			// user has access, let's edit!
			var messageData = new MessageData()
			{
				MessageText = messageTextForEditor,
				CurrentUserID = this.HttpContext.Session.GetUserID(),
				ForumID = forum.ForumID,
				ThreadID = thread.ThreadID,
				ForumName = forum.ForumName,
				SectionName = _cache.GetSectionName(forum.SectionID),
				ThreadSubject = thread.Subject,
				PageNo = 1,
			};
			return View(messageData);
		}

		
		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> Add([Bind("MessageText,Subscribe")] MessageData messageData, string submitButton, int threadId = 0)
		{
			if(submitButton != "Post")
			{
				// apparently canceled
				if(threadId <= 0)
				{
					return RedirectToAction("Index", "Home");
				}
				return RedirectToAction("Index", "Thread", new { id = threadId });
			}

			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			ThreadEntity thread;
			var userMayAddMessages = PerformAddMessageSecurityChecks(threadId, out thread);
			if(!userMayAddMessages)
			{
				return RedirectToAction("Index", "Home");
			}
			int newMessageId = 0;
			if(submitButton == "Post")
			{
				// allowed, proceed
				// parse message text to html
				var messageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(messageData.MessageText, ApplicationAdapter.GetEmojiFilenamesPerName(), ApplicationAdapter.GetSmileyMappings());
				newMessageId = await ThreadManager.CreateNewMessageInThread(threadId, this.HttpContext.Session.GetUserID(), messageData.MessageText, messageAsHtml,
																			this.HttpContext.Connection.RemoteIpAddress.ToString(), messageData.Subscribe, 
																			ApplicationAdapter.GetEmailData(this.Request.Host.Host, EmailTemplate.ThreadUpdatedNotification),
																			_cache.GetSystemData().SendReplyNotifications).ConfigureAwait(false);
				ApplicationAdapter.InvalidateCachedNumberOfThreadsInSupportQueues();
				if(this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditNewMessage))
				{
					SecurityManager.AuditNewMessage(this.HttpContext.Session.GetUserID(), newMessageId);
				}
			}
			return CalculateRedirectToMessage(thread.ThreadID, newMessageId);
		}
		
		
		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Edit([Bind("MessageText")] MessageData messageData, string submitButton, int id = 0)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			MessageEntity message;
			var userMayEditMessages = PerformEditMessageSecurityChecks(id, out message);
			if(!userMayEditMessages)
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitButton == "Post")
			{
				// allowed, proceed
				// parse message text to html
				var messageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(messageData.MessageText, ApplicationAdapter.GetEmojiFilenamesPerName(), 
																			ApplicationAdapter.GetSmileyMappings());
				var result = MessageManager.UpdateEditedMessage(this.HttpContext.Session.GetUserID(), message.MessageID, messageData.MessageText, messageAsHtml, 
																this.Request.Host.Host, string.Empty);
				if(this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditAlteredMessage))
				{
					SecurityManager.AuditAlteredMessage(this.HttpContext.Session.GetUserID(), message.MessageID);
				}
			}
			return CalculateRedirectToMessage(message.ThreadID, message.MessageID);
		}


		/// <summary>
		/// Performs the edit message security checks. Returns true if the user may edit the message, false otherwise
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="message">The message.</param>
		/// <returns>
		/// true if the user may edit the message, false otherwise
		/// </returns>
		private bool PerformEditMessageSecurityChecks(int id, out MessageEntity message)
		{
			message = null;
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return false;
			}
			message = MessageGuiHelper.GetMessage(id, prefetchThread:true);
			if(message == null)
			{
				return false;
			}
			var thread = message.Thread;
			if(thread == null)
			{
				return false;
			}
			if(!this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return false;
			}
			var userMayEditMessages = false;
			if(!thread.IsClosed)
			{
				userMayEditMessages = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID,
																						  thread.IsSticky ? ActionRights.AddAndEditMessageInSticky 
																							              : ActionRights.AddAndEditMessage);
			}

			// User has the right to generally edit messages. Check if the user has the right to edit other peoples messages
			// and if not, if the user is the poster of this message. If not, no can do.
			if(!this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages))
			{
				// cannot edit other people's messages. Check if this message is posted by the current user.
				if(message.PostedByUserID != this.HttpContext.Session.GetUserID())
				{
					// not allowed
					userMayEditMessages = false;
				}
			}

			// check if the user can view the thread the message is in. If not, don't continue.
			if((thread.StartedByUserID != this.HttpContext.Session.GetUserID()) &&
			   !this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers))
			{
				// can't edit this message, it's in a thread which isn't visible to the user
				userMayEditMessages = false;
			}
			return userMayEditMessages;
		}


		private bool PerformAddMessageSecurityChecks(int threadId, out ThreadEntity thread)
		{
			thread = null;
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return false;
			}
			thread = ThreadGuiHelper.GetThread(threadId);
			if(thread == null)
			{
				return false;
			}
			if(!this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return false;
			}
			var userMayAddMessages = false;
			if(!thread.IsClosed)
			{
				userMayAddMessages = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID,
																						 thread.IsSticky ? ActionRights.AddAndEditMessageInSticky 
																										 : ActionRights.AddAndEditMessage);
			}

			// check if the user can view the thread the message is in. If not, don't continue.
			if((thread.StartedByUserID != this.HttpContext.Session.GetUserID()) &&
			   !this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers))
			{
				// can't edit this message, it's in a thread which isn't visible to the user
				userMayAddMessages = false;
			}
			return userMayAddMessages;
		}
		

		/// <summary>
		/// Calculates the redirect to message with the id specified. This is a response to the index action on the thread controller, with the proper page and '#' id redirect.
		/// </summary>
		/// <param name="threadId">The thread identifier.</param>
		/// <param name="messageId">The message identifier.</param>
		/// <returns></returns>
		private ActionResult CalculateRedirectToMessage(int threadId, int messageId)
		{
			var maxAmountMessagesPerPage = this.HttpContext.Session.GetUserDefaultNumberOfMessagesPerPage();
			int startAtMessageNo = messageId > 0 ? ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThread(threadId, messageId, maxAmountMessagesPerPage) : 0;
			int currentPageNo = (startAtMessageNo / maxAmountMessagesPerPage) + 1;
			return Redirect(this.Url.Action("Index", "Thread", new { id = threadId, pageNo = currentPageNo }) + "#" + messageId);
		}
	}
}