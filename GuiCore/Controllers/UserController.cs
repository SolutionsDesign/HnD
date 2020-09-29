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
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Read / only user related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class UserController : Controller
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
			viewData.LastThreads = await UserGuiHelper.GetLastThreadsForUserAggregatedDataAsync(this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum), userId,
																		this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
																		this.HttpContext.Session.GetUserID(), 25);
			viewData.CurrentlyLoggedInUserID = this.HttpContext.Session.GetUserID();
			return View(viewData);
		}
	}
}