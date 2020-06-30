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
	public class UserController :Controller
	{
		/// <summary>
		/// Views the user profile for the user with id specified
		/// </summary>
		/// <param name="id">the user id for which the profile data has to be shown</param>
		/// <returns></returns>
		[HttpGet]
		[Authorize]
		public ActionResult ViewProfile(int id = 0)
		{
			var userProfileData = UserGuiHelper.GetUserProfileInfo(id);
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
			viewData.LastThreads = UserGuiHelper.GetLastThreadsForUserAggregatedData(
															 this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum),
															 id, this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
															 this.HttpContext.Session.GetUserID(), 25);
			return View(viewData);
		}


		[HttpGet]
		[Authorize]
		public ActionResult EditProfile()
		{
			var user = UserGuiHelper.GetUser(this.HttpContext.Session.GetUserID());
			if(user == null)
			{
				// not found
				return RedirectToAction("Index", "Home");
			}

			var data = new EditProfileData()
					   {
						   AutoSubscribeToThread = user.AutoSubscribeToThread,
						   EmailAddress = user.EmailAddress,
						   EmailAddressIsPublic = user.EmailAddressIsPublic ?? false,
						   NickName = user.NickName,
						   DateOfBirth = user.DateOfBirth,
						   Occupation = user.Occupation ?? string.Empty,
						   Location = user.Location ?? string.Empty,
						   Signature = user.Signature ?? string.Empty,
						   Website = user.Website ?? string.Empty,
						   IconURL = user.IconURL ?? string.Empty,
						   DefaultNumberOfMessagesPerPage = user.DefaultNumberOfMessagesPerPage
					   };
			data.Sanitize();
			return View(data);
		}


		[HttpPost]
		[Authorize]
		public ActionResult EditProfile([Bind("AutoSubscribeToThread", "EmailAddress", "EmailAddressIsPublic", "DateOfBirth", "Occupation", "Signature", "Website", 
											"IconURL", "Location", "DefaultNumberOfMessagesPerPage")] EditProfileData data)
		{
			var userID = this.HttpContext.Session.GetUserID();
			if(userID <= 0 )
			{
				// not found
				return RedirectToAction("Index", "Home");
			}
			if(!ModelState.IsValid)
			{
				return View(data);
			}
		
			data.Sanitize();
			data.StripProtocolsFromUrls();
			var result = UserManager.UpdateUserProfile(userID, data.DateOfBirth, data.EmailAddress, data.EmailAddressIsPublic, data.IconURL, data.Location,
													   data.Occupation, data.NewPassword, data.Signature, data.Website, this.HttpContext.Session.GetUserTitleID(), 
													   data.AutoSubscribeToThread, data.DefaultNumberOfMessagesPerPage);
			if(result)
			{
				return RedirectToAction("ViewProfile", "User", new {id = 2});
			}

			return View(data);
		}
	}
}