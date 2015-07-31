using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.HnD.BL;

namespace SD.HnD.Gui.Controllers
{
    public class MessageController : Controller
    {
		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Delete(int id = 0)
		{
			if(LoggedInUserAdapter.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var message = MessageGuiHelper.GetMessage(id);
			if(message==null)
			{
				return RedirectToAction("Index", "Home");
			}
			var thread = ThreadGuiHelper.GetThread(message.ThreadID);
			if(thread == null)
			{
				return RedirectToAction("Index", "Home");
			}
			// Only delete if the message isn't the first in the thread (as that's not allowed), and whether the user is allowed to delete messages at all. 
			if(!ThreadGuiHelper.CheckIfMessageIsFirstInThread(thread.ThreadID, id) && 
				LoggedInUserAdapter.CanPerformForumActionRight(thread.ForumID, ActionRights.EditDeleteOtherUsersMessages))
			{
				MessageManager.DeleteMessage(id);
			}
			return RedirectToAction("Index", "Thread", new { id = thread.ThreadID, pageNo=1});
		}
    }
}