using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.Gui.Models;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace SD.HnD.Gui.Controllers
{
	public class HomeController : Controller
	{
		private IMemoryCache _cache;
		
		public HomeController(IMemoryCache cache)
		{
			ArgumentVerifier.CantBeNull(cache, nameof(cache));
			_cache = cache;
		}
		
		
		[HttpGet]
		public async Task<ActionResult> Index()
		{
			var accessableForums = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum);
			var forumsWithThreadsFromOthers = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers);
			var allSections = _cache.GetAllSections();
			var model = new HomeData();
			model.ForumDataPerDisplayedSection = await ForumGuiHelper.GetAllAvailableForumsAggregatedData(allSections, accessableForums, forumsWithThreadsFromOthers, 
																										  this.HttpContext.Session.GetUserID());

			// create a view on the sections to display and filter the view with a filter on sectionid: a sectionid must be part of the list of ids in the hashtable with per sectionid 
			// aggregate forum data. 
			model.SectionsFiltered = new EntityView2<SectionEntity>(allSections, SectionFields.SectionID.In(model.ForumDataPerDisplayedSection.Keys.ToList()));

			model.NickName = this.HttpContext.Session.GetUserNickName();
			model.UserLastVisitDate = this.HttpContext.Session.GetLastVisitDate();
			model.IsAnonymousUser = this.HttpContext.Session.IsAnonymousUser();
			return View(model);
		}


		[HttpGet]
		public ActionResult TermsOfUsage()
		{
			return View();
		}
	}
}