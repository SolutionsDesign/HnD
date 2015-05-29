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
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;
using SD.HnD.DAL.FactoryClasses;

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
			toReturn.GetMulti(null, 0, new SortExpression(SupportQueueFields.OrderNo.Ascending()));
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
			var qf = new QueryFactory();
			var q = qf.SupportQueueThread
						.From(QueryTarget.InnerJoin(qf.SupportQueue).On(SupportQueueThreadFields.QueueID == SupportQueueFields.QueueID))
						.Where(SupportQueueThreadFields.ThreadID == threadID);

			// use a supportqueue collection to fetch the support queue, which will contain 0 or 1 entities after the fetch
			SupportQueueCollection supportQueues = new SupportQueueCollection();
			// if a transaction has been specified, we've to add the collection to the transaction so the fetch takes place inside the same transaction so no
			// deadlocks occur on sqlserver
			if(trans != null)
			{
				trans.Add(supportQueues);
			}
			supportQueues.GetMulti(q);
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
#warning IMPLEMENT
			return null;

			//if(accessableForums == null || accessableForums.Count <= 0)
			//{
			//	return null;
			//}
			//var qf = new QueryFactory();
			//var q = qf.Create();
			//var projectionFields = new List<object>(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStats(qf));
			//projectionFields.AddRange(new[] { 
			//					ForumFields.ForumName,
			//					UserFields.NickName.Source("PlacedInQueueUser").As("NickNamePlacedInQueue"),
			//					SupportQueueThreadFields.PlacedInQueueByUserID,
			//					SupportQueueThreadFields.PlacedInQueueOn,
			//					UserFields.NickName.Source("ClaimedThreadUser").As("NickNameClaimedThread"),
			//					SupportQueueThreadFields.ClaimedByUserID,
			//					SupportQueueThreadFields.ClaimedOn});
			//q.Select(projectionFields.ToArray());
			//q.From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
			//		.InnerJoin(qf.Forum).On(ThreadFields.ForumID == ForumFields.ForumID)
			//		.InnerJoin(qf.SupportQueueThread).On(ThreadFields.ThreadID == SupportQueueThreadFields.ThreadID)
			//		.InnerJoin(qf.User.As("PlacedInQueueUser"))
			//				.On(SupportQueueThreadFields.PlacedInQueueByUserID == UserFields.UserID.Source("PlacedInQueueUser"))
			//		.LeftJoin(qf.User.As("ClaimedThreadUser"))
			//				.On(SupportQueueThreadFields.ClaimedByUserID == UserFields.UserID.Source("ClaimedThreadUser")));
			//q.Where((ThreadFields.ForumID == accessableForums).And(SupportQueueThreadFields.QueueID == supportQueueID));
			//q.OrderBy(ThreadFields.ThreadLastPostingDate.Ascending());
			//TypedListDAO dao = new TypedListDAO();
			//var threadsInQueue = dao.FetchAsDataTable(q);
			//return threadsInQueue.DefaultView;
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

			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(SupportQueueThreadFields.ThreadID.Count().As("NumberOfThreadsInQueues"))
						.From(qf.SupportQueueThread.InnerJoin(qf.Thread).On(SupportQueueThreadFields.ThreadID == ThreadFields.ThreadID))
						.Where(ThreadFields.ForumID == accessableForums);
			var dao = new TypedListDAO();
			return dao.GetScalar<int>(q, null);
		}
	}
}
