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
using System.Data;
using System.Text;
using System.Collections;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.TypedListClasses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.Linq;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.DTOs.Persistence;
using SD.LLBLGen.Pro.LinqSupportClasses;
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
		/// Gets a list of all the nicknames of banned users.
		/// </summary>
		/// <returns>List of the nicknames of the users which are banned on the useraccount: the IsBanned property is set for these users.</returns>
		/// <remarks>Not async as it's called from Configure which is a sync method</remarks>
		public static List<string> GetAllBannedUserNicknames()
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().User
										  .Where(UserFields.IsBanned.Equal(true))
										  .Select(() => UserFields.NickName.ToValue<string>());
				return adapter.FetchQuery(q);
			}
		}


		/// <summary>
		/// Gets a readonly object with profile data for the user specified. 
		/// </summary>
		/// <param name="userId"></param>
		/// <returns>A single object from a typedlist with the profile data of the user specified </returns>
		public static async Task<UserProfileInfoRow> GetUserProfileInfoAsync(int userId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().GetUserProfileInfoTypedList().Where(UserFields.UserID.Equal(userId));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the last n threads in which the user specified participated with one or more messages. Threads which aren't visible for the
		/// calling user are filtered out.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user calling the method has permission to access.</param>
		/// <param name="participantUserId">The participant user ID of the user of which the threads have to be obtained.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="callingUserId">The calling user ID.</param>
		/// <param name="amount">The amount of threads to fetch.</param>
		/// <returns>a list with objects representing the last threads for the user</returns>
		public static Task<List<AggregatedThreadRow>> GetLastThreadsForUserAggregatedDataAsync(List<int> accessableForums, int participantUserId,
																							   List<int> forumsWithThreadsFromOthers, int callingUserId, int amount)
		{
			return UserGuiHelper.GetLastThreadsForUserAggregatedDataAsync(accessableForums, participantUserId, forumsWithThreadsFromOthers, callingUserId, amount, 0);
		}


		/// <summary>
		/// Gets the last pageSize threads in which the user specified participated with one or more messages for the page specified. 
		/// Threads which aren't visible for the calling user are filtered out. If pageNumber is 0, pageSize is used to limit the list to the pageSize
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user calling the method has permission to access.</param>
		/// <param name="participantUserId">The participant user ID of the user of which the threads have to be obtained.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="callingUserId">The calling user ID.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number to fetch.</param>
		/// <returns>a list with objects representing the last threads for the user</returns>
		public static async Task<List<AggregatedThreadRow>> GetLastThreadsForUserAggregatedDataAsync(List<int> accessableForums, int participantUserId,
																									 List<int> forumsWithThreadsFromOthers, int callingUserId,
																									 int pageSize, int pageNumber)
		{
			// return null, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return null;
			}

			var numberOfThreadsToFetch = pageSize;
			if(numberOfThreadsToFetch <= 0)
			{
				numberOfThreadsToFetch = 25;
			}

			var qf = new QueryFactory();
			var q = qf.Create()
					  .Select<AggregatedThreadRow>(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStatsWithForumName(qf).ToArray())
					  .From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
										   .InnerJoin(qf.Forum).On(ThreadFields.ForumID.Equal(ForumFields.ForumID)))
					  .Where(ThreadFields.ForumID.In(accessableForums)
										 .And(ThreadFields.ThreadID.In(qf.Create()
																		 .Select(MessageFields.ThreadID)
																		 .Where(MessageFields.PostedByUserID.Equal(participantUserId))))
										 .And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, callingUserId)))
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
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the row count for the set of threads in which the user specified participated with one or more messages for the page specified.
		/// Threads which aren't visible for the calling user are filtered out.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user calling the method has permission to access.</param>
		/// <param name="participantUserId">The participant user ID of the user of which the threads have to be obtained.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="callingUserId">The calling user ID.</param>
		/// <returns>the total number of threads the user participated in</returns>
		public static async Task<int> GetRowCountLastThreadsForUserAsync(List<int> accessableForums, int participantUserId, List<int> forumsWithThreadsFromOthers,
																		 int callingUserId)
		{
			// return null, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return 0;
			}

			var qf = new QueryFactory();
			var q = qf.Create()
					  .Select(Functions.CountRow())
					  .From(qf.Create()
							  .Select(ThreadFields.ThreadID)
							  .From(qf.Thread.InnerJoin(qf.Message).On(ThreadFields.ThreadID.Equal(MessageFields.ThreadID)))
							  .Where(ThreadFields.ForumID.In(accessableForums).And(MessageFields.PostedByUserID.Equal(participantUserId)))
							  .Distinct());
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchScalarAsync<int>(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Finds the users matching the filter criteria.
		/// </summary>
		/// <param name="filterOnRole"><see langword="true"/> if [filter on role]; otherwise, <see langword="false"/>.</param>
		/// <param name="roleId">Role ID.</param>
		/// <param name="filterOnNickName"><see langword="true"/> if [filter on nick name]; otherwise, <see langword="false"/>.</param>
		/// <param name="nickName">Name of the nick.</param>
		/// <param name="filterOnEmailAddress"><see langword="true"/> if [filter on email address]; otherwise, <see langword="false"/>.</param>
		/// <param name="emailAddress">Email address.</param>
		/// <param name="roleIDWhichUsersToExclude">The role id which users to exclude. </param>
		/// <returns>User objects matching the query</returns>
		public static async Task<EntityCollection<UserEntity>> FindUsers(bool filterOnRole, int roleId, bool filterOnNickName, string nickName, bool filterOnEmailAddress,
																		 string emailAddress, int roleIDWhichUsersToExclude = 0)
		{
			var qf = new QueryFactory();
			var q = qf.User.OrderBy(UserFields.NickName.Ascending());
			if(filterOnRole)
			{
				q.AndWhere(UserFields.UserID.In(qf.Create().Select(RoleUserFields.UserID).Where(RoleUserFields.RoleID.Equal(roleId))));
			}

			if(filterOnNickName)
			{
				q.AndWhere(UserFields.NickName.Contains(nickName));
			}

			if(filterOnEmailAddress)
			{
				q.AndWhere(UserFields.EmailAddress.Contains(emailAddress));
			}

			if(roleIDWhichUsersToExclude > 0)
			{
				q.AndWhere(UserFields.UserID.NotIn(qf.Create().Select(RoleUserFields.UserID).Where(RoleUserFields.RoleID.Equal(roleIDWhichUsersToExclude))));
			}

			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q, new EntityCollection<UserEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Checks the if thread is already bookmarked.
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <param name="threadId">Thread ID.</param>
		/// <returns>true if the thread is bookmarked</returns>
		public static async Task<bool> CheckIfThreadIsAlreadyBookmarkedAsync(int userId, int threadId)
		{
			var q = new QueryFactory().Create()
									  .Select(BookmarkFields.ThreadID)
									  .Where((BookmarkFields.ThreadID.Equal(threadId)).And(BookmarkFields.UserID.Equal(userId)));
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchScalarAsync<int?>(q).ConfigureAwait(false) != null;
			}
		}


		/// <summary>
		/// Gets the bookmarks with statistics for the user specified.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <returns></returns>
		public static async Task<List<AggregatedThreadRow>> GetBookmarksAggregatedDataAsync(int userID)
		{
			var qf = new QueryFactory();
			var q = qf.Create()
					  .Select<AggregatedThreadRow>(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStatsWithForumName(qf).ToArray())
					  .From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
										   .InnerJoin(qf.Forum).On(ThreadFields.ForumID.Equal(ForumFields.ForumID)))
					  .Where(ThreadFields.ThreadID.In(qf.Create()
														.Select(BookmarkFields.ThreadID)
														.Where(BookmarkFields.UserID.Equal(userID))))
					  .OrderBy(ThreadFields.ThreadLastPostingDate.Descending());
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Retrieves all available usertitles.
		/// </summary>
		/// <returns>entitycollection with all the usertitles</returns>
		public static async Task<EntityCollection<UserTitleEntity>> GetAllUserTitlesAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(new QueryFactory().UserTitle, new EntityCollection<UserTitleEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Checks if the user with the given NickName exists in the database. This is necessary to check if a user which gets authenticated through
		/// forms authentication is still available in the database. 
		/// </summary>
		/// <param name="nickName">The nickname of the user to check if he/she exists in the database</param>
		/// <returns>true if user exists, false otherwise.</returns>
		public static async Task<bool> CheckIfNickNameExistAsync(string nickName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await new LinqMetaData(adapter).User.AnyAsync(u => u.NickName == nickName).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets all UserInRole dto's for the role with the id specified. UserInRole dto's are instances of the derived element UserInRole which is
		/// a projection of a User entity.
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public static async Task<List<UserInRoleDto>> GetAllUserInRoleDtosForRoleAsync(int roleId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var qf = new QueryFactory();
				var q = qf.User
						  .Where(UserFields.UserID
										   .In(qf.RoleUser
												 .Where(RoleUserFields.RoleID.Equal(roleId))
												 .Select(RoleUserFields.UserID)))
						  .ProjectToUserInRoleDto(qf);
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets all users in range specified
		/// </summary>
		/// <param name="range">Range with userids</param>
		/// <returns></returns>
		public static async Task<EntityCollection<UserEntity>> GetAllUsersInRangeAsync(List<int> range)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(new QueryFactory().User.Where(UserFields.UserID.In(range)), new EntityCollection<UserEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Returns the user entity of the user with ID userID
		/// </summary>
		/// <param name="userId">The user ID.</param>
		/// <returns>entity with data requested or null if not found.</returns>
		public static async Task<UserEntity> GetUserAsync(int userId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().User.Where(UserFields.UserID.Equal(userId));
				if(userId == 0)
				{
					// cache the resultset, as the anonymous user doesn't change
					q.CacheResultset(3600, false, CacheKeys.AnonymousUserQueryResultset);
				}

				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Returns the user entity of the user with ID userID
		/// </summary>
		/// <param name="nickName">the nickname of the user to fetch</param>
		/// <returns>entity with data requested or null if not found.</returns>
		public static async Task<UserEntity> GetUserAsync(string nickName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().User.Where(UserFields.NickName.Equal(nickName));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Returns the set of user entities which IDs are in the list specified
		/// </summary>
		/// <param name="userIdsOfUsersToLoad"></param>
		/// <returns></returns>
		public static async Task<EntityCollection<UserEntity>> GetUsersAsync(List<int> userIdsOfUsersToLoad)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().User.Where(UserFields.UserID.In(userIdsOfUsersToLoad));
				return await adapter.FetchQueryAsync(q, new EntityCollection<UserEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the password token entity for the tokenid specified or null if not found.
		/// </summary>
		/// <param name="tokenId"></param>
		/// <returns></returns>
		public static async Task<PasswordResetTokenEntity> GetPasswordResetTokenAsync(string tokenId)
		{
			if(!Guid.TryParse(tokenId, out var tokenIDAsGuid))
			{
				return null;
			}

			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().PasswordResetToken.Where(PasswordResetTokenFields.PasswordResetToken.Equal(tokenIDAsGuid));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Checks if thread is already subscribed. If so, true is returned otherwise false.
		/// </summary>
		/// <param name="userId">The user ID.</param>
		/// <param name="threadId">The thread ID.</param>
		/// <returns>true if the user is already subscribed to this thread otherwise false</returns>
		public static async Task<bool> CheckIfThreadIsAlreadySubscribedAsync(int userId, int threadId)
		{
			return await ThreadGuiHelper.GetThreadSubscriptionAsync(threadId, userId) != null;
		}
	}
}