using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
			if(LoggedInUserAdapter.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			if(!(LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement) || LoggedInUserAdapter.HasSystemActionRight(ActionRights.SystemManagement)))
			{
				return RedirectToAction("Index", "Home");
			}
			var modelData = new ForumSelectorData {Forums = ForumGuiHelper.GetAllForumsInSection(id)};
			return PartialView("ForumSelector", modelData);
		}
    }
}