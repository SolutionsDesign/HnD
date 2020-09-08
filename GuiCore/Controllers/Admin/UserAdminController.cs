using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Classes;
using SD.HnD.Gui.Models;
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
		public ActionResult EditUserInfo()
		{
			return ActionWithUserSearch_Start(() => new ActionWithUserSearchData(), "EditUserInfo_Find", "~/Views/Admin/EditUserInfo_Search.cshtml");
		}

		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult EditUserInfo_Find(FindUserData data)
		{
			return ActionWithUserSearch_Find(data, "Manage profile", "EditUserInfo_UserSelected", "EditUserInfo_Find", "~/Views/Admin/EditUserInfo_Search.cshtml", false);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult EditUserInfo_UserSelected(FindUserData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "SearchAgain")
			{
				return EditUserInfo();
			}

			if(submitAction != "PerformAction")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.SelectedUserIDs==null || data.SelectedUserIDs.Count<=0)
			{
				return EditUserInfo_Find(data);
			}

			var user = UserGuiHelper.GetUser(data.SelectedUserIDs.FirstOrDefault());
			if(user == null)
			{
				// not found
				return RedirectToAction("Index", "Home");
			}

			var newData = new EditUserInfoData()
					   {
						   UserId = user.UserID,
						   EmailAddress = user.EmailAddress,
						   NickName = user.NickName,
						   DateOfBirth = user.DateOfBirth,
						   Occupation = user.Occupation ?? string.Empty,
						   Location = user.Location ?? string.Empty,
						   Signature = user.Signature ?? string.Empty,
						   Website = user.Website ?? string.Empty,
						   IconURL = user.IconURL ?? string.Empty,
						   UserTitleId = user.UserTitleID,
						   IPAddress = user.IPNumber,
						   LastVisitDate = user.LastVisitedDate.HasValue ? user.LastVisitedDate.Value.ToString("f") : "Never",
						   UserTitles = UserGuiHelper.GetAllUserTitles(),
					   };
			newData.Sanitize();
			return View("~/Views/Admin/EditUserInfo.cshtml", newData);
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult EditUserInfo_FinalAction(EditUserInfoData data)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			data.UserTitles = UserGuiHelper.GetAllUserTitles();

			if(!ModelState.IsValid)
			{
				return View("~/Views/Admin/EditUserInfo.cshtml", data);
			}
			data.Sanitize();
			data.StripProtocolsFromUrls();
			bool result = false;
			var user = UserGuiHelper.GetUser(data.UserId);
			if(user != null)
			{
				result = UserManager.UpdateUserProfile(data.UserId, data.DateOfBirth, data.EmailAddress, user.EmailAddressIsPublic ?? false, data.IconURL, 
													   data.Location, data.Occupation, data.NewPassword, data.Signature, data.Website, data.UserTitleId,
													   user.AutoSubscribeToThread, user.DefaultNumberOfMessagesPerPage);
			}

			data.InfoEdited = result;
			return View("~/Views/Admin/EditUserInfo.cshtml", data);
		}
				
		
		[HttpGet]
		[Authorize]
		public ActionResult DeleteUser()
		{
			return ActionWithUserSearch_Start(() => new ActionWithUserSearchData(), "DeleteUser_Find", "~/Views/Admin/DeleteUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteUser_Find(FindUserData data)
		{
			return ActionWithUserSearch_Find(data, "Delete selected user", "DeleteUser_UserSelected", "DeleteUser_Find", "~/Views/Admin/DeleteUser.cshtml", true);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteUser_UserSelected(FindUserData data, string submitAction)
		{
			return ActionWithUserSearch_UserSelected(data, submitAction, () => DeleteUser(), (d) => DeleteUser_Find(data), "DeleteUser_Perform", "~/Views/Admin/DeleteUser.cshtml");
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteUser_Perform(FindUserData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction != "Delete")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.SelectedUserIDs==null || data.SelectedUserIDs.Count<=0)
			{
				return DeleteUser_Find(data);
			}

			int userIdToDelete = data.SelectedUserIDs.FirstOrDefault();
			var user = UserGuiHelper.GetUser(userIdToDelete);
			bool result = UserManager.DeleteUser(userIdToDelete);
			if(result)
			{
				ApplicationAdapter.AddUserToListToBeLoggedOutByForce(user.NickName);
			}
			FillUserDataForState(data, AdminFindUserState.PostAction, string.Empty, string.Empty);
			var viewData = new ActionWithUserSearchData(data);
			viewData.FinalActionResult = result ? "The user has been deleted" : "Deleting the user failed, perhaps you selected a user that couldn't be deleted?";

			return View("~/Views/Admin/DeleteUser.cshtml", viewData);
		}
				
		
		[HttpGet]
		[Authorize]
		public ActionResult ShowAuditInfoUser()
		{
			return ActionWithUserSearch_Start(() => new ActionWithUserSearchData(), "ShowAuditInfoUser_Find", "~/Views/Admin/ShowAuditInfoUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult ShowAuditInfoUser_Find(FindUserData data)
		{
			return ActionWithUserSearch_Find(data, "View audit info", "ShowAuditInfoUser_UserSelected", "ShowAuditInfoUser_Find", "~/Views/Admin/ShowAuditInfoUser.cshtml", false);
		}

		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult ShowAuditInfoUser_UserSelected(FindUserData data, string submitAction, string filterAsString, string foundUserIds)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "SearchAgain")
			{
				return ShowAuditInfoUser();
			}

			if(submitAction != "PerformAction")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.SelectedUserIDs==null || data.SelectedUserIDs.Count<=0 || string.IsNullOrWhiteSpace(foundUserIds))
			{
				return ShowAuditInfoUser_Find(data);
			}

			int selectedUserId = data.SelectedUserIDs.FirstOrDefault();
			var auditDataForView = new ShowAuditInfoUserData(data);
			auditDataForView.AuditData = SecurityGuiHelper.GetAllAuditsForUser(selectedUserId);
			auditDataForView.AuditedUser = UserGuiHelper.GetUser(selectedUserId);
			data.OverrideFilterAsString(filterAsString);
			// we'll keep the search form open so we can quickly view data of multiple users without searching again. This means we'll keep the finduserdata state
			// as it is, as this is the end state of this action anyway.
			data.ActionButtonText = "View audit info";
			data.FindUserState = AdminFindUserState.UsersFound;
			var userIDsFoundAsString = foundUserIds.Split(',');
			var userIDsOfUsersToLoad = userIDsFoundAsString.Select(us => Convert.ToInt32(us)).ToList();
			data.FoundUsers = UserGuiHelper.GetUsers(userIDsOfUsersToLoad);
			return View("~/Views/Admin/ShowAuditInfoUser.cshtml", auditDataForView);
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult BanUnbanUser()
		{
			return ActionWithUserSearch_Start(() => new ActionWithUserSearchData(), "BanUnbanUser_Find", "~/Views/Admin/BanUnbanUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult BanUnbanUser_Find(FindUserData data)
		{
			return ActionWithUserSearch_Find(data, "Ban / Unban selected user", "BanUnbanUser_UserSelected", "BanUnbanUser_Find", "~/Views/Admin/BanUnbanUser.cshtml", true);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult BanUnbanUser_UserSelected(FindUserData data, string submitAction)
		{
			return ActionWithUserSearch_UserSelected(data, submitAction, () => BanUnbanUser(), (d) => BanUnbanUser_Find(data), "BanUnbanUser_Perform", "~/Views/Admin/BanUnbanUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult BanUnbanUser_Perform(FindUserData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction != "ToggleBanFlag")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.SelectedUserIDs==null || data.SelectedUserIDs.Count<=0)
			{
				return BanUnbanUser_Find(data);
			}

			int userIdToToggleBanFlagOf = data.SelectedUserIDs.FirstOrDefault();
			bool result = UserManager.ToggleBanFlagValue(userIdToToggleBanFlagOf, out bool newBanFlagValue);
			if(newBanFlagValue)
			{
				var user = UserGuiHelper.GetUser(userIdToToggleBanFlagOf);
				ApplicationAdapter.AddUserToListToBeLoggedOutByForce(user.NickName);
			}
			FillUserDataForState(data, AdminFindUserState.PostAction, string.Empty, string.Empty);
			var viewData = new ActionWithUserSearchData(data);
			if(result)
			{
				viewData.FinalActionResult = newBanFlagValue ? "The user is now banned" : "The user has been unbanned";
			}
			else
			{
				viewData.FinalActionResult = "Toggling the ban flag failed.";
			}

			return View("~/Views/Admin/BanUnbanUser.cshtml", viewData);
		}


		private static void FillUserDataForState(FindUserData data, AdminFindUserState stateToFillDataFor, string actionButtonText, string actionToPostTo)
		{
			data.Roles = SecurityGuiHelper.GetAllRoles();
			switch(stateToFillDataFor)
			{
				case AdminFindUserState.Start:
					// no-op
					break;
				case AdminFindUserState.UsersFound:
					data.FoundUsers = UserGuiHelper.FindUsers(data.FilterOnRole, data.SelectedRoleID, data.FilterOnNickName,
															  data.SpecifiedNickName, data.FilterOnEmailAddress,
															  data.SpecifiedEmailAddress);
					break;
				case AdminFindUserState.FinalAction:
				case AdminFindUserState.PostAction:
					data.SelectedUsers = UserGuiHelper.GetAllUsersInRange(data.SelectedUserIDs);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(stateToFillDataFor), stateToFillDataFor, null);
			}
			data.FindUserState = stateToFillDataFor;
			data.ActionButtonText = actionButtonText;
			data.ActionToPostTo = actionToPostTo;
		}
		

		private void FilterFoundUsers(FindUserData toFilter)
		{
			if(toFilter?.FoundUsers == null)
			{
				return;
			}
			// filter out the currently logged in user, admin (1) and anonymous (0)
			var loggedInUserId = this.HttpContext.Session.GetUserID();
			var toRemove = new List<UserEntity>();
			foreach(var e in toFilter.FoundUsers)
			{
				if(e.UserID < 2 || e.UserID == loggedInUserId)
				{
					toRemove.Add(e);
				}
			}
			foreach(var e in toRemove)
			{
				toFilter.FoundUsers.Remove(e);
			}
		}
		
		
		private ActionResult ActionWithUserSearch_Start(Func<ActionWithUserSearchData> dataCreatorFunc, string nextActionName, string viewName)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = dataCreatorFunc();
			FillUserDataForState(data.FindUserData, AdminFindUserState.Start, string.Empty, nextActionName);
			return View(viewName, data);
		}
		
		
		private ActionResult ActionWithUserSearch_Find(FindUserData data, string actionButtonText, string nextActionNameValidSearchData, 
														string nextActionNameInvalidSearchData, string viewName, bool filterOutFixedUsers)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.IsAnythingChecked)
			{
				FillUserDataForState(data, AdminFindUserState.UsersFound, actionButtonText, nextActionNameValidSearchData);
				if(filterOutFixedUsers)
				{
					// filter out the currently logged in user, Anonymous (0) and Admin (1)
					FilterFoundUsers(data);
				}
			}
			else
			{
				FillUserDataForState(data, AdminFindUserState.Start, string.Empty, nextActionNameInvalidSearchData);
			}
			return View(viewName, new ActionWithUserSearchData(data));
		}
		
		
		private ActionResult ActionWithUserSearch_UserSelected(FindUserData data, string submitAction, Func<ActionResult> actionSearchAgainFunc, 
																Func<FindUserData, ActionResult> actionNoneSelectedFunc, string nextActionName, string viewName)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "SearchAgain")
			{
				return actionSearchAgainFunc();
			}

			if(submitAction != "PerformAction")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.SelectedUserIDs==null || data.SelectedUserIDs.Count<=0)
			{
				return actionNoneSelectedFunc(data);
			}

			FillUserDataForState(data, AdminFindUserState.FinalAction, string.Empty, nextActionName);
			return View(viewName, new ActionWithUserSearchData(data));
		}
	}
}