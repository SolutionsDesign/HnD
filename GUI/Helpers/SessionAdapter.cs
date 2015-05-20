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
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.BL;
using SD.HnD.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.HelperClasses;

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
            // Adds the user object to session
            AddUserObject(user);

			ActionRightCollection systemActionRights = SecurityGuiHelper.GetSystemActionRightsForUser(user.UserID);
            // add user system rights to the session object
            AddSystemActionRights(systemActionRights);

			AuditActionCollection auditActions = SecurityGuiHelper.GetAuditActionsForUser(user.UserID);
			// add user audit actions to the session object
            AddAuditActions(auditActions);

			ForumRoleForumActionRightCollection forumActionRights = SecurityGuiHelper.GetForumsActionRightsForUser(user.UserID);
            // add user forums rights to the session object
            AddForumsActionRights(forumActionRights);

			// set the last visit date. 
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
            // add user forums rights to the session object
            AddForumsActionRights(forumActionRights);
        }

        #region Managing UserEntity Session object
        /// <summary>
        /// Adds the user object to session.
        /// If the object already exists, it is overwritten with the new value.
        /// </summary>
        /// <param name="user">The user object to be saved</param>
        public static void AddUserObject(UserEntity user)
        {
            //Adds a new item to the session-state collection.
            //If the name parameter refers to an existing session state item, the existing item is overwritten with the specified value.
            HttpContext.Current.Session.Add("user", user);
        }

        /// <summary>
        /// Gets the user object from session.
        /// </summary>
        /// <returns>User Entity object if found, otherwise returns null</returns>
        private static UserEntity GetUserObject()
        {
            if (HttpContext.Current.Session["user"] != null)
            {
                return (UserEntity)HttpContext.Current.Session["user"];
            }

            return null;
        }

        /// <summary>
        /// Gets the user ID from session.
        /// </summary>
        /// <returns>UserID if there is a user object in the session, otherwise returns Zero</returns>
        public static int GetUserID()
        {
            UserEntity user = GetUserObject();
            if (user != null)
            {
                return user.UserID;
            }

            return 0;
        }


		/// <summary>
		/// Returns true if the user controlled by the session is the anonymous user. It checks the userid, not authentication. 
		/// </summary>
		/// <returns>true if the user object in this session is of the anonymous user.</returns>
	    public static bool IsAnonymousUser()
	    {
		    return GetUserID() <= 0;
	    }


		/// <summary>
		/// Gets the user title ID.
		/// </summary>
		/// <returns></returns>
		public static int GetUserTitleID()
		{
			UserEntity user = GetUserObject();
			if(user != null)
			{
				return user.UserTitleID;
			}

			return 0;
		}

        /// <summary>
        /// Gets user nick name from the session.
        /// </summary>
        /// <returns>User nick name</returns>
        public static string GetUserNickName()
        {
            UserEntity user = GetUserObject();
            if (user != null)
            {
                return user.NickName;
            }
            return string.Empty;
        }

		/// <summary>
		/// Gets the user preference DefaultNumberOfMessagesPerPage for the current user
		/// </summary>
		/// <returns>the default # of messages per page as set by this user.</returns>
		public static int GetUserDefaultNumberOfMessagesPerPage()
		{
			UserEntity user = GetUserObject();
			if(user != null)
			{
				int toReturn = user.DefaultNumberOfMessagesPerPage;
				if(toReturn <= 0)
				{
					return ApplicationAdapter.GetMaxAmountMessagesPerPage();
				}
				else
				{
					return toReturn;
				}
			}

			return ApplicationAdapter.GetMaxAmountMessagesPerPage();
		}

		/// <summary>
		/// Gets the user preference AutoSubscribeToThread for the current user
		/// </summary>
		/// <returns>the user preference if the user wants to subscribe to a thread automatically or not.</returns>
		public static bool GetUserAutoSubscribeToThread()
		{
			UserEntity user = GetUserObject();
			if(user != null)
			{
				return user.AutoSubscribeToThread;
			}

			return false;

		}

        #endregion

        #region Managing SystemActionRights Session object
		/// <summary>
		/// Helper method which returns true if the Adminstrate menu should show, which is the case if the user can administrate or approve an attachment or can do queue content management.
		/// </summary>
		/// <returns></returns>
	    public static bool ShouldSeeAdministrateMenu()
	    {
		    return CanAdministrate() || CanApproveAttachment() || CanDoQueueContentMangement();
	    }


		/// <summary>
		/// Determines whether the active user can perform queue content management
		/// </summary>
		/// <returns></returns>
		public static bool CanDoQueueContentMangement()
		{
			return SessionAdapter.HasSystemActionRight(ActionRights.QueueContentManagement);
		}


		/// <summary>
		/// Determines whether the active user can approve in at least one forum attachments on posts.
		/// </summary>
		/// <returns></returns>
		public static bool CanApproveAttachment()
		{
			var forumsWithApprovalRight = SessionAdapter.GetForumsWithActionRight(ActionRights.ApproveAttachment);
			return ((forumsWithApprovalRight != null) && (forumsWithApprovalRight.Count > 0));
		}


		/// <summary>
		/// Determines whether the user can administrate the system in one way or the other.
		/// </summary>
		/// <returns>true if the user can administrate system, user or security</returns>
		public static bool CanAdministrate()
		{
			ActionRightCollection actionRights = GetSystemActionRights();
			if((actionRights == null) || (actionRights.Count <= 0))
			{
				return false;
			}
			// use FindMatches to determine if there are actionrights present which allow administation.
			List<int> toFind = new List<int>();
			toFind.Add((int)ActionRights.SystemManagement);
			toFind.Add((int)ActionRights.SecurityManagement);
			toFind.Add((int)ActionRights.UserManagement);

			return (actionRights.FindMatches((ActionRightFields.ActionRightID == toFind)).Count > 0);
		}


        /// <summary>
        /// Determines whether there are system action rights in the session.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if system action rights exist in the session; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasSystemActionRights()
        {
            ActionRightCollection actionRights = GetSystemActionRights();
            if (actionRights != null)
            {
                return (actionRights.Count > 0);
            }

            return false;
        }

        /// <summary>
        /// Checks if the user of the current context(session) has the ability to perform the action right on the system.
        /// If this is correct, true is returned, otherwise false.
        /// </summary>
        /// <param name="actionRightID">Actionright to check. This is a system action right</param>
        /// <returns>True if the user of the current context is allowed to perform the action right on the 
        /// system, false otherwise.</returns>
        public static bool HasSystemActionRight(ActionRights actionRightID)
        {
            ActionRightCollection actionRights = GetSystemActionRights();
            if (actionRights != null && actionRights.Count > 0)
            {
				// use the FindMatches routine to find all entities which match with the filter on the specified actionrightid
				return (actionRights.FindMatches((ActionRightFields.ActionRightID == (int)actionRightID)).Count > 0);
            }

            return false;
        }


		/// <summary>
		/// Adds the system action rights collection to the session.
		/// If the object already exists, it is overwritten with the new value.
		/// </summary>
		/// <param name="actionRights">The action rights.</param>
		private static void AddSystemActionRights(ActionRightCollection actionRights)
		{
			//Adds a new item to the session-state collection.
			//If the name parameter refers to an existing session state item, the existing item is overwritten with the specified value.
			HttpContext.Current.Session.Add("systemActionRights", actionRights);
		}


		/// <summary>
		/// Gets the system action rights from the session.
		/// </summary>
		/// <returns>ActionRightCollection if available otherwise returns null.</returns>
		private static ActionRightCollection GetSystemActionRights()
		{
			if(HttpContext.Current.Session["systemActionRights"] != null)
			{
				return (ActionRightCollection)HttpContext.Current.Session["systemActionRights"];
			}

			return null;
		}
        #endregion

        #region Managing AuditActions Session object

        /// <summary>
        /// Adds the audit actions collection to the session.
        /// If the object already exists, it is overwritten with the new value.
        /// </summary>
        /// <param name="actionRights">The action rights.</param>
        private static void AddAuditActions(AuditActionCollection auditActions)
        {
            //Adds a new item to the session-state collection.
            //If the name parameter refers to an existing session state item, the existing item is overwritten with the specified value.
            HttpContext.Current.Session.Add("auditActions", auditActions);
        }

        /// <summary>
        /// Gets the audit actions from the session.
        /// </summary>
        /// <returns>AuditActionCollection if available otherwise returns null.</returns>
        private static AuditActionCollection GetAuditActions()
        {
            if (HttpContext.Current.Session["auditActions"] != null)
            {
                return (AuditActionCollection)HttpContext.Current.Session["auditActions"];
            }
            return null;
        }

        /// <summary>
        /// Checks if the current user needs auditing for the action specified
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>true if the user needs auditing, otherwise false</returns>
        public static bool CheckIfNeedsAuditing(AuditActions auditActionID)
        {
            AuditActionCollection auditActions = GetAuditActions();
            if (auditActions != null && auditActions.Count > 0)
            {
                // create an ActionRight entity, and forcing the PK value, to avoid fetching it from the database.
                AuditActionEntity auditAction = new AuditActionEntity();
                auditAction.Fields[(int)AuditActionFieldIndex.AuditActionID].ForcedCurrentValueWrite((int)auditActionID);
                auditAction.IsNew = false;

                return auditActions.Contains(auditAction);
            }

            return false;
        }
        #endregion

        #region Managing ForumsActionRights Session object
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
            // create a dictionary that will be stored in the session
            Dictionary<int, List<int>> forumsActionRightsInSession = new Dictionary<int, List<int>>();

            // For each forumActionRight returned from the database, which contains a forum-actionright combination, we store it in the structure
            // for forum-actionrights, if it's not already present. We only store ActionRightIDs and ForumIDs, as the forum code uses these ids to check if a user
            // has a given action right for a given forum, which are also numbers, and storing entities wouldn't make much sense in this case, as it would only
            // increase memory usage. 
            foreach (ForumRoleForumActionRightEntity forumActionRight in forumsActionRights)
            {
                List<int> forumIDs;

                // check if the dictionary already contains a KeyValuePair with the specified ActionRightID key
                if (!forumsActionRightsInSession.TryGetValue(forumActionRight.ActionRightID, out forumIDs))
                {
                    // if not then add a a KeyValuePair to the dictionary with the specified ActionRightID key
                    forumIDs = new List<int>();
                    forumsActionRightsInSession.Add(forumActionRight.ActionRightID, forumIDs);
                }

                // Check if the List of forum IDs associated with the specified Action Right ID already contains the forumID
                if (!forumIDs.Contains(forumActionRight.ForumID))
                {
                    // the list does not contain the forumID -> Add the forumID to the List of forum IDs.
                    forumIDs.Add(forumActionRight.ForumID);
                }
            }

            //Adds a new item to the session-state collection.
            //If the name parameter refers to an existing session state item, the existing item is overwritten with the specified value.
            HttpContext.Current.Session.Add("forumsActionRights", forumsActionRightsInSession);
        }

        /// <summary>
        /// Gets the forums action rights from the session.
        /// </summary>
        /// <returns>Dictionary of ActionRightID as a key and List of forumIDs as the corresponding value, if available otherwise returns null.</returns>
        private static Dictionary<int, List<int>> GetForumsActionRights()
        {
            if (HttpContext.Current.Session["forumsActionRights"] != null)
            {
                return (Dictionary<int, List<int>>)HttpContext.Current.Session["forumsActionRights"];
            }
            return null;
        }

        /// <summary>
        /// Checks if the user of the current context has the ability to perform the action right given
        /// on the forum given. If this is correct, true is returned, otherwise false.
        /// </summary>
        /// <param name="forumID">Forum to check</param>
        /// <param name="actionRightID">Actionright to check on forum</param>
        /// <returns>True if the user of the current context is allowed to perform the action right on the 
        /// forum given, false otherwise.</returns>
        public static bool CanPerformForumActionRight(int forumID, ActionRights actionRightID)
        {
            // Get the dictionary of ForumActionRights from the session.
            Dictionary<int, List<int>> forumActionRights = GetForumsActionRights();

            if (forumActionRights != null)
            {
                // if there is an forumActionRights dictionary in the session
                List<int> forumIDs;

                // check if the dictionary contains a KeyValuePair with the specified ActionRightID key
                if (forumActionRights.TryGetValue((int)actionRightID, out forumIDs))
                {
                    // Check if the List of forum IDs associated with the specified Action Right ID already contains the forumID
                    if (forumIDs.Contains(forumID))
                    {
                        // the list contains the forumID
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the forums to which the user has the specified action right.
        /// </summary>
        /// <param name="actionRightID">The action right ID.</param>
        /// <returns>List of forums IDs</returns>
        public static List<int> GetForumsWithActionRight(ActionRights actionRightID)
        {
            // Get the dictionary of ForumActionRights from the session.
            Dictionary<int, List<int>> forumActionRights = GetForumsActionRights();

            if (forumActionRights != null)
            {
                // if there is an forumActionRights dictionary in the session
                List<int> forumIDs;

                // check if the dictionary contains a KeyValuePair with the specified ActionRightID key
                if (forumActionRights.TryGetValue((int)actionRightID, out forumIDs))
                {
                    return forumIDs;
                }
            }

            return null;
        }
        #endregion

        #region Managing LastVisitDate
        /// <summary>
        /// Adds the lastVisitDate & isLastVisitDateValid to the session.
        /// </summary>
        /// <param name="lastVisitDate">The last visit date.</param>
        /// <param name="isLastVisitDateValid">boolean to determine the validity of the last visit date</param>
        public static void AddLastVisitDate(DateTime lastVisitDate, bool isLastVisitDateValid)
        {
            //Adds a new item to the session-state collection.
            //If the name parameter refers to an existing session state item, the existing item is overwritten with the specified value.
            HttpContext.Current.Session.Add("lastVisitDate", lastVisitDate);
            HttpContext.Current.Session.Add("isLastVisitDateValid", isLastVisitDateValid);
        }

        /// <summary>
        /// Gets the isLastVisitDateValid stored in the session object.
        /// </summary>
        /// <returns>The boolean value if available otherwise returns false as the default value.</returns>
        public static bool IsLastVisitDateValid()
        {
            if (HttpContext.Current.Session["isLastVisitDateValid"] != null)
            {
                return (bool)HttpContext.Current.Session["isLastVisitDateValid"];
            }

            return false;
        }

        /// <summary>
        /// Gets the last visit date stored in the session object.
        /// </summary>
        /// <returns>DateTime of last visit date if available, otherwise returns DateTime.MinValue</returns>
        public static DateTime GetLastVisitDate()
        {
            if (HttpContext.Current.Session["lastVisitDate"] != null)
            {
                return (DateTime)HttpContext.Current.Session["lastVisitDate"];
            }

            return DateTime.MinValue;
        }

        #endregion

        #region Managing Search Terms and Results
        /// <summary>
        /// Adds the search terms and results to the session.
        /// </summary>
        /// <param name="searchTerms">A string of search terms.</param>
        /// <param name="searchResults">A dataTable of search results.</param>
        public static void AddSearchTermsAndResults(string searchTerms, DataTable searchResults)
        {
            //Adds a new item to the session-state collection.
            //If the name parameter refers to an existing session state item, the existing item is overwritten with the specified value.
            HttpContext.Current.Session.Add("searchTerms", searchTerms);
            HttpContext.Current.Session.Add("searchResults", searchResults);
        }

        /// <summary>
        /// Gets the search terms.
        /// </summary>
        /// <returns>string of search terms, and an empty string if no such value is present in the session</returns>
        public static string GetSearchTerms()
        {
            if (HttpContext.Current.Session["searchTerms"] != null)
            {
                return (string)HttpContext.Current.Session["searchTerms"];
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the search results.
        /// </summary>
        /// <returns>A dataTable of search results, and null if no such value is present in the session</returns>
        public static DataTable GetSearchResults()
        {
            if (HttpContext.Current.Session["searchResults"] != null)
            {
                return (DataTable)HttpContext.Current.Session["searchResults"];
            }

            return null;
        }

        #endregion

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
			else
			{
				return (T)value;
			}
		}
	}
}