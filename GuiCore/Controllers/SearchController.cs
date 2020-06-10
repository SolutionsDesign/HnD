using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.TypedListClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	public class SearchController : Controller
	{
		private IMemoryCache _cache;


		public SearchController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		/// <summary>
		/// Get method for the advanced search UI
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult AdvancedSearch()
		{
			var allAccessibleForumIDs = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum).ToHashSet();
			var viewData = new AdvancedSearchUIData()
						   {
							   NumberOfMessages = MessageGuiHelper.GetTotalNumberOfMessages(),
							   AllAccessibleForumsWithSectionName = ForumGuiHelper.GetAllForumsWithSectionNames().Where(r => allAccessibleForumIDs.Contains(r.ForumID)).ToList()
						   };
			return View(viewData);
		}


		/// <summary>
		/// post method for the advanced search. It's called 'SearchAdvanced' as the other search methods are called Search<i>method</i>.
		/// </summary>
		/// <param name="searchData"></param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SearchAdvanced([Bind("SearchParameters, SearchTarget, TargetForums, FirstSortClause, SecondSortClause")] AdvancedSearchModel searchData)
		{
			if(string.IsNullOrWhiteSpace(searchData.SearchParameters))
			{
				return RedirectToAction("Index", "Home");
			}
			var allAccessibleForums = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum).ToHashSet();
			var forumsToSearch = new List<int>();
			if(searchData.TargetForums == null || searchData.TargetForums.Count <= 0)
			{
				forumsToSearch.AddRange(allAccessibleForums);
			}
			else
			{
				forumsToSearch.AddRange(searchData.TargetForums.Where(f=>allAccessibleForums.Contains(f)));
			}
			var firstSortClause = SearchResultsOrderSetting.ForumAscending;
			if(!Enum.TryParse(searchData.FirstSortClause, out firstSortClause))
			{
				firstSortClause = SearchResultsOrderSetting.ForumAscending;
			}
			var secondSortClause = SearchResultsOrderSetting.LastPostDateAscending;
			if(!Enum.TryParse(searchData.SecondSortClause, out secondSortClause))
			{
				secondSortClause = SearchResultsOrderSetting.LastPostDateAscending;
			}
			var searchTarget = SearchTarget.MessageText;
			if(!Enum.TryParse(searchData.SearchTarget, out searchTarget))
			{
				searchTarget = SearchTarget.MessageText;
			}
			PerformSearch(searchData.SearchParameters, forumsToSearch, firstSortClause, secondSortClause, searchTarget);
			return RedirectToAction("Results", "Search", new { pageNo = 1 });
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SearchAll([Bind] string searchParameters="")
		{
			if(string.IsNullOrWhiteSpace(searchParameters))
			{
				return RedirectToAction("Index", "Home");
			}
			PerformSearch(searchParameters, this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum), 
						  SearchResultsOrderSetting.LastPostDateDescending, SearchResultsOrderSetting.ForumAscending, 
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
			var allAccessibleForums = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum).ToHashSet();
			if(!allAccessibleForums.Contains(forumId))
			{
				return RedirectToAction("Index", "Home");
			}
			var forum = _cache.GetForum(forumId);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}
			PerformSearch(searchParameters, new List<int>() { forumId}, SearchResultsOrderSetting.LastPostDateDescending, SearchResultsOrderSetting.ThreadSubjectAscending, 
						  SearchTarget.MessageTextAndThreadSubject);
			return RedirectToAction("Results", "Search", new { pageNo = 1 });
		}


		[HttpGet]
		public ActionResult SearchUnattended()
		{
			var forumIDs = this.Request.Query["ForumID"];
			var forumIDsToSearchIn = new List<int>();
			var allAccessibleForumIDs = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum).ToHashSet();
			if(forumIDs.Count<=0)
			{
				forumIDsToSearchIn.AddRange(allAccessibleForumIDs);
			}
			else
			{
				foreach(string forumIDAsString in forumIDs)
				{
					int forumID;
					if(!int.TryParse(forumIDAsString, out forumID))
					{
						return RedirectToAction("Index", "Home");
					}
					if(allAccessibleForumIDs.Contains(forumID))
					{
						forumIDsToSearchIn.Add(forumID);
					}
				}
			}
			string searchParameters = this.Request.Query["SearchTerms"];		// 'SearchTerms' is the URL argument used in older HnD versions, so we keep that.
			if(string.IsNullOrWhiteSpace(searchParameters))
			{
				return RedirectToAction("Index", "Home");
			}
			PerformSearch(searchParameters, forumIDsToSearchIn, SearchResultsOrderSetting.LastPostDateDescending, SearchResultsOrderSetting.ThreadSubjectAscending,
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
			var pageSize = _cache.GetSystemData().PageSizeSearchResults;
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


		[HttpGet]
		public ActionResult IgnoredSearchWords()
		{
			var viewData = new IgnoredSearchWordsData(ApplicationAdapter.GetNoiseWords());
			return View(viewData);
		}


		private void PerformSearch(string searchParameters, List<int> forumIDs, SearchResultsOrderSetting orderFirstElement, SearchResultsOrderSetting orderSecondElement, 
								   SearchTarget targetToSearch)
		{
			var searchTerms = searchParameters.Length > 1024 ? searchParameters.Substring(0, 1024) : searchParameters;
			var results = Searcher.DoSearch(searchTerms, forumIDs, orderFirstElement, orderSecondElement,
											this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), 
											this.HttpContext.Session.GetUserID(), targetToSearch);
			SessionAdapter.AddSearchTermsAndResults(searchTerms, results);
		}
	}
}