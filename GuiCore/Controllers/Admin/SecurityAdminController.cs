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
	/// Controller which exposes a WebAPI to be used with the jsGrid using views for sections.
	/// The methods in this controller therefore use the Http action as prefix.
	/// </summary>
	public class SecurityAdminController : Controller
	{	
		private IMemoryCache _cache;
		
		public SecurityAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
								
		
		[HttpGet]
		[Authorize]
		public ActionResult Roles()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			return View("~/Views/Admin/Roles.cshtml");
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult<IEnumerable<SectionDto>> GetRoles()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var roleDtos = SecurityGuiHelper.GetAllRoleDTOs();
			return Ok(roleDtos);
		}
		

		[HttpGet]
		[Authorize]
		public ActionResult EditRole(int id)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new AddEditRoleData();
			data.RoleEdited = SecurityGuiHelper.GetRole(id);
			if(data.RoleEdited == null)
			{
				return RedirectToRoute("ManageRoles");
			}
			FillAddEditRoleData(data);
			data.SystemRightsSet = SecurityGuiHelper.GetAllSystemActionRightIDsForRole(id);
			data.AuditActionsSet = SecurityGuiHelper.GetAllAuditActionIDsForRole(id);
			return View("~/Views/Admin/EditRole.cshtml", data);
		}
		

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditRole(AddEditRoleData data, string submitAction, int id = 0)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			if(submitAction == "cancel" || id <= 0)
			{
				return RedirectToRoute("ManageRoles");
			}
			if(!ModelState.IsValid)
			{
				FillAddEditRoleData(data);
				return View("~/Views/Admin/EditRole.cshtml", data);
			}
			try
			{
				var result = await SecurityManager.ModifyRoleAsync(id, data.RoleEdited.RoleDescription, data.SystemRightsSet, data.AuditActionsSet);
				if(!result)
				{
					ModelState.AddModelError(string.Empty, "Save failed.");
					FillAddEditRoleData(data);
					return View("~/Views/Admin/EditRole.cshtml", data);
				}
			}
			catch(ORMQueryExecutionException)
			{
				ModelState.AddModelError("RoleEdited.RoleDescription", "Save failed, likely due to the role description not being unique. Please specify a unique role description name.");
				FillAddEditRoleData(data);
				return View("~/Views/Admin/EditRole.cshtml", data);
			}
			return View("~/Views/Admin/Roles.cshtml", data);			
		}


		[HttpGet]
		[Authorize]
		public ActionResult AddRole()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new AddEditRoleData();
			FillAddEditRoleData(data);
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
				FillAddEditRoleData(data);
				return View("~/Views/Admin/AddRole.cshtml", data);
			}

			try
			{
				await SecurityManager.CreateNewRoleAsync(data.RoleEdited.RoleDescription, data.SystemRightsSet, data.AuditActionsSet);
			}
			catch(ORMQueryExecutionException ex)
			{
				ModelState.AddModelError("RoleDescription", "Save failed, likely due to the role description not being unique. Please specify a unique role description name." + ex.Message);
				FillAddEditRoleData(data);
				return View("~/Views/Admin/AddRole.cshtml", data);
			}
			return View("~/Views/Admin/Roles.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteRole(int id)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SecurityManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(id>0)
			{
				// check if the role is set as a default role in system settings. If so, it's not deleted
				var systemSettings = _cache.GetSystemData();
				if(systemSettings.AnonymousRole == id || systemSettings.DefaultRoleNewUser == id)
				{
					return ValidationProblem("The role wasn't deleted because it's a role that's set as a default in System Settings.");
				}

				result = SecurityManager.DeleteRole(id);
			}

			if(result)
			{
				return Json(new {success = true});
			}

			return ValidationProblem("The role wasn't deleted.");
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult IPBans()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			return View("~/Views/Admin/IPBans.cshtml");
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult<IEnumerable<SectionDto>> GetIPBans()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var ipBanDtos = SecurityGuiHelper.GetAllIPBanDTOs();
			return Ok(ipBanDtos);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult UpdateIPBan([FromBody] IPBanDto toUpdate)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			toUpdate.IPBanSetOn = DateTime.Now;
			var result = SecurityManager.ModifyIPBan(toUpdate);
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
		public ActionResult InsertIPBan([FromBody] IPBanDto toInsert)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			toInsert.IPBanSetByUserID = this.HttpContext.Session.GetUserID();
			toInsert.IPBanSetOn = DateTime.Now;
			var ipBanId = SecurityManager.AddNewIPBan(toInsert);
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
		public ActionResult DeleteIPBan(int id)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.UserManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(id>0)
			{
				result = SecurityManager.DeleteIPBan(id);
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
		
		
		private void FillAddEditRoleData(AddEditRoleData data)
		{
			data.AvailableSystemRights = SecurityGuiHelper.GetAllSystemActionRights();
			data.AvailableAuditActions = SecurityGuiHelper.GetAllAuditActions();
		}
	}
}
