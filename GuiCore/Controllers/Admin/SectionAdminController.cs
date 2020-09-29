/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
    https://www.llblgen.com
	http:s//www.sd.nl

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

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for section related administration actions. This controller exposes a WebAPI to be used with the jsGrid using views for sections.
	/// The methods in this controller therefore use the Http action as prefix.
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class SectionAdminController : Controller
	{
		private IMemoryCache _cache;


		public SectionAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[HttpGet]
		[Authorize]
		public ActionResult ManageSections()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			return View("~/Views/Admin/Sections.cshtml");
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<SectionDto>>> GetSections()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var supportQueueDtos = await SectionGuiHelper.GetAllSectionDtosAsync();
			return Ok(supportQueueDtos);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> UpdateSection([FromBody] SectionDto toUpdate)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = await SectionManager.ModifySectionAsync(toUpdate);
			if(result)
			{
				_cache.Remove(CacheKeys.AllSections);
			}

			// jsGrid requires the updated object as return value.
			return Json(toUpdate);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> InsertSection([FromBody] SectionDto toInsert)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var sectionId = await SectionManager.AddNewSectionAsync(toInsert);
			if(sectionId > 0)
			{
				_cache.Remove(CacheKeys.AllSections);
				toInsert.SectionID = sectionId;
			}

			// jsGrid requires the inserted object as return value.
			return Json(toInsert);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteSection(int sectionId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(sectionId > 0)
			{
				result = await SectionManager.DeleteSectionAsync(sectionId);
				if(result)
				{
					_cache.Remove(CacheKeys.AllSections);
				}
			}

			if(result)
			{
				return Json(new {success = true});
			}

			return ValidationProblem("The section wasn't deleted. Likely because it contained one or more forums. First delete the forums, then delete the section.");
		}
	}
}