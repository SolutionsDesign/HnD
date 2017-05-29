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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using SD.HnD.BL.TypedDataClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.TypedListClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Thread Gui
	/// </summary>
	public static class ThreadGuiHelper
	{
		/// <summary>
		/// Gets the thread.
		/// </summary>
		/// <param name="threadId">Thread ID.</param>
		/// <returns>Thread object or null if not found</returns>
		public static ThreadEntity	GetThread(int threadId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var thread = new ThreadEntity(threadId);
				return adapter.FetchEntity(thread) ? thread : null;
			}
		}


		/// <summary>
		/// Gets the thread subscription object for the thread - user combination passed in. If there's no subscription, null is returned.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="userID">The user ID.</param>
		/// <returns>requested Threadsubscription entity or null if not found</returns>
		public static ThreadSubscriptionEntity GetThreadSubscription(int threadID, int userID)
		{
			return GetThreadSubscription(threadID, userID, null);
		}


		/// <summary>
		/// Gets the thread subscription object for the thread - user combination passed in. If there's no subscription, null is returned.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="userID">The user ID.</param>
		/// <param name="adapter">The live adapter with an active transaction. Can be null, in which case a local adapter is used.</param>
		/// <returns>
		/// requested Threadsubscription entity or null if not found
		/// </returns>
		public static ThreadSubscriptionEntity GetThreadSubscription(int threadID, int userID, IDataAccessAdapter adapter)
		{
			bool localAdapter = adapter == null;
			var adapterToUse = adapter ?? new DataAccessAdapter();
			try
			{
				var threadSubscription = new ThreadSubscriptionEntity(userID, threadID);
				return adapterToUse.FetchEntity(threadSubscription) ? threadSubscription : null;
			}
			finally
			{
				if(localAdapter)
				{
					adapterToUse.Dispose();
				}
			}
		}


		/// <summary>
		/// Gets the total number of messages in thread.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <returns></returns>
		public static int GetTotalNumberOfMessagesInThread(int threadID)
		{
			var qf = new QueryFactory();
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int>(qf.Message.Select(Functions.CountRow()).Where(MessageFields.ThreadID.Equal(threadID)));
			}
		}


#warning OBSOLETE?
		/// <summary>
		/// Gets the active threads with statistics.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="hoursThreshold">The hours threshold for the query to fetch the active threads. All threads within this threshold's period of time (in hours)
		/// are fetched.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums for which the calling user can view other users' threads. Can be null</param>
		/// <param name="userID">The userid of the calling user.</param>
		/// <returns>
		/// a dataTable of Active threads with statistics
		/// </returns>
		public static DataTable GetActiveThreadsStatisticsAsDataTable(List<int> accessableForums, short hoursThreshold, List<int> forumsWithThreadsFromOthers, int userID)
		{
            // return null, if the user does not have a valid list of forums to access
            if (accessableForums == null || accessableForums.Count <= 0)
            {
                return null;
            }

			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(ThreadFields.ThreadID.CountDistinct().As("AmountThreads"),
								MessageFields.MessageID.Count().As("AmountPostings"),
								ThreadFields.ThreadLastPostingDate.Max().As("LastPostingDate"))
						.From(qf.Thread.InnerJoin(qf.Message).On(ThreadFields.ThreadID==MessageFields.ThreadID))
						.Where((ThreadFields.ForumID == accessableForums)
								.And(ThreadFields.IsClosed == false)
								.And(ThreadFields.MarkedAsDone == false)
								.And(ThreadFields.ThreadLastPostingDate >= DateTime.Now.AddHours((double)0 - hoursThreshold))
								.And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userID)));
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchAsDataTable(q);
			}
		}

#warning CONVERT TO List<AggregatedActiveThreadRow>() RETURNING METHOD
		/// <summary>
		/// Gets the active threads.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="hoursThreshold">The hours threshold for the query to fetch the active threads. All threads within this threshold's period of time (in hours)
		/// are fetched.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums for which the calling user can view other users' threads. Can be null</param>
		/// <param name="userID">The userid of the calling user.</param>
		/// <returns>a dataView of Active threads</returns>
		public static DataView GetActiveThreadsAsDataView(List<int> accessableForums, short hoursThreshold, List<int> forumsWithThreadsFromOthers, int userID)
		{
            if (accessableForums == null || accessableForums.Count <= 0)
            {
                return null;
            }

			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(ThreadGuiHelper.BuildQueryProjectionElementsForAllActiveThreadsWithStats(qf))
						.From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
								.InnerJoin(qf.Forum).On(ThreadFields.ForumID == ForumFields.ForumID))
						.Where((ThreadFields.ForumID == accessableForums)
									.And(ThreadFields.IsClosed == false)
									.And(ThreadFields.MarkedAsDone == false)
									.And(ThreadFields.ThreadLastPostingDate >= DateTime.Now.AddHours((double)0 - hoursThreshold))
									.And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userID)))
						.OrderBy(ThreadFields.ThreadLastPostingDate.Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchAsDataTable(q).DefaultView;
			}
		}


		/// <summary>
		/// Gets the last message in thread, and prefetches the user + usertitle entities. 
		/// </summary>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>fetched messageentity with the userentity + usertitle entity fetched as well of the user who posted the message.</returns>
		public static MessageEntity GetLastMessageInThreadWithUserInfo(int threadID)
		{
			var qf = new QueryFactory();
			var q = qf.Message
						.Where(MessageFields.MessageID.Equal(
											qf.Create()
												.Select(MessageFields.MessageID.Source("LastMessage"))
												.Where((MessageFields.ThreadID == MessageFields.ThreadID.Source("LastMessage"))
														.And(MessageFields.ThreadID.Source("LastMessage")==threadID))
												.Limit(1)
												.OrderBy(MessageFields.PostingDate.Source("LastMessage").Descending())
												.ToScalar()
												.ForceRowLimit()))
						.WithPath(MessageEntity.PrefetchPathPostedByUser.WithSubPath(UserEntity.PrefetchPathUserTitle));
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchFirst(q);
			}
		}
		

		/// <summary>
		/// Constructs a poco typed list with all the messages in the thread given. Poster info is included, so the
		/// returned list is bindable at once to the message list repeater.
		/// </summary>
		/// <param name="threadID">ID of Thread which messages should be returned</param>
		/// <param name="pageNo">The page no.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>List with all messages in the thread for the page specified</returns>
		public static List<MessagesInThreadRow> GetAllMessagesInThreadAsTypedList(int threadID, int pageNo, int pageSize)
		{
			// we'll use an extended typedlist. We've extended the typed list with a scalar query to pull the # of attachments in the same query. 
			var qf = new QueryFactory();
			var q = qf.GetMessagesInThreadExtendedTypedList()
						  .Where(MessageFields.ThreadID == threadID)			// create the filter with the threadID passed to the method.
						  .OrderBy(MessageFields.PostingDate.Ascending())		// Sort Messages on posting date, ascending, so the first post is located on top. 
						  .Page(pageNo, pageSize)								// Pass in the paging information as well, to perform server-side paging. 
						  .Distinct();                                          // Use distinct to avoid duplicates as we're paging.
			using(var adapter = new DataAccessAdapter())
			{
				var messages = adapter.FetchQuery(q);

				// update thread entity directly inside the DB with an update statement so the # of views is increased by one.
				var updater = new ThreadEntity();
				// set the NumberOfViews field to an expression which increases it by 1
				updater.Fields[(int)ThreadFieldIndex.NumberOfViews].ExpressionToApply = (ThreadFields.NumberOfViews + 1);
				adapter.UpdateEntitiesDirectly(updater, new RelationPredicateBucket(ThreadFields.ThreadID == threadID));
				return messages;
			}
		}


		/// <summary>
		/// Will return the StartMessageNo for including it in the URL when redirecting to a page with messages in the given
		/// thread. The page started with StartMessageNo will contain the message with ID messageID. Paging is done using the
		/// maxAmountMessagesPerPage property in Application.
		/// </summary>
		/// <param name="threadID">ID of the thread to which the messages belong</param>
		/// <param name="messageID"></param>
		/// <param name="maxAmountMessagesPerPage">The max amount of messages per page to show. </param>
		/// <returns></returns>
		public static int GetStartAtMessageForGivenMessageAndThread(int threadID, int messageID, int maxAmountMessagesPerPage)
        {
			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(()=>MessageFields.MessageID.ToValue<int>())
						.Where(MessageFields.ThreadID == threadID)
						.OrderBy(MessageFields.PostingDate.Ascending())
						.Distinct();
	        using(var adapter = new DataAccessAdapter())
	        {
		        var messageIDs = adapter.FetchQuery(q);
		        int startAtMessage = 0;
		        int rowIndex = 0;
		        if(messageIDs.Count > 0)
		        {
			        for(int i = 0; i < messageIDs.Count; i++)
			        {
				        if(messageIDs[i] == messageID)
				        {
					        // found the row
					        rowIndex = i;
					        break;
				        }
			        }
			        startAtMessage = (rowIndex / maxAmountMessagesPerPage) * maxAmountMessagesPerPage;
		        }
		        return startAtMessage;
	        }
        }


		/// <summary>
		/// Checks if the message with the ID specified is first message in thread with id specified.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="messageID">The message ID.</param>
		/// <returns>true if message is first message in thread, false otherwise</returns>
		public static bool CheckIfMessageIsFirstInThread(int threadID, int messageID)
		{
			// use a scalar query, which obtains the first MessageID in a given thread. We sort on posting date ascending, and simply read
			// the first messageid. If that's not available or not equal to messageID, the messageID isn't the first post in the thread, otherwise it is.
			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(()=>MessageFields.MessageID.ToValue<int>())
						.Where(MessageFields.ThreadID == threadID)
						.OrderBy(MessageFields.PostingDate.Ascending())
						.Limit(1);
			using(var adapter = new DataAccessAdapter())
			{
				var firstMessageId = adapter.FetchScalar<int?>(q);
				return firstMessageId.HasValue && firstMessageId.Value == messageID;
			}
		}
		

		/// <summary>
		/// Creates the thread filter. Filters on the threads viewable by the passed in userid, which is the caller of the method. 
		/// If a forum isn't in the list of forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should 
		/// be counted / taken into account. Which comes down to: (ForumID in forumsWithThreadsFromOthers) OR IsSticky Or StartedBy==Userid.
		/// It's ok it doesn't filter on forums not visible to the user, as this filter is used in combination of a filter on forums with a filter on visible forums
		/// by the user.
		/// </summary>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="userID">The user ID.</param>
		/// <returns>ready to use thread filter.</returns>
		internal static IPredicateExpression CreateThreadFilter(List<int> forumsWithThreadsFromOthers, int userID)
		{
			if((forumsWithThreadsFromOthers != null) && (forumsWithThreadsFromOthers.Count > 0))
			{
				// accept only those threads which are in the forumsWithThreadsFromOthers list or which are either started by userID or sticky.
				return ThreadFields.ForumID.In(forumsWithThreadsFromOthers).Or((ThreadFields.IsSticky == true).Or(ThreadFields.StartedByUserID == userID));
			}
			// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
			// sticky threads or threads started by the calling user.
			return (ThreadFields.IsSticky == true).Or(ThreadFields.StartedByUserID == userID);
		}


		/// <summary>
		/// Builds the projection for a dynamic query which contains thread and statistics information.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>The fields for the projection</returns>
		/// <remarks>Doesn't add the forum fields</remarks>
		internal static List<object> BuildQueryProjectionForAllThreadsWithStats(QueryFactory qf)
		{
			return new List<object>()
				   {
					   ThreadFields.ThreadID,
					   ThreadFields.ForumID,
					   ThreadFields.Subject,
					   ThreadFields.StartedByUserID.As("ThreadStartedByUserID"),
					   ThreadFields.ThreadLastPostingDate,
					   ThreadFields.IsSticky,
					   ThreadFields.IsClosed,
					   ThreadFields.MarkedAsDone,
					   ThreadFields.NumberOfViews,
					   UserFields.NickName.Source("ThreadStarterUser").As("ThreadStartedByNickName"),
					   qf.Create()
							 .Select(MessageFields.MessageID.Count())
							 .CorrelatedOver(MessageFields.ThreadID == ThreadFields.ThreadID)
							 .ToScalar()
							 .As("NumberOfMessages"),
					   UserFields.UserID.Source("LastPostingUser").As("LastPostByUserID"),
					   UserFields.NickName.Source("LastPostingUser").As("LastPostByNickName"),
					   MessageFields.MessageID.Source("LastMessage").As("MessageIDLastPost"),
				   };
		}
		

		/// <summary>
		/// Builds the projection elements for a dynamic query which contains active thread and statistics information.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>The fields for the projection</returns>
		/// <remarks>Doesn't add the forum fields</remarks>
		internal static List<object> BuildQueryProjectionElementsForAllActiveThreadsWithStats(QueryFactory qf)
		{
			var toReturn = BuildQueryProjectionForAllThreadsWithStats(qf);
			toReturn.Add(ForumFields.ForumName);
			return toReturn;
		}


		/// <summary>
		/// Builds form clause for the query specified for a fetch of all threads with statistics.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>ready to use join operand</returns>
		internal static IJoinOperand BuildFromClauseForAllThreadsWithStats(QueryFactory qf)
		{
			return qf.Thread
						.LeftJoin(qf.User.As("ThreadStarterUser")).On(ThreadFields.StartedByUserID == UserFields.UserID.Source("ThreadStarterUser"))
						.InnerJoin(qf.Message.As("LastMessage")).On((ThreadFields.ThreadID == MessageFields.ThreadID.Source("LastMessage"))
									.And(MessageFields.MessageID.Source("LastMessage").Equal(
											qf.Create()
												.Select(MessageFields.MessageID)
												.Where(MessageFields.ThreadID == MessageFields.ThreadID.Source("LastMessage"))
												.Limit(1)
												.OrderBy(MessageFields.PostingDate.Descending())
												.ToScalar()
												.ForceRowLimit())))		// force the row limit otherwise the scalar won't have the TOP 1, which will force
																		// the engine to remove the orderby / distinct as it otherwise fails. 
						.LeftJoin(qf.User.As("LastPostingUser"))
								.On(MessageFields.PostedByUserID.Source("LastMessage") == UserFields.UserID.Source("LastPostingUser"));
		}
	}
}
