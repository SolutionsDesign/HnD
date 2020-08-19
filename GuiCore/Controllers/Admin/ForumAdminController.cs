using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models.Admin;
using SD.HnD.Utility;

namespace SD.HnD.Gui.Controllers
{
	public class ForumAdminController : Controller
	{
		private IMemoryCache _cache;

		public ForumAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult AddForum()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new AddForumData();
			FillDataSetsInModelObject(data);
			return View("~/Views/Admin/AddForum.cshtml", data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddForum(AddForumData data)
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}
			
			if(!ModelState.IsValid)
			{
				FillDataSetsInModelObject(data);
				return View("~/Views/Admin/AddForum.cshtml", data);
			}
			data.Sanitize();

			var welcomeMessageAsHtml = HnDGeneralUtils.TransformMarkdownToHtml(data.NewThreadWelcomeText, ApplicationAdapter.GetEmojiFilenamesPerName(), ApplicationAdapter.GetSmileyMappings());
			var result = await ForumManager.CreateNewForumAsync(data.SectionID, data.ForumName, data.ForumDescription, data.HasRSSFeed, data.DefaultSupportQueueID, 1,
																data.OrderNo, data.MaxAttachmentSize, data.MaxNoOfAttachmentsPerMessage,
																data.NewThreadWelcomeText, welcomeMessageAsHtml);
			if(result > 0)
			{
				data.Persisted = true;
			}
			else
			{
				FillDataSetsInModelObject(data);
			}
			return View("~/Views/Admin/AddForum.cshtml", data);
		}


		private static void FillDataSetsInModelObject(AddForumData data)
		{
			data.AllExistingSupportQueues = SupportQueueGuiHelper.GetAllSupportQueueDTOs();
			data.AllExistingSections = SectionGuiHelper.GetAllSectionDtos();
		}
	}
}