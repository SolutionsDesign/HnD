using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.DALAdapter.TypedListClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	public class SearchController : Controller
	{
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SearchAll([Bind] string searchParameters="")
		{
			if(string.IsNullOrWhiteSpace(searchParameters))
			{
				return RedirectToAction("Index", "Home");
			}
			PerformSearch(searchParameters, ForumGuiHelper.GetAllForumIds(), SearchResultsOrderSetting.LastPostDateDescending, SearchResultsOrderSetting.ForumAscending, 
						  SearchTarget.MessageTextAndThreadSubject);

			return RedirectToAction("Results", "Search", new { pageNo = 1 });
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SearchForum(int forumId = 0, string searchParameters="")
		{
			if(string.IsNullOrWhiteSpace(searchParameters))
			{
				return RedirectToAction("Index", "Home");
			}
			var forum = CacheManager.GetForum(forumId);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}
			PerformSearch(searchParameters, new List<int>() { forumId}, SearchResultsOrderSetting.LastPostDateDescending, SearchResultsOrderSetting.ThreadSubjectAscending, 
						  SearchTarget.MessageTextAndThreadSubject);
			return RedirectToAction("Results", "Search", new { pageNo = 1 });
		}


		[HttpGet]
		public ActionResult Results(int pageNo = 0)
		{
			if(pageNo < 1)
			{
				return RedirectToAction("Index", "Home");
			}

			var results = SessionAdapter.GetSearchResults();
			if(results == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var pageSize = CacheManager.GetSystemData().PageSizeSearchResults;
			if(pageSize <= 0)
			{
				pageSize = 50;
			}
			int numberOfPages = (results.Count / pageSize);
			if(numberOfPages * pageSize < results.Count)
			{
				numberOfPages++;
			}
			var rowsToShow = new List<SearchResultRow>();
			for(int i = 0; (i < pageSize) && ((((pageNo - 1) * pageSize) + i) < results.Count); i++)
			{
				rowsToShow.Add(results[((pageNo-1)*pageSize) + i]);
			}
			var viewData = new SearchResultsData()
						   {
							   NumberOfPages = numberOfPages,
							   PageNo = pageNo,
							   PageRows = rowsToShow,
							   NumberOfResultRows = results.Count,
							   SearchParameters = SessionAdapter.GetSearchTerms()
						   };
			return View(viewData);
		}


		private void PerformSearch(string searchParameters, List<int> forumIDs, SearchResultsOrderSetting orderFirstElement, SearchResultsOrderSetting orderSecondElement, 
								   SearchTarget targetToSearch)
		{
			var searchTerms = searchParameters.Length > 1024 ? searchParameters.Substring(0, 1024) : searchParameters;
			var results = Searcher.DoSearch(searchTerms, forumIDs, orderFirstElement, orderSecondElement,
										    LoggedInUserAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), LoggedInUserAdapter.GetUserID(), targetToSearch);
			SessionAdapter.AddSearchTermsAndResults(searchTerms, results);
		}
	}
}