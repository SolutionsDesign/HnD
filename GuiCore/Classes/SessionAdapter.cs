/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
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
using System;
using System.Collections.Generic;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.BL;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.TypedListClasses;
using SD.HnD.Gui.Classes;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui
{
    /// <summary>
    /// SessionAdapter is used to access session objects
    /// </summary>
    public static class SessionAdapter
    {
		/// <summary>
		/// Initializes the session with the initial static data for the user. 
		/// </summary>
		/// <param name="session"></param>
		/// <param name="context"></param>
		public static async Task InitializeAsync(this ISession session, HttpContext context)
		{
			if(session.GetInt32(SessionKeys.SessionInitialized) == 1)
			{
				// already initialized
				return;
			}
			
			bool useEntityBasedLastVisitDateTracking = false;
			UserEntity user = null;
			if(context.User.Identity.IsAuthenticated)
			{
				user = await UserGuiHelper.GetUserAsync(context.User.Identity.Name);
				if(user == null)
				{
					user = await UserGuiHelper.GetUserAsync(0); // 0 is UserID of Anonymous Coward;
				}
				else
				{
					// if the lastvisited date is null in the user entity, we'll use the cookie approach first
					useEntityBasedLastVisitDateTracking = user.LastVisitedDate.HasValue;
				}
			}
			else
			{
				user = await UserGuiHelper.GetUserAsync(0);	// 0 is UserID of Anonymous Coward
			}

			if(user == null || user.IsBanned)
			{
				// banned user, revert to AC
				user = await UserGuiHelper.GetUserAsync(0);
				useEntityBasedLastVisitDateTracking = false;
			}

			if(user == null || user.UserID<=0)
			{
				await session.LoadAnonymousSessionDataAsync();
			}
			else
			{
				await session.LoadUserSessionDataAsync(user);
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
				if(context.Request.Cookies[lastVisitDateCookieName] != null)
				{
					string lastVisitDateAsString = context.Request.Cookies[lastVisitDateCookieName];

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
				}
			}

			if(isLastVisitDateValid)
			{
				// store in session object
				session.AddLastVisitDate(lastVisitDate);
			}

			// update date
			if(useEntityBasedLastVisitDateTracking || (user!=null && user.UserID != 0 && !user.LastVisitedDate.HasValue))
			{
				await UserManager.UpdateLastVisitDateForUserAsync(user.UserID);
			}

			// always write new cookie
			// cookie path is set to '/', to avoid path name casing mismatches. The cookie has a unique name anyway.
			context.Response.Cookies.Append(lastVisitDateCookieName, DateTime.Now.ToString("ddMMyyyyHHmm"),
											new CookieOptions()
											{
												Expires = new DateTimeOffset(DateTime.Now.AddYears(1)), 
												Path = "/",
												SameSite = SameSiteMode.Lax, 		
												HttpOnly = true			// no js accessibility
											});

			if(session.CheckIfNeedsAuditing(AuditActions.AuditLogin))
			{
				await SecurityManager.AuditLoginAsync(session.GetUserID());
			}
			
			// mark the session as initialized.
			session.SetInt32(SessionKeys.SessionInitialized, 1);
		}
		
		
        /// <summary>
        /// Loads the user and his rights and audits to the session object.
        /// </summary>
		/// <param name="session">The session the method works on</param>
        /// <param name="user">The user to be added to the session.</param>
        public static async Task LoadUserSessionDataAsync(this ISession session, UserEntity user)
        {
	        session.AddUserObject(user);
			session.AddSystemActionRights(await SecurityGuiHelper.GetSystemActionRightsForUserAsync(user.UserID));
			session.AddAuditActions(await SecurityGuiHelper.GetAuditActionsForUserAsync(user.UserID));
			session.AddForumsActionRights(await SecurityGuiHelper.GetForumsActionRightsForUserAsync(user.UserID));
			if((user.UserID > 0) && (user.LastVisitedDate.HasValue))
			{
				session.AddLastVisitDate(user.LastVisitedDate.Value);
			}
			else
			{
				session.AddLastVisitDate(DateTime.Now);
			}
        }


        /// <summary>
        /// Loads the anonymous user session data.
        /// </summary>
		/// <param name="session">The session the method works on</param>
        public static async Task LoadAnonymousSessionDataAsync(this ISession session)
        {
			session.AddForumsActionRights(await SecurityGuiHelper.GetForumsActionRightsForUserAsync(0));
        }


        /// <summary>
        /// Gets the forums action rights from the session.
        /// </summary>
		/// <param name="session">The session the method works on</param>
        /// <returns>Dictionary of ActionRightID as a key and List of forumIDs as the corresponding value, if available otherwise returns null.</returns>
        internal static MultiValueDictionary<int, int> GetForumsActionRights(this ISession session)
		{
			var rightsAsString = session.GetString(SessionKeys.ForumActionRights);
			return string.IsNullOrEmpty(rightsAsString) ? null : JsonConvert.DeserializeObject<MultiValueDictionary<int, int>>(rightsAsString);
		}

		
        /// <summary>
        /// Adds the lastVisitDate & isLastVisitDateValid to the session.
        /// </summary>
		/// <param name="session">The session the method works on</param>
        /// <param name="lastVisitDate">The last visit date.</param>
        public static void AddLastVisitDate(this ISession session, DateTime lastVisitDate)
        {
			session.SetString(SessionKeys.LastVisitedDateTickValue, lastVisitDate.Ticks.ToString());
        }


		/// <summary>
		/// Adds the search terms and results to the session.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="cache">The cache to store the results in</param>
		/// <param name="searchTerms">A string of search terms.</param>
		/// <param name="searchResults">A dataTable of search results.</param>
		public static void AddSearchTermsAndResults(this ISession session, IMemoryCache cache, string searchTerms, List<SearchResultRow> searchResults)
        {
			var resultsToCache = new SearchResultsWrapper() {SearchResults = searchResults, SearchTerms = searchTerms};
			var key = Guid.NewGuid().ToString();
			// cache the results for 10 minutes.
			cache.Set(key, resultsToCache, new TimeSpan(0, ApplicationAdapter.GetMaxNumberOfMinutesToCacheSearchResults(), 0));
			// cache the key in the session so we can find back the actual results in the cache!
			session.SetString(SessionKeys.SearchResultsKey, key);
		}
		

        /// <summary>
        /// Gets the search terms.
        /// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="cache">The cache to store the results in</param>
        /// <returns>string of search terms, and an empty string if no such value is present in the session</returns>
        public static string GetSearchTerms(this ISession session, IMemoryCache cache)
		{
			return SessionAdapter.GetSearchResultsFromCache(session, cache)?.SearchTerms ?? string.Empty;
		}

		
        /// <summary>
        /// Gets the search results.
        /// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="cache">The cache to store the results in</param>
        /// <returns>A list of search result rows if present, or null if no such value is present in the session</returns>
        public static List<SearchResultRow> GetSearchResults(this ISession session, IMemoryCache cache)
		{
			return SessionAdapter.GetSearchResultsFromCache(session, cache)?.SearchResults;
		}


		private static SearchResultsWrapper GetSearchResultsFromCache(ISession session, IMemoryCache cache)
		{
			var key = session.GetString(SessionKeys.SearchResultsKey) ?? string.Empty;
			if(string.IsNullOrEmpty(key))
			{
				return null;
			}
			var toReturn = cache.Get<SearchResultsWrapper>(key);
			if(toReturn == null)
			{
				// cached data has expired. Remove key
				session.Remove(SessionKeys.SearchResultsKey);
			}
			return toReturn;
		}


		/// <summary>
		/// Adds the forums action rights collection to the session.
		/// If the object already exists, it is overwritten with the new value.
		/// The user can be in various Roles. Each role has 0 or more actionrights assigned to it for each forum. An action right which can be applied to 
		/// a forum can be for example 'access forum'. These relations are stored in TF_ForumRoleForumActionRight. The user's session object 
		/// keeps a list of forum - actionrights tuples so the system can quickly check if the user has a given action right assigned to it for a given forum. 
		/// It does that by storing for each actionrightID a list of forumIDs the user has that actionrightID applied to it. 
		/// To check if a user then for example has the access forum right for a given forum is easy: if the
		/// user has the access forum right assigned to it via a role, is the forum in the list of forums? if not, the user doesn't have the right for the
		/// forum, otherwise s/he has the right. 
		/// This routine reads forum - actionrights combinations and stores them in the dictionary 
		/// forumsActionRightsInSession, which is stored in the user's Session object under 'forumsActionRights' 
		/// which keeps per ActionRightID a list of ForumIDs. 
		/// Since in general the number of Action Rights will be less than the number of forums, we decided to group forum IDs per each action right.
		/// An example: A "Power User" Role, has "Access Forum" Action right for the following Forums: 1,3,4 and 8, then in the collection of the 
		/// action right 'Access forum', the ForumIDs 1, 3, 4, and 8 are placed. 
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="forumsActionRights">The action rights.</param>
		private static void AddForumsActionRights(this ISession session, EntityCollection<ForumRoleForumActionRightEntity> forumsActionRights)
		{
			var forumsActionRightsInSession = new MultiValueDictionary<int, int>();

			// For each forumActionRight returned from the database, which contains a forum-actionright combination, we store it in the structure
			// for forum-actionrights, if it's not already present. We only store ActionRightIDs and ForumIDs, as the forum code uses these ids to check if a user
			// has a given action right for a given forum, which are also numbers, and storing entities wouldn't make much sense in this case, as it would only
			// increase memory usage. 
			foreach(ForumRoleForumActionRightEntity forumActionRight in forumsActionRights)
			{
				forumsActionRightsInSession.Add(forumActionRight.ActionRightID, forumActionRight.ForumID);
			}
			session.SetString(SessionKeys.ForumActionRights, JsonConvert.SerializeObject(forumsActionRightsInSession));
		}
	}
}