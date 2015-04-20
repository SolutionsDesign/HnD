<%@ Application Language="C#" %>
<%@ Import Namespace="SD.HnD.BL" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="SD.HnD.DAL.EntityClasses" %>
<%@ Import Namespace="SD.HnD.DAL.CollectionClasses" %>
<%@ Import Namespace="SD.HnD.GUI" %>

<script runat="server">
/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

	/// <summary>
	/// Fired when the first request is made to the total application. This routine will load common global
	/// data into the Application Object, so it is cached there for all users (UserTitles f.e.)
	/// This saves many roundtrips to the database.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Application_Start( Object sender, EventArgs e )
	{
		//SD.Tools.OrmProfiler.Interceptor.InterceptorCore.Initialize("HnD_3.5 Dev");

		// Use static method in BL to fill the Application object with the data which is systemwide
		// and thus cacheable in the application object.
		ApplicationAdapter.LoadApplicationObjectCacheData();
	}

	
	/// <summary>
	/// Raised when a new session starts. In this handler user specific data is loaded into the
	/// session object. This is small data that is cached in the session object to avoid database roundtrips.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Session_Start( Object sender, EventArgs e )
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
		
        if (SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditLogin))
		{
            SecurityManager.AuditLogin(SessionAdapter.GetUserID());				
		}
	}


	/// <summary>
	/// Handler of the BeginRequest event fired up by a HttpModule. In here we can do initial processing of the
	/// request and terminate it if necessary (f.e. in case of an IP ban)
	/// </summary>
	/// <param name="sender">HttpApplication object firing the event</param>
	/// <param name="e">arguments of the event.</param>
	protected void Application_BeginRequest( Object sender, EventArgs e )
	{
		HttpApplication requestSender = (HttpApplication)sender;
		// Check if the current request is coming from a person who is IP-banned.
		string ipAddressUser = requestSender.Request.UserHostAddress;

		// Check if the user's IP address matches an IP ban.
		IPBanEntity matchingIPBan = SecurityGuiHelper.GetIPBanMatchingUserIPAddress(CacheManager.GetAllIPBans(), ipAddressUser);
		if(matchingIPBan!=null)
		{
			// there are matching IP bans. ban this user.
			requestSender.CompleteRequest();
			Response.StatusCode = 200;
			Response.StatusDescription = "You are banned";
			// show IP Ban page.
			Server.Execute("IPBanViewer.aspx");
		}
	}


	protected void Application_Error( Object sender, EventArgs e )
	{
		// If you want low-level error reporting, add code here to for example send an email. Be aware that a
		// response.redirect will create a NEW session. This will cause infinite loops if the error/exception originates from
		// session initialization code. So use Server.Transfer instead. 
	}

	
	protected void Application_PostAcquireRequestState(object sender, EventArgs e)
	{
		HttpContext currentContext = HttpContext.Current;

		if(currentContext.Request.IsAuthenticated)
		{
			string nickName = currentContext.User.Identity.Name;
			
			// check if the user has to be logged out by force. If so, write the cookie as expired and also kill the user's session.
			if(ApplicationAdapter.UserHasToBeLoggedOutByForce(nickName))
			{
				// sign out the user, so the user isn't able to login again next time. 
				FormsAuthentication.SignOut();
				// user has to be forced to log out, construct a responsecookie.
				currentContext.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);
				currentContext.Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
				ApplicationAdapter.RemoveUserFromListToBeLoggedOutByForce(nickName);
				if(currentContext.Session != null)
				{
					currentContext.Session.Abandon();
				}
			}
		}

	}
</script>
