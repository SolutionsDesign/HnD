using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.Gui.Models.Admin;

namespace SD.HnD.Gui.Controllers
{
	public class SystemAdminController : Controller
	{
		private IMemoryCache _cache;

		public SystemAdminController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		
		[HttpGet]
		[Authorize]
		public ActionResult SystemParameters()
		{
			if(!this.HttpContext.Session.HasSystemActionRights() || !this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new SystemParametersData()
					   {
						   AllRoles = SecurityGuiHelper.GetAllRoles(),
						   AllUserTitles = UserGuiHelper.GetAllUserTitles(),
						   SystemData = _cache.GetSystemData()
					   };
			return View("~/Views/Admin/SystemParameters.cshtml", data);
		}
	}
}