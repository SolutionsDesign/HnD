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
using SD.HnD.DAL.HelperClasses;
using System.Data;
using SD.HnD.DAL.CollectionClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.BL
{
	/// <summary>
	/// General class for support queue management related tasks
	/// </summary>
	public static class SupportQueueManager
	{
		/// <summary>
		/// Creates a new support queue.
		/// </summary>
		/// <param name="queueName">Name of the queue.</param>
		/// <param name="queueDescription">The queue description.</param>
		/// <param name="orderNo">The order no.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool CreateNewSupportQueue(string queueName, string queueDescription, short orderNo)
		{
			SupportQueueEntity toInsert = new SupportQueueEntity();
			toInsert.QueueDescription = queueDescription;
			toInsert.QueueName = queueName;
			toInsert.OrderNo = orderNo;
			return toInsert.Save();
		}


		/// <summary>
		/// Modifies the support queue definition data.
		/// </summary>
		/// <param name="queueID">The queue ID of the queue to modify the definition data of.</param>
		/// <param name="queueName">Name of the queue.</param>
		/// <param name="queueDescription">The queue description.</param>
		/// <param name="orderNo">The order no.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool ModifySupportQueue(int queueID, string queueName, string queueDescription, short orderNo)
		{
			SupportQueueEntity toModify = SupportQueueGuiHelper.GetSupportQueue(queueID);
			if(toModify == null)
			{
				// not found
				return false;
			}

			// set the fields, if they're not changed, the field won't be updated in the db.
			toModify.QueueName = queueName;
			toModify.QueueDescription = queueDescription;
			toModify.OrderNo = orderNo;
			return toModify.Save();
		}


		/// <summary>
		/// Deletes the support queue with the ID specified.
		/// </summary>
		/// <param name="queueID">The queue ID of the queue to delete.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		/// <remarks>All threads in the queue are automatically de-queued and not in a queue anymore. The Default support queue
		/// for forums which have this queue as the default support queue is reset to null.</remarks>
		public static bool DeleteSupportQueue(int queueID)
		{
			// we'll do several actions in one atomic transaction, so start a transaction first. 
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "DeleteSupportQ");

			try
			{
				// first reset all the FKs in Forum to NULL if they point to this queue.
				ForumEntity forumUpdater = new ForumEntity();
				// set the field to NULL. This is a nullable field, so we can just set the field to 'null', thanks to nullable types.
				forumUpdater.DefaultSupportQueueID = null;
				// update the entities directly in the db, use a forum collection for that
				ForumCollection forums = new ForumCollection();
				trans.Add(forums);
				// specify a filter that only the forums which have this queue as the default queue are updated and have their FK field set to NULL.
				forums.UpdateMulti(forumUpdater, (ForumFields.DefaultSupportQueueID == queueID));

				// delete all SupportQueueThread entities which refer to this queue. This will make all threads which are in this queue become queue-less.
				SupportQueueThreadCollection supportQueueThreads = new SupportQueueThreadCollection();
				trans.Add(supportQueueThreads);
				// delete them directly from the db.
				supportQueueThreads.DeleteMulti((SupportQueueThreadFields.QueueID == queueID));

				// it's now time to delete the actual supportqueue entity.
				SupportQueueCollection supportQueues = new SupportQueueCollection();
				trans.Add(supportQueues);
				// delete it directly from the db.
				int numberOfQueuesDeleted = supportQueues.DeleteMulti((SupportQueueFields.QueueID == queueID));

				// done so commit the transaction.
				trans.Commit();
				return (numberOfQueuesDeleted > 0);
			}
			catch
			{
				// first roll back the transaction
				trans.Rollback();
				// then bubble up the exception
				throw;
			}
			finally
			{
				trans.Dispose();
			}
		}


		/// <summary>
		/// Claims the thread specified for the user specified. As the thread can be in one queue at a time, it simply has to update the SupportQueueThread entity.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <param name="threadID">The thread ID.</param>
		public static void ClaimThread(int userID, int threadID)
		{
			SupportQueueThreadEntity supportQueueThread = new SupportQueueThreadEntity();
			supportQueueThread.FetchUsingUCThreadID(threadID);
			if(supportQueueThread.IsNew)
			{
				// not found, return
				return;
			}

			// simply overwrite an existing claim if any.
			supportQueueThread.ClaimedByUserID = userID;
			supportQueueThread.ClaimedOn = DateTime.Now;

			// done, save it
			supportQueueThread.Save();
		}
		

		/// <summary>
		/// Releases the claim on the thread specified. As the thread can be in one queue at a time, it simply has to update the SupportQueueThread entity.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		public static void ReleaseClaimOnThread(int threadID)
		{
			SupportQueueThreadEntity supportQueueThread = new SupportQueueThreadEntity();
			supportQueueThread.FetchUsingUCThreadID(threadID);
			if(supportQueueThread.IsNew)
			{
				// not found, return
				return;
			}

			// simply reset an existing claim
			supportQueueThread.ClaimedByUserID = null;		// nullable type, so set to null.
			supportQueueThread.ClaimedOn = null;			// nullable type, so set to null.

			// done, save it
			supportQueueThread.Save();
		}
		

		/// <summary>
		/// Persists the unit of work passed in with supportqueue entities. The call to this method originates from the form which manages support queues with
		/// one LLBLGenProDataSource controls which is used to persist changes. This LLBLGenProDataSource produces a UnitOfWork when the
		/// PerformWork event is raised and this UoW contains the changes to persist. This routine persists these changes. 
		/// </summary>
		/// <param name="uow">The unitofwork object which contains 1 or more changes (with standard .NET controls, this is 1) to persist.</param>
		/// </summary>
		public static void PersistSupportQueueUnitOfWork(UnitOfWork uow)
		{
			// pass a new transaction to the commit routine and auto-commit this transaction when the transaction is complete.
			uow.Commit(new Transaction(IsolationLevel.ReadCommitted, "PersistSupportQ"), true);
		}


		/// <summary>
		/// Removes the thread with the threadid specified from the queue it's in. A thread can be in a single queue, so we don't need the queueID.
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="transactionToUse">The transaction currently in progress. Can be null if no transaction is in progress.</param>
		public static void RemoveThreadFromQueue(int threadID, Transaction transactionToUse)
		{
			// delete the SupportQueueThread entity for this thread directly from the db, inside the transaction specified (if applicable)
			SupportQueueThreadCollection supportQueueThreads = new SupportQueueThreadCollection();
			if(transactionToUse != null)
			{
				// there's a transaction in progress, simply add it to the transaction
				transactionToUse.Add(supportQueueThreads);
			}

			// delete directly, using a filter on threadid
			supportQueueThreads.DeleteMulti((SupportQueueThreadFields.ThreadID == threadID));

			// don't commit the current transaction if specified, simply return to caller.
		}


		/// <summary>
		/// Adds the thread with the ID specified to the support queue with the ID specified
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="queueID">The queue ID.</param>
		/// <param name="userID">The user ID of the user causing this thread to be placed in the queue specified.</param>
		/// <param name="transactionToUse">The transaction to use. Is not null if there's a transaction in progress.</param>
		/// <remarks>first removes the thread from a queue if it's in a queue</remarks>
		public static void AddThreadToQueue(int threadID, int queueID, int userID, Transaction transactionToUse)
		{
			// first remove the thread from any queue it's in. 
			RemoveThreadFromQueue(threadID, transactionToUse);

			// then add it to the queue specified.
			SupportQueueThreadEntity supportQueueThread = new SupportQueueThreadEntity();
			supportQueueThread.ThreadID = threadID;
			supportQueueThread.QueueID = queueID;
			supportQueueThread.PlacedInQueueByUserID = userID;
			supportQueueThread.PlacedInQueueOn = DateTime.Now;

			if(transactionToUse != null)
			{
				// transaction in progress, add the entity to the transaction
				transactionToUse.Add(supportQueueThread);
			}
			supportQueueThread.Save();
		}
	}
}
