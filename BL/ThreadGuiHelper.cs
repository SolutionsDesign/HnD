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
using System.Web;

using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.TypedListClasses;

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

			// create dyn. list and pull statistics using that list.
			ResultsetFields fields = new ResultsetFields(3);
			fields.DefineField(ThreadFields.ThreadID, 0, "AmountThreads", string.Empty, AggregateFunction.CountDistinct);
			fields.DefineField(MessageFields.MessageID, 1, "AmountPostings", string.Empty, AggregateFunction.Count);
			fields.DefineField(ThreadFields.ThreadLastPostingDate, 2, "LastPostingDate", string.Empty, AggregateFunction.Max);
			
            RelationCollection relations = new RelationCollection();
			relations.Add(ThreadEntity.Relations.MessageEntityUsingThreadID);

			PredicateExpression filter = new PredicateExpression();
			// only the forums the user has access to
            filter.Add(ThreadFields.ForumID == accessableForums.ToArray());
			// only the threads which are not closed
			filter.AddWithAnd(ThreadFields.IsClosed == false);
			// only the threads which are active (== not done)
			filter.AddWithAnd(ThreadFields.MarkedAsDone == false);
			// only threads which have been updated in the last Globals.HoursForActiveThreadsTreshold hours
			filter.AddWithAnd(ThreadFields.ThreadLastPostingDate >= DateTime.Now.AddHours((double)0 - hoursThreshold));

			// Also filter on the threads viewable by the passed in userid, which is the caller of the method. If a forum isn't in the list of
			// forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should be counted / taken into account. 
			PredicateExpression threadFilter = new PredicateExpression();
			if((forumsWithThreadsFromOthers!=null) && (forumsWithThreadsFromOthers.Count > 0))
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
						.AddWithOr(ThreadFields.StartedByUserID==userID));
				threadFilter.AddWithOr(onlyOwnThreadsFilter);
			}
			else
			{
				// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
				// sticky threads or threads started by the calling user.
				threadFilter.Add(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID == userID));
			}
			
			filter.AddWithAnd(threadFilter);

			TypedListDAO dao = new TypedListDAO();
			DataTable toReturn = new DataTable();
            dao.GetMultiAsDataTable(fields, toReturn, 0, null, filter, relations, true, null, null, 0, 0);
            return toReturn;
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
		public static DataView GetActiveThreadsAsDataView(List<int> accessableForums, short hoursThreshold,
				List<int> forumsWithThreadsFromOthers, int userID)
		{
            // return null, if the user does not have a valid list of forums to access
            if (accessableForums == null || accessableForums.Count <= 0)
            {
                return null;
            }

			PredicateExpression filter = new PredicateExpression();
			// only the forums the user has access to
            filter.Add(ThreadFields.ForumID == accessableForums);
			// only the threads which are not closed
			filter.Add(ThreadFields.IsClosed == false);
			// only the threads which are active (== not done)
			filter.Add(ThreadFields.MarkedAsDone == false);
			// only threads which have been updated in the last Globals.HoursForActiveThreadsTreshold hours
			filter.Add(ThreadFields.ThreadLastPostingDate >= DateTime.Now.AddHours((double)0 - hoursThreshold));

			// Also filter on the threads viewable by the passed in userid, which is the caller of the method. If a forum isn't in the list of
			// forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should be counted / taken into account. 
			PredicateExpression threadFilter = new PredicateExpression();
			if((forumsWithThreadsFromOthers!=null) && (forumsWithThreadsFromOthers.Count > 0))
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
						.AddWithOr(ThreadFields.StartedByUserID==userID));
				threadFilter.AddWithOr(onlyOwnThreadsFilter);
			}
			else
			{
				// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
				// sticky threads or threads started by the calling user.
				threadFilter.Add(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID == userID));
			}
			
			filter.AddWithAnd(threadFilter);

			SortExpression sorter = new SortExpression(ThreadFields.ThreadLastPostingDate | SortOperator.Ascending);

			// We'll use a dynamic list to retrieve all threads which are 'active' and in the specified interval
			ResultsetFields fields = BuildDynamicListForAllThreadsWithStats();
			int count = fields.Count;
			// add 1 field to the resultset fields as we need data from Forum as well:
			fields.Expand(1);
			fields.DefineField(ForumFields.ForumName, count);

			// now build the relations for the dynamic list. We'll join User twice: once for the startuser and one for the lastpost user. 
			// also, we'll join the last message to the thread. The last message is joined with a custom filter added to the relation. 
			RelationCollection relations = BuildRelationsForAllThreadsWithStats();
			// add the relation thread-forum as well, as we need information from Forum
			relations.Add(ThreadEntity.Relations.ForumEntityUsingForumID);
			
			DataTable activeThreads = new DataTable();
			TypedListDAO dao = new TypedListDAO();

			dao.GetMultiAsDataTable(fields, activeThreads, 0, sorter, filter, relations, true, null, null, 0, 0);
            return activeThreads.DefaultView;
		}


		/// <summary>
		/// Gets the last message in thread, and prefetches the user + usertitle entities. 
		/// </summary>
		/// <param name="threadID">Thread ID.</param>
        /// <returns>fetched messageentity with the userentity + usertitle entity fetched as well of the user who posted the message.</returns>
		public static MessageEntity GetLastMessageInThreadWithUserInfo(int threadID)
		{
			MessageCollection messages = new MessageCollection();
			PrefetchPath path = new PrefetchPath((int)EntityType.MessageEntity);
			path.Add(MessageEntity.PrefetchPathPostedByUser).SubPath.Add(UserEntity.PrefetchPathUserTitle);

			messages.GetMulti(
					new FieldCompareSetPredicate(
						MessageFields.MessageID,
						MessageFields.MessageID.SetObjectAlias("LastMessage"), 
						SetOperator.Equal,
						new PredicateExpression(MessageFields.ThreadID == MessageFields.ThreadID.SetObjectAlias("LastMessage"))
								.AddWithAnd(MessageFields.ThreadID==threadID), 
						null, 
						string.Empty, 
						1,
						new SortExpression(MessageFields.PostingDate.SetObjectAlias("LastMessage") | SortOperator.Descending)
					), 1, 
					null, 
					null, 
					path);
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
		public static MessagesInThreadTypedList GetAllMessagesInThreadAsTypedList(int threadID)
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
		public static MessagesInThreadTypedList GetAllMessagesInThreadAsTypedList(int threadID, int pageNo, int pageSize)
		{
			// we'll use a typedlist, MessagesInThread to pull the necessary data from the db. The typedlist contains fields from
			// message, user and usertitle. 
			MessagesInThreadTypedList messages = new MessagesInThreadTypedList(); 

			//create the filter with the threadID passed to the method.
			PredicateExpression filter = new PredicateExpression(MessageFields.ThreadID == threadID);

			// Sort Messages on posting date, ascending, so the first post is located on top. 
			SortExpression sorter = new SortExpression(MessageFields.PostingDate | SortOperator.Ascending);

			// fetch the data into the typedlist. Pass in the paging information as well, to perform server-side paging. 
			messages.Fill(0, sorter, true, filter, null, null, pageNo, pageSize);

			// update thread entity directly inside the DB with a non-transactional update statement so the # of views is increased by one.
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
        /// <returns></returns>
        public static int GetStartAtMessageForGivenMessageAndThread(int threadID, int messageID, int maxAmountMessagesPerPage)
        {
            //construct the dynamic list fields
            ResultsetFields fields = new ResultsetFields(1);
            fields.DefineField(MessageFields.MessageID, 0);

            //create the filter with the ID passed to the method.
            PredicateExpression filter = new PredicateExpression(MessageFields.ThreadID == threadID);

            // Sort messages on postingdate / ascending
            SortExpression sorter = new SortExpression(MessageFields.PostingDate | SortOperator.Ascending);

            // the value to be returned
            int startAtMessage = 0;
	        int rowIndex = 0;
			DataTable dynamicList = new DataTable();
            TypedListDAO dao = new TypedListDAO();
            // Retrieves rows in the datatable provided which match the specified filter, containing the fields specified
            dao.GetMultiAsDataTable(fields, dynamicList, 0, sorter, filter, null, false, null, null, 0, 0);
            
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
			ResultsetFields fields = new ResultsetFields(1);
			fields.DefineField(MessageFields.MessageID, 0);
			DataTable results = new DataTable();
			TypedListDAO dao = new TypedListDAO();
			dao.GetMultiAsDataTable(fields, results, 1, new SortExpression(MessageFields.PostingDate | SortOperator.Ascending),
					(MessageFields.ThreadID == threadID), null, true, null, null, 0, 0);
			if(results.Rows.Count <= 0)
			{
				// not found
				return false;
			}

			return (((int)results.Rows[0][0]) == messageID);
		}


		/// <summary>
		/// Builds the dynamic list for a query with all threads with statistics. 
		/// </summary>
		/// <returns>setup in and ready to use resultset object</returns>
		/// <remarks>Doesn't add the forum fields</remarks>
		internal static ResultsetFields BuildDynamicListForAllThreadsWithStats()
		{
			ResultsetFields fields = new ResultsetFields(14);
			fields.DefineField(ThreadFields.ThreadID, 0);
			fields.DefineField(ThreadFields.ForumID, 1);
			fields.DefineField(ThreadFields.Subject, 2);
			fields.DefineField(ThreadFields.StartedByUserID, 3);
			fields.DefineField(ThreadFields.ThreadLastPostingDate, 4);
			fields.DefineField(ThreadFields.IsSticky, 5);
			fields.DefineField(ThreadFields.IsClosed, 6);
			fields.DefineField(ThreadFields.MarkedAsDone, 7);
			fields.DefineField(ThreadFields.NumberOfViews, 8);
			// the next field refers to an object alias, as we'll join User twice. 
			fields.DefineField(UserFields.NickName.SetObjectAlias("ThreadStarterUser"), 9);
			// the next field is a scalar query with the # of postings in the thread. 
			fields.DefineField(new EntityField("AmountMessages",
					new ScalarQueryExpression(MessageFields.MessageID.SetAggregateFunction(AggregateFunction.Count),
						(MessageFields.ThreadID == ThreadFields.ThreadID)), typeof(int)), 10);
			// the next two field refer to an object alias, as we'll join User twice. 
			fields.DefineField(UserFields.UserID, 11, "LastPostingByUserID", "LastPostingUser");
			fields.DefineField(UserFields.NickName, 12, "NickNameLastPosting", "LastPostingUser");
			// the next field sets the alias for the field to a different string than the default. 
			fields.DefineField(MessageFields.MessageID, 13, "LastMessageID", "LastMessage");

			return fields;
		}


		/// <summary>
		/// Builds the relation collection for a fetch of all threads with statistics. 
		/// </summary>
		/// <returns>A ready to use relationcollection</returns>
		/// <returns>Doesn't add the thread-forum relation.</returns>
		internal static RelationCollection BuildRelationsForAllThreadsWithStats()
		{
			RelationCollection relations = new RelationCollection();
			relations.Add(ThreadEntity.Relations.UserEntityUsingStartedByUserID, "ThreadStarterUser", JoinHint.Left);
			IEntityRelation threadMessage = ThreadEntity.Relations.MessageEntityUsingThreadID;
			// the custom filter of the relation is a subquery which compares the messageID of the last message in the thread with the messageid of the set to join
			threadMessage.CustomFilter = new PredicateExpression(
					new FieldCompareSetPredicate(MessageFields.MessageID.SetObjectAlias("LastMessage"),
						MessageFields.MessageID, SetOperator.Equal,
						(MessageFields.ThreadID == MessageFields.ThreadID.SetObjectAlias("LastMessage")), null, string.Empty, 1,
							new SortExpression(MessageFields.PostingDate | SortOperator.Descending)));
			// now add the relation to the relationcollection, we'll alias the message entity in the relation so we can refer to it in our custom filter.
			relations.Add(threadMessage, "LastMessage");
			relations.Add(MessageEntity.Relations.UserEntityUsingPostedByUserID, "LastMessage", "LastPostingUser", JoinHint.Left);
			return relations;
		}

	}
}
