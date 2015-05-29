using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
    public class RssForumController : Controller
    {
        // GET: RssForum
        public ActionResult Index(int id=0)
        {
			Response.ContentType = "text/xml";
	        var forum = CacheManager.GetForum(id);
	        if(forum == null)
	        {
		        return View();
	        }

	        var data = new RssForumData()
					   {
						   ForumUrl = "http://" + Request.Url.Host + ApplicationAdapter.GetVirtualRoot() + @"/Forum/" + id,
						   SiteName = ApplicationAdapter.GetSiteName(),
						   ForumName = forum.ForumName,
						   ForumItems = ForumGuiHelper.GetLastPostedMessagesInForum(10, id)
					   };

            return View(data);
        }
    }
}