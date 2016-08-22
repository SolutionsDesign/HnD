using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
    public class ForumController : Controller
    {
		[HttpGet]
        public ActionResult Index(int id=0, int pageNo=1)
        {
			// do forum security checks on authorized user.
			bool userHasAccess = LoggedInUserAdapter.CanPerformForumActionRight(id, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				return RedirectToAction("Index", "Home");
			}

	        var forum = CacheManager.GetForum(id);
	        if(forum == null)
	        {
				return RedirectToAction("Index", "Home");
	        }

	        var pageNoToUse = pageNo >= 0 ? pageNo : 1;
	        var pageSize = CacheManager.GetSystemData().MinNumberOfThreadsToFetch;
	        var data = new ForumData
					   {
						   ForumDescription = forum.ForumDescription, 
						   ForumID = id, 
						   ForumName = forum.ForumName, 
						   HasRSSFeed = forum.HasRSSFeed,
						   PageNo = pageNoToUse,
						   SectionName = CacheManager.GetSectionName(forum.SectionID),
						   PageSize = pageSize, 
						   UserCanCreateThreads = (LoggedInUserAdapter.CanPerformForumActionRight(id, ActionRights.AddNormalThread) ||
													LoggedInUserAdapter.CanPerformForumActionRight(id, ActionRights.AddStickyThread)),
						   UserLastVisitDate = LoggedInUserAdapter.GetLastVisitDate(),
						   ThreadRows = ForumGuiHelper.GetAllThreadsInForumAggregatedData(id, pageNoToUse, pageSize,
																						   LoggedInUserAdapter.CanPerformForumActionRight(id, ActionRights.ViewNormalThreadsStartedByOthers),
																						   LoggedInUserAdapter.GetUserID())
					   };
	        return View(data);
        }
    }
}