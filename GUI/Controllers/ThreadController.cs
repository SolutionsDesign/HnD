using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;
using SD.HnD.Utility;

namespace SD.HnD.Gui.Controllers
{
	public class ThreadController : Controller
	{
		[HttpGet]
		public ActionResult Index(int id = 0, int pageNo = 1)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, true, out thread);
			if(result != null)
			{
				return result;
			}
			var forum = CacheManager.GetForum(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}
			int pageNoToFetch = pageNo < 1 ? 1 : pageNo;
			var numberOfMessages = ThreadGuiHelper.GetTotalNumberOfMessagesInThread(id);
			var numberOfMessagesPerPage = LoggedInUserAdapter.GetUserDefaultNumberOfMessagesPerPage();
			var userID = LoggedInUserAdapter.GetUserID();
			var threadData = new ThreadData()
			{
				Thread = thread,
				ForumName = forum.ForumName,
				SectionName = CacheManager.GetSectionName(forum.SectionID),
				PageNo = pageNo,
				PageSize = numberOfMessagesPerPage,
				NumberOfPages = ((numberOfMessages - 1) / numberOfMessagesPerPage) + 1,
				ShowIPAddresses = (LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemManagement) ||
								   LoggedInUserAdapter.HasSystemActionRight(ActionRights.SecurityManagement) ||
								   LoggedInUserAdapter.HasSystemActionRight(ActionRights.UserManagement)),
				ForumMaxNumberOfAttachmentsPerMessage = forum.MaxNoOfAttachmentsPerMessage,
				ThreadStartedByCurrentUser = thread.StartedByUserID == userID,
				UserMayAddAttachments = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AddAttachment),
				UserCanCreateThreads = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AddNormalThread) ||
									   LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AddStickyThread),
				UserCanApproveAttachments = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ApproveAttachment),
				UserMayDoForumSpecificThreadManagement = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ForumSpecificThreadManagement),
				UserMayDoSystemWideThreadManagement = LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement),
				UserMayEditMemo = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.EditThreadMemo),
				UserMayMarkThreadAsDone = (LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.FlagThreadAsDone) || (thread.StartedByUserID == userID)),
				UserMayManageSupportQueueContents = LoggedInUserAdapter.HasSystemActionRight(ActionRights.QueueContentManagement),
				UserMayManageOtherUsersAttachments = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ManageOtherUsersAttachments),
				UserMayDoBasicThreadOperations = !LoggedInUserAdapter.IsAnonymousUser(),
				ThreadIsBookmarked = UserGuiHelper.CheckIfThreadIsAlreadyBookmarked(userID, id),
				ThreadIsSubscribed = UserGuiHelper.CheckIfThreadIsAlreadySubscribed(userID, id),
				ThreadMessages = ThreadGuiHelper.GetAllMessagesInThreadAsDTOs(id, pageNoToFetch, numberOfMessagesPerPage),
			};
			if(!thread.IsClosed)
			{
				threadData.UserMayAddNewMessages = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, thread.IsSticky ? ActionRights.AddAndEditMessageInSticky
																																  : ActionRights.AddAndEditMessage);
				threadData.ShowEditMessageLink = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages);
			}
			FillSupportQueueInformation(threadData);
			FillMemoInformation(threadData);
			return View(threadData);
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditProperties([Bind(Include = "Subject, IsSticky, IsClosed")] ThreadPropertiesModel properties, int id = 0)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, false, out thread);
			if(result != null)
			{
				return result;
			}
			if(!LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			ThreadManager.ModifyThreadProperties(id, properties.Subject, properties.IsSticky, properties.IsClosed);
			return RedirectToAction("Index", "Thread", new { id = id, pageNo = 1 });
		}



		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Move(int id = 0, int newSectionId = 0, int newForumId = 0)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, false, out thread);
			if(result != null)
			{
				return result;
			}
			if(!LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			if((newSectionId <= 0) || (newForumId <= 0))
			{
				return RedirectToAction("Index", "Home");
			}
			ThreadManager.MoveThread(id, newForumId);
			return RedirectToAction("Index", "Thread", new { id = id, pageNo = 1 });
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id = 0)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, false, out thread);
			if(result != null)
			{
				return result;
			}
			if(!LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			int forumId = thread.ForumID;
			ThreadManager.DeleteThread(id);
			return RedirectToAction("Index", "Forum", new { id = forumId });
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ToggleBookmark(int id = 0)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, false, out thread);
			if(result != null)
			{
				return Json(new { success = false });
			}
			var userID = LoggedInUserAdapter.GetUserID();
			if(!LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return Json(new { success = false });
			}
			bool currentState = UserGuiHelper.CheckIfThreadIsAlreadyBookmarked(userID, id);
			if(currentState)
			{
				UserManager.RemoveSingleBookmark(id, userID);
			}
			else
			{
				UserManager.AddThreadToBookmarks(id, userID);
			}
			return Json(new {success = true, newstate = !currentState});
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ToggleSubscribe(int id = 0)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, false, out thread);
			if(result != null)
			{
				return Json(new {success = false});
			}
			var userID = LoggedInUserAdapter.GetUserID();
			if(!LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement))
			{
				return Json(new { success = false });
			}
			var currentState = UserGuiHelper.CheckIfThreadIsAlreadySubscribed(userID, id);
			if(currentState)
			{
				UserManager.RemoveSingleSubscription(id, userID);
			}
			else
			{
				UserManager.AddThreadToSubscriptions(id, userID, null);
			}
			return Json(new { success = true, newstate = !currentState });
		}

		
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ToggleMarkAsDone(int id = 0, int pageNo = 1)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, false, out thread);
			if(result != null)
			{
				return result;
			}
			var userID = LoggedInUserAdapter.GetUserID();
			if(!(LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.FlagThreadAsDone) || (thread.StartedByUserID == userID)))
			{
				return RedirectToAction("Index", "Home");
			}

			if(thread.MarkedAsDone)
			{
				ThreadManager.UnMarkThreadAsDone(thread.ThreadID, userID);
			}
			else
			{
				ThreadManager.MarkThreadAsDone(thread.ThreadID);
			}
			return RedirectToAction("Index", "Thread", new { id = id, pageNo = pageNo });
		}

		[Authorize]
		[HttpGet]
		public ActionResult Add(int forumId = 0)
		{
			bool userMayAddStickThread = false;
			ForumEntity forum;
			var userMayAddThread = ThreadController.PerformAddThreadSecurityChecks(forumId, out forum, out userMayAddStickThread);
			if(!userMayAddThread)
			{
				return RedirectToAction("Index", "Home");
			}
			var newThreadData = new NewThreadData()
			{
				CurrentUserID = LoggedInUserAdapter.GetUserID(),
				ForumID = forumId,
				ForumName = forum.ForumName,
				SectionName = CacheManager.GetSectionName(forum.SectionID),
				ThreadSubject = string.Empty,
				MessageText = string.Empty,
				IsSticky = false,
				UserCanAddStickyThread = userMayAddStickThread,
				SubscribeToThread =  false,
				NewThreadWelcomeTextAsHTML = forum.NewThreadWelcomeTextAsHTML,
			};
			return View(newThreadData);
		}
		

		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Add([Bind(Include = "MessageText, ThreadSubject, IsSticky")] NewThreadData newThreadData, string submitButton, int forumId = 0)
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
			bool userMayAddStickThread = false;
			ForumEntity forum;
			var userMayAddThread = ThreadController.PerformAddThreadSecurityChecks(forumId, out forum, out userMayAddStickThread);
			if(!userMayAddThread)
			{
				return RedirectToAction("Index", "Home");
			}
			int newThreadId = 0;
			if(submitButton == "Post")
			{
				// allowed, proceed
				// parse message text to html
				var messageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(newThreadData.MessageText, ApplicationAdapter.GetEmojiFilenamesPerName(), ApplicationAdapter.GetSmileyMappings());
#warning IMPLEMENT SUBSCRIBING AND EMAILSENDING
				newThreadId = ForumManager.CreateNewThreadInForum(forumId, LoggedInUserAdapter.GetUserID(), newThreadData.ThreadSubject, newThreadData.MessageText, messageAsHtml, 
																  (userMayAddStickThread && newThreadData.IsSticky), Request.UserHostAddress, forum.DefaultSupportQueueID, 
																  false, out newThreadId);
				ApplicationAdapter.InvalidateCachedForumRSS(forumId);
				if(AuditingAdapter.CheckIfNeedsAuditing(AuditActions.AuditNewThread))
				{
					SecurityManager.AuditNewThread(LoggedInUserAdapter.GetUserID(), newThreadId);
				}
				CacheManager.InvalidateCachedItem(CacheManager.ProduceCacheKey(CacheKeys.SingleForum, forumId));
#warning IMPLEMENT ATTACHMENTS
			}
			return Redirect(this.Url.Action("Index", "Thread", new { id = newThreadId, pageNo = 1 }));
		}


		private static bool PerformAddThreadSecurityChecks(int forumId, out ForumEntity forum, out bool userMayAddStickThread)
		{
			userMayAddStickThread = false;
			forum = CacheManager.GetForum(forumId);
			if(forum == null)
			{
				return false;
			}
			if(!LoggedInUserAdapter.CanPerformForumActionRight(forumId, ActionRights.AccessForum))
			{
				return false;
			}
			userMayAddStickThread = LoggedInUserAdapter.CanPerformForumActionRight(forumId, ActionRights.AddStickyThread);
			if(!(userMayAddStickThread || LoggedInUserAdapter.CanPerformForumActionRight(forumId, ActionRights.AddNormalThread)))
			{
				return false;
			}
			return true;
		}


		/// <summary>
		/// Performs the basic security check for the logged in user if that user has any access rights to this thread at all. It doesn't check specific thread actions. 
		/// </summary>
		/// <param name="id">the thread id</param>
		/// <param name="allowAnonymous">if set to true, anonymous users are allowed, otherwise they're denied access</param>
		/// <param name="thread">the thread object related to id</param>
		/// <returns>An action result to redirect to if the current user shouldn't be here, otherwise null</returns>
		private ActionResult PerformSecurityCheck(int id, bool allowAnonymous, out ThreadEntity thread)
		{
			thread = ThreadGuiHelper.GetThread(id);
			if((thread == null) || (!allowAnonymous && LoggedInUserAdapter.IsAnonymousUser()) || !LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return RedirectToAction("Index", "Home");
			}
			// check if the user can view this thread. If not, don't continue.
			if((thread.StartedByUserID != LoggedInUserAdapter.GetUserID()) &&
				!LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!thread.IsSticky)
			{
				return RedirectToAction("Index", "Home");
			}
			return null;
		}


		private void FillMemoInformation(ThreadData container)
		{
			if(container.UserMayEditMemo && (container.Thread.Memo.Length > 0))
			{
				// convert memo contents to HTML so it's displayed above the thread. 
				container.MemoAsHTML = HnDGeneralUtils.TransformMarkdownToHtml(container.Thread.Memo, ApplicationAdapter.GetEmojiFilenamesPerName(), ApplicationAdapter.GetSmileyMappings());
			}
		}


		private void FillSupportQueueInformation(ThreadData container)
		{
			if(!container.UserMayManageSupportQueueContents)
			{
				return;
			}
			// fill support queue management area with data.
			container.AllSupportQueues = CacheManager.GetAllSupportQueues().ToList();
			container.ContainingSupportQueue = SupportQueueGuiHelper.GetQueueOfThread(container.Thread.ThreadID);
			if(container.ContainingSupportQueue != null)
			{
				// get claim info
				container.SupportQueueThreadInfo = SupportQueueGuiHelper.GetSupportQueueThreadInfo(container.Thread.ThreadID, true);
			}
		}
	}
}