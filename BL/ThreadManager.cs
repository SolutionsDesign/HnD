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
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.Utility;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net.Mail;

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
            ThreadEntity thread = ThreadGuiHelper.GetThread(threadID);
			if(thread==null)
			{
				// not found
				return false;
			}

			thread.Memo = memo;

            //update the entity in the database
			return thread.Save();
		}


		/// <summary>
		/// Marks the thread as done.
		/// </summary>
		/// <param name="threadID">Thread ID.</param>
		/// <returns></returns>
        public static bool MarkThreadAsDone(int threadID)
		{
            // load the entity from the database
			ThreadEntity thread = ThreadGuiHelper.GetThread(threadID);
			if(thread == null)
			{
				// not found
				return false;
			}

			// get the support queue the thread is in (if any)
			SupportQueueEntity containingSupportQueue = SupportQueueGuiHelper.GetQueueOfThread(threadID);
            thread.MarkedAsDone = true;

			// if the thread is in a support queue, the thread has to be removed from that queue. This is a multi-entity action and therefore we've to start a 
			// transaction if that's the case. If not, we can use the easy route and simply save the thread and be done with it.
			if(containingSupportQueue == null)
			{
				// not in a queue, simply save the thread.
				return thread.Save();
			}

			// in a queue, so remove from the queue and save the entity.
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "MarkThreadDone");
			trans.Add(thread);
			try
			{
				// save the thread
				bool result = thread.Save();
				if(result)
				{
					// save succeeded, so remove from queue, pass the current transaction to the method so the action takes place inside this transaction.
					SupportQueueManager.RemoveThreadFromQueue(threadID, trans);
				}

				trans.Commit();
				return true;
			}
			catch
			{
				// rollback transaction
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
		}

        /// <summary>
        /// Marks the thread as un-done, and add it to the default queue of the forum.
        /// </summary>
        /// <param name="threadID">Thread ID</param>
        /// <returns></returns>
        public static bool UnMarkThreadAsDone(int threadID, int userID)
        {
            // load the entity from the database
            ThreadEntity thread = ThreadGuiHelper.GetThread(threadID);
            if (thread == null)
            {
                // not found
                return false;
            }
            
            thread.MarkedAsDone = false;

            ForumEntity forum = new ForumEntity(thread.ForumID);
            
            // Save the thread and add it to the default queue of the forum.
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "MarkThreadUnDone");
			trans.Add(thread);
			try
			{
                thread.Save();

                if ((forum.Fields.State == EntityState.Fetched) && (forum.DefaultSupportQueueID.HasValue))
                {
                    // not in a queue, and the forum has a default queue. Add the thread to the queue of the forum
                    SupportQueueManager.AddThreadToQueue(threadID, forum.DefaultSupportQueueID.Value, userID, trans);
                }

				trans.Commit();
                return true;
			}
			catch
			{
				// rollback transaction
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
        }

		/// <summary>
		/// Creates a new message in the given thread
		/// Caller should validate input parameters.
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
        public static int CreateNewMessageInThread(int threadID, int userID, string messageText, string messageAsHTML, string userIDIPAddress, 
				string messageAsXML, bool subscribeToThread, string threadUpdatedNotificationTemplate, Dictionary<string,string> emailData,
				bool sendReplyNotifications)
		{
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "InsertNewMessage");
			int messageID = 0;
			try
			{
				DateTime postingDate = DateTime.Now;
				messageID = InsertNewMessage(threadID, userID, messageText, messageAsHTML, userIDIPAddress, messageAsXML, trans, postingDate);
                MessageManager.UpdateStatisticsAfterMessageInsert(threadID, userID, trans, postingDate, true, subscribeToThread);
				trans.Commit();
			}
			catch(Exception)
			{
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}

			if(sendReplyNotifications)
			{
				// send notification email to all subscribers. Do this outside the transaction so a failed email send action doesn't terminate the save process
				// of the message.
				ThreadManager.SendThreadReplyNotifications(threadID, userID, threadUpdatedNotificationTemplate, emailData);
			}
            return messageID;
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
        public static int CreateNewMessageInThreadAndCloseThread(int threadID, int userID, string messageText, string messageAsHTML,
					string userIDIPAddress, string messageAsXML, string threadUpdatedNotificationTemplate, Dictionary<string, string> emailData,
				bool sendReplyNotifications)
		{
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "InsertNewMessage");
			int messageID = 0;
			try
			{
				DateTime postingDate = DateTime.Now;
				messageID = InsertNewMessage(threadID, userID, messageText, messageAsHTML, userIDIPAddress, messageAsXML, trans, postingDate);

				MessageManager.UpdateStatisticsAfterMessageInsert(threadID, userID, trans, postingDate, false, false);

				ThreadEntity thread = new ThreadEntity();
				trans.Add(thread);
				thread.FetchUsingPK(threadID);
				thread.IsClosed=true;
				thread.IsSticky=false;
				thread.MarkedAsDone = true;
				bool result = thread.Save();
				if(result)
				{
					// save succeeded, so remove from queue, pass the current transaction to the method so the action takes place inside this transaction.
					SupportQueueManager.RemoveThreadFromQueue(threadID, trans);
				}

				trans.Commit();
			}
			catch(Exception)
			{
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}

			if(sendReplyNotifications)
			{
				// send notification email to all subscribers. Do this outside the transaction so a failed email send action doesn't terminate the save process
				// of the message.
				ThreadManager.SendThreadReplyNotifications(threadID, userID, threadUpdatedNotificationTemplate, emailData);
			}
			return messageID;
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
            // load the entity from the database
			ThreadEntity thread = ThreadGuiHelper.GetThread(threadID);
			if(thread == null)
			{
				// not found
				return false;
			}
			
            // update the fields with new values
            thread.Subject = subject;
            thread.IsSticky = isSticky;
            thread.IsClosed = isClosed;

            // save the updated entity back to the database
            return thread.Save();
		}


		/// <summary>
		/// Moves the given thread to the given forum.
		/// </summary>
        /// <param name="threadID">ID of thread to move</param>
        /// <param name="newForumID">ID of forum to move the thread to</param>
		/// <returns></returns>
		public static bool MoveThread(int threadID, int newForumID)
		{
            // load the entity from the database
			ThreadEntity thread = ThreadGuiHelper.GetThread(threadID);
			if(thread == null)
			{
				// not found
				return false;
			}
            
            // update the ForumID field with the new value
            thread.ForumID = newForumID;

            // save the updated entity back to the database
            return thread.Save();
        }

		
		/// <summary>
		/// Deletes the given Thread from the system, including <b>all</b> messages and related data in this Thread.
		/// </summary>
		/// <param name="ID">Thread to delete.</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static bool DeleteThread(int threadID)
		{
            // trying to delete the entity directly from the database without first loading it.
            // for that we use an entity collection and use the DeleteMulti method with a filter on the PK.
			PredicateExpression threadFilter = new PredicateExpression(ThreadFields.ThreadID == threadID);
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "DeleteThread");
			try
			{
				DeleteThreads(threadFilter, trans);
				trans.Commit();
				return true;
			}
			catch
			{
				// error occured
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
        }


		/// <summary>
		/// Deletes all threads in the specified forum.
		/// </summary>
		/// <param name="forumFilter">The forum filter.</param>
		/// <param name="trans">The transaction to use.</param>
		internal static void DeleteAllThreadsInForum(int forumID, Transaction trans)
		{
			// fabricate the threadfilter, based on the passed in forumId. We do this by creating a FieldCompareValuePredicate:
            // WHERE Thread.ForumID = forumID
			PredicateExpression threadFilter = new PredicateExpression();
            threadFilter.Add(ThreadFields.ForumID == forumID);
			DeleteThreads(threadFilter, trans);
		}


		/// <summary>
		/// Deletes the threads matching the passed in filter, inside the transaction specified.
		/// </summary>
		/// <param name="threadFilter">The thread filter.</param>
		/// <param name="trans">The transaction to use.</param>
		private static void DeleteThreads(PredicateExpression threadFilter, Transaction trans)
		{
			// we've to perform a set of actions in a given order to make sure we're not violating FK constraints in the DB. 
			
			// delete messages in thread
			MessageManager.DeleteAllMessagesInThreads(threadFilter, trans);

            // delete bookmarks (if exists) of the threads to be deleted
            BookmarkCollection bookmarks = new BookmarkCollection();
            trans.Add(bookmarks);
            // use again a fieldcompareset predicate
            bookmarks.DeleteMulti(new FieldCompareSetPredicate(BookmarkFields.ThreadID, ThreadFields.ThreadID, SetOperator.In, threadFilter));

			// delete audit info related to this thread. Can't be done directly on the db due to the fact the entities are in a TargetPerEntity hierarchy, which
			// can't be deleted directly on the db, so we've to fetch the entities first. 
			AuditDataThreadRelatedCollection threadAuditData = new AuditDataThreadRelatedCollection();
			trans.Add(threadAuditData);
			// use a fieldcompareset predicate filter, based on the threadFilter. 
			threadAuditData.GetMulti(new FieldCompareSetPredicate(AuditDataThreadRelatedFields.ThreadID, ThreadFields.ThreadID, SetOperator.In, threadFilter));
			threadAuditData.DeleteMulti();

			// delete support queue thread entity for this thread (if any)
			SupportQueueThreadCollection supportQueueThreads = new SupportQueueThreadCollection();
			trans.Add(supportQueueThreads);
			// use again a fieldcompareset predicate
			supportQueueThreads.DeleteMulti(new FieldCompareSetPredicate(SupportQueueThreadFields.ThreadID, ThreadFields.ThreadID, SetOperator.In, threadFilter));

			// delete threadsubscription entities
			ThreadSubscriptionCollection threadSubscriptions = new ThreadSubscriptionCollection();
			trans.Add(threadSubscriptions);
			// use again a fieldcompareset predicate
			threadSubscriptions.DeleteMulti(new FieldCompareSetPredicate(ThreadSubscriptionFields.ThreadID, ThreadFields.ThreadID, SetOperator.In, threadFilter));

			// delete the threads
			ThreadCollection threads = new ThreadCollection();
			trans.Add(threads);
			// we already have the filter to use, namely the filter passed in.
			threads.DeleteMulti(threadFilter);

			// don't commit the transaction, that's up to the caller.
		}
		

		/// <summary>
		/// Inserts a new message in thread given. All exceptions are passed upwards, caller has full control over transaction.
		/// </summary>
		/// <param name="threadID">Thread wherein the new message will be placed</param>
		/// <param name="userID">User who posted this message</param>
		/// <param name="messageText">Message text</param>
		/// <param name="messageAsHTML">Message text as HTML</param>
		/// <param name="userIDIPAddress">IP address of user calling this method</param>
		/// <param name="messageAsXML">Message text as XML, which is the result of the parse action on MessageText.</param>
		/// <param name="transactionToUse">the open transaction to use for saving this message.</param>
		/// <param name="postingDate">The posting date.</param>
		/// <returns>new messageid</returns>
        private static int InsertNewMessage(int threadID, int userID, string messageText, string messageAsHTML, string userIDIPAddress, 
				string messageAsXML, Transaction transactionToUse, DateTime postingDate)
		{
			MessageEntity message = new MessageEntity();
			message.MessageText = messageText;
			message.MessageTextAsHTML = messageAsHTML;
			message.PostedByUserID = userID;
			message.PostingDate = postingDate;
			message.ThreadID = threadID;
			message.PostedFromIP = userIDIPAddress;
			message.MessageTextAsXml = messageAsXML;
			transactionToUse.Add(message);
			bool result = message.Save();
			if(result)
			{
				return message.MessageID;
			}
			else
			{
				return 0;
			}
		}


        /// <summary>
        /// Sends email to all users subscribed to a specified thread, except the user who initiated the thread update.
        /// </summary>
        /// <param name="threadID">The thread that was updated.</param>
        /// <param name="initiatedByUserID">The user who initiated the update (who will not receive notification).</param>
        private static void SendThreadReplyNotifications(int threadID, int initiatedByUserID, string emailTemplate, 
				Dictionary<string, string> emailData)
        {
            // get list of subscribers to thread, minus the initiator. Do this by fetching the subscriptions plus the related user entity entity instances. 
			// The related user entities are loaded using a prefetch path. 
            ThreadSubscriptionCollection subscriptions = new ThreadSubscriptionCollection();
            PrefetchPath prefetch = new PrefetchPath((int)EntityType.ThreadSubscriptionEntity);
            prefetch.Add(ThreadSubscriptionEntity.PrefetchPathUser);

			// we're interested in subscriptions on the specified thread and for all users who aren't the initiating user. 
            PredicateExpression predicate = new PredicateExpression();
            predicate.Add(ThreadSubscriptionFields.ThreadID == threadID);
            predicate.AddWithAnd(ThreadSubscriptionFields.UserID != initiatedByUserID);

			// fetch all subscriptions, using the filter and the prefetch path. 
            subscriptions.GetMulti(predicate, prefetch);

			if(subscriptions.Count <= 0)
			{
				// no subscriptions, nothing to do
				return;
			}

			// now collect all email addresses into an array so we can pass that to the email routine. 
            string[] toAddresses = new string[subscriptions.Count];

            for(int i=0;i<subscriptions.Count;i++)
            {
				toAddresses[i] = subscriptions[i].User.EmailAddress;
            }

            // use template to construct message to send. 
            StringBuilder mailBody = new StringBuilder(emailTemplate);
            string applicationURL = string.Empty;
            emailData.TryGetValue("applicationURL", out applicationURL);

			if (!string.IsNullOrEmpty(emailTemplate))
            {
                // Use the existing template to format the body
                string siteName = string.Empty;
                emailData.TryGetValue("siteName", out siteName);

                string threadSubject = string.Empty;
                string threadUrl = string.Empty;

				ThreadEntity thread = ThreadGuiHelper.GetThread(threadID);
				if(thread != null)
				{
					threadSubject = thread.Subject;
					threadUrl = applicationURL + string.Format("Messages.aspx?ThreadID={0}", thread.ThreadID);
				}
				else
				{
					// thread doesn't exist, exit
					return;
				}

                mailBody.Replace("[SiteURL]", applicationURL);
                mailBody.Replace("[SiteName]", siteName);
                mailBody.Replace("[ThreadSubject]", threadSubject);
                mailBody.Replace("[ThreadURL]", threadUrl);
            }

            // format the subject
            string subject = string.Empty;
            emailData.TryGetValue("emailThreadNotificationSubject", out subject);
            subject += applicationURL;

            string fromAddress = string.Empty;
            emailData.TryGetValue("defaultFromEmailAddress", out fromAddress);

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
	}
}
