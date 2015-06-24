using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Gui.Models;
using SD.HnD.Utility;

namespace SD.HnD.Gui.Controllers
{
    public class ThreadController : Controller
    {
        public ActionResult Index(int id=0, int pageNo=1)
        {
	        ThreadEntity thread;
			var result = PerformSecurityCheck(id, out thread);
			if(result != null)
			{
				return result;
			}
			var forum = CacheManager.GetForum(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

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
								 ForumAllowsAttachments = (forum.MaxNoOfAttachmentsPerMessage > 0),
								 ThreadStartedByCurrentUser = thread.StartedByUserID == userID,
								 UserMayAddAttachments = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AddAttachment),
								 UserCanCreateThreads = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AddNormalThread) ||
														LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AddStickyThread),
								 UserMayDoForumSpecificThreadManagement = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ForumSpecificThreadManagement),
								 UserMayDoSystemWideThreadManagement = LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement),
								 UserMayEditMemo = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.EditThreadMemo),
								 UserMayMarkThreadAsDone = (LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.FlagThreadAsDone) || (thread.StartedByUserID==userID)),
								 UserMayManageSupportQueueContents = LoggedInUserAdapter.HasSystemActionRight(ActionRights.QueueContentManagement),
								 UserMayDoBasicThreadOperations = !LoggedInUserAdapter.IsAnonymousUser(),
								 ThreadIsBookmarked = UserGuiHelper.CheckIfThreadIsAlreadyBookmarked(userID, id),
								 ThreadIsSubscribed = UserGuiHelper.CheckIfThreadIsAlreadySubscribed(userID, id),
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


		public ActionResult ToggleSubscribe(int id = 0, int pageNo = 1)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, out thread);
			if(result != null)
			{
				return result;
			}
			var userID = LoggedInUserAdapter.GetUserID();
			if(LoggedInUserAdapter.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			if(UserGuiHelper.CheckIfThreadIsAlreadySubscribed(userID, id))
			{
				UserManager.RemoveSingleSubscription(id, userID);
			}
			else
			{
				UserManager.AddThreadToSubscriptions(id, userID, null);
			}
			return RedirectToAction("Index", "Thread", new { id = id, pageNo = pageNo });
		}


		public ActionResult ToggleBookmark(int id = 0, int pageNo = 1)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, out thread);
			if(result != null)
			{
				return result;
			}
			var userID = LoggedInUserAdapter.GetUserID();
			if(LoggedInUserAdapter.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			if(UserGuiHelper.CheckIfThreadIsAlreadyBookmarked(userID, id))
			{
				UserManager.RemoveSingleBookmark(id, userID);
			}
			else
			{
				UserManager.AddThreadToBookmarks(id, userID);
			}
			return RedirectToAction("Index", "Thread", new { id = id, pageNo = pageNo });
		}


		public ActionResult ToggleMarkAsDone(int id=0, int pageNo=1)
		{
			ThreadEntity thread;
			var result = PerformSecurityCheck(id, out thread);
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
			return RedirectToAction("Index", "Thread", new {id = id, pageNo = pageNo});
		}


		/// <summary>
		/// Performs the basic security check for the logged in user if that user has any access rights to this thread at all. It doesn't check specific thread actions. 
		/// </summary>
		/// <param name="id">the thread id</param>
		/// <param name="thread">the thread object related to id</param>
		/// <returns>An action result to redirect to if the current user shouldn't be here, otherwise null</returns>
	    private ActionResult PerformSecurityCheck(int id, out ThreadEntity thread)
	    {
			 thread = ThreadGuiHelper.GetThread(id);
			if(thread == null)
			{
				return RedirectToAction("Index", "Home");
			}
			if(!LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum))
			{
				return RedirectToAction("Index", "Home");
			}
			// check if the user can view this thread. If not, don't continue.
			if((thread.StartedByUserID != LoggedInUserAdapter.GetUserID()) && !LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
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
				string parserLog, messageTextXml;
				bool errorsOccured;
				container.MemoAsHTML = TextParser.TransformUBBMessageStringToHTML(container.Thread.Memo, ApplicationAdapter.GetParserData(), out parserLog, out errorsOccured, out messageTextXml);
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