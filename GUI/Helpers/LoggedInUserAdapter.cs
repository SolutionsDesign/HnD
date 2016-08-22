using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.Gui
{
	/// <summary>
	/// Class which gives access to the data of the logged in user. 
	/// </summary>
	public static class LoggedInUserAdapter
	{
		/// <summary>
		/// Adds the user object to session.
		/// If the object already exists, it is overwritten with the new value.
		/// </summary>
		/// <param name="user">The user object to be saved</param>
		public static void AddUserObject(UserEntity user)
		{
			HttpContext.Current.Session.Add("user", user);
		}


		/// <summary>
		/// Gets the user object from session.
		/// </summary>
		/// <returns>User Entity object if found, otherwise returns null</returns>
		private static UserEntity GetUserObject()
		{
			return HttpContext.Current.Session["user"] as UserEntity;
		}


		/// <summary>
		/// Gets the user ID from session.
		/// </summary>
		/// <returns>UserID if there is a user object in the session, otherwise returns Zero</returns>
		public static int GetUserID()
		{
			UserEntity user = GetUserObject();
			return user == null ? 0 : user.UserID;
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
			return user == null ? 0 : user.UserTitleID;
		}


		/// <summary>
		/// Gets user nick name from the session.
		/// </summary>
		/// <returns>User nick name</returns>
		public static string GetUserNickName()
		{
			UserEntity user = GetUserObject();
			return user == null ? string.Empty : user.NickName;
		}


		/// <summary>
		/// Gets the user preference DefaultNumberOfMessagesPerPage for the current user
		/// </summary>
		/// <returns>the default # of messages per page as set by this user.</returns>
		public static int GetUserDefaultNumberOfMessagesPerPage()
		{
			UserEntity user = GetUserObject();
			if(user == null)
			{
				return ApplicationAdapter.GetMaxAmountMessagesPerPage();
			}
			int toReturn = user.DefaultNumberOfMessagesPerPage;
			return toReturn <= 0 ? ApplicationAdapter.GetMaxAmountMessagesPerPage() : toReturn;
		}


		/// <summary>
		/// Gets the user preference AutoSubscribeToThread for the current user
		/// </summary>
		/// <returns>the user preference if the user wants to subscribe to a thread automatically or not.</returns>
		public static bool GetUserAutoSubscribeToThread()
		{
			UserEntity user = GetUserObject();
			return user != null && user.AutoSubscribeToThread;
		}

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
			return HasSystemActionRight(ActionRights.QueueContentManagement);
		}


		/// <summary>
		/// Determines whether the active user can approve in at least one forum attachments on posts.
		/// </summary>
		/// <returns></returns>
		public static bool CanApproveAttachment()
		{
			var forumsWithApprovalRight = GetForumsWithActionRight(ActionRights.ApproveAttachment);
			return ((forumsWithApprovalRight != null) && (forumsWithApprovalRight.Count > 0));
		}


		/// <summary>
		/// Determines whether the user can administrate the system in one way or the other.
		/// </summary>
		/// <returns>true if the user can administrate system, user or security</returns>
		public static bool CanAdministrate()
		{
			var actionRights = GetSystemActionRights();
			if((actionRights == null) || (actionRights.Count <= 0))
			{
				return false;
			}
			var rightsRequired = new HashSet<int>() { (int)ActionRights.SystemManagement, (int)ActionRights.SecurityManagement, (int)ActionRights.UserManagement };
			return actionRights.Any(a => rightsRequired.Contains(a.ActionRightID));
		}


		/// <summary>
		/// Determines whether there are system action rights in the session.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if system action rights exist in the session; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasSystemActionRights()
		{
			var actionRights = GetSystemActionRights();
			if(actionRights != null)
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
			var actionRights = GetSystemActionRights();
			if(actionRights != null && actionRights.Count > 0)
			{
				return (actionRights.Any(a=>a.ActionRightID == (int)actionRightID));
			}
			return false;
		}


		/// <summary>
		/// Adds the system action rights collection to the session.
		/// If the object already exists, it is overwritten with the new value.
		/// </summary>
		/// <param name="actionRights">The action rights.</param>
		internal static void AddSystemActionRights(EntityCollection<ActionRightEntity> actionRights)
		{
			HttpContext.Current.Session.Add("systemActionRights", actionRights);
		}


		/// <summary>
		/// Gets the system action rights from the session.
		/// </summary>
		/// <returns>collection with action rights if available otherwise returns null.</returns>
		internal static EntityCollection<ActionRightEntity> GetSystemActionRights()
		{
			return HttpContext.Current.Session["systemActionRights"] as EntityCollection<ActionRightEntity>;
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
			var forumActionRights = SessionAdapter.GetForumsActionRights();
			return forumActionRights != null && forumActionRights.Contains((int)actionRightID, forumID);
		}


		/// <summary>
		/// Gets the forums to which the user has the specified action right.
		/// </summary>
		/// <param name="actionRightID">The action right ID.</param>
		/// <returns>List of forums IDs</returns>
		public static List<int> GetForumsWithActionRight(ActionRights actionRightID)
		{
			var forumActionRights = SessionAdapter.GetForumsActionRights();
			if(forumActionRights == null)
			{
				return null;
			}
			var forumIDs = forumActionRights[(int)actionRightID];
			return forumIDs == null ? null : forumIDs.ToList();
		}


		/// <summary>
		/// Gets the isLastVisitDateValid stored in the session object.
		/// </summary>
		/// <returns>The boolean value if available otherwise returns false as the default value.</returns>
		public static bool IsLastVisitDateValid()
		{
			var toReturn = HttpContext.Current.Session["isLastVisitDateValid"];
			return toReturn == null ? false : (bool)toReturn;
		}


		/// <summary>
		/// Gets the last visit date stored in the session object.
		/// </summary>
		/// <returns>DateTime of last visit date if available, otherwise returns DateTime.MinValue</returns>
		public static DateTime GetLastVisitDate()
		{
			var toReturn = HttpContext.Current.Session["lastVisitDate"];
			return toReturn==null ? DateTime.MinValue : (DateTime)toReturn;
		}
	}
}