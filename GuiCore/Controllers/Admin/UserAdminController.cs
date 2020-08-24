using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Classes;
using SD.HnD.Gui.Models.Admin;

namespace SD.HnD.Gui.Controllers
{
	public class UserAdminController : Controller
	{
		private IMemoryCache _cache;

		public UserAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult BanUnbanUser()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			return GotoBanUnbanUserView(new BanUnbanUserData());
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult BanUnbanUser_Find(FindUserData data)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(!data.IsAnythingChecked)
			{
				return GotoBanUnbanUserView(new BanUnbanUserData());
			}
			
			data.FoundUsers = UserGuiHelper.FindUsers( data.FilterOnRole, data.SelectedRoleID, data.FilterOnNickName,
													   data.SpecifiedNickName, data.FilterOnEmailAddress,
													   data.SpecifiedEmailAddress);
			data.FindUserState = AdminFindUserState.UsersFound;
			data.ActionButtonText = "Ban / Unban selected user";
			data.ActionToPostTo = "BanUnbanUser_ToggleBanFlag";
			return GotoBanUnbanUserView(new BanUnbanUserData(data), "BanUnbanUser_UserSelected");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult BanUnbanUser_UserSelected(FindUserData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "SearchAgain")
			{
				return BanUnbanUser();
			}

			if(submitAction != "PerformAction")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.SelectedUserIDs==null || data.SelectedUserIDs.Count<=0)
			{
				return BanUnbanUser_Find(data);
			}
			
			data.FoundUsers = UserGuiHelper.FindUsers( data.FilterOnRole, data.SelectedRoleID, data.FilterOnNickName,
													  data.SpecifiedNickName, data.FilterOnEmailAddress,
													  data.SpecifiedEmailAddress);
			data.FindUserState = AdminFindUserState.UsersFound;
			data.ActionButtonText = "Ban / Unban selected user";
			data.ActionToPostTo = "BanUnbanUser_ToggleBanFlag";
			return GotoBanUnbanUserView(new BanUnbanUserData(data), "BanUnbanUser_UserSelected");
		}

		
		
		private ActionResult GotoBanUnbanUserView(BanUnbanUserData data, string actionName = "BanUnbanUser_Find")
		{
			data.FindUserData.ActionToPostTo = actionName;
			data.FindUserData.Roles = SecurityGuiHelper.GetAllRoles();
			return View("~/Views/Admin/BanUnbanUser.cshtml", data);
		}

	}
}