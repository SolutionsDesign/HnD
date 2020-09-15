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
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for security related administration actions. The controller exposes a WebAPI to be used with the jsGrid using views for sections.
	/// The methods in this controller therefore use the Http action as prefix.
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class SecurityAdminController : Controller
	{	
		private IMemoryCache _cache;
		
		public SecurityAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}

		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> ManageRoleRights()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var allRoles = await SecurityGuiHelper.GetAllRolesAsync();
			var roleId = allRoles.FirstOrDefault()?.RoleID ?? 0;
			var allForumIds = await ForumGuiHelper.GetAllForumIdsAsync();
			var forumId = allForumIds.FirstOrDefault();
			return await ManageRightsForForum(new ManageForumRoleRightsData() {RoleID = roleId, ForumID = forumId});
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ManageRightsForForum(ManageForumRoleRightsData data, string submitAction="")
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			data.AvailableRoles = await SecurityGuiHelper.GetAllRolesAsync();
			data.AvailableActionRights = await SecurityGuiHelper.GetAllActionRightsApplybleToAForumAsync();
			data.AvailableForums = await ForumGuiHelper.GetAllForumsWithSectionNamesAsync();
			switch(submitAction)
			{
				case "save":
					// save the data, then after this action, it'll reload the data and show it.
					data.LastActionResult = await SecurityManager.SaveForumActionRightsForForumRoleAsync(data.ActionRightsSet, data.RoleID, data.ForumID) 
													? "Save successful" : "Save failed";
					break;
				case "cancel":
					return RedirectToAction("Index", "Home");
				default:
					// nothin'
					break;
			}
			// postback which should simply fill in the data and show the form
			var forumActionRightRolesForForumRole = await SecurityGuiHelper.GetForumActionRightRolesForForumRoleAsync(data.RoleID, data.ForumID);
			data.ActionRightsSet = forumActionRightRolesForForumRole.Select(r => r.ActionRightID).ToList();

			return View("~/Views/Admin/ManageRightsPerForum.cshtml", data);
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult> GetActionRights(int roleId, int forumId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var forumActionRightRolesForForumRole = await SecurityGuiHelper.GetForumActionRightRolesForForumRoleAsync(roleId, forumId);
			return Ok(forumActionRightRolesForForumRole.Select(r => r.ActionRightID).ToList());
		}

		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> ManageUsersPerRole()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new UsersInRolesData();
			data.AvailableRoles = await SecurityGuiHelper.GetAllRolesAsync();
			return View("~/Views/Admin/ManageUsersPerRole.cshtml", data);
		}
		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<SectionDto>>> GetUsersInRole(int roleId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var roleDtos = await UserGuiHelper.GetAllUserInRoleDtosForRoleAsync(roleId);
			return Ok(roleDtos);
		}
		
		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> RemoveUserFromRole([FromBody] RemoveUserFromRoleData data)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(data.RoleID > 0 && data.UserID > 0)
			{
				result = await SecurityManager.RemoveUserFromRoleAsync(data.RoleID, data.UserID);
			}

			if(result)
			{
				return Json(new {success = true});
			}
			return ValidationProblem("The user wasn't removed from the role.");
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult ManageRoles()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			return View("~/Views/Admin/Roles.cshtml");
		}
		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<SectionDto>>> GetRoles()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var roleDtos = await SecurityGuiHelper.GetAllRoleDtosAsync();
			return Ok(roleDtos);
		}
		

		[HttpGet]
		[Authorize]
		public async Task<ActionResult> EditRole(int roleId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new AddEditRoleData { RoleEdited = await SecurityGuiHelper.GetRoleAsync(roleId)};
			if(data.RoleEdited == null)
			{
				return RedirectToRoute("ManageRoles");
			}
			await FillAddEditRoleDataAsync(data);
			data.SystemRightsSet = SecurityGuiHelper.GetAllSystemActionRightIDsForRole(roleId);
			data.AuditActionsSet = SecurityGuiHelper.GetAllAuditActionIDsForRole(roleId);
			return View("~/Views/Admin/EditRole.cshtml", data);
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditRole(AddEditRoleData data, string submitAction, int roleId = 0)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			if(submitAction == "cancel" || roleId <= 0)
			{
				return RedirectToRoute("ManageRoles");
			}
			if(!ModelState.IsValid)
			{
				await FillAddEditRoleDataAsync(data);
				return View("~/Views/Admin/EditRole.cshtml", data);
			}
			try
			{
				var result = await SecurityManager.ModifyRoleAsync(roleId, data.RoleEdited.RoleDescription, data.SystemRightsSet, data.AuditActionsSet);
				if(!result)
				{
					ModelState.AddModelError(string.Empty, "Save failed.");
					await FillAddEditRoleDataAsync(data);
					return View("~/Views/Admin/EditRole.cshtml", data);
				}
			}
			catch(ORMQueryExecutionException)
			{
				ModelState.AddModelError("RoleEdited.RoleDescription", "Save failed, likely due to the role description not being unique. Please specify a unique role description name.");
				await FillAddEditRoleDataAsync(data);
				return View("~/Views/Admin/EditRole.cshtml", data);
			}
			return View("~/Views/Admin/Roles.cshtml", data);			
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult> AddRole()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new AddEditRoleData();
			await FillAddEditRoleDataAsync(data);
			return View("~/Views/Admin/AddRole.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddRole(AddEditRoleData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "cancel")
			{
				return RedirectToRoute("ManageRoles");
			}
			if(!ModelState.IsValid)
			{
				await FillAddEditRoleDataAsync(data);
				return View("~/Views/Admin/AddRole.cshtml", data);
			}

			try
			{
				await SecurityManager.CreateNewRoleAsync(data.RoleEdited.RoleDescription, data.SystemRightsSet, data.AuditActionsSet);
			}
			catch(ORMQueryExecutionException ex)
			{
				ModelState.AddModelError("RoleDescription", "Save failed, likely due to the role description not being unique. Please specify a unique role description name." + ex.Message);
				await FillAddEditRoleDataAsync(data);
				return View("~/Views/Admin/AddRole.cshtml", data);
			}
			return View("~/Views/Admin/Roles.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteRole(int roleId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(roleId>0)
			{
				// check if the role is set as a default role in system settings. If so, it's not deleted
				var systemSettings = await _cache.GetSystemDataAsync();
				if(systemSettings.AnonymousRole == roleId || systemSettings.DefaultRoleNewUser == roleId)
				{
					return ValidationProblem("The role wasn't deleted because it's a role that's set as a default in System Settings.");
				}

				result = await SecurityManager.DeleteRoleAsync(roleId);
			}

			if(result)
			{
				return Json(new {success = true});
			}

			return ValidationProblem("The role wasn't deleted.");
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult ManageIPBans()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			return View("~/Views/Admin/IPBans.cshtml");
		}
		
		
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<SectionDto>>> GetIPBans()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var ipBanDtos = await SecurityGuiHelper.GetAllIPBanDtosAsync();
			return Ok(ipBanDtos);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> UpdateIPBan([FromBody] IPBanDto toUpdate)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			toUpdate.IPBanSetOn = DateTime.Now;
			var result = await SecurityManager.ModifyIPBanAsync(toUpdate);
			if(result)
			{
				_cache.Remove(CacheKeys.AllIPBans);
			}
			// jsGrid requires the updated object as return value.
			return Json(toUpdate);
		}
		
		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> InsertIPBan([FromBody] IPBanDto toInsert)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			toInsert.IPBanSetByUserID = this.HttpContext.Session.GetUserID();
			toInsert.IPBanSetOn = DateTime.Now;
			var ipBanId = await SecurityManager.AddNewIPBanAsync(toInsert);
			if(ipBanId>0)
			{
				_cache.Remove(CacheKeys.AllIPBans);
				toInsert.IPBanID = ipBanId;
			}
			// jsGrid requires the inserted object as return value.
			return Json(toInsert);
		}
		
		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteIPBan(int ipBanId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(ipBanId>0)
			{
				result = await SecurityManager.DeleteIPBanAsync(ipBanId);
				if(result)
				{
					_cache.Remove(CacheKeys.AllIPBans);
				}
			}
			if(result)
			{
				return Json(new {success = true});
			}
			return ValidationProblem("The IPBan wasn't deleted.");
		}
		
		
		private async Task FillAddEditRoleDataAsync(AddEditRoleData data)
		{
			data.AvailableSystemRights = await SecurityGuiHelper.GetAllSystemActionRightsAsync();
			data.AvailableAuditActions = await SecurityGuiHelper.GetAllAuditActionsAsync();
		}
	}
}
