using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
    public class RssForumController : Controller
	{
		private IMemoryCache _cache;


		public RssForumController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60*10, VaryByQueryKeys = new[]{"id"})]
        public ActionResult Index(int id=0)
        {
			this.Response.ContentType = "text/xml";
	        var forum = _cache.GetForum(id);
	        if(forum == null)
	        {
		        return View();
	        }

	        var data = new RssForumData()
					   {
						   ForumUrl = "https://" + this.Request.Host.Host + ApplicationAdapter.GetVirtualRoot() + @"/Forum/" + id,
						   SiteName = ApplicationAdapter.GetSiteName(),
						   ForumName = forum.ForumName,
						   ForumItems = ForumGuiHelper.GetLastPostedMessagesInForum(10, id)
					   };
            return View(data);
        }
    }
}