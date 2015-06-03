using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
    public class RssForumController : Controller
    {
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

			Response.Cache.SetExpires(DateTime.Now.AddDays(7));
			Response.Cache.SetCacheability(HttpCacheability.Public);
			Response.Cache.SetValidUntilExpires(true);
			Response.Cache.VaryByParams["id"] = true;
			Response.Cache.AddValidationCallback(Validate, id);

            return View(data);
        }

		
		public void Validate(HttpContext context, Object data, ref HttpValidationStatus status)
		{
			var cacheFlags = ApplicationAdapter.GetCacheFlags();
			bool isValid = true;
			var id = (int)data;
			if(cacheFlags.ContainsKey(id))
			{
				isValid = cacheFlags[id];
			}
			status = isValid ? HttpValidationStatus.Valid : HttpValidationStatus.Invalid;
		}
    }
}