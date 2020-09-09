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
	/// Controller which exposes a WebAPI to be used with the jsGrid using views for sections.
	/// The methods in this controller therefore use the Http action as prefix.
	/// </summary>
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
		public ActionResult<IEnumerable<SectionDto>> GetSections()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var supportQueueDtos = SectionGuiHelper.GetAllSectionDtos();
			return Ok(supportQueueDtos);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult UpdateSection([FromBody] SectionDto toUpdate)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			var result = SectionManager.ModifySection(toUpdate);
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
		public ActionResult InsertSection([FromBody] SectionDto toInsert)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var sectionId = SectionManager.AddNewSection(toInsert);
			if(sectionId>0)
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
		public ActionResult DeleteSection(int id)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(id>0)
			{
				result = SectionManager.DeleteSection(id);
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
