using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
		public ActionResult Index()
		{
			var accessableForums = LoggedInUserAdapter.GetForumsWithActionRight(ActionRights.AccessForum);
			var forumsWithThreadsFromOthers = LoggedInUserAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers);
			var allSections = CacheManager.GetAllSections();
			var model = new HomeData();
			model.ForumDataPerDisplayedSection = ForumGuiHelper.GetAllAvailableForumsAggregatedData(allSections, accessableForums, forumsWithThreadsFromOthers, LoggedInUserAdapter.GetUserID());

			// create a view on the sections to display and filter the view with a filter on sectionid: a sectionid must be part of the list of ids in the hashtable with per sectionid 
			// aggregate forum data. 
			model.SectionsFiltered = new EntityView2<SectionEntity>(allSections, SectionFields.SectionID.In(model.ForumDataPerDisplayedSection.Keys.ToList()));

			model.NickName = LoggedInUserAdapter.GetUserNickName();
			model.UserLastVisitDate = LoggedInUserAdapter.GetLastVisitDate();
			return View(model);
		}
	}
}