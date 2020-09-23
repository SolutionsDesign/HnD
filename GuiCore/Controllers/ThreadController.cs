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
	/// Controller for Forum Thread related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class ThreadController : Controller
	{
		private IMemoryCache _cache;

		public ThreadController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[HttpGet]
		public ActionResult IndexOldVersion(int threadID)
		{
			// We expect the ThreadID as argument in the querystring. Typical URL is /Thread/Old/?ThreadID=1012
			return RedirectToAction("Index", "Thread", new {id = threadID});
		}
		
		
		[HttpGet]
		public async Task<ActionResult> Index(int threadId = 0, int pageNo = 1)
		{
			var (result, thread) = await PerformSecurityCheckAsync(threadId, allowAnonymous:true);
			if(result != null)
			{
				return result;
			}
			var forum = await _cache.GetForumAsync(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}
			int pageNoToFetch = pageNo < 1 ? 1 : pageNo;
			var numberOfMessages = await ThreadGuiHelper.GetTotalNumberOfMessagesInThreadAsync(threadId);
			var numberOfMessagesPerPage = this.HttpContext.Session.GetUserDefaultNumberOfMessagesPerPage();
			var userID = this.HttpContext.Session.GetUserID();
			var threadData = new ThreadData()
			{
				Thread = thread,
				ForumName = forum.ForumName,
				SectionName = await _cache.GetSectionNameAsync(forum.SectionID),
				PageNo = pageNo,
				PageSize = numberOfMessagesPerPage,
				NumberOfPages = ((numberOfMessages - 1) / numberOfMessagesPerPage) + 1,
				ShowIPAddresses = (this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement) ||
								   this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement) ||
								   this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement)),
				ForumMaxNumberOfAttachmentsPerMessage = forum.MaxNoOfAttachmentsPerMessage,
				ThreadStartedByCurrentUser = thread.StartedByUserID == userID,
				UserMayAddAttachments = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AddAttachment),
				UserCanCreateThreads =  this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AddNormalThread) ||
									    this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AddStickyThread),
				UserCanApproveAttachments = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ApproveAttachment),
				UserMayDoForumSpecificThreadManagement = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ForumSpecificThreadManagement),
				UserMayDoSystemWideThreadManagement = this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement),
				UserMayEditMemo = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.EditThreadMemo),
				UserMayMarkThreadAsDone = (this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.FlagThreadAsDone) || (thread.StartedByUserID == userID)),
				UserMayManageSupportQueueContents = this.HttpContext.Session.HasSystemActionRight(ActionRights.QueueContentManagement),
				UserMayManageOtherUsersAttachments = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ManageOtherUsersAttachments),
				UserMayDoBasicThreadOperations = !this.HttpContext.Session.IsAnonymousUser(),
				ThreadIsBookmarked = await UserGuiHelper.CheckIfThreadIsAlreadyBookmarkedAsync(userID, threadId),
				ThreadIsSubscribed = await UserGuiHelper.CheckIfThreadIsAlreadySubscribedAsync(userID, threadId),
				ThreadMessages = await ThreadGuiHelper.GetAllMessagesInThreadAsDTOsAsync(threadId, pageNoToFetch, numberOfMessagesPerPage),
			};
			if(!thread.IsClosed)
			{
				threadData.UserMayAddNewMessages = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, thread.IsSticky 
																										   ? ActionRights.AddAndEditMessageInSticky
																										   : ActionRights.AddAndEditMessage);
				threadData.ShowEditMessageLink = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages);
			}
			await FillSupportQueueInformationAsync(threadData);
			FillMemoInformation(threadData);
			return View(threadData);
		}


		[HttpGet]
		public async Task<ActionResult> Active()
		{
			var systemData = await _cache.GetSystemDataAsync();
			var aggregatedActiveThreadsData = await ThreadGuiHelper.GetActiveThreadsAggregatedData(
																		   this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum),
																		   systemData?.HoursThresholdForActiveThreads ?? 0,
																		   this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), 
																		   this.HttpContext.Session.GetUserID());
			var viewData = new ThreadsData() {ThreadRows = aggregatedActiveThreadsData};
			return View(viewData);
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditProperties(ThreadPropertiesModel properties, int threadId = 0)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			var (result, thread) = await PerformSecurityCheckAsync(threadId, allowAnonymous:false);
			if(result != null)
			{
				return result;
			}
			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			await ThreadManager.ModifyThreadPropertiesAsync(threadId, properties.Subject, properties.IsSticky, properties.IsClosed);
			return RedirectToAction("Index", "Thread", new { threadId = threadId, pageNo = 1 });
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Move(int threadId = 0, int newSectionId = 0, int newForumId = 0)
		{
			var (result, thread) = await PerformSecurityCheckAsync(threadId, allowAnonymous:false);
			if(result != null)
			{
				return result;
			}
			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			if((newSectionId <= 0) || (newForumId <= 0))
			{
				return RedirectToAction("Index", "Home");
			}
			await ThreadManager.MoveThreadAsync(threadId, newForumId);
			return RedirectToAction("Index", "Thread", new { id = threadId, pageNo = 1 });
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id = 0)
		{
			var (result, thread) = await PerformSecurityCheckAsync(id, allowAnonymous:false);
			if(result != null)
			{
				return result;
			}
			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			int forumId = thread.ForumID;
			await ThreadManager.DeleteThreadAsync(id);
			return RedirectToAction("Index", "Forum", new { id = forumId });
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ToggleBookmark(int id = 0)
		{
			var (result, thread) = await PerformSecurityCheckAsync(id, allowAnonymous:false);
			if(result != null)
			{
				return Json(new { success = false });
			}
			var userID = this.HttpContext.Session.GetUserID();
			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return Json(new { success = false });
			}
			bool currentState = await UserGuiHelper.CheckIfThreadIsAlreadyBookmarkedAsync(userID, id);
			if(currentState)
			{
				await UserManager.RemoveSingleBookmarkAsync(id, userID);
			}
			else
			{
				await UserManager.AddThreadToBookmarksAsync(id, userID);
			}
			return Json(new {success = true, newstate = !currentState});
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ToggleSubscribe(int id = 0)
		{
			var (result, thread) = await PerformSecurityCheckAsync(id, allowAnonymous:false);
			if(result != null)
			{
				return Json(new {success = false});
			}
			var userID = this.HttpContext.Session.GetUserID();
			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return Json(new { success = false });
			}
			var currentState = await UserGuiHelper.CheckIfThreadIsAlreadySubscribedAsync(userID, id);
			if(currentState)
			{
				await UserManager.RemoveSingleSubscriptionAsync(id, userID);
			}
			else
			{
				await UserManager.AddThreadToSubscriptionsAsync(id, userID, null);
			}
			return Json(new { success = true, newstate = !currentState });
		}

		
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ToggleMarkAsDone(int threadId = 0, int pageNo = 1)
		{
			var (result, thread) = await PerformSecurityCheckAsync(threadId, allowAnonymous:false);
			if(result != null)
			{
				return result;
			}
			var userID = this.HttpContext.Session.GetUserID();
			if(!(this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.FlagThreadAsDone) || (thread.StartedByUserID == userID)))
			{
				return RedirectToAction("Index", "Home");
			}

			if(thread.MarkedAsDone)
			{
				await ThreadManager.UnMarkThreadAsDoneAsync(thread.ThreadID, userID);
			}
			else
			{
				await ThreadManager.MarkThreadAsDoneAsync(thread.ThreadID);
			}
			ApplicationAdapter.InvalidateCachedNumberOfThreadsInSupportQueues();
			return RedirectToAction("Index", "Thread", new { threadId = threadId, pageNo = pageNo });
		}

		
		[Authorize]
		[HttpGet]
		public async Task<ActionResult> Add(int forumId = 0)
		{
			var (userMayAddThread, forum, userMayAddStickyThread)  = await PerformAddThreadSecurityChecksAsync(forumId);
			if(!userMayAddThread)
			{
				return RedirectToAction("Index", "Home");
			}
			var newThreadData = new NewThreadData()
			{
				CurrentUserID = this.HttpContext.Session.GetUserID(),
				ForumID = forumId,
				ForumName = forum.ForumName,
				SectionName = await _cache.GetSectionNameAsync(forum.SectionID),
				ThreadSubject = string.Empty,
				MessageText = string.Empty,
				UserCanAddStickyThread = userMayAddStickyThread,
				NewThreadWelcomeTextAsHTML = forum.NewThreadWelcomeTextAsHTML,
				Subscribe = this.HttpContext.Session.GetUserAutoSubscribeToThread(),
			};
			return View(newThreadData);
		}
		

		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> Add([Bind(nameof(NewThreadData.MessageText), nameof(NewThreadData.ThreadSubject), nameof(NewThreadData.IsSticky), 
				 							nameof(NewThreadData.Subscribe))] NewThreadData newThreadData, string submitButton, int forumId = 0)
		{
			if(submitButton != "Post")
			{
				// apparently canceled
				if(forumId <= 0)
				{
					return RedirectToAction("Index", "Home");
				}
				return RedirectToAction("Index", "Forum", new {id = forumId});
			}
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			var (userMayAddThread, forum, userMayAddStickThread) = await PerformAddThreadSecurityChecksAsync(forumId);
			if(!userMayAddThread)
			{
				return RedirectToAction("Index", "Home");
			}
			int newThreadId = 0;
			if(submitButton == "Post")
			{
				// allowed, proceed
				// parse message text to html
				var messageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(newThreadData.MessageText, ApplicationAdapter.GetEmojiFilenamesPerName(), 
																			ApplicationAdapter.GetSmileyMappings());
				var (newThreadIdFromCall, newMessageId) = await ForumManager.CreateNewThreadInForumAsync(forumId, this.HttpContext.Session.GetUserID(), 
																										 newThreadData.ThreadSubject, newThreadData.MessageText,
																										 messageAsHtml, userMayAddStickThread && newThreadData.IsSticky, 
																										 this.Request.Host.Host, forum.DefaultSupportQueueID, 
																										 newThreadData.Subscribe);
				newThreadId = newThreadIdFromCall;
				ApplicationAdapter.InvalidateCachedNumberOfThreadsInSupportQueues();
				if(this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditNewThread))
				{
					await SecurityManager.AuditNewThreadAsync(this.HttpContext.Session.GetUserID(), newThreadId);
				}
				_cache.Remove(CacheManager.ProduceCacheKey(CacheKeys.SingleForum, forumId));
			}
			return Redirect(this.Url.Action("Index", "Thread", new { threadId = newThreadId, pageNo = 1 }));
		}


		private async Task<(bool userMayAddThread, ForumEntity forum, bool userMayAddStickyThread)> PerformAddThreadSecurityChecksAsync(int forumId)
		{
			var forum = await _cache.GetForumAsync(forumId);
			if(forum == null)
			{
				return (false, null, false);
			}
			if(!this.HttpContext.Session.CanPerformForumActionRight(forumId, ActionRights.AccessForum))
			{
				return (false, null, false);
			}
			var userMayAddStickThread = this.HttpContext.Session.CanPerformForumActionRight(forumId, ActionRights.AddStickyThread);
			if(!(userMayAddStickThread || this.HttpContext.Session.CanPerformForumActionRight(forumId, ActionRights.AddNormalThread)))
			{
				return (false, null, false);
			}
			return (true, forum, userMayAddStickThread);
		}


		/// <summary>
		/// Performs the basic security check for the logged in user if that user has any access rights to this thread at all. It doesn't check specific thread actions. 
		/// </summary>
		/// <param name="threadId">the thread id</param>
		/// <param name="allowAnonymous">if set to true, anonymous users are allowed, otherwise they're denied access</param>
		/// <returns>A tuple with a redirectaction and the thread of the threadId specified.
		/// The redirectaction is set to an action result to redirect to if the current user shouldn't be here, otherwise null</returns>
		private async Task<(ActionResult redirectResult, ThreadEntity thread)> PerformSecurityCheckAsync(int threadId, bool allowAnonymous)
		{
			var thread = await ThreadGuiHelper.GetThreadAsync(threadId);
			if(thread == null || !allowAnonymous && this.HttpContext.Session.IsAnonymousUser() || 
			   !this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return (RedirectToAction("Index", "Home"), null);
			}
			// check if the user can view this thread. If not, don't continue.
			if((thread.StartedByUserID != this.HttpContext.Session.GetUserID()) &&
				!this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!thread.IsSticky)
			{
				return (RedirectToAction("Index", "Home"), null);
			}
			
			// All OK
			return (null, thread);
		}


		private void FillMemoInformation(ThreadData container)
		{
			if(container.UserMayEditMemo && (container.Thread.Memo.Length > 0))
			{
				// convert memo contents to HTML so it's displayed above the thread. 
				container.MemoAsHTML = HnDGeneralUtils.TransformMarkdownToHtml(container.Thread.Memo, ApplicationAdapter.GetEmojiFilenamesPerName(), 
																			   ApplicationAdapter.GetSmileyMappings());
			}
		}


		private async Task FillSupportQueueInformationAsync(ThreadData container)
		{
			if(!container.UserMayManageSupportQueueContents)
			{
				return;
			}
			// fill support queue management area with data.
			container.AllSupportQueues = (await _cache.GetAllSupportQueuesAsync()).ToList();
			container.ContainingSupportQueue = await SupportQueueGuiHelper.GetQueueOfThreadAsync(container.Thread.ThreadID);
			if(container.ContainingSupportQueue != null)
			{
				// get claim info
				container.SupportQueueThreadInfo = await SupportQueueGuiHelper.GetSupportQueueThreadInfoAsync(container.Thread.ThreadID, true);
			}
		}
	}
}