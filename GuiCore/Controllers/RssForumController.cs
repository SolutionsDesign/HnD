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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for RSS Feed related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class RssForumController : Controller
	{
		private IMemoryCache _cache;


		public RssForumController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[HttpGet]
		public ActionResult IndexOldVersion(int forumId)
		{
			// We expect the ForumID as argument in the querystring. Typical URL is /RssForum/Old/?ForumID=10
			return RedirectToAction("Index", "RssForum", new {forumId = forumId});
		}


		[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60 * 10, VaryByQueryKeys = new[] {"forumId"})]
		public async Task<ActionResult> Index(int forumId = 0)
		{
			this.Response.ContentType = "text/xml";
			var forum = await _cache.GetForumAsync(forumId);
			if(forum == null)
			{
				return View();
			}

			var data = new RssForumData()
					   {
						   ForumUrl = "https://" + this.Request.Host.Host + ApplicationAdapter.GetVirtualRoot() + @"/Forum/" + forumId,
						   SiteName = ApplicationAdapter.GetSiteName(),
						   ForumName = forum.ForumName,
						   ForumItems = await ForumGuiHelper.GetLastPostedMessagesInForumAsync(10, forumId)
					   };
			return View(data);
		}
	}
}