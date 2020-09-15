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
using System.Threading.Tasks;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.BL
{
	/// <summary>
	/// General forum management class. 
	/// </summary>
	public static class ForumManager
	{
		/// <summary>
		/// Creates a new forum in the system, and locates this forum in the section iSectionID.
		/// </summary>
		/// <param name="sectionID">The section ID.</param>
		/// <param name="forumName">Name of the forum.</param>
		/// <param name="forumDescription">The forum description.</param>
		/// <param name="hasRSSFeed">True if the forum has an RSS feed.</param>
		/// <param name="defaultSupportQueueID">The ID of the default support queue for this forum. Can be null.</param>
		/// <param name="defaultThreadListInterval">The default thread list interval.</param>
		/// <param name="orderNo">The order no for the section. Sections are sorted ascending on orderno.</param>
		/// <param name="maxAttachmentSize">Max. size of an attachment.</param>
		/// <param name="maxNoOfAttachmentsPerMessage">The max no of attachments per message.</param>
		/// <param name="newThreadWelcomeText">The new thread welcome text, as shown when a new thread is created. Can be null.</param>
		/// <param name="newThreadWelcomeTextAsHTML">The new thread welcome text as HTML, is null when newThreadWelcomeText is null or empty.</param>
		/// <returns>
		/// ForumID of new forum or 0 if something went wrong.
		/// </returns>
		public static async Task<int>  CreateNewForumAsync(int sectionID, string forumName, string forumDescription, bool hasRSSFeed, int? defaultSupportQueueID, 
														   int defaultThreadListInterval, short orderNo, int maxAttachmentSize, short maxNoOfAttachmentsPerMessage, 
														   string newThreadWelcomeText, string newThreadWelcomeTextAsHTML)
		{
			var newForum = new ForumEntity
						   {
							   SectionID = sectionID,
							   ForumDescription = forumDescription,
							   ForumName = forumName,
							   HasRSSFeed = hasRSSFeed,
							   DefaultSupportQueueID = defaultSupportQueueID,
							   DefaultThreadListInterval = Convert.ToByte(defaultThreadListInterval),
							   OrderNo = orderNo,
							   MaxAttachmentSize = maxAttachmentSize,
							   MaxNoOfAttachmentsPerMessage = maxNoOfAttachmentsPerMessage,
							   NewThreadWelcomeText = newThreadWelcomeText,
							   NewThreadWelcomeTextAsHTML = newThreadWelcomeTextAsHTML
						   };
			using(var adapter = new DataAccessAdapter())
			{
				var toReturn = await adapter.SaveEntityAsync(newForum).ConfigureAwait(false);
				return toReturn ? newForum.ForumID : 0;
			}
		}


		/// <summary>
		/// Modifies the given forum with the information given
		/// </summary>
		/// <param name="forumID">ID of forum to modify</param>
		/// <param name="sectionID">ID of section to locate this forum in</param>
		/// <param name="forumName">Name of the forum</param>
		/// <param name="forumDescription">Short description of the forum.</param>
		/// <param name="hasRSSFeed">True if the forum has an RSS feed.</param>
		/// <param name="defaultSupportQueueID">The ID of the default support queue for this forum. Can be null.</param>
		/// <param name="defaultThreadListInterval">The default thread list interval.</param>
		/// <param name="orderNo">The order no for the section. Sections are sorted ascending on orderno.</param>
		/// <param name="maxAttachmentSize">Max. size of an attachment.</param>
		/// <param name="maxNoOfAttachmentsPerMessage">The max no of attachments per message.</param>
		/// <param name="newThreadWelcomeText">The new thread welcome text, as shown when a new thread is created. Can be null.</param>
		/// <param name="newThreadWelcomeTextAsHTML">The new thread welcome text as HTML, is null when newThreadWelcomeText is null or empty.</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static async Task<bool> ModifyForumAsync(int forumID, int sectionID, string forumName, string forumDescription, bool hasRSSFeed, int? defaultSupportQueueID,
														int defaultThreadListInterval, short orderNo, int maxAttachmentSize, short maxNoOfAttachmentsPerMessage,
														string newThreadWelcomeText, string newThreadWelcomeTextAsHTML)
		{
			var forum = await ForumGuiHelper.GetForumAsync(forumID);
			if(forum==null)
			{
				// not found
				return false;	// doesn't exist
			}
			forum.SectionID = sectionID;
			forum.ForumDescription = forumDescription;
			forum.ForumName = forumName;
			forum.HasRSSFeed = hasRSSFeed;
			forum.DefaultSupportQueueID = defaultSupportQueueID;
			forum.DefaultThreadListInterval = Convert.ToByte(defaultThreadListInterval);
			forum.OrderNo = orderNo;
			forum.MaxAttachmentSize = maxAttachmentSize;
			forum.MaxNoOfAttachmentsPerMessage = maxNoOfAttachmentsPerMessage;
			forum.NewThreadWelcomeText = newThreadWelcomeText;
			forum.NewThreadWelcomeTextAsHTML = newThreadWelcomeTextAsHTML;
			using(var adapter = new DataAccessAdapter())
			{
				var toReturn = await adapter.SaveEntityAsync(forum).ConfigureAwait(false);
				return toReturn;
			}
		}


		/// <summary>
		/// Deletes the given forum from the system, including <b>all</b> threads in this forum and messages in those threads.
		/// </summary>
		/// <param name="forumID">Forum ID.</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static async Task<bool> DeleteForumAsync(int forumID)
		{
			// first all threads in this forum have to be removed, then this forum should be removed. Do this in one transaction.
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "DeleteForum").ConfigureAwait(false);
				try
				{
					await ThreadManager.DeleteAllThreadsInForumAsync(forumID, adapter);

					// remove all ForumRoleForumActionRight entities for this forum
					await adapter.DeleteEntitiesDirectlyAsync(typeof(ForumRoleForumActionRightEntity), 
															  new RelationPredicateBucket(ForumRoleForumActionRightFields.ForumID == forumID))
								 .ConfigureAwait(false);

					// remove the forum entity. do this by executing a direct delete statement on the database
					await adapter.DeleteEntitiesDirectlyAsync(typeof(ForumEntity), new RelationPredicateBucket(ForumFields.ForumID == forumID)).ConfigureAwait(false);
					adapter.Commit();
					return true;
				}
				catch
				{
					// exception occured, rollback
					adapter.Rollback();
					throw;
				}
			}
		}


		/// <summary>
		/// Creates a new thread in the given forum and places the passed in message as the first message in the thread.
		/// Caller should validate input parameters.
		/// </summary>
		/// <param name="forumID">Forum wherein the new thread will be placed</param>
		/// <param name="userID">User who started this thread</param>
		/// <param name="subject">Subject of the thread</param>
		/// <param name="messageText">First message of the thread</param>
		/// <param name="messageAsHTML">Message text as HTML</param>
		/// <param name="isSticky">Flag if the thread is sticky / pinned (true) or not (false)</param>
		/// <param name="userIDIPAddress">IP address of user calling this method</param>
		/// <param name="defaultSupportQueueID">The ID of the default support queue for this forum. If not null, the thread created will be
		/// added to the support queue with the ID specified.</param>
		/// <param name="subscribeToThread">If true, the user with userid is automatically subscribed to the new thread created</param>
		/// <returns>tuple with ThreadID and messageid. ThreadId, if succeeded, is set to the threadid of the new thread, or 0 if failed.
		/// The message ID is the id of the new message, which is the start message in the thread.</returns>
		public static async Task<(int threadId, int messageId)> CreateNewThreadInForumAsync(int forumID, int userID, string subject, string messageText, string messageAsHTML, 
																						   bool isSticky, string userIDIPAddress, int? defaultSupportQueueID, 
																						   bool subscribeToThread)
		{
			var newThread = new ThreadEntity
							{
								ForumID = forumID,
								IsClosed = false,
								IsSticky = isSticky,
								StartedByUserID = userID,
								Subject = subject,
								ThreadLastPostingDate = DateTime.Now
							};

			if(defaultSupportQueueID.HasValue)
			{
				// a support queue has been specified as the default support queue for this forum. Add the new thread to this support queue.
				var supportQueueThread = new SupportQueueThreadEntity();
				supportQueueThread.QueueID = defaultSupportQueueID.Value;
				supportQueueThread.PlacedInQueueByUserID = userID;
				supportQueueThread.PlacedInQueueOn = DateTime.Now;
				// assign the Thread property to the newly created thread entity, so this supportqueuethreadentity will be part of the graph
				// of objects which will be saved.
				supportQueueThread.Thread = newThread;
			}

			var newMessage = new MessageEntity
							 {
								 MessageText = messageText,
								 MessageTextAsHTML = messageAsHTML,
								 PostedByUserID = userID,
								 PostingDate = DateTime.Now,
								 PostedFromIP = userIDIPAddress,
								 Thread = newThread
							 };

			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "NewThread").ConfigureAwait(false);
				try
				{
					// save the complete graph
					await adapter.SaveEntityAsync(newMessage, true).ConfigureAwait(false);
					var messageId = newMessage.MessageID;
					int threadId = newMessage.ThreadID;

					// update thread statistics, this is the task for the message manager, and we pass the adapter so the actions will run in
					// the same transaction.
					await MessageManager.UpdateStatisticsAfterMessageInsert(threadId, userID, adapter, DateTime.Now, false, subscribeToThread);

					adapter.Commit();
					return (newThread.ThreadID, messageId);
				}
				catch
				{
					adapter.Rollback();
					throw;
				}
			}
		}
	}
}
