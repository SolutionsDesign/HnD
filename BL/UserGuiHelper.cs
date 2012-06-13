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

using SD.HnD.DAL;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.RelationClasses;
using SD.HnD.DAL.DaoClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;

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
			var dao = new TypedListDAO();
			return dao.FetchAsDataTable(q);
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
			var dao = new TypedListDAO();
			var results = dao.FetchAsDataTable(q);
			return results.DefaultView;
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
		public static DataView GetLastThreadsForUserAsDataView(List<int> accessableForums, int participantUserID,
																List<int> forumsWithThreadsFromOthers, int callingUserID, int amount)
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
		public static DataView GetLastThreadsForUserAsDataView(List<int> accessableForums, int participantUserID,
															   List<int> forumsWithThreadsFromOthers, int callingUserID, int pageSize, int pageNumber)
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
			var dao = new TypedListDAO();
			var lastThreads = dao.FetchAsDataTable(q);
			return lastThreads.DefaultView;
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
		public static int GetRowCountLastThreadsForUserAsDataView(List<int> accessableForums, int participantUserID,
																  List<int> forumsWithThreadsFromOthers, int callingUserID)
		{
			// return null, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return 0;
			}
			var qf = new QueryFactory();
			var q = qf.Create()
							.Select(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStats(qf))
							.From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf))
							.Where((ThreadFields.ForumID == accessableForums)
									.And(ThreadFields.ThreadID.In(qf.Create()
																		.Select(MessageFields.ThreadID)
																		.Where(MessageFields.PostedByUserID == participantUserID)))
									.And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, callingUserID)));
			var dao = new TypedListDAO();
			return dao.GetScalar<int>(qf.Create().Select(Functions.CountRow()).From(q), null);
		}


		/// <summary>
		/// Creates the filter for last threads for user code
		/// </summary>
		/// <param name="accessableForums">The accessable forums.</param>
		/// <param name="participantUserID">The participant user ID.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="callingUserID">The calling user ID.</param>
		/// <returns></returns>
		private static PredicateExpression CreateFilterForLastThreadsForUser(List<int> accessableForums, int participantUserID, List<int> forumsWithThreadsFromOthers, int callingUserID)
		{
			PredicateExpression filter = new PredicateExpression();

			// only the forums the calling user has access to
			filter.Add(ThreadFields.ForumID == accessableForums);
			// only the threads in which the participant user has posted one or more posts in. Do this with a fieldcompareset predicate
			// to create the clause:
			// where threadid in (select threadid from message where postedbyuserid = the participaintuserid specified.)
			filter.AddWithAnd(new FieldCompareSetPredicate(ThreadFields.ThreadID, MessageFields.ThreadID, SetOperator.In,
					(MessageFields.PostedByUserID == participantUserID)));

			// Also filter on the threads viewable by the passed in userid, which is the caller of the method. If a forum isn't in the list of
			// forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should be counted / taken into account. 
			PredicateExpression threadFilter = new PredicateExpression();
			if((forumsWithThreadsFromOthers != null) && (forumsWithThreadsFromOthers.Count > 0))
			{
				PredicateExpression onlyOwnThreadsFilter = new PredicateExpression();

				// accept only those threads who aren't in the forumsWithThreadsFromOthers list and which are either started by userID or sticky.
				// the filter on the threads not in the forums listed in the forumsWithThreadsFromOthers
				if(forumsWithThreadsFromOthers.Count == 1)
				{
					// optimization, specify the only value instead of the range, so we won't get a WHERE Field IN (@param) query which is slow on some
					// databases, but we'll get a WHERE Field == @param
					// accept all threads which are in a forum located in the forumsWithThreadsFromOthers list 
					threadFilter.Add((ThreadFields.ForumID == forumsWithThreadsFromOthers[0]));
					onlyOwnThreadsFilter.Add(ThreadFields.ForumID != forumsWithThreadsFromOthers[0]);
				}
				else
				{
					// accept all threads which are in a forum located in the forumsWithThreadsFromOthers list 
					threadFilter.Add((ThreadFields.ForumID == forumsWithThreadsFromOthers));
					onlyOwnThreadsFilter.Add(ThreadFields.ForumID != forumsWithThreadsFromOthers);
				}
				// the filter on either sticky or threads started by the calling user
				onlyOwnThreadsFilter.AddWithAnd(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID == callingUserID));
				threadFilter.AddWithOr(onlyOwnThreadsFilter);
			}
			else
			{
				// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
				// sticky threads or threads started by the calling user.
				threadFilter.Add(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID == callingUserID));
			}

			filter.AddWithAnd(threadFilter);

			return filter;
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
		public static UserCollection FindUsers(bool filterOnRole, int roleID, bool filterOnNickName, string nickName, bool filterOnEmailAddress, string emailAddress)
		{
			PredicateExpression filter = new PredicateExpression();
			if(filterOnRole)
			{
				filter.Add(new FieldCompareSetPredicate(UserFields.UserID, RoleUserFields.UserID, SetOperator.In, (RoleUserFields.RoleID == roleID)));
			}
			if(filterOnNickName)
			{
				filter.Add((UserFields.NickName % ("%" + nickName + "%")));
			}
			if(filterOnEmailAddress)
			{
				filter.Add((UserFields.EmailAddress % ("%" + emailAddress + "%")));
			}

			UserCollection toReturn = new UserCollection();
			toReturn.GetMulti(filter, 0, new SortExpression(UserFields.NickName | SortOperator.Ascending));
			return toReturn;
		}


		/// <summary>
		/// Checks the if thread is already bookmarked.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>true if the thread is bookmarked</returns>
		public static bool CheckIfThreadIsAlreadyBookmarked(int userID, int threadID)
		{
			BookmarkCollection bookmarks = new BookmarkCollection();
			PredicateExpression filter = new PredicateExpression((BookmarkFields.ThreadID == threadID) & (BookmarkFields.UserID == userID));
			return (bookmarks.GetScalar(BookmarkFieldIndex.ThreadID, null, AggregateFunction.None, filter)!=null);
		}


		/// <summary>
		/// Gets the bookmarks with statistics for the user specified.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <returns></returns>
		public static DataView GetBookmarksAsDataView(int userID)
		{
			FieldCompareSetPredicate filter = new FieldCompareSetPredicate(
				ThreadFields.ThreadID, BookmarkFields.ThreadID,	SetOperator.In, (BookmarkFields.UserID == userID));

			SortExpression sorter = new SortExpression(ThreadFields.ThreadLastPostingDate | SortOperator.Descending);
			
			// We'll use a dynamic list to retrieve all threads which are bookmarked by the user.
			ResultsetFields fields = ThreadGuiHelper.BuildDynamicListForAllThreadsWithStats();
			// add 2 fields to the resultset fields as we need data from Forum as well:
			int count = fields.Count;
			fields.Expand(2);
			fields.DefineField(ForumFields.ForumName, count);
			fields.DefineField(ForumFields.SectionID, count+1);

			// now build the relations for the dynamic list. We'll join User twice: once for the startuser and one for the lastpost user. 
			// also, we'll join the last message to the thread. The last message is joined with a custom filter added to the relation. 
			RelationCollection relations = ThreadGuiHelper.BuildRelationsForAllThreadsWithStats();
			// add the relation thread-forum as well, as we need information from Forum
			relations.Add(ThreadEntity.Relations.ForumEntityUsingForumID);

			DataTable bookmarkedThreads = new DataTable();
			TypedListDAO dao = new TypedListDAO();
			dao.GetMultiAsDataTable(fields, bookmarkedThreads, 0, sorter, filter, relations, true, null, null, 0, 0);
			return bookmarkedThreads.DefaultView;
		}


		/// <summary>
		/// Retrieves all available usertitles.
		/// </summary>
		/// <returns>entitycollection with all the usertitles</returns>
		public static UserTitleCollection GetAllUserTitles()
		{
			UserTitleCollection userTitles = new UserTitleCollection();
			userTitles.GetMulti(null);
			return userTitles;
		}

		
		/// <summary>
		/// Checks if the given nickname is already taken. If so, true is returned, otherwise false.
		/// </summary>
		/// <param name="sNickName">NickName to check</param>
		/// <returns>true if nickname already exists in the database, false otherwise</returns>
		public static bool CheckIfNickNameExists(string nickName)
		{
			UserEntity user = new UserEntity();
			user.FetchUsingUCNickName(nickName);
			return !user.IsNew;
		}


		/// <summary>
		/// Returns an entity collection with all User entities of users who are not currently in the given Role
		/// </summary>
		/// <param name="roleID">Role to use as filter</param>
		/// <returns>entitycollection with data requested</returns>
		public static UserCollection GetAllUsersNotInRole(int roleID)
		{
			// we're going to use the query:
			// SELECT ... FROM User
			// WHERE UserID NOT IN (SELECT UserID FROM RoleUser WHERE RoleID = @roleID)
			// so define the filter as a fieldcompareset predicate where we use the roleid in the filter and negate the predicate so it will emit NOT IN
			PredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareSetPredicate(UserFields.UserID, RoleUserFields.UserID,
					SetOperator.In, (RoleUserFields.RoleID == roleID), true));

			// sort on nickname ascending
			SortExpression sorter = new SortExpression(UserFields.NickName | SortOperator.Ascending);
			UserCollection users = new UserCollection();
			users.GetMulti(filter, 0, sorter);
			return users;
		}


		/// <summary>
		/// Gets all users in range specified
		/// </summary>
		/// <param name="range">Range with userids</param>
		/// <returns></returns>
		public static UserCollection GetAllUsersInRange(List<int> range)
		{
			UserCollection users = new UserCollection();
			users.GetMulti((UserFields.UserID==range));
			return users;
		}


		/// <summary>
		/// Returns a UserCollection with all User entities of users who are currently in the given Role
		/// </summary>
		/// <param name="iRoleID">Role to use as filter</param>
		/// <returns>UserCollection with data requested</returns>
		public static UserCollection GetAllUsersInRole(int roleID)
		{
			// we're going to use the query:
			// SELECT ... FROM User
			// WHERE UserID IN (SELECT UserID FROM RoleUser WHERE RoleID = @roleID)
			// so define the filter as a fieldcompareset predicate where we use the roleid in the filter
			PredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareSetPredicate(UserFields.UserID, RoleUserFields.UserID,
					SetOperator.In, (RoleUserFields.RoleID == roleID)));

			// sort on nickname ascending
			SortExpression sorter = new SortExpression(UserFields.NickName | SortOperator.Ascending);

			UserCollection users = new UserCollection();
			users.GetMulti(filter, 0, sorter);
			return users;
		}


		/// <summary>
		/// Returns the user entity of the user with ID userID
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <returns>entity with data requested or null if not found.</returns>
		public static UserEntity GetUser(int userID)
		{
			UserEntity user = new UserEntity(userID);
			if(user.IsNew)
			{
				// not found
				return null;
			}
			return user;
		}

        /// <summary>
        /// Returns the user entity of the user with ID userID, With A UserEntityTitle prefetched.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns>entity with data requested</returns>
        public static UserEntity GetUserWithTitleDescription(int userID)
        {
            PrefetchPath prefetchPath = new PrefetchPath((int)EntityType.UserEntity);
            prefetchPath.Add(UserEntity.PrefetchPathUserTitle);

            UserEntity user = new UserEntity(userID, prefetchPath);
			if(user.IsNew)
			{
				// not found
				return null;
			}
            return user;
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
	}
}
