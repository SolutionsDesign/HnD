using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;

namespace SD.HnD.Gui.Controllers
{
    public class ForumController : Controller
    {
        public ActionResult Index(int id=0, int pageNo=1)
        {
			// do forum security checks on authorized user.
			bool userHasAccess = LoggedInUserAdapter.CanPerformForumActionRight(id, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				return RedirectToAction("Index", "Home");
			}


            return View();
        }
    }
}