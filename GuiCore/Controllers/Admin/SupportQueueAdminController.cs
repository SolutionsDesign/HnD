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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.Gui.Models.Admin;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for support queue related administration actions. The controller exposes a WebAPI to be used with the jsGrid using views for support queues.
	/// The methods in this controller therefore use the Http action as prefix.
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class SupportQueueAdminController : Controller
	{
		private IMemoryCache _cache;


		public SupportQueueAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[HttpGet]
		[Authorize]
		public ActionResult ManageSupportQueues()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			return View("~/Views/Admin/SupportQueues.cshtml");
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<SupportQueueDto>>> GetSupportQueues()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var supportQueueDtos = await SupportQueueGuiHelper.GetAllSupportQueueDTOsAsync();
			return Ok(supportQueueDtos);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> UpdateSupportQueue([FromBody] SupportQueueDto toUpdate)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = await SupportQueueManager.ModifySupportQueueAsync(toUpdate);
			if(result)
			{
				_cache.Remove(CacheKeys.AllSupportQueues);
			}

			// jsGrid requires the updated object as return value.
			return Json(toUpdate);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> InsertSupportQueue([FromBody] SupportQueueDto toInsert)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var queueId = await SupportQueueManager.CreateNewSupportQueueAsync(toInsert);
			if(queueId > 0)
			{
				_cache.Remove(CacheKeys.AllSupportQueues);
				toInsert.QueueID = queueId;
			}

			// jsGrid requires the inserted object as return value.
			return Json(toInsert);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteSupportQueue(int queueId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(queueId > 0)
			{
				result = await SupportQueueManager.DeleteSupportQueueAsync(queueId);
				if(result)
				{
					_cache.Remove(CacheKeys.AllSupportQueues);
				}
			}

			return Json(new {success = result});
		}
	}
}