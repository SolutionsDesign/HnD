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
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Forum related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class ForumController : Controller
	{
		private IMemoryCache _cache;


		public ForumController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[HttpGet]
		public async Task<ActionResult> Index(int forumId = 0, int pageNo = 1)
		{
			// do forum security checks on authorized user.
			bool userHasAccess = this.HttpContext.Session.CanPerformForumActionRight(forumId, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				return RedirectToAction("Index", "Home");
			}

			var forum = await _cache.GetForumAsync(forumId);
			if(forum == null)
			{
				return RedirectToAction("Index", "Home");
			}

			var pageNoToUse = pageNo > 0 ? pageNo : 1;
			var systemData = await _cache.GetSystemDataAsync();
			var pageSize = systemData.MinNumberOfThreadsToFetch;
			var threadRows = await ForumGuiHelper.GetAllThreadsInForumAggregatedDataAsync(forumId, pageNoToUse, pageSize,
																						  this.HttpContext.Session.CanPerformForumActionRight(forumId,
																												ActionRights.ViewNormalThreadsStartedByOthers),
																						  this.HttpContext.Session.GetUserID());
			var data = new ForumData
					   {
						   ForumDescription = forum.ForumDescription,
						   ForumID = forumId,
						   ForumName = forum.ForumName,
						   HasRSSFeed = forum.HasRSSFeed,
						   PageNo = pageNoToUse,
						   SectionName = await _cache.GetSectionNameAsync(forum.SectionID),
						   PageSize = pageSize,
						   UserCanCreateThreads = this.HttpContext.Session.CanPerformForumActionRight(forumId, ActionRights.AddNormalThread) ||
												  this.HttpContext.Session.CanPerformForumActionRight(forumId, ActionRights.AddStickyThread),
						   UserLastVisitDate = this.HttpContext.Session.GetLastVisitDate(),
						   ThreadRows = threadRows,
					   };
			return View(data);
		}
	}
}