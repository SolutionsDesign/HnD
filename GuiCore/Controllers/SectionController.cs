using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
    public class SectionController : Controller
    {
		[Authorize]
		[HttpGet]
		public ActionResult Forums(int id = 0)
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
			var modelData = new ForumSelectorData {Forums = ForumGuiHelper.GetAllForumsInSection(id)};
			return PartialView("ForumSelector", modelData);
		}
    }
}