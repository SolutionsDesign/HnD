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
using System.Threading.Tasks;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.DTOs.Persistence;
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
		/// <param name="queueId">The queue ID.</param>
		/// <returns>the supportqueue entity requested or null if not found.</returns>
		public static async Task<SupportQueueEntity> GetSupportQueueAsync(int queueId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().SupportQueue.Where(SupportQueueFields.QueueID.Equal(queueId));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the support queue entities projected to DTOs from the derived model 'DTOs'. 
		/// </summary>
		/// <returns></returns>
		public static async Task<List<SupportQueueDto>> GetAllSupportQueueDTOsAsync()
		{
			var qf = new QueryFactory();
			var q = qf.SupportQueue.ProjectToSupportQueueDto(qf)
					  .OrderBy(SupportQueueFields.OrderNo.Source("__BQ").Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}
		

		/// <summary>
		/// Gets all support queues known in the system, sorted by orderno, ascending.
		/// </summary>
		/// <returns>filled collection with entities requested.</returns>
		public static async Task<EntityCollection<SupportQueueEntity>> GetAllSupportQueuesAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().SupportQueue.OrderBy(SupportQueueFields.OrderNo.Ascending());
				return await adapter.FetchQueryAsync(q, new EntityCollection<SupportQueueEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the support queue of the thread with the threadID specified.
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <returns>The requested supportqueue entity, or null if the thread isn't in a support queue.</returns>
		public static Task<SupportQueueEntity> GetQueueOfThreadAsync(int threadId)
		{
			return GetQueueOfThreadAsync(threadId, null);
		}


		/// <summary>
		/// Gets the support queue of the thread with the threadID specified.
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="adapter">The live adapter with a transaction currently in progress. Can be null if no transaction is in progress.</param>
		/// <returns>
		/// The requested supportqueue entity, or null if the thread isn't in a support queue.
		/// </returns>
		public static async Task<SupportQueueEntity> GetQueueOfThreadAsync(int threadId, IDataAccessAdapter adapter)
		{
			// the relation supportqueue - thread is stored in a SupportQueueThread entity. Use that entity as a filter for the support queue. If
			// that entity doesn't exist, the thread isn't in a supportqueue.
			var qf = new QueryFactory();
			var q = qf.SupportQueue
						.From(QueryTarget.InnerJoin(qf.SupportQueueThread).On(SupportQueueThreadFields.QueueID.Equal(SupportQueueFields.QueueID)))
						.Where(SupportQueueThreadFields.ThreadID.Equal(threadId));

			var localAdapter = adapter == null;
			var adapterToUse = adapter ?? new DataAccessAdapter();
			try
			{
				return await adapterToUse.FetchFirstAsync(q).ConfigureAwait(false);
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
		/// <param name="threadId">The thread ID.</param>
		/// <param name="prefetchClaimUser">if set to true it will </param>
		/// <returns>fetched entity if found, otherwise null</returns>
		public static async Task<SupportQueueThreadEntity> GetSupportQueueThreadInfoAsync(int threadId, bool prefetchClaimUser)
		{
			var q = new QueryFactory().SupportQueueThread.Where(SupportQueueThreadFields.ThreadID.Equal(threadId));
			if(prefetchClaimUser)
			{
				q.WithPath(SupportQueueThreadEntity.PrefetchPathClaimedByUser);
			}
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the threads and accompanying statistics info, in the supportqueues specified. Only the threads which are in the forums in the list of
		/// accessable forums are returned.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="supportQueueIds">The support queue IDs to obtain the threads info for.</param>
		/// <returns>
		/// a list of aggregated support queue contents rows, one per thread, or an empty list if no forums were accessible. 
		/// </returns>
		public static async Task<List<AggregatedSupportQueueContentsRow>> GetAllThreadsInSpecifiedSupportQueuesAsync(List<int> accessableForums, int[] supportQueueIds)
		{
			// return null, if the user does not have a valid list of forums to access
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return new List<AggregatedSupportQueueContentsRow>();
			}
			var qf = new QueryFactory();
			var projectionFields = new List<object>(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStatsWithForumName(qf));
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
										   .InnerJoin(qf.Forum).On(ThreadFields.ForumID.Equal(ForumFields.ForumID))
										   .InnerJoin(qf.SupportQueueThread).On(ThreadFields.ThreadID.Equal(SupportQueueThreadFields.ThreadID))
										   .InnerJoin(qf.User.As("PlacedInQueueUser"))
												.On(SupportQueueThreadFields.PlacedInQueueByUserID.Equal(UserFields.UserID.Source("PlacedInQueueUser")))
										   .LeftJoin(qf.User.As("ClaimedThreadUser"))
												.On(SupportQueueThreadFields.ClaimedByUserID.Equal(UserFields.UserID.Source("ClaimedThreadUser"))))
					  .Where(ThreadFields.ForumID.In(accessableForums.ToArray()).And(SupportQueueThreadFields.QueueID.In(supportQueueIds)))
					  .OrderBy(SupportQueueThreadFields.QueueID.Ascending(), ThreadFields.ThreadLastPostingDate.Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the total number of threads in support queues no matter what the calling user can see.
		/// </summary>
		/// <returns>total number of threads in support queues</returns>
		public static int GetTotalNumberOfThreadsInSupportQueues()
		{
			var q = new QueryFactory().SupportQueueThread
									  .Select(SupportQueueThreadFields.ThreadID.Count().As("NumberOfThreadsInQueues"));
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int>(q);
			}
		}
	}
}
