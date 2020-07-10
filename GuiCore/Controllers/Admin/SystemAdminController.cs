using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models.Admin;

namespace SD.HnD.Gui.Controllers
{
	public class SystemAdminController : Controller
	{
		private IMemoryCache _cache;

		public SystemAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult SystemParameters()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new SystemParametersData()
					   {
						   AllRoles = SecurityGuiHelper.GetAllRoles(),
						   AllUserTitles = UserGuiHelper.GetAllUserTitles(),
						   SystemData = _cache.GetSystemData()
					   };
			return View("~/Views/Admin/SystemParameters.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult SystemParameters(SystemParametersData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "cancel")
			{
				return RedirectToAction("Index", "Home");
			}
			
			if(!ModelState.IsValid)
			{
				return View("~/Views/Admin/SystemParameters.cshtml", data);
			}

			if(SystemManager.StoreNewSystemSettings(_cache.GetSystemData().ID, data.SystemData.DefaultRoleNewUser, data.SystemData.AnonymousRole,
													data.SystemData.DefaultUserTitleNewUser, data.SystemData.HoursThresholdForActiveThreads,
													data.SystemData.PageSizeSearchResults, data.SystemData.MinNumberOfThreadsToFetch,
													data.SystemData.MinNumberOfNonStickyVisibleThreads, data.SystemData.SendReplyNotifications))
			{
				_cache.Remove(CacheKeys.SystemData);
				data.Persisted = true;
			}
			return View("~/Views/Admin/SystemParameters.cshtml", data);
		}

		
		[HttpGet]
		[Authorize]
		public ActionResult ReparseMessages()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			
			var data = new ReparsingMessageData();
			data.Completed = false;
			
			return View("~/Views/Admin/ReparseMessages.cshtml", data);
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ReparseMessagesAsync(string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			
			if(submitAction == "cancel")
			{
				return RedirectToAction("Index", "Home");
			}
			
			var data = new ReparsingMessageData();
			Action<string> consoleLogger = s => Console.WriteLine(s); 
			data.NumberOfMessagesReparsed = await MessageManager.ReParseMessagesAsync(ApplicationAdapter.GetEmojiFilenamesPerName(), 
																					  ApplicationAdapter.GetSmileyMappings(), consoleLogger).ConfigureAwait(false);
			data.Completed = true;
			
			return View("~/Views/Admin/ReparseMessages.cshtml", data);
		}
	}
}