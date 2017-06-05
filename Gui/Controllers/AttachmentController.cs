using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;

namespace SD.HnD.Gui.Controllers
{
    public class AttachmentController : Controller
    {
	 //   [AllowAnonymous]
  //      [HttpGet]
  //      public ActionResult Index(int id=0)
	 //   {
		//    MessageEntity message = null;
		//    if(!GetMessageAndThread(id, out message))
		//    {
		//	    return RedirectToAction("Index", "Home");
		//	}
		//    var forum = CacheManager.GetForum(message.Thread.ForumID);
		//    if(forum == null)
		//    {
		//	    return RedirectToAction("Index", "Home");
		//    }

		//}


	 //   private bool GetMessageAndThread(int id, out MessageEntity message)
	 //   {
		//    message = null;
		//    if(id <= 0)
		//    {
		//	    return false;
		//    }

		//    message = MessageGuiHelper.GetMessage(id, prefetchThread: true);
		//    return message != null && message.Thread!=null;
	 //   }
    }
}