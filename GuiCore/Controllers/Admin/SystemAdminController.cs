using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Classes;
using SD.HnD.Gui.Models;
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
		public async Task<ActionResult> Init()
		{
			var (proceedWithInit, incorrectlyConfigured) = await ShouldPerformInitAsync(); 
			if(incorrectlyConfigured)
			{
				return Redirect("~/Error/1337");
			}

			if(proceedWithInit)
			{
				return View("~/Views/Admin/Init.cshtml");
			}
			// database is initialized already
			return RedirectToAction("Index", "Home");
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Init(InitData data)
		{
			var (proceedWithInit, incorrectlyConfigured) = await ShouldPerformInitAsync(); 
			if(incorrectlyConfigured)
			{
				return Redirect("~/Error/1337");
			}

			if(!proceedWithInit)
			{
				return RedirectToAction("Index", "Home");
			}

			if(!ModelState.IsValid)
			{
				return View("~/Views/Admin/Init.cshtml", data);
			}

			await SystemManager.Initialize(data.NewPassword, data.EmailAddress);
			return RedirectToAction("Index", "Home");
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
		

		private async Task<(bool proceedWithInit, bool incorrectlyConfigured)> ShouldPerformInitAsync()
		{
			bool proceedWithInit = false;
			bool incorrectlyConfigured = false;

			// check if there's an anonymous user in the database
			var anonymous = await UserGuiHelper.GetUserAsync(0); // use hardcoded 0 id.
			if(anonymous == null)
			{
				proceedWithInit = true;
			}
			else
			{
				if(anonymous.NickName != "Anonymous")
				{
					incorrectlyConfigured = true;
				}
			}

			if(proceedWithInit)
			{
				var admin = await UserGuiHelper.GetUserAsync(1); // use hardcoded 1 id.
				if(admin != null)
				{
					proceedWithInit = false;
					incorrectlyConfigured = true;	// anonymous wasn't there, but admin was... 
				}
			}

			return (proceedWithInit, incorrectlyConfigured);
		}
	}
}