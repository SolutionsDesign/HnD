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
	/// <summary>
	/// Controller for user related administration actions. Many of the actions share a multi-step search wizard, using a shared partial view.  
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class UserAdminController : Controller
	{
		private IMemoryCache _cache;

		public UserAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> EditUserInfo()
		{
			return await ActionWithUserSearch_StartAsync(() => Task.FromResult(new ActionWithUserSearchData()), "EditUserInfo_Find", 
														 "~/Views/Admin/EditUserInfo_Search.cshtml");
		}

		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditUserInfo_Find(ActionWithUserSearchData data)
		{
			return await ActionWithUserSearch_FindAsync(d => Task.FromResult(new ActionWithUserSearchData(d)), data.FindUserData, "Manage profile", 
														"EditUserInfo_UserSelected", "EditUserInfo_Find", "~/Views/Admin/EditUserInfo_Search.cshtml", false);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditUserInfo_UserSelected(ActionWithUserSearchData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "SearchAgain")
			{
				return await EditUserInfo();
			}

			if(submitAction != "PerformAction")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.FindUserData.SelectedUserIDs==null || data.FindUserData.SelectedUserIDs.Count<=0)
			{
				return await EditUserInfo_Find(data);
			}

			var user = await UserGuiHelper.GetUserAsync(data.FindUserData.SelectedUserIDs.FirstOrDefault());
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
						   IsBanned = user.IsBanned,
						   RoleIDs = await SecurityGuiHelper.GetAllRoleIDsForUserAsync(user.UserID),
						   Roles = await SecurityGuiHelper.GetAllRolesAsync(),
						   UserTitles = await UserGuiHelper.GetAllUserTitlesAsync(),
					   };
			newData.Sanitize();
			return View("~/Views/Admin/EditUserInfo.cshtml", newData);
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditUserInfo_FinalAction(EditUserInfoData data)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			data.UserTitles = await UserGuiHelper.GetAllUserTitlesAsync();

			if(!ModelState.IsValid)
			{
				return View("~/Views/Admin/EditUserInfo.cshtml", data);
			}
			data.Sanitize();
			data.StripProtocolsFromUrls();
			bool result = false;
			var user = await UserGuiHelper.GetUserAsync(data.UserId);
			if(user != null)
			{
				result = await UserManager.UpdateUserProfileAsync(data.UserId, data.DateOfBirth, data.EmailAddress, user.EmailAddressIsPublic ?? false, data.IconURL,
																  data.Location, data.Occupation, data.NewPassword, data.Signature, data.Website, data.UserTitleId,
																  user.AutoSubscribeToThread, user.DefaultNumberOfMessagesPerPage, data.IsBanned, data.RoleIDs);
			}

			data.InfoEdited = result;
			return View("~/Views/Admin/EditUserInfo.cshtml", data);
		}
		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> AddUsersToRole(int id=0)
		{
			return await ActionWithUserSearch_StartAsync(async () => await CreateFilledAddUsersToRoleDataAsync(null, id), "AddUsersToRole_Find", 
														 "~/Views/Admin/AddUsersToRole.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddUsersToRole_Find(AddUsersToRoleData data)
		{
			return await ActionWithUserSearch_FindAsync(async d=> await CreateFilledAddUsersToRoleDataAsync(d, data.SelectedRoleID), data.FindUserData, 
														"Add selected users to role", "AddUsersToRole_UsersSelected", "AddUsersToRole_Find", 
														"~/Views/Admin/AddUsersToRole.cshtml", false, data.SelectedRoleID);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddUsersToRole_UsersSelected(AddUsersToRoleData data, string submitAction)
		{
			return await ActionWithUserSearch_UserSelectedAsync(async d=> await CreateFilledAddUsersToRoleDataAsync(d, data.SelectedRoleID), data.FindUserData, 
																submitAction, async () => await AddUsersToRole(data.SelectedRoleID), 
																async d => await AddUsersToRole_Find(data), "AddUsersToRole_Perform",
																"~/Views/Admin/AddUsersToRole.cshtml");
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddUsersToRole_Perform(AddUsersToRoleData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction != "Add")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.FindUserData.SelectedUserIDs==null || data.FindUserData.SelectedUserIDs.Count<=0)
			{
				return await AddUsersToRole_Find(data);
			}

			await SecurityManager.AddUsersToRoleAsync(data.FindUserData.SelectedUserIDs, data.SelectedRoleID);
			// simply redirect to manage users per role route
			return RedirectToRoute("ManageUsersPerRole");
		}

		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> DeleteUser()
		{
			return await ActionWithUserSearch_StartAsync(() => Task.FromResult(new ActionWithUserSearchData()), "DeleteUser_Find", "~/Views/Admin/DeleteUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteUser_Find(ActionWithUserSearchData data)
		{
			return await ActionWithUserSearch_FindAsync(d=>Task.FromResult(new ActionWithUserSearchData(d)), data.FindUserData, "Delete selected user", 
														"DeleteUser_UserSelected", "DeleteUser_Find", "~/Views/Admin/DeleteUser.cshtml", true);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteUser_UserSelected(ActionWithUserSearchData data, string submitAction)
		{
			return await ActionWithUserSearch_UserSelectedAsync(d=>Task.FromResult(new ActionWithUserSearchData(d)), data.FindUserData, submitAction, 
																async () => await DeleteUser(), async d => await DeleteUser_Find(data), "DeleteUser_Perform", 
																"~/Views/Admin/DeleteUser.cshtml");
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteUser_Perform(ActionWithUserSearchData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction != "Delete")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.FindUserData.SelectedUserIDs==null || data.FindUserData.SelectedUserIDs.Count<=0)
			{
				return await DeleteUser_Find(data);
			}

			int userIdToDelete = data.FindUserData.SelectedUserIDs.FirstOrDefault();
			var user = await UserGuiHelper.GetUserAsync(userIdToDelete);
			bool result = await UserManager.DeleteUserAsync(userIdToDelete);
			if(result)
			{
				ApplicationAdapter.AddUserToListToBeLoggedOutByForce(user.NickName);
			}
			await FillUserDataForStateAsync(data.FindUserData, AdminFindUserState.PostAction, string.Empty, string.Empty);
			var viewData = new ActionWithUserSearchData(data.FindUserData);
			viewData.FinalActionResult = result ? "The user has been deleted" : "Deleting the user failed, perhaps you selected a user that couldn't be deleted?";

			return View("~/Views/Admin/DeleteUser.cshtml", viewData);
		}
				
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> ShowAuditInfoUser()
		{
			return await ActionWithUserSearch_StartAsync(() => Task.FromResult(new ActionWithUserSearchData()), "ShowAuditInfoUser_Find", 
														 "~/Views/Admin/ShowAuditInfoUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ShowAuditInfoUser_Find(ActionWithUserSearchData data)
		{
			return await ActionWithUserSearch_FindAsync(d=>Task.FromResult(new ActionWithUserSearchData(d)), data.FindUserData, "View audit info", 
														"ShowAuditInfoUser_UserSelected", "ShowAuditInfoUser_Find", "~/Views/Admin/ShowAuditInfoUser.cshtml", false);
		}

		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ShowAuditInfoUser_UserSelected(ActionWithUserSearchData data, string submitAction, string filterAsString, string foundUserIds)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "SearchAgain")
			{
				return await ShowAuditInfoUser();
			}

			if(submitAction != "PerformAction")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.FindUserData.SelectedUserIDs==null || data.FindUserData.SelectedUserIDs.Count<=0 || string.IsNullOrWhiteSpace(foundUserIds))
			{
				return await ShowAuditInfoUser_Find(data);
			}

			int selectedUserId = data.FindUserData.SelectedUserIDs.FirstOrDefault();
			var auditDataForView = new ShowAuditInfoUserData(data.FindUserData)
								   {
									   AuditData = await SecurityGuiHelper.GetAllAuditsForUserAsync(selectedUserId), 
									   AuditedUser = await UserGuiHelper.GetUserAsync(selectedUserId)
								   };
			data.FindUserData.OverrideFilterAsString(filterAsString);
			// we'll keep the search form open so we can quickly view data of multiple users without searching again. This means we'll keep the finduserdata state
			// as it is, as this is the end state of this action anyway.
			data.FindUserData.ActionButtonText = "View audit info";
			data.FindUserData.FindUserState = AdminFindUserState.UsersFound;
			var userIDsFoundAsString = foundUserIds.Split(',');
			var userIDsOfUsersToLoad = userIDsFoundAsString.Select(us => Convert.ToInt32(us)).ToList();
			data.FindUserData.FoundUsers = await UserGuiHelper.GetUsersAsync(userIDsOfUsersToLoad);
			
			return View("~/Views/Admin/ShowAuditInfoUser.cshtml", auditDataForView);
		}
		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> BanUnbanUser()
		{
			return await ActionWithUserSearch_StartAsync(() => Task.FromResult(new ActionWithUserSearchData()), "BanUnbanUser_Find", "~/Views/Admin/BanUnbanUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> BanUnbanUser_Find(ActionWithUserSearchData data)
		{
			return await ActionWithUserSearch_FindAsync(d=>Task.FromResult(new ActionWithUserSearchData(d)), data.FindUserData, "Ban / Unban selected user", 
														"BanUnbanUser_UserSelected", "BanUnbanUser_Find", "~/Views/Admin/BanUnbanUser.cshtml", true);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> BanUnbanUser_UserSelected(ActionWithUserSearchData data, string submitAction)
		{
			return await ActionWithUserSearch_UserSelectedAsync(d=>Task.FromResult(new ActionWithUserSearchData(d)), data.FindUserData, submitAction, 
																async () => await BanUnbanUser(), async d => await BanUnbanUser_Find(data), 
																"BanUnbanUser_Perform", "~/Views/Admin/BanUnbanUser.cshtml");
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> BanUnbanUser_Perform(ActionWithUserSearchData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction != "ToggleBanFlag")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.FindUserData.SelectedUserIDs==null || data.FindUserData.SelectedUserIDs.Count<=0)
			{
				return await BanUnbanUser_Find(data);
			}

			int userIdToToggleBanFlagOf = data.FindUserData.SelectedUserIDs.FirstOrDefault();
			var (toggleResult, newBanFlagValue) = await UserManager.ToggleBanFlagValueAsync(userIdToToggleBanFlagOf);
			if(newBanFlagValue)
			{
				var user = await UserGuiHelper.GetUserAsync(userIdToToggleBanFlagOf);
				ApplicationAdapter.AddUserToListToBeLoggedOutByForce(user.NickName);
			}
			await FillUserDataForStateAsync(data.FindUserData, AdminFindUserState.PostAction, string.Empty, string.Empty);
			var viewData = new ActionWithUserSearchData(data.FindUserData);
			if(toggleResult)
			{
				viewData.FinalActionResult = newBanFlagValue ? "The user is now banned" : "The user has been unbanned";
			}
			else
			{
				viewData.FinalActionResult = "Toggling the ban flag failed.";
			}

			return View("~/Views/Admin/BanUnbanUser.cshtml", viewData);
		}


		private static async Task FillUserDataForStateAsync(FindUserData data, AdminFindUserState stateToFillDataFor, string actionButtonText, string actionToPostTo, 
															int roleIDWhichUsersToExclude=0 )
		{
			data.Roles = await SecurityGuiHelper.GetAllRolesAsync();
			switch(stateToFillDataFor)
			{
				case AdminFindUserState.Start:
					// no-op
					break;
				case AdminFindUserState.UsersFound:
					data.FoundUsers = await UserGuiHelper.FindUsers(data.FilterOnRole, data.SelectedRoleID, data.FilterOnNickName, data.SpecifiedNickName, 
																	data.FilterOnEmailAddress, data.SpecifiedEmailAddress, roleIDWhichUsersToExclude);
					break;
				case AdminFindUserState.FinalAction:
				case AdminFindUserState.PostAction:
					data.SelectedUsers = await UserGuiHelper.GetAllUsersInRangeAsync(data.SelectedUserIDs);
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
		
		
		private async Task<ActionResult> ActionWithUserSearch_StartAsync(Func<Task<ActionWithUserSearchData>> dataCreatorFunc, string nextActionName, string viewName)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = await dataCreatorFunc();
			await FillUserDataForStateAsync(data.FindUserData, AdminFindUserState.Start, string.Empty, nextActionName);
			return View(viewName, data);
		}
		
		
		private async Task<ActionResult> ActionWithUserSearch_FindAsync(Func<FindUserData, Task<ActionWithUserSearchData>> dataCreatorFunc, FindUserData data, 
																		string actionButtonText, string nextActionNameValidSearchData, 
																		string nextActionNameInvalidSearchData, string viewName, bool filterOutFixedUsers,
																		int roleIDWhichUsersToExclude=0)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.IsAnythingChecked)
			{
				await FillUserDataForStateAsync(data, AdminFindUserState.UsersFound, actionButtonText, nextActionNameValidSearchData, 
																	roleIDWhichUsersToExclude);
				if(filterOutFixedUsers)
				{
					// filter out the currently logged in user, Anonymous (0) and Admin (1)
					FilterFoundUsers(data);
				}
			}
			else
			{
				await FillUserDataForStateAsync(data, AdminFindUserState.Start, string.Empty, nextActionNameInvalidSearchData);
			}
			return View(viewName, await dataCreatorFunc(data));
		}
		
		
		private async Task<ActionResult> ActionWithUserSearch_UserSelectedAsync(Func<FindUserData, Task<ActionWithUserSearchData>> dataCreatorFunc, FindUserData data, 
																				string submitAction, Func<Task<ActionResult>> actionSearchAgainFunc, 
																				Func<FindUserData, Task<ActionResult>> actionNoneSelectedFunc, string nextActionName, 
																				string viewName)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "SearchAgain")
			{
				return await actionSearchAgainFunc();
			}

			if(submitAction != "PerformAction")
			{
				return RedirectToAction("Index", "Home");
			}

			if(data.SelectedUserIDs==null || data.SelectedUserIDs.Count<=0)
			{
				return await actionNoneSelectedFunc(data);
			}

			await FillUserDataForStateAsync(data, AdminFindUserState.FinalAction, string.Empty, nextActionName);
			return View(viewName, await dataCreatorFunc(data));
		}
		

		private async Task<AddUsersToRoleData> CreateFilledAddUsersToRoleDataAsync(FindUserData userData, int roleID)
		{
			var selectedRole = await SecurityGuiHelper.GetRoleAsync(roleID);
			return new AddUsersToRoleData(userData) { SelectedRoleDescription = selectedRole?.RoleDescription ?? string.Empty, SelectedRoleID = selectedRole?.RoleID ?? 0};
		}
	}
}