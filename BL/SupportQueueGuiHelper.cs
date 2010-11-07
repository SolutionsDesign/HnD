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
using System.Collections.Generic;
using System.Text;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.HelperClasses;
using System.Data;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Support queue gui.
	/// </summary>
	public static class SupportQueueGuiHelper
	{
		/// <summary>
		/// Gets the support queue entity with the queue id passed in
		/// </summary>
		/// <param name="queueID">The queue ID.</param>
		/// <returns>the supportqueue entity requested or null if not found.</returns>
		public static SupportQueueEntity GetSupportQueue(int queueID)
		{
			// fetch using the constructor. 
			SupportQueueEntity toReturn = new SupportQueueEntity(queueID);
			if(toReturn.IsNew)
			{
				// not found
				return null;
			}
			return toReturn;
		}


		/// <summary>
		/// Gets all support queues known in the system, sorted by orderno, ascending.
		/// </summary>
		/// <returns>filled collection with entities requested.</returns>
		public static SupportQueueCollection GetAllSupportQueues()
		{
			SupportQueueCollection toReturn = new SupportQueueCollection();
			// fetch all supportqueue entities and sort on the orderno fields
			toReturn.GetMulti(null, 0, new SortExpression(SupportQueueFields.OrderNo | SortOperator.Ascending));
			return toReturn;
		}


		/// <summary>
		/// Gets the support queue of the thread with the threadID specified.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <returns>The requested supportqueue entity, or null if the thread isn't in a support queue.</returns>
		public static SupportQueueEntity GetQueueOfThread(int threadID)
		{
			return GetQueueOfThread(threadID, null);
		}


		/// <summary>
		/// Gets the support queue of the thread with the threadID specified.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="trans">The transaction currently in progress. Can be null if no transaction is in progress.</param>
		/// <returns>
		/// The requested supportqueue entity, or null if the thread isn't in a support queue.
		/// </returns>
		public static SupportQueueEntity GetQueueOfThread(int threadID, Transaction trans)
		{
			// the relation supportqueue - thread is stored in a SupportQueueThread entity. Use that entity as a filter for the support queue. If
			// that entity doesn't exist, the thread isn't in a supportqueue.

			RelationCollection relations = new RelationCollection();
			relations.Add(SupportQueueEntity.Relations.SupportQueueThreadEntityUsingQueueID);

			// use a supportqueue collection to fetch the support queue, which will contain 0 or 1 entities after the fetch
			SupportQueueCollection supportQueues = new SupportQueueCollection();
			// if a transaction has been specified, we've to add the collection to the transaction so the fetch takes place inside the same transaction so no
			// deadlocks occur on sqlserver
			if(trans != null)
			{
				trans.Add(supportQueues);
			}

			// fetch using a filter on a related entity, namely the SupportQueueThread entity. We'll filter on thread.
			supportQueues.GetMulti((SupportQueueThreadFields.ThreadID == threadID), relations);
			if(supportQueues.Count > 0)
			{
				// in a queue, return the instance
				return supportQueues[0];
			}
			else
			{
				// not in a queue, return null
				return null;
			}
		}


		/// <summary>
		/// Gets the support queue thread info entity and if specified, prefetches the user entity which claimed the related thread. 
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="prefetchClaimUser">if set to true it will </param>
		/// <returns>fetched entity if found, otherwise null</returns>
		public static SupportQueueThreadEntity GetSupportQueueThreadInfo(int threadID, bool prefetchClaimUser)
		{
			SupportQueueThreadEntity toReturn = new SupportQueueThreadEntity();
			PrefetchPath path = null;
			if(prefetchClaimUser)
			{
				// prefetch the user who claimed this thread (if any)
				path = new PrefetchPath((int)EntityType.SupportQueueThreadEntity);
				path.Add(SupportQueueThreadEntity.PrefetchPathClaimedByUser);
			}

			// now fetch the entity using the unique constraint on Thread by specifying the threadID passed in. Also specify the prefetch path (if any)
			toReturn.FetchUsingUCThreadID(threadID, path);
			if(toReturn.IsNew)
			{
				// not found
				return null;
			}
			return toReturn;
		}
		

		/// <summary>
		/// Gets the threads and accompanying statistics info, in the supportqueue specified. Only the threads which are in the forums in the list of
		/// accessable forums are returned.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="supportQueueID">The ID of the support queue to retrieve the threads for.</param>
		/// <returns>a dataView of Active threads</returns>
		public static DataView GetAllThreadsInSupportQueueAsDataView(List<int> accessableForums, int supportQueueID)
		{
			// return null, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return null;
			}

			PredicateExpression filter = new PredicateExpression();
			// only the forums the user has access to
			filter.Add(ThreadFields.ForumID == accessableForums);
			// only the threads which are in this queue.
			filter.Add(SupportQueueThreadFields.QueueID == supportQueueID);

			SortExpression sorter = new SortExpression(ThreadFields.ThreadLastPostingDate | SortOperator.Ascending);

			// We'll use a dynamic list to retrieve all threads which are in support queues
			ResultsetFields fields = ThreadGuiHelper.BuildDynamicListForAllThreadsWithStats();
			int count = fields.Count;
			// add fields to the resultset fields as we need data from forum, the nickname of the user who placed the thread in the queue,
			// the nickname of the user who claimed the thread (if any) and the date/times when the thread was placed or claimed
			fields.Expand(7);
			fields.DefineField(ForumFields.ForumName, count);
			fields.DefineField(UserFields.NickName, count + 1, "NickNamePlacedInQueue", "PlacedInQueueUser");
			fields.DefineField(SupportQueueThreadFields.PlacedInQueueByUserID, count + 2);
			fields.DefineField(SupportQueueThreadFields.PlacedInQueueOn, count + 3);
			fields.DefineField(UserFields.NickName, count + 4, "NickNameClaimedThread", "ClaimedThreadUser");
			fields.DefineField(SupportQueueThreadFields.ClaimedByUserID, count + 5);
			fields.DefineField(SupportQueueThreadFields.ClaimedOn, count + 6);

			// now build the relations for the dynamic list. We'll join User three times: once for the startuser, once for the lastpost user and
			// once for the user who placed the thread in the queue.
			// Also, we'll join the last message to the thread. The last message is joined with a custom filter added to the relation. 
			RelationCollection relations = ThreadGuiHelper.BuildRelationsForAllThreadsWithStats();

			// add the relation thread-forum as well, as we need information from Forum
			relations.Add(ThreadEntity.Relations.ForumEntityUsingForumID);
			// add the relation thread - SupportQueueThread and the relation SupportQueueThread - User, where we'll alias User. 
			relations.Add(ThreadEntity.Relations.SupportQueueThreadEntityUsingThreadID);
			relations.Add(SupportQueueThreadEntity.Relations.UserEntityUsingPlacedInQueueByUserID, "PlacedInQueueUser");
			// add the relation supportqueuethread - user for the claiming user. We'll specify a left join, because a thread can be unclaimed.
			relations.Add(SupportQueueThreadEntity.Relations.UserEntityUsingClaimedByUserID, "ClaimedThreadUser", JoinHint.Left); 

			DataTable threadsInQueue = new DataTable();
			TypedListDAO dao = new TypedListDAO();

			dao.GetMultiAsDataTable(fields, threadsInQueue, 0, sorter, filter, relations, true, null, null, 0, 0);
			return threadsInQueue.DefaultView;
		}


		/// <summary>
		/// Gets the total number of threads in support queues. Only the count of threads which are in the forums in the list of
		/// accessable forums are returned.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <returns>total number of threads in support queues</returns>
		public static int GetTotalNumberOfThreadsInSupportQueues(List<int> accessableForums)
		{
			// return 0, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return 0;
			}

			PredicateExpression filter = new PredicateExpression();
			// only the forums the user has access to
			filter.Add(ThreadFields.ForumID == accessableForums);

			// We'll a GetDbCount call to obtain the total number of threads which are in support queues

			// we need to join support queue with thread, so we can filter on thread's fields. We work with the intermediate entity 
			// 'SupportQueueThreadEntity' as we're not interested in the data, just the # of entries. 
			RelationCollection relations = new RelationCollection();
			relations.Add(SupportQueueThreadEntity.Relations.ThreadEntityUsingThreadID);

			SupportQueueThreadCollection supportQueueThreads = new SupportQueueThreadCollection();
			return supportQueueThreads.GetDbCount(filter, relations);
		}
	}
}
