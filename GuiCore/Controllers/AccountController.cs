using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Controllers
{
    public class AccountController : Controller
    {
	    [Authorize]
	    [HttpGet]
	    public ActionResult Bookmarks()
	    {
		    var bookmarkData = UserGuiHelper.GetBookmarksAggregatedData(this.HttpContext.Session.GetUserID());
		    var viewData = new BookmarksData() {Bookmarks = bookmarkData};
		    return View(viewData);
	    }


	    [Authorize]
	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public ActionResult UpdateBookmarks(int[] threadIdsToUnbookmark)
	    {
			// the user manager will take care of threads which are passed to this method and which don't exist. We'll only do a limit
		    if(threadIdsToUnbookmark != null && threadIdsToUnbookmark.Length < 100 && threadIdsToUnbookmark.Length > 0)
		    {
			    UserManager.RemoveBookmarks(threadIdsToUnbookmark, this.HttpContext.Session.GetUserID());
		    }
		    return RedirectToAction("Bookmarks");
	    }
		
		
		[AllowAnonymous]
		[HttpGet]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}


	    [Authorize]
	    public async Task<IActionResult> LogoutAsync()
	    {
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			this.HttpContext.Session.Clear();
			return RedirectToLocal("~/");
	    }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LoginAsync([Bind("NickName, Password, RememberMe")] LoginModel data, string returnUrl)
        {
	        if(!ModelState.IsValid)
	        {
		        return View(data);
	        }
	        var result = await PerformLoginAsync(data);
	        switch(result)
	        {
				case SecurityManager.AuthenticateResult.AllOk:
					return RedirectToLocal(returnUrl);
				default:
			        return View(data);
	        }
        }


		private async Task<SecurityManager.AuthenticateResult> PerformLoginAsync(LoginModel data)
	    {
			UserEntity user = null;
			SecurityManager.AuthenticateResult result = SecurityManager.AuthenticateUser(data.NickName, data.Password, out user);

			switch(result)
			{
				case SecurityManager.AuthenticateResult.AllOk:
					// authenticated
					// Save session cacheable data
					this.HttpContext.Session.LoadUserSessionData(user);
					// update last visit date in db
					UserManager.UpdateLastVisitDateForUser(user.UserID);
					// done
					//FormsAuthentication.SetAuthCookie(user.NickName, data.RememberMe);
					var claims = new List<Claim> {new Claim(ClaimTypes.Name, user.NickName)};
					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var authProperties = new AuthenticationProperties() {IsPersistent = data.RememberMe};
					await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
					
					// Audit the login action, if it was defined to be logged for this role.
					if(this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditLogin))
					{
						SecurityManager.AuditLogin(this.HttpContext.Session.GetUserID());
					}
					break;
				case SecurityManager.AuthenticateResult.IsBanned:
					ModelState.AddModelError(string.Empty, "You are banned. Login won't work for you.");
					break;
				case SecurityManager.AuthenticateResult.WrongUsernamePassword:
					ModelState.AddModelError(string.Empty, "You specified a wrong User name - Password combination. Please try again.");
					break;
			}
			return result;
	    }


		private ActionResult RedirectToLocal(string returnUrl)
		{
			if(Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			return RedirectToAction("Index", "Home");
		}
    }
}
