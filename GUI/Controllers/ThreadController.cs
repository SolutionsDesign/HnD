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
			var thread = ThreadGuiHelper.GetThread(id);
			if(thread == null)
			{
				// not found, return to start page
				return RedirectToAction("Index", "Home");
			}
			var forum = CacheManager.GetForum(thread.ForumID);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}
			// Check credentials
			bool userHasAccess = LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				return RedirectToAction("Index", "Home");
			}
			// check if the user can view this thread. If not, don't continue.
			if((thread.StartedByUserID != LoggedInUserAdapter.GetUserID()) && !LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!thread.IsSticky)
			{
				// can't view this thread, it isn't visible to the user
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