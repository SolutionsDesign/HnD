/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.TypedListClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Search related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
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
		public async Task<ActionResult> AdvancedSearch()
		{
			var allAccessibleForumIDs = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum).ToHashSet();
			var allForumsWithSectionNames = await ForumGuiHelper.GetAllForumsWithSectionNamesAsync();
			var viewData = new AdvancedSearchUIData()
						   {
							   NumberOfMessages = await MessageGuiHelper.GetTotalNumberOfMessagesAsync(),
							   AllAccessibleForumsWithSectionName = allForumsWithSectionNames.Where(r => allAccessibleForumIDs.Contains(r.ForumID)).ToList()
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
		public async Task<ActionResult> SearchAdvanced(AdvancedSearchModel searchData)
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
				forumsToSearch.AddRange(searchData.TargetForums.Where(f => allAccessibleForums.Contains(f)));
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

			await PerformSearchAsync(searchData.SearchParameters, forumsToSearch, firstSortClause, secondSortClause, searchTarget);
			return RedirectToAction("Results", "Search", new {pageNo = 1});
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> SearchAll([Bind] string searchParameters = "")
		{
			if(string.IsNullOrWhiteSpace(searchParameters))
			{
				return RedirectToAction("Index", "Home");
			}

			await PerformSearchAsync(searchParameters, this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum),
									 SearchResultsOrderSetting.LastPostDateDescending, SearchResultsOrderSetting.ForumAscending,
									 SearchTarget.MessageTextAndThreadSubject);

			return RedirectToAction("Results", "Search", new {pageNo = 1});
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> SearchForum(int forumId = 0, string searchParameters = "")
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

			var forum = await _cache.GetForumAsync(forumId);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

			await PerformSearchAsync(searchParameters, new List<int>() {forumId}, SearchResultsOrderSetting.LastPostDateDescending,
									 SearchResultsOrderSetting.ThreadSubjectAscending, SearchTarget.MessageTextAndThreadSubject);
			return RedirectToAction("Results", "Search", new {pageNo = 1});
		}


		[HttpGet]
		public async Task<ActionResult> SearchUnattended()
		{
			var forumIDs = this.Request.Query["ForumID"];
			var forumIDsToSearchIn = new List<int>();
			var allAccessibleForumIDs = this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum).ToHashSet();
			if(forumIDs.Count <= 0)
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

			string searchParameters = this.Request.Query["SearchTerms"]; // 'SearchTerms' is the URL argument used in older HnD versions, so we keep that.
			if(string.IsNullOrWhiteSpace(searchParameters))
			{
				return RedirectToAction("Index", "Home");
			}

			await PerformSearchAsync(searchParameters, forumIDsToSearchIn, SearchResultsOrderSetting.LastPostDateDescending,
									 SearchResultsOrderSetting.ThreadSubjectAscending, SearchTarget.MessageTextAndThreadSubject);
			return RedirectToAction("Results", "Search", new {pageNo = 1});
		}


		[HttpGet]
		public async Task<ActionResult> Results(int pageNo = 0)
		{
			if(pageNo < 1)
			{
				return RedirectToAction("Index", "Home");
			}

			var results = this.HttpContext.Session.GetSearchResults(_cache);
			if(results == null)
			{
				return RedirectToAction("Index", "Home");
			}

			var systemData = await _cache.GetSystemDataAsync();
			var pageSize = systemData.PageSizeSearchResults;
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
				rowsToShow.Add(results[((pageNo - 1) * pageSize) + i]);
			}

			var viewData = new SearchResultsData()
						   {
							   NumberOfPages = numberOfPages,
							   PageNo = pageNo,
							   PageRows = rowsToShow,
							   NumberOfResultRows = results.Count,
							   SearchParameters = this.HttpContext.Session.GetSearchTerms(_cache)
						   };
			return View(viewData);
		}


		[HttpGet]
		public ActionResult IgnoredSearchWords()
		{
			var viewData = new IgnoredSearchWordsData(ApplicationAdapter.GetNoiseWords());
			return View(viewData);
		}


		private async Task PerformSearchAsync(string searchParameters, List<int> forumIDs, SearchResultsOrderSetting orderFirstElement,
											  SearchResultsOrderSetting orderSecondElement, SearchTarget targetToSearch)
		{
			var searchTerms = searchParameters.Length > 1024 ? searchParameters.Substring(0, 1024) : searchParameters;
			var results = await Searcher.DoSearchAsync(searchTerms, forumIDs, orderFirstElement, orderSecondElement,
													   this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
													   this.HttpContext.Session.GetUserID(), targetToSearch);
			this.HttpContext.Session.AddSearchTermsAndResults(_cache, searchTerms, results);
		}
	}
}