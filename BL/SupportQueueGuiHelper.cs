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
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Data;
using SD.LLBLGen.Pro.QuerySpec;
using System.Text;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

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
			using(var adapter = new DataAccessAdapter())
			{
				var supportQueue = new SupportQueueEntity(queueID);
				return adapter.FetchEntity(supportQueue) ? supportQueue : null;
			}
		}


		/// <summary>
		/// Gets all support queues known in the system, sorted by orderno, ascending.
		/// </summary>
		/// <returns>filled collection with entities requested.</returns>
		public static EntityCollection<SupportQueueEntity> GetAllSupportQueues()
		{
			var qf = new QueryFactory();
			var q = qf.SupportQueue.OrderBy(SupportQueueFields.OrderNo.Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(q, new EntityCollection<SupportQueueEntity>());
			}
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
		/// <param name="adapter">The live adapter with a transaction currently in progress. Can be null if no transaction is in progress.</param>
		/// <returns>
		/// The requested supportqueue entity, or null if the thread isn't in a support queue.
		/// </returns>
		public static SupportQueueEntity GetQueueOfThread(int threadID, IDataAccessAdapter adapter)
		{
			// the relation supportqueue - thread is stored in a SupportQueueThread entity. Use that entity as a filter for the support queue. If
			// that entity doesn't exist, the thread isn't in a supportqueue.
			var qf = new QueryFactory();
			var q = qf.SupportQueue
						.From(QueryTarget.InnerJoin(qf.SupportQueueThread).On(SupportQueueThreadFields.QueueID == SupportQueueFields.QueueID))
						.Where(SupportQueueThreadFields.ThreadID == threadID);

			bool localAdapter = adapter == null;
			var adapterToUse = adapter ?? new DataAccessAdapter();
			try
			{
				var toReturn = adapterToUse.FetchFirst(q);
				return toReturn;
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
		/// Gets the support queue thread info entity and if specified, prefetches the user entity which claimed the related thread. 
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="prefetchClaimUser">if set to true it will </param>
		/// <returns>fetched entity if found, otherwise null</returns>
		public static SupportQueueThreadEntity GetSupportQueueThreadInfo(int threadID, bool prefetchClaimUser)
		{
			var qf = new QueryFactory();
			var q = qf.SupportQueueThread.Where(SupportQueueThreadFields.ThreadID.Equal(threadID));
			if(prefetchClaimUser)
			{
				q.WithPath(SupportQueueThreadEntity.PrefetchPathClaimedByUser);
			}
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchFirst(q);
			}
		}


		/// <summary>
		/// Gets the threads and accompanying statistics info, in the supportqueues specified. Only the threads which are in the forums in the list of
		/// accessable forums are returned.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="supportQueueIDs">The support queue IDs to obtain the threads info for.</param>
		/// <returns>
		/// a list of aggregated support queue contents rows, one per thread, or an empty list if no forums were accessible. 
		/// </returns>
		public static List<AggregatedSupportQueueContentsRow> GetAllThreadsInSpecifiedSupportQueues(List<int> accessableForums, int[] supportQueueIDs)
		{
			// return null, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return new List<AggregatedSupportQueueContentsRow>();
			}
			var qf = new QueryFactory();
			var projectionFields = new List<object>(ThreadGuiHelper.BuildQueryProjectionElementsForAllActiveThreadsWithStats(qf));
			projectionFields.AddRange(new[]
									  {
										  SupportQueueThreadFields.QueueID, 
										  UserFields.NickName.Source("PlacedInQueueUser").As("PlacedInQueueByNickName"),
										  SupportQueueThreadFields.PlacedInQueueByUserID,
										  SupportQueueThreadFields.PlacedInQueueOn,
										  UserFields.NickName.Source("ClaimedThreadUser").As("ClaimedByNickName"),
										  SupportQueueThreadFields.ClaimedByUserID,
										  SupportQueueThreadFields.ClaimedOn
									  });
			var q = qf.Create()
					  .Select<AggregatedSupportQueueContentsRow>(projectionFields.ToArray())
					  .From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
										   .InnerJoin(qf.Forum).On(ThreadFields.ForumID == ForumFields.ForumID)
										   .InnerJoin(qf.SupportQueueThread).On(ThreadFields.ThreadID == SupportQueueThreadFields.ThreadID)
										   .InnerJoin(qf.User.As("PlacedInQueueUser")).On(SupportQueueThreadFields.PlacedInQueueByUserID == UserFields.UserID.Source("PlacedInQueueUser"))
										   .LeftJoin(qf.User.As("ClaimedThreadUser")).On(SupportQueueThreadFields.ClaimedByUserID == UserFields.UserID.Source("ClaimedThreadUser")))
					  .Where(ThreadFields.ForumID.In(accessableForums.ToArray()).And(SupportQueueThreadFields.QueueID.In(supportQueueIDs)))
					  .OrderBy(SupportQueueThreadFields.QueueID.Ascending(), ThreadFields.ThreadLastPostingDate.Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(q);
			}
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
						.Where(ThreadFields.ForumID.In(accessableForums));
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int>(q);
			}
		}
	}
}
