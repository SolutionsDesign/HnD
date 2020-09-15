using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models.Admin;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for general system related administration actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class SystemAdminController : Controller
	{
		private IMemoryCache _cache;

		public SystemAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> SystemParameters()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new SystemParametersData()
					   {
						   AllRoles = await SecurityGuiHelper.GetAllRolesAsync(),
						   AllUserTitles = await UserGuiHelper.GetAllUserTitlesAsync(),
						   SystemData = await _cache.GetSystemDataAsync()
					   };
			return View("~/Views/Admin/SystemParameters.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> SystemParameters(SystemParametersData data, string submitAction)
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

			var systemData = await _cache.GetSystemDataAsync();
			var storeResult = await SystemManager.StoreNewSystemSettings(systemData.ID, data.SystemData.DefaultRoleNewUser, data.SystemData.AnonymousRole,
																		 data.SystemData.DefaultUserTitleNewUser, data.SystemData.HoursThresholdForActiveThreads,
																		 data.SystemData.PageSizeSearchResults, data.SystemData.MinNumberOfThreadsToFetch,
																		 data.SystemData.MinNumberOfNonStickyVisibleThreads, data.SystemData.SendReplyNotifications);
			if(storeResult)
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
		public async Task<ActionResult> ReparseMessages(string submitAction)
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