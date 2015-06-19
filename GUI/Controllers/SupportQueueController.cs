using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;

namespace SD.HnD.Gui.Controllers
{
    public class SupportQueueController : Controller
    {
		[Authorize]
	    public ActionResult ClaimThread(int id, int pageNo)
	    {
			var result = PerformSecurityCheck(id);
			if(result != null)
			{
				return result;
			}
			SupportQueueManager.ClaimThread(LoggedInUserAdapter.GetUserID(), id);
			return RedirectToAction("Index", "Thread", new {id = id, pageNo=pageNo});
		}


		[Authorize]
		public ActionResult ReleaseThread(int id, int pageNo)
		{
			var result = PerformSecurityCheck(id);
			if(result != null)
			{
				return result;
			}
			SupportQueueManager.ReleaseClaimOnThread(id);
			return RedirectToAction("Index", "Thread", new { id = id, pageNo = pageNo });
		}


	    [Authorize]
	    public ActionResult MoveToQueue(int queueId=0, int id=0, int pageNo=1)
	    {
			var result = PerformSecurityCheck(id);
			if(result != null)
			{
				return result;
			}
			var containingQueue = SupportQueueGuiHelper.GetQueueOfThread(id);
			// now set the queue if: 
			// a) the thread isn't in a queue and the selected queueID > 0 (so not None)
			// b) the thread is in a queue and the selected queueuID isn't the id of the queue containing the thread
			if(((containingQueue == null) && (queueId > 0)) || ((containingQueue != null) && (containingQueue.QueueID != queueId)))
			{
				// Set the queue. if the new queue is 0, remove from queue.
				if(queueId > 0)
				{
					SupportQueueManager.AddThreadToQueue(id, queueId, LoggedInUserAdapter.GetUserID(), null);
				}
				else
				{
					SupportQueueManager.RemoveThreadFromQueue(id, null);
				}
			}
			return RedirectToAction("Index", "Thread", new { id = id, pageNo = pageNo });
		}


		/// <summary>
		/// Returns an action result if security check failed, otherwise it will return null.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
	    private ActionResult PerformSecurityCheck(int id)
	    {
			var thread = ThreadGuiHelper.GetThread(id);
			if(thread == null)
			{
				// not found, return to start page
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
			if(!LoggedInUserAdapter.HasSystemActionRight(ActionRights.QueueContentManagement))
			{
				return RedirectToAction("Index", "Home");
			}
		    return null;
	    }
    }
}