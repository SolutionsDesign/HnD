using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.Gui.Models;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var model = new HomeData();
			BuildData(model);
			return View(model);
		}


		private void BuildData(HomeData model)
		{
			List<int> accessableForums = SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum);
			List<int> forumsWithThreadsFromOthers = SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers);
			var allSections = CacheManager.GetAllSections();
            model.ForumDataPerDisplayedSection = ForumGuiHelper.GetAllAvailableForumsAggregatedData(allSections, accessableForums, forumsWithThreadsFromOthers, SessionAdapter.GetUserID());

			// create a view on the sections to display and filter the view with a filter on sectionid: a sectionid must be part of the list of ids in the hashtable with per sectionid 
			// aggregate forum data. 
			model.SectionsFiltered = new EntityView<SectionEntity>(allSections, SectionFields.SectionID == model.ForumDataPerDisplayedSection.Keys.ToList());

			model.NickName = SessionAdapter.GetUserNickName();
			model.LastVisitedDateTime = SessionAdapter.GetLastVisitDate();
		}
	}
}