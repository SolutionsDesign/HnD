using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Read / only user related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class UserController :Controller
	{
		/// <summary>
		/// Views the user profile for the user with id specified
		/// </summary>
		/// <param name="userId">the user id for which the profile data has to be shown</param>
		/// <returns></returns>
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> ViewProfile(int userId = 0)
		{
			var userID = this.HttpContext.Session.GetUserID();
			if(userID <= 0 || userId == 0)
			{
				// not useful
				return RedirectToAction("Index", "Home");
			}
			var userProfileData = await UserGuiHelper.GetUserProfileInfoAsync(userId);
			if(userProfileData == null)
			{
				// not found
				return RedirectToAction("Index", "Home");
			}

			var viewData = new UserProfileData() {ProfileDataFromDatabase = userProfileData};
			viewData.AdminSectionIsVisible = this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement) ||
											 this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement) ||
											 this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement);
			viewData.UserHasSystemManagementRight = this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement);
			viewData.LastThreads = await UserGuiHelper.GetLastThreadsForUserAggregatedDataAsync(
															 this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum), userId, 
															 this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
															 this.HttpContext.Session.GetUserID(), 25);
			viewData.CurrentlyLoggedInUserID = this.HttpContext.Session.GetUserID(); 
			return View(viewData);
		}
	}
}