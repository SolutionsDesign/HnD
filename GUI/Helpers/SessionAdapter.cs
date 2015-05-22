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
using System;
using System.Data;
using System.Web;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.BL;
using System.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui
{
    /// <summary>
    /// SessionAdapter is used to access session objects
    /// </summary>
    public static class SessionAdapter
    {
        /// <summary>
        /// Cancels the current Session.
        /// </summary>
        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
        

        /// <summary>
        /// Loads the user and his rights and audits to the session object.
        /// </summary>
        /// <param name="user">The user to be added to the session.</param>
        public static void LoadUserSessionData(UserEntity user)
        {
	        LoggedInUserAdapter.AddUserObject(user);
			ActionRightCollection systemActionRights = SecurityGuiHelper.GetSystemActionRightsForUser(user.UserID);
            LoggedInUserAdapter.AddSystemActionRights(systemActionRights);
			AuditActionCollection auditActions = SecurityGuiHelper.GetAuditActionsForUser(user.UserID);
	        AuditingAdapter.AddAuditActions(auditActions);
			ForumRoleForumActionRightCollection forumActionRights = SecurityGuiHelper.GetForumsActionRightsForUser(user.UserID);
            AddForumsActionRights(forumActionRights);
			if((user.UserID > 0) && (user.LastVisitedDate.HasValue))
			{
				SessionAdapter.AddLastVisitDate(user.LastVisitedDate.Value, true);
			}
			else
			{
				SessionAdapter.AddLastVisitDate(DateTime.Now, true);
			}
        }


        /// <summary>
        /// Loads the anonymous user session data.
        /// </summary>
        public static void LoadAnonymousSessionData()
        {
			ForumRoleForumActionRightCollection forumActionRights = SecurityGuiHelper.GetForumsActionRightsForUser(0); // 0 is the the Anonymous userID.
            AddForumsActionRights(forumActionRights);
        }


        /// <summary>
        /// Gets the forums action rights from the session.
        /// </summary>
        /// <returns>Dictionary of ActionRightID as a key and List of forumIDs as the corresponding value, if available otherwise returns null.</returns>
        internal static MultiValueHashtable<int, int> GetForumsActionRights()
        {
            return HttpContext.Current.Session["forumsActionRights"] as MultiValueHashtable<int, int>;
        }

        /// <summary>
        /// Adds the lastVisitDate & isLastVisitDateValid to the session.
        /// </summary>
        /// <param name="lastVisitDate">The last visit date.</param>
        /// <param name="isLastVisitDateValid">boolean to determine the validity of the last visit date</param>
        public static void AddLastVisitDate(DateTime lastVisitDate, bool isLastVisitDateValid)
        {
            HttpContext.Current.Session.Add("lastVisitDate", lastVisitDate);
            HttpContext.Current.Session.Add("isLastVisitDateValid", isLastVisitDateValid);
        }

        /// <summary>
        /// Adds the search terms and results to the session.
        /// </summary>
        /// <param name="searchTerms">A string of search terms.</param>
        /// <param name="searchResults">A dataTable of search results.</param>
        public static void AddSearchTermsAndResults(string searchTerms, DataTable searchResults)
        {
            HttpContext.Current.Session.Add("searchTerms", searchTerms);
            HttpContext.Current.Session.Add("searchResults", searchResults);
        }

        /// <summary>
        /// Gets the search terms.
        /// </summary>
        /// <returns>string of search terms, and an empty string if no such value is present in the session</returns>
        public static string GetSearchTerms()
        {
	        return (HttpContext.Current.Session["searchTerms"] as string) ?? string.Empty;
        }

        /// <summary>
        /// Gets the search results.
        /// </summary>
        /// <returns>A dataTable of search results, and null if no such value is present in the session</returns>
        public static DataTable GetSearchResults()
        {
	        return HttpContext.Current.Session["searchResults"] as DataTable;
        }


		/// <summary>
		/// Sets a temporary result in the session. The value is meant to be temporary.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public static void SetTempResult<T>(string key, T value)
		{
			HttpContext.Current.Session[key] = value;
		}


		/// <summary>
		/// Gets the temp result for the key specified from the session. It casts the value to the generic type T. 
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>the value stored in the session under the key specified, and cast to the type T. Is the default value for T key wasn't found</returns>
		public static T GetTempResult<T>(string key)
		{
			object value = HttpContext.Current.Session[key];
			if(value == null)
			{
				return default(T);
			}
			return (T)value;
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
		/// An example: A "Power User" Role, has "Access Forum" Action right for the followoing Forums: 1,3,4 and 8, then in the collection of the 
		/// action right 'Access forum', the ForumIDs 1, 3, 4, and 8 are placed. 
		/// </summary>
		/// <param name="forumsActionRights">The action rights.</param>
		private static void AddForumsActionRights(ForumRoleForumActionRightCollection forumsActionRights)
		{
			var forumsActionRightsInSession = new MultiValueHashtable<int, int>();

			// For each forumActionRight returned from the database, which contains a forum-actionright combination, we store it in the structure
			// for forum-actionrights, if it's not already present. We only store ActionRightIDs and ForumIDs, as the forum code uses these ids to check if a user
			// has a given action right for a given forum, which are also numbers, and storing entities wouldn't make much sense in this case, as it would only
			// increase memory usage. 
			foreach(ForumRoleForumActionRightEntity forumActionRight in forumsActionRights)
			{
				forumsActionRightsInSession.Add(forumActionRight.ActionRightID, forumActionRight.ForumID);
			}
			HttpContext.Current.Session.Add("forumsActionRights", forumsActionRightsInSession);
		}
	}
}