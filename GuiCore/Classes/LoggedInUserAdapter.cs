using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.Gui.Classes;

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
		/// <param name="session">The session the method works on</param>
		/// <param name="user">The user object to be saved</param>
		public static void AddUserObject(this ISession session, UserEntity user)
		{
			// store the individual values as primitive values, as ASP.NET Core's session isn't as flexible as previous versions were.
			session.SetInt32(SessionKeys.UserId, user.UserID);
			session.SetInt32(SessionKeys.TitleId, user.UserTitleID);
			session.SetString(SessionKeys.NickName, user.NickName);
			session.SetInt32(SessionKeys.DefaultNumberOfMessagesPerPage, user.DefaultNumberOfMessagesPerPage);
			session.SetInt32(SessionKeys.AutoSubscribeToThread, user.AutoSubscribeToThread ? 1 : 0);
			session.SetInt32(SessionKeys.AmountOfPostings, user.AmountOfPostings ?? 0);
		}


		/// <summary>
		/// Gets the user ID from session.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>UserID if there is a user object in the session, otherwise returns Zero</returns>
		public static int GetUserID(this ISession session)
		{
			return session.GetInt32(SessionKeys.UserId) ?? 0;
		}


		/// <summary>
		/// Returns true if the user controlled by the session is the anonymous user. It checks the userid, not authentication. 
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>true if the user object in this session is of the anonymous user.</returns>
		public static bool IsAnonymousUser(this ISession session)
		{
			return session.GetUserID() <= 0;
		}


		/// <summary>
		/// Gets the user title ID.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns></returns>
		public static int GetUserTitleID(this ISession session)
		{
			return session.GetInt32(SessionKeys.TitleId) ?? 0;
		}


		/// <summary>
		/// Gets user nick name from the session.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>User nick name</returns>
		public static string GetUserNickName(this ISession session)
		{
			return session.GetString(SessionKeys.NickName) ?? string.Empty;
		}


		/// <summary>
		/// Gets the user preference DefaultNumberOfMessagesPerPage for the current user
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>the default # of messages per page as set by this user.</returns>
		public static int GetUserDefaultNumberOfMessagesPerPage(this ISession session)
		{
			int toReturn = session.GetInt32(SessionKeys.DefaultNumberOfMessagesPerPage) ?? 0;
			return toReturn <= 0 ? ApplicationAdapter.GetMaxAmountMessagesPerPage() : toReturn;
		}


		/// <summary>
		/// Gets the user preference AutoSubscribeToThread for the current user
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>the user preference if the user wants to subscribe to a thread automatically or not.</returns>
		public static bool GetUserAutoSubscribeToThread(this ISession session)
		{
			var toReturn = session.GetInt32(SessionKeys.AutoSubscribeToThread) ?? 0;
			return toReturn == 1;
		}

		/// <summary>
		/// Helper method which returns true if the Adminstrate menu should show, which is the case if the user can administrate or approve an attachment or can do queue content management.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns></returns>
		public static bool ShouldSeeAdministrateMenu(this ISession session)
		{
			return CanAdministrate(session) || CanApproveAttachment(session) || CanDoQueueContentMangement(session);
		}


		/// <summary>
		/// Determines whether the active user can perform queue content management
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns></returns>
		public static bool CanDoQueueContentMangement(this ISession session)
		{
			return HasSystemActionRight(session, ActionRights.QueueContentManagement);
		}


		/// <summary>
		/// Determines whether the active user can approve in at least one forum attachments on posts.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns></returns>
		public static bool CanApproveAttachment(this ISession session)
		{
			var forumsWithApprovalRight = GetForumsWithActionRight(session, ActionRights.ApproveAttachment);
			return ((forumsWithApprovalRight != null) && (forumsWithApprovalRight.Count > 0));
		}


		/// <summary>
		/// Determines whether the user can administrate the system in one way or the other.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>true if the user can administrate system, user or security</returns>
		public static bool CanAdministrate(this ISession session)
		{
			var actionRights = GetSystemActionRights(session);
			if((actionRights == null) || (actionRights.Length <= 0))
			{
				return false;
			}
			var rightsRequired = new HashSet<int>() { (int)ActionRights.SystemManagement, (int)ActionRights.SecurityManagement, (int)ActionRights.UserManagement };
			return actionRights.Any(a => rightsRequired.Contains(a));
		}


		/// <summary>
		/// Determines whether there are system action rights in the session.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>
		/// 	<c>true</c> if system action rights exist in the session; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasSystemActionRights(this ISession session)
		{
			return session.GetSystemActionRights()?.Length > 0;
		}

		/// <summary>
		/// Checks if the user of the current context(session) has the ability to perform the action right on the system.
		/// If this is correct, true is returned, otherwise false.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="actionRightID">Actionright to check. This is a system action right</param>
		/// <returns>True if the user of the current context is allowed to perform the action right on the 
		/// system, false otherwise.</returns>
		public static bool HasSystemActionRight(this ISession session, ActionRights actionRightID)
		{
			var actionRights = session.GetSystemActionRights();
			if(actionRights != null && actionRights.Length > 0)
			{
				return actionRights.Contains((int)actionRightID);
			}
			return false;
		}


		/// <summary>
		/// Adds the system action rights collection to the session.
		/// If the object already exists, it is overwritten with the new value.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="actionRights">The action rights.</param>
		internal static void AddSystemActionRights(this ISession session, EntityCollection<ActionRightEntity> actionRights)
		{
			var idsToStore = actionRights.Select(e => e.ActionRightID).ToArray();
			var toStore = JsonConvert.SerializeObject(idsToStore);
			session.SetString(SessionKeys.SystemActionRights, toStore);
		}


		/// <summary>
		/// Gets the system action rights from the session.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>array with action right id's if available otherwise returns null.</returns>
		internal static int[] GetSystemActionRights(this ISession session)
		{
			var rightsAsString = session.GetString(SessionKeys.SystemActionRights);
			return string.IsNullOrEmpty(rightsAsString) ? null : JsonConvert.DeserializeObject<int[]>(rightsAsString);
		}


		/// <summary>
		/// Checks if the user of the current context has the ability to perform the action right given
		/// on the forum given. If this is correct, true is returned, otherwise false.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="forumID">Forum to check</param>
		/// <param name="actionRightID">Actionright to check on forum</param>
		/// <returns>True if the user of the current context is allowed to perform the action right on the 
		/// forum given, false otherwise.</returns>
		public static bool CanPerformForumActionRight(this ISession session, int forumID, ActionRights actionRightID)
		{
			var forumActionRights = session.GetForumsActionRights();
			return forumActionRights != null && forumActionRights.ContainsValue((int)actionRightID, forumID);
		}


		/// <summary>
		/// Gets the forums to which the user has the specified action right.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="actionRightID">The action right ID.</param>
		/// <returns>List of forums IDs</returns>
		public static List<int> GetForumsWithActionRight(this ISession session, ActionRights actionRightID)
		{
			var forumActionRights = session.GetForumsActionRights();
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
		/// <param name="session">The session the method works on</param>
		/// <returns>The boolean value if available otherwise returns false as the default value.</returns>
		public static bool IsLastVisitDateValid(this ISession session)
		{
			var lastVisitDateValue = session.GetString(SessionKeys.LastVisitedDateTickValue);
			return !string.IsNullOrEmpty(lastVisitDateValue);
		}


		/// <summary>
		/// Gets the last visit date stored in the session object.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>DateTime of last visit date if available, otherwise returns DateTime.MinValue</returns>
		public static DateTime GetLastVisitDate(this ISession session)
		{
			var lastVisitDateValue = session.GetString(SessionKeys.LastVisitedDateTickValue);
			if(string.IsNullOrEmpty(lastVisitDateValue))
			{
				return DateTime.MinValue;
			}
			// is tickcount
			var lastVisitDateAsLong = long.Parse(lastVisitDateValue);
			return new DateTime(lastVisitDateAsLong);
		}
	}
}