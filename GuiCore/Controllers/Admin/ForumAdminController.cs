/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.TypedListClasses;
using SD.HnD.Gui.Models.Admin;
using SD.HnD.Utility;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for forum related administration actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class ForumAdminController : Controller
	{
		private IMemoryCache _cache;


		public ForumAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[HttpGet]
		[Authorize]
		public ActionResult ManageForums()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			return View("~/Views/Admin/Forums.cshtml");
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<ForumsWithSectionNameRow>>> GetForums()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var forums = await ForumGuiHelper.GetAllForumsWithSectionNamesAsync();
			return Ok(forums);
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult> AddForum()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new AddEditForumData();
			await FillDataSetsInModelObjectAsync(data);
			return View("~/Views/Admin/AddForum.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddForum(AddEditForumData data, string submitAction)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "cancel")
			{
				return RedirectToRoute("ManageForums");
			}

			if(!ModelState.IsValid)
			{
				await ForumAdminController.FillDataSetsInModelObjectAsync(data);
				return View("~/Views/Admin/AddForum.cshtml", data);
			}

			data.Sanitize();

			var welcomeMessageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(data.ForumEdited.NewThreadWelcomeText, ApplicationAdapter.GetEmojiFilenamesPerName(),
																			   ApplicationAdapter.GetSmileyMappings());
			try
			{
				await ForumManager.CreateNewForumAsync(data.ForumEdited.SectionID, data.ForumEdited.ForumName, data.ForumEdited.ForumDescription,
													   data.ForumEdited.HasRSSFeed, data.ForumEdited.DefaultSupportQueueID, data.ForumEdited.OrderNo,
													   data.ForumEdited.MaxAttachmentSize, data.ForumEdited.MaxNoOfAttachmentsPerMessage,
													   data.ForumEdited.NewThreadWelcomeText, welcomeMessageAsHtml);
			}
			catch(ORMQueryExecutionException ex)
			{
				ModelState.AddModelError("ForumName", "Save failed, likely due to the forum name not being unique. Please specify a unique forum name." + ex.Message);
				await ForumAdminController.FillDataSetsInModelObjectAsync(data);
				return View("~/Views/Admin/AddForum.cshtml", data);
			}

			return View("~/Views/Admin/Forums.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteForum(int forumId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var result = false;
			if(forumId > 0)
			{
				result = await ForumManager.DeleteForumAsync(forumId);
			}

			if(result)
			{
				return Json(new {success = true});
			}

			return ValidationProblem("The forum wasn't deleted, due to an error. Please try again.");
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult> EditForum(int forumId)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var toEdit = await ForumGuiHelper.GetForumAsync(forumId);
			if(toEdit == null)
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new AddEditForumData(toEdit);
			await ForumAdminController.FillDataSetsInModelObjectAsync(data);
			return View("~/Views/Admin/EditForum.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditForum(AddEditForumData data, string submitAction, int forumId = 0)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			if(submitAction == "cancel")
			{
				return RedirectToRoute("ManageForums");
			}

			if(!ModelState.IsValid)
			{
				await ForumAdminController.FillDataSetsInModelObjectAsync(data);
				return View("~/Views/Admin/EditForum.cshtml", data);
			}

			data.Sanitize();

			var welcomeMessageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(data.ForumEdited.NewThreadWelcomeText, ApplicationAdapter.GetEmojiFilenamesPerName(),
																			   ApplicationAdapter.GetSmileyMappings());
			try
			{
				await ForumManager.ModifyForumAsync(forumId, data.ForumEdited.SectionID, data.ForumEdited.ForumName, data.ForumEdited.ForumDescription,
													data.ForumEdited.HasRSSFeed, data.ForumEdited.DefaultSupportQueueID, data.ForumEdited.OrderNo,
													data.ForumEdited.MaxAttachmentSize, data.ForumEdited.MaxNoOfAttachmentsPerMessage,
													data.ForumEdited.NewThreadWelcomeText, welcomeMessageAsHtml);
			}
			catch(ORMQueryExecutionException ex)
			{
				ModelState.AddModelError("ForumName", "Save failed, likely due to the forum name not being unique. Please specify a unique forum name." + ex.Message);
				await ForumAdminController.FillDataSetsInModelObjectAsync(data);
				return View("~/Views/Admin/AddForum.cshtml", data);
			}

			return View("~/Views/Admin/Forums.cshtml", data);
		}


		private static async Task FillDataSetsInModelObjectAsync(AddEditForumData data)
		{
			data.AllExistingSupportQueues = await SupportQueueGuiHelper.GetAllSupportQueueDTOsAsync();
			data.AllExistingSections = await SectionGuiHelper.GetAllSectionDtosAsync();
		}
	}
}