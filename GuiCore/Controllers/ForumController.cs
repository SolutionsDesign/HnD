using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
    public class ForumController : Controller
    {
		private IMemoryCache _cache;

		public ForumController(IMemoryCache cache)
		{
			_cache = cache;
		}

		
		[HttpGet]
        public async Task<ActionResult> Index(int id=0, int pageNo=1)
        {
			// do forum security checks on authorized user.
			bool userHasAccess = this.HttpContext.Session.CanPerformForumActionRight(id, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				return RedirectToAction("Index", "Home");
			}

	        var forum = _cache.GetForum(id);
	        if(forum == null)
	        {
				return RedirectToAction("Index", "Home");
	        }

	        var pageNoToUse = pageNo >= 0 ? pageNo : 1;
	        var pageSize = _cache.GetSystemData().MinNumberOfThreadsToFetch;
			var threadRows = await ForumGuiHelper.GetAllThreadsInForumAggregatedDataAsync(id, pageNoToUse, pageSize,
																					 this.HttpContext.Session.CanPerformForumActionRight(id, 
																									ActionRights.ViewNormalThreadsStartedByOthers),
																					 this.HttpContext.Session.GetUserID());
	        var data = new ForumData
					   {
						   ForumDescription = forum.ForumDescription, 
						   ForumID = id, 
						   ForumName = forum.ForumName, 
						   HasRSSFeed = forum.HasRSSFeed,
						   PageNo = pageNoToUse,
						   SectionName = _cache.GetSectionName(forum.SectionID),
						   PageSize = pageSize, 
						   UserCanCreateThreads = (this.HttpContext.Session.CanPerformForumActionRight(id, ActionRights.AddNormalThread) ||
												   this.HttpContext.Session.CanPerformForumActionRight(id, ActionRights.AddStickyThread)),
						   UserLastVisitDate = this.HttpContext.Session.GetLastVisitDate(),
						   ThreadRows = threadRows,
					   };
	        return View(data);
        }
    }
}