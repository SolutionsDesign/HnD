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
using System.Text;
using System.Collections;

using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.FactoryClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the User gui
	/// </summary>
	public static class UserGuiHelper
	{
		/// <summary>
		/// Gets the bookmark statistics for the user with id passed in.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <returns></returns>
		public static DataTable GetBookmarkStatisticsAsDataTable(int userID)
		{
			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(BookmarkFields.ThreadID.CountDistinct().As("AmountThreads"),
								MessageFields.MessageID.Count().As("AmountPostings"),
								ThreadFields.ThreadLastPostingDate.Max().As("LastPostingDate"))
						.From(qf.Bookmark
								.InnerJoin(qf.Thread).On(BookmarkFields.ThreadID == ThreadFields.ThreadID)
								.InnerJoin(qf.Message).On(ThreadFields.ThreadID == MessageFields.ThreadID))
						.Where(BookmarkFields.UserID == userID);
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchAsDataTable(q);
			}
		}


		/// <summary>
		/// Gets all the banned users as a dataview. This is returned as a dataview because only the nicknames are required, so a dynamic list is
		/// used to avoid unnecessary data fetching.
		/// </summary>
		/// <returns>dataview with the nicknames of the users which are banned on the useraccount: the IsBanned property is set for these users.</returns>
		/// <remarks>This list of nicknames is cached in the application object so these users can be logged off by force.</remarks>
		public static DataView GetAllBannedUserNicknamesAsDataView()
		{
			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(UserFields.NickName)
						.Where(UserFields.IsBanned == true);
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchAsDataTable(q).DefaultView;
			}
		}


		/// <summary>
		/// Gets the last n threads in which the user specified participated with one or more messages. Threads which aren't visible for the
		/// calling user are filtered out.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user calling the method has permission to access.</param>
		/// <param name="participantUserID">The participant user ID of the user of which the threads have to be obtained.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="callingUserID">The calling user ID.</param>
		/// <param name="amount">The amount of threads to fetch.</param>
		/// <returns>a dataView of the threads requested</returns>
		public static DataView GetLastThreadsForUserAsDataView(List<int> accessableForums, int participantUserID, List<int> forumsWithThreadsFromOthers, int callingUserID, int amount)
		{
			return GetLastThreadsForUserAsDataView(accessableForums, participantUserID, forumsWithThreadsFromOthers, callingUserID, amount, 0);
		}


		/// <summary>
		/// Gets the last pageSize threads in which the user specified participated with one or more messages for the page specified. 
		/// Threads which aren't visible for the calling user are filtered out. If pageNumber is 0, pageSize is used to limit the list to the pageSize
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user calling the method has permission to access.</param>
		/// <param name="participantUserID">The participant user ID of the user of which the threads have to be obtained.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="callingUserID">The calling user ID.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number to fetch.</param>
		/// <returns>a dataView of the threads requested</returns>
		public static DataView GetLastThreadsForUserAsDataView(List<int> accessableForums, int participantUserID, List<int> forumsWithThreadsFromOthers, int callingUserID, 
																int pageSize, int pageNumber)
		{
			// return null, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return null;
			}

			int numberOfThreadsToFetch = pageSize;
			if(numberOfThreadsToFetch <= 0)
			{
				numberOfThreadsToFetch = 25;
			}

			var qf = new QueryFactory();
			var q = qf.Create()
							.Select(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStats(qf))
							.From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf))
							.Where((ThreadFields.ForumID == accessableForums)
									.And(ThreadFields.ThreadID.In(qf.Create()
																		.Select(MessageFields.ThreadID)
																		.Where(MessageFields.PostedByUserID == participantUserID)))
									.And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, callingUserID)))
							.OrderBy(ThreadFields.ThreadLastPostingDate.Descending());
			if(pageNumber <= 0)
			{
				// no paging
				// get the last numberOfThreadsToFetch, so specify a limit equal to the numberOfThreadsToFetch specified
				q.Limit(numberOfThreadsToFetch);
			}
			else
			{
				// use paging
				q.Page(pageNumber, numberOfThreadsToFetch);
			}
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchAsDataTable(q).DefaultView;
			}
		}


		/// <summary>
		/// Gets the row count for the set of threads in which the user specified participated with one or more messages for the page specified.
		/// Threads which aren't visible for the calling user are filtered out.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user calling the method has permission to access.</param>
		/// <param name="participantUserID">The participant user ID of the user of which the threads have to be obtained.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="callingUserID">The calling user ID.</param>
		/// <returns>a dataView of the threads requested</returns>
		public static int GetRowCountLastThreadsForUserAsDataView(List<int> accessableForums, int participantUserID, List<int> forumsWithThreadsFromOthers, int callingUserID)
		{
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return 0;
			}
			var qf = new QueryFactory();
			var q = qf.Create()
						  .Select(Functions.CountRow())
						  .From(
								qf.Create()
								  .Select(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStats(qf))
								  .From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf))
								  .Where((ThreadFields.ForumID == accessableForums)
											 .And(ThreadFields.ThreadID.In(qf.Create()
																			 .Select(MessageFields.ThreadID)
																			 .Where(MessageFields.PostedByUserID == participantUserID)))
											 .And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, callingUserID))));
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int>(q);
			}
		}

		
		/// <summary>
		/// Finds the users matching the filter criteria.
		/// </summary>
		/// <param name="filterOnRole"><see langword="true"/> if [filter on role]; otherwise, <see langword="false"/>.</param>
		/// <param name="roleID">Role ID.</param>
		/// <param name="filterOnNickName"><see langword="true"/> if [filter on nick name]; otherwise, <see langword="false"/>.</param>
		/// <param name="nickName">Name of the nick.</param>
		/// <param name="filterOnEmailAddress"><see langword="true"/> if [filter on email address]; otherwise, <see langword="false"/>.</param>
		/// <param name="emailAddress">Email address.</param>
		/// <returns>User objects matching the query</returns>
		public static EntityCollection<UserEntity> FindUsers(bool filterOnRole, int roleID, bool filterOnNickName, string nickName, bool filterOnEmailAddress, string emailAddress)
		{
			var qf = new QueryFactory();
			var q = qf.User
						.OrderBy(UserFields.NickName.Ascending());
			if(filterOnRole)
			{
				q.AndWhere(UserFields.UserID.In(qf.Create().Select(RoleUserFields.UserID).Where(RoleUserFields.RoleID == roleID)));
			}
			if(filterOnNickName)
			{
				q.AndWhere(UserFields.NickName.Contains(nickName));
			}
			if(filterOnEmailAddress)
			{
				q.AndWhere(UserFields.EmailAddress.Contains(emailAddress));
			}
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(q, new EntityCollection<UserEntity>());
			}
		}


		/// <summary>
		/// Checks the if thread is already bookmarked.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>true if the thread is bookmarked</returns>
		public static bool CheckIfThreadIsAlreadyBookmarked(int userID, int threadID)
		{
			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(BookmarkFields.ThreadID)
						.Where((BookmarkFields.ThreadID == threadID).And(BookmarkFields.UserID == userID));
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int?>(q) != null;
			}
		}


		/// <summary>
		/// Gets the bookmarks with statistics for the user specified.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <returns></returns>
		public static DataView GetBookmarksAsDataView(int userID)
		{
#warning IMPLEMENT
			return null;

			//var qf = new QueryFactory();
			//var q = qf.Create()
			//			.Select(new List<object>(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStats(qf))
			//						{
			//							ForumFields.ForumName,
			//							ForumFields.SectionID
			//						}.ToArray())
			//			.From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
			//					.InnerJoin(qf.Forum).On(ThreadFields.ForumID==ForumFields.ForumID))
			//			.Where(ThreadFields.ThreadID.In(qf.Create().Select(BookmarkFields.ThreadID).Where(BookmarkFields.UserID==userID)))
			//			.OrderBy(ThreadFields.ThreadLastPostingDate.Descending());
			//var dao = new TypedListDAO();
			//var bookmarkedThreads = dao.FetchAsDataTable(q);
			//return bookmarkedThreads.DefaultView;
		}


		/// <summary>
		/// Retrieves all available usertitles.
		/// </summary>
		/// <returns>entitycollection with all the usertitles</returns>
		public static EntityCollection<UserTitleEntity> GetAllUserTitles()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(new QueryFactory().UserTitle, new EntityCollection<UserTitleEntity>());
			}
		}

		
		/// <summary>
		/// Checks if the given nickname is already taken. If so, true is returned, otherwise false.
		/// </summary>
		/// <param name="nickName">NickName to check</param>
		/// <returns>true if nickname already exists in the database, false otherwise</returns>
		public static bool CheckIfNickNameExists(string nickName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int?>(new QueryFactory().User.Where(UserFields.NickName.Equal(nickName)).Select(UserFields.UserID)) != null;
			}
		}


		/// <summary>
		/// Returns the users who are not currently in the given Role
		/// </summary>
		/// <param name="roleID">Role to use as filter</param>
		/// <returns>entitycollection with data requested</returns>
		public static EntityCollection<UserEntity> GetAllUsersNotInRole(int roleID)
		{
			return GetAllUsersBasedOnRoleLogic(roleID, getUsersInRole: false);
		}


		/// <summary>
		/// Returns the users who are currently in the given Role
		/// </summary>
		/// <param name="iRoleID">Role to use as filter</param>
		/// <returns>UserCollection with data requested</returns>
		public static EntityCollection<UserEntity> GetAllUsersInRole(int roleID)
		{
			return GetAllUsersBasedOnRoleLogic(roleID, getUsersInRole: true);
		}


		/// <summary>
		/// Gets all users in range specified
		/// </summary>
		/// <param name="range">Range with userids</param>
		/// <returns></returns>
		public static EntityCollection<UserEntity> GetAllUsersInRange(List<int> range)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(new QueryFactory().User.Where(UserFields.UserID.In(range)), new EntityCollection<UserEntity>());
			}
		}


		/// <summary>
		/// Returns the user entity of the user with ID userID
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <returns>entity with data requested or null if not found.</returns>
		public static UserEntity GetUser(int userID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var user = new UserEntity(userID);
				return adapter.FetchEntity(user) ? user : null;
			}
		}

        /// <summary>
        /// Returns the user entity of the user with ID userID, With A UserEntityTitle prefetched.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns>entity with data requested, or null if not found</returns>
        public static UserEntity GetUserWithTitleDescription(int userID)
        {
	        var qf = new QueryFactory();
	        var q = qf.User
					  .Where(UserFields.UserID.Equal(userID))
					  .WithPath(UserEntity.PrefetchPathUserTitle);
	        using(var adapter = new DataAccessAdapter())
	        {
		        return adapter.FetchFirst(q);
	        }
        }


		/// <summary>
		/// Checks if thread is already subscribed. If so, true is returned otherwise false.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <param name="threadID">The thread ID.</param>
		/// <returns>true if the user is already subscribed to this thread otherwise false</returns>
		public static bool CheckIfThreadIsAlreadySubscribed(int userID, int threadID)
		{
			return (ThreadGuiHelper.GetThreadSubscription(threadID, userID) != null);
		}


		/// <summary>
		/// Gets all users based on role logic.
		/// </summary>
		/// <param name="roleID">The role identifier.</param>
		/// <param name="getUsersInRole">if set to <c>true</c> gets the users in the role specified. If false it will get the users not in the role specified</param>
		/// <returns></returns>
		private static EntityCollection<UserEntity> GetAllUsersBasedOnRoleLogic(int roleID, bool getUsersInRole)
		{
			var qf = new QueryFactory();
			var q = qf.User
						.OrderBy(UserFields.NickName.Ascending());
			q.Where(getUsersInRole ? UserFields.UserID.In(qf.Create().Select(RoleUserFields.UserID).Where(RoleUserFields.RoleID == roleID))
								   : UserFields.UserID.NotIn(qf.Create().Select(RoleUserFields.UserID).Where(RoleUserFields.RoleID == roleID)));
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(q, new EntityCollection<UserEntity>());
			}
		}
	}
}
