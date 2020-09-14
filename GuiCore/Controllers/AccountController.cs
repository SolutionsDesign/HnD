using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Classes;
using SD.HnD.Gui.Models;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Controllers
{
    public class AccountController : Controller
    {
		private IMemoryCache _cache;
		
		public AccountController(IMemoryCache cache)
		{
			_cache = cache;
		}
		
		
	    [Authorize]
	    [HttpGet]
	    public ActionResult Bookmarks()
	    {
		    var bookmarkData = UserGuiHelper.GetBookmarksAggregatedData(this.HttpContext.Session.GetUserID());
		    var viewData = new ThreadsData() {ThreadRows = bookmarkData};
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
		

		[HttpGet]
		[Authorize]
		public ActionResult Threads(int pageNo = 1)
		{
			var userID = this.HttpContext.Session.GetUserID();
			if(userID <= 0 )
			{
				// not found
				return RedirectToAction("Index", "Home");
			}

			int rowCount = this.HttpContext.Session.GetInt32(SessionKeys.MyThreadsRowCount) ?? 0;
			if(rowCount <= 0)
			{
				rowCount = UserGuiHelper.GetRowCountLastThreadsForUser(this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum), userID,
																	   this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
																	   userID);
				this.HttpContext.Session.SetInt32(SessionKeys.MyThreadsRowCount, rowCount);
			}

			int pageSize = _cache.GetSystemData().PageSizeSearchResults;
			if(pageSize <= 0)
			{
				pageSize = 50;
			}
			int rowCountCapped = rowCount;
			if(rowCount > 500)
			{
				// maximum is 500
				rowCountCapped = 500;
			}
			int numberOfPages = (rowCountCapped / pageSize);
			if((numberOfPages * pageSize) < rowCountCapped)
			{
				numberOfPages++;
			}
			var data = new MyThreadsData() {RowCount = rowCount, NumberOfPages = numberOfPages, PageNo = pageNo};
			data.ThreadRows = UserGuiHelper.GetLastThreadsForUserAggregatedData(this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum), userID,
																				this.HttpContext.Session.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
																				userID, pageSize, pageNo);
			return View(data);
		}
		

		[HttpGet]
		[Authorize]
		public ActionResult EditProfile()
		{
			var user = UserGuiHelper.GetUser(this.HttpContext.Session.GetUserID());
			if(user == null)
			{
				// not found
				return RedirectToAction("Index", "Home");
			}

			var data = new EditProfileData()
					   {
						   AutoSubscribeToThread = user.AutoSubscribeToThread,
						   EmailAddress = user.EmailAddress,
						   EmailAddressIsPublic = user.EmailAddressIsPublic ?? false,
						   NickName = user.NickName,
						   DateOfBirth = user.DateOfBirth,
						   Occupation = user.Occupation ?? string.Empty,
						   Location = user.Location ?? string.Empty,
						   Signature = user.Signature ?? string.Empty,
						   Website = user.Website ?? string.Empty,
						   IconURL = user.IconURL ?? string.Empty,
						   DefaultNumberOfMessagesPerPage = user.DefaultNumberOfMessagesPerPage
					   };
			data.Sanitize();
			return View(data);
		}


		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditProfileAsync(EditProfileData data)
		{
			var userID = this.HttpContext.Session.GetUserID();
			if(userID <= 0 )
			{
				// not found
				return RedirectToAction("Index", "Home");
			}
			if(!ModelState.IsValid)
			{
				return View(data);
			}
		
			data.Sanitize();
			data.StripProtocolsFromUrls();
			var result = await UserManager.UpdateUserProfileAsync(userID, data.DateOfBirth, data.EmailAddress, data.EmailAddressIsPublic, data.IconURL, data.Location,
																   data.Occupation, data.NewPassword, data.Signature, data.Website, this.HttpContext.Session.GetUserTitleID(), 
																   data.AutoSubscribeToThread, data.DefaultNumberOfMessagesPerPage, null, null);
			if(result)
			{
				this.HttpContext.Session.UpdateUserSettings(data);
				return RedirectToAction("ViewProfile", "User", new {id = userID});
			}

			return View(data);
		}


		[AllowAnonymous]
		[HttpGet]
		public ActionResult Register()
		{
			return View(new NewProfileData() { DefaultNumberOfMessagesPerPage = (short)this.HttpContext.Session.GetUserDefaultNumberOfMessagesPerPage() });
		}
		
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> RegisterAsync(NewProfileData data)
		{
			if(!ModelState.IsValid)
			{
				return View(data);
			}
		
			data.Sanitize();
			data.StripProtocolsFromUrls();
			var result = await UserManager.RegisterNewUserAsync(data.NickName, data.DateOfBirth, data.EmailAddress, data.EmailAddressIsPublic, data.IconURL,
														   this.HttpContext.Connection.RemoteIpAddress.ToString(), data.Location,
														   data.Occupation, data.Signature, data.Website,
														   ApplicationAdapter.GetEmailData(this.Request.Host.Host, EmailTemplate.RegistrationReply),
														   data.AutoSubscribeToThread, data.DefaultNumberOfMessagesPerPage);
			if(result > 0)
			{
				this.HttpContext.Session.UpdateUserSettings(data);
				return RedirectToAction("Login", "Account");
			}

			return View(data);
		}
		
		

		[AllowAnonymous]
		[HttpGet]
		public ActionResult ResetPassword()
		{
			return View(new ResetPasswordData());
		}
		

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPasswordAsync(ResetPasswordData data)
		{
			if(!ModelState.IsValid)
			{
				return View(data);
			}
			await PerformResetPasswordAsync(data);
			return View(data);
		}


		[AllowAnonymous]
		[HttpGet]
		public ActionResult SpecifyNewPassword(string tokenID)
		{
			// the token might be invalid or non existent.
			bool tokenIsValid = UserGuiHelper.GetPasswordResetToken(tokenID)!=null;
			if(!tokenIsValid)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}


		[AllowAnonymous]
		[HttpPost]
		public ActionResult SpecifyNewPassword(NewPasswordData data,string tokenID)
		{
			// the token might be invalid or non existent.
			var passwordResetToken = UserGuiHelper.GetPasswordResetToken(tokenID);
			if(passwordResetToken==null)
			{
				return RedirectToAction("Index", "Home");
			}
			if(!ModelState.IsValid)
			{
				return View(data);
			}

			if(string.IsNullOrWhiteSpace(data.NewPassword))
			{
				data.NewPassword = string.Empty;
				data.ConfirmNewPassword = string.Empty;
				return View(data);
			}
			if(!UserManager.ResetPassword(data.NewPassword, passwordResetToken))
			{
				return View(data);
			}
			// all done, user can now login.
			return RedirectToAction("Login", "Account");
		}


		[AllowAnonymous]
		[HttpGet]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}


		[HttpPost]
	    [Authorize]
	    public async Task<IActionResult> LogoutAsync()
	    {
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			this.HttpContext.Session.Clear();
			return RedirectToLocal("~/");
	    }

		
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LoginAsync(LoginData data, string returnUrl)
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


		private async Task<SecurityManager.AuthenticateResult> PerformLoginAsync(LoginData data)
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
		

		private async Task PerformResetPasswordAsync(ResetPasswordData data)
		{
			bool result = await UserManager.EmailPasswordResetLink(data.NickName, ApplicationAdapter.GetEmailData(this.Request.Host.Host, 
																												  EmailTemplate.ResetPasswordLink)).ConfigureAwait(false);
			data.EmailSent = result;
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
