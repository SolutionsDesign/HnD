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
	/// <summary>
	/// Controller for Message related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class MessageController : Controller
	{
		private IMemoryCache _cache;

		public MessageController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		[HttpGet]
		public ActionResult GotoOldVersion(int messageID)
		{
			// We expect the messageID as argument in the querystring. Typical URL is /Message/OldGoto/?MessageID=10000
			return RedirectToAction("Goto", "Message", new {messageId = messageID});
		}

		
		[HttpGet]
		public async Task<ActionResult> Goto(int id = 0)
		{
			var message = await MessageGuiHelper.GetMessageAsync(id);
			return message == null ? RedirectToAction("Index", "Home") : await CalculateRedirectToMessageAsync(message.ThreadID, message.MessageID);
		}


		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> Delete(int id = 0)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var message = await MessageGuiHelper.GetMessageAsync(id);
			if(message == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var thread = await ThreadGuiHelper.GetThreadAsync(message.ThreadID);
			if(thread == null)
			{
				return RedirectToAction("Index", "Home");
			}

			// Only delete if the message isn't the first in the thread (as that's not allowed), and whether the user is allowed to delete messages in that forum at all. 
			var messageIsFirstInThread = await ThreadGuiHelper.CheckIfMessageIsFirstInThreadAsync(thread.ThreadID, id);
			if(!messageIsFirstInThread && this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages))
			{
				await MessageManager.DeleteMessageAsync(id);
			}
			return RedirectToAction("Index", "Thread", new {threadId = thread.ThreadID, pageNo = 1});
		}


		/// <summary>
		/// Method which handles the default HttpGet on a message/edit url. View is the editor, if allowed. 
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[Authorize]
		[HttpGet]
		public async Task<ActionResult> Edit(int id = 0)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var (userMayEditMessages, message) = await PerformEditMessageSecurityChecksAsync(id);
			if(!userMayEditMessages)
			{
				return RedirectToAction("Index", "Home");
			}
			var thread = message.Thread;
			var forum = await _cache.GetForumAsync(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

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
		public async Task<ActionResult> Add(int threadId = 0, int messageIdToQuote=0)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var (userMayAddMessages, thread) = await PerformAddMessageSecurityChecksAsync(threadId);
			if(!userMayAddMessages)
			{
				return RedirectToAction("Index", "Home");
			}
			MessageEntity messageToQuote = null;
			UserEntity userOfMessageToQuote = null;
			if(messageIdToQuote > 0)
			{
				messageToQuote = await MessageGuiHelper.GetMessageAsync(messageIdToQuote);
				if(messageToQuote == null || messageToQuote.ThreadID!=threadId)
				{
					// doesn't exist, or is in another thread, ignore.
					return RedirectToAction("Index", "Home");
				}
				userOfMessageToQuote = await UserGuiHelper.GetUserAsync(messageToQuote.PostedByUserID);
				if(userOfMessageToQuote == null)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			var forum = await _cache.GetForumAsync(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}
			string messageTextForEditor = messageToQuote == null ? string.Empty
																 : string.Format("@quote {0}{1}{2}{1}@end{1}", userOfMessageToQuote.NickName, Environment.NewLine, 
																				 messageToQuote.MessageText);
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
		public async Task<ActionResult> Add([Bind(nameof(MessageData.MessageText), nameof(MessageData.Subscribe))] MessageData messageData, string submitButton, 
											int threadId = 0)
		{
			if(submitButton != "Post")
			{
				return threadId <= 0 ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Thread", new { id = threadId });
			}

			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			var (userMayAddMessages, thread) = await PerformAddMessageSecurityChecksAsync(threadId);
			if(!userMayAddMessages)
			{
				return RedirectToAction("Index", "Home");
			}
			int newMessageId = 0;
			if(submitButton == "Post")
			{
				// allowed, proceed
				// parse message text to html
				var messageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(messageData.MessageText, ApplicationAdapter.GetEmojiFilenamesPerName(), 
																			ApplicationAdapter.GetSmileyMappings());
				var systemData = await _cache.GetSystemDataAsync();
				newMessageId = await ThreadManager.CreateNewMessageInThreadAsync(threadId, this.HttpContext.Session.GetUserID(), messageData.MessageText, messageAsHtml,
																				 this.HttpContext.Connection.RemoteIpAddress.ToString(), messageData.Subscribe, 
																				 ApplicationAdapter.GetEmailData(this.Request.Host.Host, 
																												 EmailTemplate.ThreadUpdatedNotification),
																				 systemData.SendReplyNotifications);
				ApplicationAdapter.InvalidateCachedNumberOfThreadsInSupportQueues();
				if(this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditNewMessage))
				{
					await SecurityManager.AuditNewMessageAsync(this.HttpContext.Session.GetUserID(), newMessageId);
				}
			}
			return await CalculateRedirectToMessageAsync(thread.ThreadID, newMessageId);
		}
		
		
		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> Edit([Bind(nameof(MessageData.MessageText))] MessageData messageData, string submitButton, int id = 0)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			var (userMayEditMessages, message) = await PerformEditMessageSecurityChecksAsync(id);
			if(!userMayEditMessages)
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitButton == "Post")
			{
				// parse message text to html
				var messageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(messageData.MessageText, ApplicationAdapter.GetEmojiFilenamesPerName(), 
																			ApplicationAdapter.GetSmileyMappings());
				await MessageManager.UpdateEditedMessageAsync(this.HttpContext.Session.GetUserID(), message.MessageID, messageData.MessageText, messageAsHtml,
															  this.Request.Host.Host, string.Empty);
				if(this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditAlteredMessage))
				{
					await SecurityManager.AuditAlteredMessageAsync(this.HttpContext.Session.GetUserID(), message.MessageID);
				}
			}
			return await CalculateRedirectToMessageAsync(message.ThreadID, message.MessageID);
		}


		private async Task<(bool userMayEditMessages, MessageEntity message)> PerformEditMessageSecurityChecksAsync(int id)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return (false, null);
			}
			var message = await MessageGuiHelper.GetMessageAsync(id, prefetchThread:true);
			if(message == null)
			{
				return (false, null);
			}
			var thread = message.Thread;
			if(thread == null)
			{
				return (false, null);
			}
			if(!this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return (false, null);
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
			if(thread.StartedByUserID != this.HttpContext.Session.GetUserID() &&
			   !this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers))
			{
				// can't edit this message, it's in a thread which isn't visible to the user
				userMayEditMessages = false;
			}
			return (userMayEditMessages, message);
		}


		private async Task<(bool userMayAddMessages, ThreadEntity thread)> PerformAddMessageSecurityChecksAsync(int threadId)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return (false, null);
			}
			var thread = await ThreadGuiHelper.GetThreadAsync(threadId);
			if(thread == null)
			{
				return (false, null);
			}
			if(!this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return (false, null);
			}
			var userMayAddMessages = false;
			if(!thread.IsClosed)
			{
				userMayAddMessages = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID,
																						 thread.IsSticky ? ActionRights.AddAndEditMessageInSticky 
																										 : ActionRights.AddAndEditMessage);
			}

			// check if the user can view the thread the message is in. If not, don't continue.
			if(thread.StartedByUserID != this.HttpContext.Session.GetUserID() &&
			   !this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers))
			{
				// can't edit this message, it's in a thread which isn't visible to the user
				userMayAddMessages = false;
			}
			return (userMayAddMessages, thread);
		}
		

		/// <summary>
		/// Calculates the redirect to message with the id specified. This is a response to the index action on the thread controller, with the proper page and '#' id redirect.
		/// </summary>
		/// <param name="threadId">The thread identifier.</param>
		/// <param name="messageId">The message identifier.</param>
		/// <returns></returns>
		private async Task<ActionResult> CalculateRedirectToMessageAsync(int threadId, int messageId)
		{
			var maxAmountMessagesPerPage = this.HttpContext.Session.GetUserDefaultNumberOfMessagesPerPage();
			var idOfStartMessage = await ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThreadAsync(threadId, messageId, maxAmountMessagesPerPage);
			int startAtMessageNo = messageId > 0 ? idOfStartMessage : 0;
			int currentPageNo = (startAtMessageNo / maxAmountMessagesPerPage) + 1;
			return Redirect(this.Url.Action("Index", "Thread", new { threadId = threadId, pageNo = currentPageNo }) + "#" + messageId);
		}
	}
}