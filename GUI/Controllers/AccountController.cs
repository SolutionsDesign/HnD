using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SD.HnD.BL;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
    public class AccountController : Controller
    {
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}


	    [Authorize]
	    public ActionResult Logout()
	    {
		    FormsAuthentication.SignOut();
			SessionAdapter.Abandon();
			return RedirectToLocal("~/");
	    }


        [HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include="NickName, Password, RememberMe")] LoginModel data, string returnUrl)
        {
	        if(!ModelState.IsValid)
	        {
		        return View(data);
	        }
	        var result = PerformLogin(data);
	        switch(result)
	        {
				case SecurityManager.AuthenticateResult.AllOk:
					return RedirectToLocal(returnUrl);
				default:
			        return View(data);
	        }
        }


		private SecurityManager.AuthenticateResult PerformLogin(LoginModel data)
	    {
			UserEntity user = null;
			SecurityManager.AuthenticateResult result = SecurityManager.AuthenticateUser(data.NickName, data.Password, out user);

			switch(result)
			{
				case SecurityManager.AuthenticateResult.AllOk:
					// authenticated
					// Save session cacheable data
					SessionAdapter.LoadUserSessionData(user);
					// update last visit date in db
					UserManager.UpdateLastVisitDateForUser(user.UserID);
					// done
					FormsAuthentication.SetAuthCookie(user.NickName, data.RememberMe);
					// Audit the login action, if it was defined to be logged for this role.
					if(SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditLogin))
					{
						SecurityManager.AuditLogin(SessionAdapter.GetUserID());
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
