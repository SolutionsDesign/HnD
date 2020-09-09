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
	/// Controller which exposes a WebAPI to be used with the jsGrid using views for support queues.
	/// The methods in this controller therefore use the Http action as prefix.
	/// </summary>
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
		public ActionResult<IEnumerable<SupportQueueDto>> GetSupportQueues()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var supportQueueDtos = SupportQueueGuiHelper.GetAllSupportQueueDTOs();
			return Ok(supportQueueDtos);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult UpdateSupportQueue([FromBody] SupportQueueDto toUpdate)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = SupportQueueManager.ModifySupportQueue(toUpdate);
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
		public ActionResult InsertSupportQueue([FromBody] SupportQueueDto toInsert)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var queueId = SupportQueueManager.CreateNewSupportQueue(toInsert);
			if(queueId>0)
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
		public ActionResult DeleteSupportQueue(int id)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(id>0)
			{
				result = SupportQueueManager.DeleteSupportQueue(id);
				if(result)
				{
					_cache.Remove(CacheKeys.AllSupportQueues);
				}
			}
			return Json(new {success=result});
		}
	}
}
