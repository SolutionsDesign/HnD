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
using System.Collections;

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.Utility;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.LLBLGen.Pro.QuerySpec;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace SD.HnD.BL
{
	/// <summary>
	/// General class for Thread management related tasks
	/// </summary>
	public static class ThreadManager
	{
		/// <summary>
		/// Updates the memo field for the given thread
		/// </summary>
		/// <param name="threadID">Thread ID.</param>
		/// <param name="memo">Memo.</param>
		/// <returns></returns>
		public static bool UpdateMemo(int threadID, string memo)
		{
            // load the entity from the database
            var thread = ThreadGuiHelper.GetThread(threadID);
			if(thread==null)
			{
				// not found
				return false;
			}
			using(var adapter = new DataAccessAdapter())
			{
				thread.Memo = memo;
				return adapter.SaveEntity(thread);
			}
		}


		/// <summary>
		/// Marks the thread as done.
		/// </summary>
		/// <param name="threadID">Thread ID.</param>
		/// <returns></returns>
        public static bool MarkThreadAsDone(int threadID)
		{
			var thread = ThreadGuiHelper.GetThread(threadID);
			if(thread == null)
			{
				// not found
				return false;
			}
			var containingSupportQueue = SupportQueueGuiHelper.GetQueueOfThread(threadID);
            thread.MarkedAsDone = true;
			using(var adapter = new DataAccessAdapter())
			{ 
				// if the thread is in a support queue, the thread has to be removed from that queue. This is a multi-entity action and therefore we've to start a 
				// transaction if that's the case. If not, we can use the easy route and simply save the thread and be done with it.
				if(containingSupportQueue == null)
				{
					// not in a queue, simply save the thread.
					return adapter.SaveEntity(thread);
				}
				// in a queue, so remove from the queue and save the entity.
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "MarkThreadDone");
				try
				{
					// save the thread
					bool result = adapter.SaveEntity(thread);
					if(result)
					{
						// save succeeded, so remove from queue, pass the current adapter to the method so the action takes place inside this transaction.
						SupportQueueManager.RemoveThreadFromQueue(threadID, adapter);
					}
					adapter.Commit();
					return true;
				}
				catch
				{
					// rollback transaction
					adapter.Rollback();
					throw;
				}
			}
		}

        /// <summary>
        /// Marks the thread as un-done, and add it to the default queue of the forum.
        /// </summary>
        /// <param name="threadID">Thread ID</param>
        /// <returns></returns>
        public static bool UnMarkThreadAsDone(int threadID, int userID)
        {
            var thread = ThreadGuiHelper.GetThread(threadID);
            if (thread == null)
            {
                // not found
                return false;
            }
            thread.MarkedAsDone = false;
			using(var adapter = new DataAccessAdapter())
			{ 
				// Save the thread and add it to the default queue of the forum.
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "MarkThreadUnDone");
				try
				{
					adapter.SaveEntity(thread, true);
					var forum = new ForumEntity(thread.ForumID);
					var result = adapter.FetchEntity(forum);
					if(result && forum.DefaultSupportQueueID.HasValue)
					{
						// not in a queue, and the forum has a default queue. Add the thread to the queue of the forum
						SupportQueueManager.AddThreadToQueue(threadID, forum.DefaultSupportQueueID.Value, userID, adapter);
					}
					adapter.Commit();
					return true;
				}
				catch
				{
					// rollback transaction
					adapter.Rollback();
					throw;
				}
			}
        }

		
		/// <summary>
		/// Creates a new message in the given thread. Caller should validate input parameters.
		/// </summary>
		/// <param name="threadID">Thread wherein the new message will be placed</param>
		/// <param name="userID">User who posted this message</param>
		/// <param name="messageText">Message text</param>
		/// <param name="messageAsHTML">Message text as HTML</param>
		/// <param name="userIDIPAddress">IP address of user calling this method</param>
		/// <param name="messageAsXML">Message text as XML, which is the result of the parse action on MessageText.</param>
		/// <param name="subscribeToThread">if set to <c>true</c> [subscribe to thread].</param>
		/// <param name="threadUpdatedNotificationTemplate">The thread updated notification template.</param>
		/// <param name="emailData">The email data.</param>
		/// <param name="sendReplyNotifications">Flag to signal to send reply notifications. If set to false no notifications are mailed,
		/// otherwise a notification is mailed to all subscribers to the thread the new message is posted in</param>
		/// <returns>MessageID if succeeded, 0 if not.</returns>
        public static int CreateNewMessageInThread(int threadID, int userID, string messageText, string messageAsHTML, string userIDIPAddress, string messageAsXML, 
												   bool subscribeToThread, string threadUpdatedNotificationTemplate, Dictionary<string,string> emailData, bool sendReplyNotifications)
		{
			return CreateNewMessageInThreadAndPotentiallyCloseThread(threadID, userID, messageText, messageAsHTML, userIDIPAddress, messageAsXML, subscribeToThread, 
																	 threadUpdatedNotificationTemplate, emailData, sendReplyNotifications, closeThreadAfterInsert: false);
		}
		

		/// <summary>
		/// Creates a new message in the given thread and closes the thread right after the addition of the message,
		/// which makes the just added message the 'close' message of the thread. Close messages are handy when the
		/// closure of a thread is not obvious.
		/// Caller should validate input parameters.
		/// </summary>
		/// <param name="threadID">Thread wherein the new message will be placed</param>
		/// <param name="userID">User who posted this message</param>
		/// <param name="messageText">Message text</param>
		/// <param name="messageAsHTML">Message text as HTML</param>
		/// <param name="userIDIPAddress">IP address of user calling this method</param>
		/// <param name="messageAsXML">Message text as XML, which is the result of the parse action on MessageText.</param>
		/// <param name="threadUpdatedNotificationTemplate">The thread updated notification template.</param>
		/// <param name="emailData">The email data.</param>
		/// <param name="sendReplyNotifications">Flag to signal to send reply notifications. If set to false no notifications are mailed,
		/// otherwise a notification is mailed to all subscribers to the thread the new message is posted in</param>
		/// <returns>MessageID if succeeded, 0 if not.</returns>
		public static int CreateNewMessageInThreadAndCloseThread(int threadID, int userID, string messageText, string messageAsHTML, string userIDIPAddress, string messageAsXML, 
																  string threadUpdatedNotificationTemplate, Dictionary<string, string> emailData, bool sendReplyNotifications)
		{
			return CreateNewMessageInThreadAndPotentiallyCloseThread(threadID, userID, messageText, messageAsHTML, userIDIPAddress, messageAsXML, false,
																	 threadUpdatedNotificationTemplate, emailData, sendReplyNotifications, closeThreadAfterInsert: false);
		}


		/// <summary>
		/// Modifies the given properties of the given thread.
		/// </summary>
		/// <param name="threadID">The threadID of the thread which properties should be changed</param>
        /// <param name="subject">The new subject for this thread</param>
        /// <param name="isSticky">The new value for IsSticky</param>
        /// <param name="isClosed">The new value for IsClosed</param>
		/// <returns></returns>
		public static bool ModifyThreadProperties(int threadID, string subject, bool isSticky, bool isClosed)
		{
			var thread = ThreadGuiHelper.GetThread(threadID);
			if(thread == null)
			{
				// not found
				return false;
			}
			
            // update the fields with new values
            thread.Subject = subject;
            thread.IsSticky = isSticky;
            thread.IsClosed = isClosed;
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.SaveEntity(thread);
			}
		}


		/// <summary>
		/// Moves the given thread to the given forum.
		/// </summary>
        /// <param name="threadID">ID of thread to move</param>
        /// <param name="newForumID">ID of forum to move the thread to</param>
		/// <returns></returns>
		public static bool MoveThread(int threadID, int newForumID)
		{
			var thread = ThreadGuiHelper.GetThread(threadID);
			if(thread == null)
			{
				// not found
				return false;
			}
            thread.ForumID = newForumID;
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.SaveEntity(thread);
			}
		}


		/// <summary>
		/// Deletes the given Thread from the system, including <b>all</b> messages and related data in this Thread.
		/// </summary>
		/// <param name="threadID">Thread to delete.</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static bool DeleteThread(int threadID)
		{
			using(var adapter = new DataAccessAdapter())
			{ 
				// we'll use the delete threads feature as deleting a thread requires updating more data than just deleting a single thread object. 
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "DeleteThread");
				try
				{
					DeleteThreads(new PredicateExpression(ThreadFields.ThreadID == threadID), adapter);
					adapter.Commit();
					return true;
				}
				catch
				{
					// error occured
					adapter.Rollback();
					throw;
				}
			}
        }


		/// <summary>
		/// Deletes all threads in the specified forum.
		/// </summary>
		/// <param name="forumID">The forum identifier for which all threads have to be deleted.</param>
		/// <param name="adapter">The adapter to use in this method, has a live transaction.</param>
		internal static void DeleteAllThreadsInForum(int forumID, IDataAccessAdapter adapter)
		{
			DeleteThreads(new PredicateExpression(ThreadFields.ForumID == forumID), adapter);
		}


		/// <summary>
		/// Deletes the threads matching the passed in filter, inside the transaction specified.
		/// </summary>
		/// <param name="threadFilter">The thread filter.</param>
		/// <param name="adapter">The adapter to use in this method, has a live transaction.</param>
		private static void DeleteThreads(PredicateExpression threadFilter, IDataAccessAdapter adapter)
		{
			// we've to perform a set of actions in a given order to make sure we're not violating FK constraints in the DB. 
			MessageManager.DeleteAllMessagesInThreads(threadFilter, adapter);

			var qf = new QueryFactory();
			// delete bookmarks (if exists) of the threads to be deleted
			adapter.DeleteEntitiesDirectly(typeof(BookmarkEntity), new RelationPredicateBucket(BookmarkFields.ThreadID.In(qf.Thread.Where(threadFilter).Select(ThreadFields.ThreadID))));
			// delete audit info related to this thread. Can't be done directly on the db due to the fact the entities are in a TargetPerEntity hierarchy, which
			// can't be deleted directly on the db, so we've to fetch the entities first. 
			var q = qf.AuditDataThreadRelated.Where(AuditDataThreadRelatedFields.ThreadID.In(qf.Thread.Where(threadFilter).Select(ThreadFields.ThreadID)));
			var threadAuditData = adapter.FetchQuery(q);
			adapter.DeleteEntityCollection(threadAuditData);
			// delete support queue thread entity for this thread (if any)
			adapter.DeleteEntitiesDirectly(typeof(SupportQueueThreadEntity), 
											new RelationPredicateBucket(SupportQueueThreadFields.ThreadID.In(qf.Thread.Where(threadFilter).Select(ThreadFields.ThreadID))));
			// delete threadsubscription entities
			adapter.DeleteEntitiesDirectly(typeof(ThreadSubscriptionEntity),
											new RelationPredicateBucket(ThreadSubscriptionFields.ThreadID.In(qf.Thread.Where(threadFilter).Select(ThreadFields.ThreadID))));
			// delete the threads themselves, using the filter passed in
			adapter.DeleteEntitiesDirectly(typeof(ThreadEntity), new RelationPredicateBucket(threadFilter));

			// don't commit the transaction, that's up to the caller.
		}


		/// <summary>
		/// Sends email to all users subscribed to a specified thread, except the user who initiated the thread update.
		/// </summary>
		/// <param name="threadID">The thread that was updated.</param>
		/// <param name="initiatedByUserID">The user who initiated the update (who will not receive notification).</param>
		/// <param name="emailTemplate">The email template.</param>
		/// <param name="emailData">The email data.</param>
		private static void SendThreadReplyNotifications(int threadID, int initiatedByUserID, string emailTemplate, Dictionary<string, string> emailData)
        {
            // get list of subscribers to thread, minus the initiator. Do this by fetching the subscriptions plus the related user entity entity instances. 
			// The related user entities are loaded using a prefetch path. 
			var qf = new QueryFactory();
			var q = qf.ThreadSubscription
							.Where((ThreadSubscriptionFields.ThreadID == threadID).And(ThreadSubscriptionFields.UserID != initiatedByUserID))
							.WithPath(ThreadSubscriptionEntity.PrefetchPathUser);
	        var subscriptions = new EntityCollection<ThreadSubscriptionEntity>();
			using(var adapter = new DataAccessAdapter())
			{
				adapter.FetchQuery(q, subscriptions);
		        if(subscriptions.Count <= 0)
		        {
			        // no subscriptions, nothing to do
			        return;
		        }
	        }

	        // now collect all email addresses into an array so we can pass that to the email routine. 
            var toAddresses = new string[subscriptions.Count];
            for(int i=0;i<subscriptions.Count;i++)
            {
				toAddresses[i] = subscriptions[i].User.EmailAddress;
            }

#warning POTENTIAL CLONE OF SD.HnDUtility.HnDGeneralUtils.EmailPassword's HANDLING OF TEMPLATE.
			// use template to construct message to send. 
			var mailBody = new StringBuilder(emailTemplate);
            var applicationURL = emailData.GetValue("applicationURL") ?? string.Empty;
			if (!string.IsNullOrEmpty(emailTemplate))
            {
                // Use the existing template to format the body
	            string siteName = emailData.GetValue("siteName") ?? string.Empty;
				var thread = ThreadGuiHelper.GetThread(threadID);
	            if(thread == null)
	            {
		            // thread doesn't exist, exit
		            return;
	            }
	            var threadSubject = thread.Subject;
#warning UPDATE TO MVC URL
		        var threadUrl =  string.Format("{0}Messages.aspx?ThreadID={1}", applicationURL, thread.ThreadID);
	            mailBody.Replace("[SiteURL]", applicationURL);
                mailBody.Replace("[SiteName]", siteName);
                mailBody.Replace("[ThreadSubject]", threadSubject);
                mailBody.Replace("[ThreadURL]", threadUrl);
            }

            // format the subject
            string subject = (emailData.GetValue("emailThreadNotificationSubject") ?? string.Empty) + applicationURL;
            string fromAddress = emailData.GetValue("defaultFromEmailAddress") ?? string.Empty;

			try
			{
				//send message
				HnDGeneralUtils.SendEmail(subject, mailBody.ToString(), fromAddress, toAddresses, emailData, true);
			}
			catch(SmtpFailedRecipientsException)
			{
				// swallow as it shouldn't have any effect on further operations
			}
			catch(SmtpException)
			{
				// swallow, as there's nothing we can do
			}
			// rest: problematic, so bubble upwards.
        }


		/// <summary>
		/// Creates a new message in the given thread. Caller should validate input parameters. It potentially closes the thread if ordered to do so.
		/// </summary>
		/// <param name="threadID">Thread wherein the new message will be placed</param>
		/// <param name="userID">User who posted this message</param>
		/// <param name="messageText">Message text</param>
		/// <param name="messageAsHTML">Message text as HTML</param>
		/// <param name="userIDIPAddress">IP address of user calling this method</param>
		/// <param name="messageAsXML">Message text as XML, which is the result of the parse action on MessageText.</param>
		/// <param name="subscribeToThread">if set to <c>true</c> [subscribe to thread].</param>
		/// <param name="threadUpdatedNotificationTemplate">The thread updated notification template.</param>
		/// <param name="emailData">The email data.</param>
		/// <param name="sendReplyNotifications">Flag to signal to send reply notifications. If set to false no notifications are mailed,
		/// otherwise a notification is mailed to all subscribers to the thread the new message is posted in</param>
		/// <param name="closeThreadAfterInsert">if set to <c>true</c> it closes the thread after the message was inserted. </param>
		/// <returns>
		/// MessageID if succeeded, 0 if not.
		/// </returns>
		private static int CreateNewMessageInThreadAndPotentiallyCloseThread(int threadID, int userID, string messageText, string messageAsHTML, string userIDIPAddress, string messageAsXML,
																		bool subscribeToThread, string threadUpdatedNotificationTemplate, Dictionary<string, string> emailData,
																		bool sendReplyNotifications, bool closeThreadAfterInsert)
		{
			int messageID = 0;
			using(var adapter = new DataAccessAdapter())
			{
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "InsertNewMessage");
				try
				{
					var postingDate = DateTime.Now;
					var message = new MessageEntity
								  {
									  MessageText = messageText,
									  MessageTextAsHTML = messageAsHTML,
									  PostedByUserID = userID,
									  PostingDate = postingDate,
									  ThreadID = threadID,
									  PostedFromIP = userIDIPAddress,
									  MessageTextAsXml = messageAsXML
								  };
					messageID = adapter.SaveEntity(message) ? message.MessageID : 0;
					if(messageID > 0)
					{
						MessageManager.UpdateStatisticsAfterMessageInsert(threadID, userID, adapter, postingDate, true, subscribeToThread);
						if(closeThreadAfterInsert)
						{
							var thread = new ThreadEntity(threadID);
							var result = adapter.FetchEntity(thread);
							if(result)
							{
								thread.IsClosed = true;
								thread.IsSticky = false;
								thread.MarkedAsDone = true;
								result = adapter.SaveEntity(thread);
								if(result)
								{
									// save succeeded, so remove from queue, pass the current transaction to the method so the action takes place inside this transaction.
									SupportQueueManager.RemoveThreadFromQueue(threadID, adapter);
								}
							}
						}
					}
					adapter.Commit();
				}
				catch
				{
					adapter.Rollback();
					throw;
				}
			}
			if(sendReplyNotifications)
			{
				// send notification email to all subscribers. Do this outside the transaction so a failed email send action doesn't terminate the save process
				// of the message.
				ThreadManager.SendThreadReplyNotifications(threadID, userID, threadUpdatedNotificationTemplate, emailData);
			}
			return messageID;
		}

	}
}
