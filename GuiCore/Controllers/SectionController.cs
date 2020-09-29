using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Section related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
    public class SectionController : Controller
    {
		[Authorize]
		[HttpGet]
		public async Task<ActionResult> Forums(int id = 0)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			if(!(this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement) || 
				 this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement)))
			{
				return RedirectToAction("Index", "Home");
			}
			var modelData = new ForumSelectorData { Forums = await ForumGuiHelper.GetAllForumsInSectionAsync(id)};
			return PartialView("ForumSelector", modelData);
		}
    }
}