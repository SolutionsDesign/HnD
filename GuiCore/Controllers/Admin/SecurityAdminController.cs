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
	public class SecurityAdminController : Controller
	{	
		private IMemoryCache _cache;
		
		public SecurityAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
						
		
		[HttpGet]
		[Authorize]
		public ActionResult IPBans()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			return View("~/Views/Admin/IPBans.cshtml");
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult<IEnumerable<SectionDto>> GetIPBans()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var ipBanDtos = SecurityGuiHelper.GetAllIPBanDTOs();
			return Ok(ipBanDtos);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult UpdateIPBan([FromBody] IPBanDto toUpdate)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			toUpdate.IPBanSetOn = DateTime.Now;
			var result = SecurityManager.ModifyIPBan(toUpdate);
			if(result)
			{
				_cache.Remove(CacheKeys.AllIPBans);
			}
			// jsGrid requires the updated object as return value.
			return Json(toUpdate);
		}
		
		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult InsertIPBan([FromBody] IPBanDto toInsert)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			toInsert.IPBanSetByUserID = this.HttpContext.Session.GetUserID();
			toInsert.IPBanSetOn = DateTime.Now;
			var ipBanId = SecurityManager.AddNewIPBan(toInsert);
			if(ipBanId>0)
			{
				_cache.Remove(CacheKeys.AllIPBans);
				toInsert.IPBanID = ipBanId;
			}
			// jsGrid requires the inserted object as return value.
			return Json(toInsert);
		}
		
		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteIPBan(int id)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(id>0)
			{
				result = SecurityManager.DeleteIPBan(id);
				if(result)
				{
					_cache.Remove(CacheKeys.AllIPBans);
				}
			}

			if(result)
			{
				return Json(new {success = true});
			}

			return ValidationProblem("The IPBan wasn't deleted.");
		}
	}
}
