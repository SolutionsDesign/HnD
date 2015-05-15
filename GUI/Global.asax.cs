using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SD.HnD.BL;
using SD.HnD.DAL.EntityClasses;

namespace SD.HnD.Gui
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
#if DEBUG
			SD.Tools.OrmProfiler.Interceptor.InterceptorCore.Initialize("HnD_3.5 Dev");
#endif
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			// Use static method in BL to fill the Application object with the data which is systemwide
			// and thus cacheable in the application object.
			ApplicationAdapter.LoadApplicationObjectCacheData();
		}


		protected void Session_Start()
		{
			// Use static methods in SessionAdapter to fill the Session object with the data which is user specific
			// and thus cacheable in the session object.
			UserEntity user = null;
			bool useEntityBasedLastVisitDateTracking = false;
			if(HttpContext.Current.Request.IsAuthenticated)
			{
				if(!SecurityManager.DoesUserExist(HttpContext.Current.User.Identity.Name, out user))
				{
					user = UserGuiHelper.GetUser(0);	// 0 is UserID of Anonymous Coward;
				}
				else
				{
					// if the lastvisited date is null in the user entity, we'll use the cookie approach first
					useEntityBasedLastVisitDateTracking = user.LastVisitedDate.HasValue;
				}
			}
			else
			{
				user = UserGuiHelper.GetUser(0);	// 0 is UserID of Anonymous Coward
			}

			if((user != null) && user.IsBanned)
			{
				// banned user, revert to AC
				user = UserGuiHelper.GetUser(0);
				useEntityBasedLastVisitDateTracking = false;
			}

			if(user == null)
			{
				SessionAdapter.LoadAnonymousSessionData();
			}
			else
			{
				SessionAdapter.LoadUserSessionData(user);
			}

			bool isLastVisitDateValid = false;
			DateTime lastVisitDate = DateTime.Now;
			string lastVisitDateCookieName = ApplicationAdapter.GetSiteName() + " LastVisitDate";

			// the last visited date is either stored in a cookie or on the server. Older versions of this forum system used cookie based last visited date storage,
			// newer versions use server side storage in the User entity. For non-logged in users, cookie based storage is still used. 
			if(useEntityBasedLastVisitDateTracking)
			{
				lastVisitDate = user.LastVisitedDate.Value;
				isLastVisitDateValid = true;
			}
			else
			{
				// read last visit date from cookie collection sent 
				if(Request.Cookies[lastVisitDateCookieName] != null)
				{
					string lastVisitDateAsString = Request.Cookies[lastVisitDateCookieName].Value.ToString();

					// convert to datetime
					lastVisitDate = new DateTime(
							int.Parse(lastVisitDateAsString.Substring(4, 4)),	// Year
							int.Parse(lastVisitDateAsString.Substring(2, 2)),	// Month
							int.Parse(lastVisitDateAsString.Substring(0, 2)),	// Day
							int.Parse(lastVisitDateAsString.Substring(8, 2)),	// Hour
							int.Parse(lastVisitDateAsString.Substring(10, 2)),	// Minute
							0);											// Seconds

					isLastVisitDateValid = true;
				}
				else
				{
					lastVisitDate = DateTime.Now;
					isLastVisitDateValid = false;
				}
			}

			// store in session object
			SessionAdapter.AddLastVisitDate(lastVisitDate, isLastVisitDateValid);

			// update date
			if(useEntityBasedLastVisitDateTracking || ((user.UserID != 0) && !user.LastVisitedDate.HasValue))
			{
				UserManager.UpdateLastVisitDateForUser(user.UserID);
			}

			// always write new cookie
			HttpCookie visitCookie = new HttpCookie(lastVisitDateCookieName, DateTime.Now.ToString("ddMMyyyyHHmm"));
			visitCookie.Expires = DateTime.Now.AddYears(1);
			visitCookie.Path = "/";		// cookie path is set to '/', to avoid path name casing mismatches. The cookie has a unique name anyway.
			Response.Cookies.Add(visitCookie);

			if(SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditLogin))
			{
				SecurityManager.AuditLogin(SessionAdapter.GetUserID());
			}
		}
	}
}
