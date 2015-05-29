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
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.TypedListClasses;
using SD.LLBLGen.Pro.QuerySpec;
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
		/// <param name="ID">Thread ID.</param>
		/// <returns>Thread object or null if not found</returns>
		public static ThreadEntity	GetThread(int ID)
		{
            // load the entity from the database
            ThreadEntity thread = new ThreadEntity(ID);

            //check if the entity is new (not found in the database), then return null.
			if(thread.IsNew == true)
			{
				return null;
			}

            return thread;
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
		/// <param name="transactionToUse">The transaction to use. Pass in the transaction object if this fetch has to take place inside a transaction</param>
		/// <returns>
		/// requested Threadsubscription entity or null if not found
		/// </returns>
		public static ThreadSubscriptionEntity GetThreadSubscription(int threadID, int userID, Transaction transactionToUse)
		{
			ThreadSubscriptionEntity toReturn = new ThreadSubscriptionEntity();
			if(transactionToUse != null)
			{
				// transaction in progress, add entity to it so it's not blocked
				transactionToUse.Add(toReturn);
			}

			// fetch the data
			toReturn.FetchUsingPK(userID, threadID);
			if(toReturn.IsNew)
			{
				// not found
				return null;
			}

			// done. Don't commit a passed in transaction here, it's controlled by the caller.
			return toReturn;
		}


		/// <summary>
		/// Gets the total number of messages in thread.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <returns></returns>
		public static int GetTotalNumberOfMessagesInThread(int threadID)
		{
			MessageCollection messages = new MessageCollection();
			return messages.GetDbCount((MessageFields.ThreadID == threadID));
		}


		/// <summary>
		/// Gets the active threads with statistics.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="hoursThreshold">The hours threshold for the query to fetch the active threads. All threads within this threshold's period of time (in hours)
		/// are fetched.</param>
		/// <param name="forumsWithOnlyOwnThreads">The forums for which the calling user can view other users' threads. Can be null</param>
		/// <param name="userID">The userid of the calling user.</param>
		/// <returns>
		/// a dataTable of Active threads with statistics
		/// </returns>
		public static DataTable GetActiveThreadsStatisticsAsDataTable(List<int> accessableForums, short hoursThreshold, 
				List<int> forumsWithThreadsFromOthers, int userID)
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
			var dao = new TypedListDAO();
			return dao.FetchAsDataTable(q);


			//// create dyn. list and pull statistics using that list.
			//ResultsetFields fields = new ResultsetFields(3);
			//fields.DefineField(ThreadFields.ThreadID, 0, "AmountThreads", string.Empty, AggregateFunction.CountDistinct);
			//fields.DefineField(MessageFields.MessageID, 1, "AmountPostings", string.Empty, AggregateFunction.Count);
			//fields.DefineField(ThreadFields.ThreadLastPostingDate, 2, "LastPostingDate", string.Empty, AggregateFunction.Max);
			
			//RelationCollection relations = new RelationCollection();
			//relations.Add(ThreadEntity.Relations.MessageEntityUsingThreadID);

			//PredicateExpression filter = new PredicateExpression();
			//// only the forums the user has access to
			//filter.Add(ThreadFields.ForumID == accessableForums.ToArray());
			//// only the threads which are not closed
			//filter.AddWithAnd(ThreadFields.IsClosed == false);
			//// only the threads which are active (== not done)
			//filter.AddWithAnd(ThreadFields.MarkedAsDone == false);
			//// only threads which have been updated in the last Globals.HoursForActiveThreadsTreshold hours
			//filter.AddWithAnd(ThreadFields.ThreadLastPostingDate >= DateTime.Now.AddHours((double)0 - hoursThreshold));

			//// Also filter on the threads viewable by the passed in userid, which is the caller of the method. If a forum isn't in the list of
			//// forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should be counted / taken into account. 
			//IPredicateExpression threadFilter = ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userID);
			//filter.AddWithAnd(threadFilter);

			//TypedListDAO dao = new TypedListDAO();
			//DataTable toReturn = new DataTable();
			//dao.GetMultiAsDataTable(fields, toReturn, 0, null, filter, relations, true, null, null, 0, 0);
            //return toReturn;
		}


        /// <summary>
        /// Gets the active threads.
        /// </summary>
        /// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="hoursThreshold">The hours threshold for the query to fetch the active threads. All threads within this threshold's period of time (in hours)
		/// are fetched.</param>
		/// <param name="forumsWithOnlyOwnThreads">The forums for which the calling user can view other users' threads. Can be null</param>
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
						.Select(ThreadGuiHelper.BuildQueryProjectionForAllActiveThreadsWithStats(qf))
						.From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
								.InnerJoin(qf.Forum).On(ThreadFields.ForumID == ForumFields.ForumID))
						.Where((ThreadFields.ForumID == accessableForums)
									.And(ThreadFields.IsClosed == false)
									.And(ThreadFields.MarkedAsDone == false)
									.And(ThreadFields.ThreadLastPostingDate >= DateTime.Now.AddHours((double)0 - hoursThreshold))
									.And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userID)))
						.OrderBy(ThreadFields.ThreadLastPostingDate.Ascending());
			var dao = new TypedListDAO();
			var activeThreads = dao.FetchAsDataTable(q);
			return activeThreads.DefaultView;
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
			MessageCollection messages = new MessageCollection();
			messages.GetMulti(q);
			if(messages.Count<=0)
			{
				// not found
				return null;
			}
			return messages[0];
		}

		
		/// <summary>
		/// Constructs a TypedList with all the messages in the thread given. Poster info is included, so the
		/// returned dataview is bindable at once to the message list repeater.
		/// </summary>
		/// <param name="threadID">ID of Thread which messages should be returned</param>
		/// <returns>TypedList with all messages in the thread</returns>
		public static List<MessagesInThreadRow> GetAllMessagesInThreadAsTypedList(int threadID)
		{
			return GetAllMessagesInThreadAsTypedList(threadID, 0, 0);
		}
		

		/// <summary>
		/// Constructs a TypedList with all the messages in the thread given. Poster info is included, so the
		/// returned dataview is bindable at once to the message list repeater.
		/// </summary>
		/// <param name="threadID">ID of Thread which messages should be returned</param>
		/// <param name="pageNo">The page no.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>TypedList with all messages in the thread for the page specified</returns>
		public static List<MessagesInThreadRow> GetAllMessagesInThreadAsTypedList(int threadID, int pageNo, int pageSize)
		{
			// we'll use a typedlist, MessagesInThread to pull the necessary data from the db. The typedlist contains fields from message, user and usertitle. 
			var qf = new QueryFactory();
			var q = qf.GetMessagesInThreadTypedList()
						  .Where(MessageFields.ThreadID == threadID)			// create the filter with the threadID passed to the method.
						  .OrderBy(MessageFields.PostingDate.Descending())		// Sort Messages on posting date, ascending, so the first post is located on top. 
						  .Page(pageNo, pageSize)								// Pass in the paging information as well, to perform server-side paging. 
						  .Distinct();											// Use distinct to avoid duplicates as we're paging.
			var messages = new TypedListDAO().FetchQuery(q);					// fetch the data into the typedlist. 

			// update thread entity directly inside the DB with an update statement so the # of views is increased by one.
			ThreadEntity updater = new ThreadEntity();

			// set the NumberOfViews field to an expression which increases it by 1
			updater.Fields[(int)ThreadFieldIndex.NumberOfViews].ExpressionToApply = (ThreadFields.NumberOfViews + 1);
			updater.IsNew = false;

			// update the entity directly, and filter on the PK
			ThreadCollection threads = new ThreadCollection();
			threads.UpdateMulti(updater, (ThreadFields.ThreadID == threadID));
			
			// return the constructed typedlist
			return messages;
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
						.Select(MessageFields.MessageID)
						.Where(MessageFields.ThreadID == threadID)
						.OrderBy(MessageFields.PostingDate.Ascending())
						.Distinct();
			var dao = new TypedListDAO();
			var dynamicList = dao.FetchAsDataTable(q);
           
			int startAtMessage = 0;
			int rowIndex = 0;
            if (dynamicList.Rows.Count > 0)
            {
                // there are messages. Find the row with messageID. There can be only one row with this messageID                    
                for (int i = 0; i < dynamicList.Rows.Count; i++)
                {
                    if (((int)dynamicList.Rows[i]["MessageID"]) == messageID)
                    {
                        // found the row
                        rowIndex = i;
                        break;
                    }
                }
            }

            startAtMessage = (rowIndex / maxAmountMessagesPerPage) * maxAmountMessagesPerPage;

            // done
            return startAtMessage;
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
						.Select(MessageFields.MessageID)
						.Where(MessageFields.ThreadID == threadID)
						.OrderBy(MessageFields.PostingDate.Ascending())
						.Limit(1);
			var dao = new TypedListDAO();
			var firstMessageId = dao.GetScalar<int?>(q, null);
			if(firstMessageId.HasValue)
			{
				return firstMessageId.Value == messageID;
			}
			// not found.
			return false;
		}
		

		/// <summary>
		/// Creates the thread filter. Filters on the threads viewable by the passed in userid, which is the caller of the method. 
		/// If a forum isn't in the list of forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should 
		/// be counted / taken into account. 
		/// </summary>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="userID">The user ID.</param>
		/// <returns>ready to use thread filter.</returns>
		internal static IPredicateExpression CreateThreadFilter(List<int> forumsWithThreadsFromOthers, int userID)
		{
			var threadFilter = new PredicateExpression();
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
				onlyOwnThreadsFilter.AddWithAnd((ThreadFields.IsSticky == true).Or(ThreadFields.StartedByUserID == userID));
				threadFilter.AddWithOr(onlyOwnThreadsFilter);
			}
			else
			{
				// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
				// sticky threads or threads started by the calling user.
				threadFilter.Add((ThreadFields.IsSticky == true).Or(ThreadFields.StartedByUserID == userID));
			}
			return threadFilter;
		}


		/// <summary>
		/// Builds the projection for a dynamic query which contains thread and statistics information.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>The fields for the projection</returns>
		/// <remarks>Doesn't add the forum fields</remarks>
		internal static Expression<Func<AggregatedThreadRow>>  BuildQueryProjectionForAllThreadsWithStats(QueryFactory qf)
		{
			return () => new AggregatedThreadRow() 
			{ 
			 	ThreadID = ThreadFields.ThreadID.ToValue<int>(),
				ForumID = ThreadFields.ForumID.ToValue<int>(),
				Subject = ThreadFields.Subject.ToValue<string>(),
				UserIDThreadStarter = ThreadFields.StartedByUserID.As("UserIDThreadStarter").ToValue<int>(),
				NickNameThreadStarter = UserFields.NickName.Source("ThreadStarterUser").As("NickNameThreadStarter").ToValue<string>(),
				DateLastPost = ThreadFields.ThreadLastPostingDate.ToValue<DateTime?>(),
				IsSticky = ThreadFields.IsSticky.ToValue<bool>(),
				IsClosed = ThreadFields.IsClosed.ToValue<bool>(),
				MarkedAsDone = ThreadFields.MarkedAsDone.ToValue<bool>(),
				NumberOfViews = ThreadFields.NumberOfViews.ToValue<int>(),
				NumberOfMessages = qf.Create()
									.Select(MessageFields.MessageID.Count())
									.CorrelatedOver(MessageFields.ThreadID == ThreadFields.ThreadID)
									.ToScalar()
									.As("NumberOfMessages").ToValue<int>(),
				UserIDLastPost = UserFields.UserID.Source("LastPostingUser").As("LastPostingByUserID").ToValue<int>(),
				NickNameLastPost = UserFields.NickName.Source("LastPostingUser").As("NickNameLastPosting").ToValue<string>(),
				MessageIDLastPost = MessageFields.MessageID.Source("LastMessage").As("LastMessageID").ToValue<int>()
			};
		}
		

		/// <summary>
		/// Builds the projection for a dynamic query which contains active thread and statistics information.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>The fields for the projection</returns>
		/// <remarks>Doesn't add the forum fields</remarks>
		internal static Expression<Func<AggregatedActiveThreadRow>> BuildQueryProjectionForAllActiveThreadsWithStats(QueryFactory qf)
		{
			return () => new AggregatedActiveThreadRow()
			{
				ThreadID = ThreadFields.ThreadID.ToValue<int>(),
				ForumID = ThreadFields.ForumID.ToValue<int>(),
				Subject = ThreadFields.Subject.ToValue<string>(),
				UserIDThreadStarter = ThreadFields.StartedByUserID.ToValue<int>(),
				DateLastPost = ThreadFields.ThreadLastPostingDate.ToValue<DateTime?>(),
				IsSticky = ThreadFields.IsSticky.ToValue<bool>(),
				IsClosed = ThreadFields.IsClosed.ToValue<bool>(),
				MarkedAsDone = ThreadFields.MarkedAsDone.ToValue<bool>(),
				NumberOfViews = ThreadFields.NumberOfViews.ToValue<int>(),
				NickNameThreadStarter = UserFields.NickName.Source("ThreadStarterUser").ToValue<string>(),
				NumberOfMessages = qf.Create()
									.Select(MessageFields.MessageID.Count())
									.CorrelatedOver(MessageFields.ThreadID == ThreadFields.ThreadID)
									.ToScalar()
									.As("AmountMessages").ToValue<int>(),
				UserIDLastPost = UserFields.UserID.Source("LastPostingUser").As("LastPostingByUserID").ToValue<int>(),
				NickNameLastPost = UserFields.NickName.Source("LastPostingUser").As("NickNameLastPosting").ToValue<string>(),
				MessageIDLastPost = MessageFields.MessageID.Source("LastMessage").As("LastMessageID").ToValue<int>(),
				ForumName = ForumFields.ForumName.ToValue<string>()
			};
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
