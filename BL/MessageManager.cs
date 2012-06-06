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
using SD.HnD.Utility;

using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.FactoryClasses;

namespace SD.HnD.BL
{
	/// <summary>
	/// General class for Message management related tasks
	/// </summary>
	public static class MessageManager
	{
		/// <summary>
		/// Deletes the given message from the database and the complete logged history.
		/// </summary>
		/// <param name="messageID">The ID of the message to delete</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static bool DeleteMessage(int messageID)
		{
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "DeleteMessage");

            try
			{
				// formulate a filter so we can re-use the delete routine for all messages in threads matching a filter. 
				PredicateExpression messageFilter = new PredicateExpression(MessageFields.MessageID == messageID);

				// call the routine which is used to delete 1 or more messages and related data from the db.
				DeleteMessages(messageFilter, trans);
				trans.Commit();
				return true;
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
		}
		

		/// <summary>
		/// Deletes all messages in threads which match the passed in filter. 
		/// </summary>
		/// <param name="threadFilter">The thread filter.</param>
		/// <param name="trans">The transaction to use.</param>
		internal static void DeleteAllMessagesInThreads(PredicateExpression threadFilter, Transaction trans)
		{
			// fabricate the messagefilter, based on the passed in filter on threads. We do this by creating a FieldCompareSetPredicate:
			// WHERE Message.ThreadID IN (SELECT ThreadID FROM Thread WHERE threadFilter)
			var messageFilter = MessageFields.ThreadID.In(new QueryFactory().Create()
																.Select(ThreadFields.ThreadID)
																.Where(threadFilter));
			DeleteMessages(messageFilter, trans);
		}


		/// <summary>
		/// Deletes the messages matching the messagefilter passed in
		/// </summary>
		/// <param name="messageFilter">The message filter.</param>
		/// <param name="trans">The transaction to use.</param>
		private static void DeleteMessages(IPredicate messageFilter, Transaction trans)
		{
			// first delete all audit info for these message. This isn't done by a batch call directly on the db, as this is a targetperentity hierarchy
			// which can't be deleted directly into the database in all cases, so we first fetch the entities to delete. 
			AuditDataMessageRelatedCollection messageAudits = new AuditDataMessageRelatedCollection();
			trans.Add(messageAudits);
			// use a fieldcompareset predicate to get the auditdata related to this message and then delete all of them using the collection.
			messageAudits.GetMulti(new FieldCompareSetPredicate(AuditDataMessageRelatedFields.MessageID, MessageFields.MessageID, SetOperator.In, messageFilter));
			messageAudits.DeleteMulti();

			// delete all attachments for this message. This can be done directly onto the db.
			AttachmentCollection attachments = new AttachmentCollection();
			trans.Add(attachments);
			// delete these directly from the db, using a fieldcompareset predicate
			attachments.DeleteMulti(new FieldCompareSetPredicate(AttachmentFields.MessageID, MessageFields.MessageID, SetOperator.In, messageFilter));

			// delete the message/messages
			MessageCollection messages = new MessageCollection();
			trans.Add(messages);
			// use the passed in filter to remove the messages
			messages.DeleteMulti(messageFilter);

			// don't commit the transaction, leave that to the caller.
		}


		/// <summary>
		/// Updates the given message with the message passed, and logs the user passed as the changer of this
		/// message.
		/// </summary>
		/// <param name="editorUserID">ID of user who changed the message</param>
		/// <param name="editedMessageID">ID of message which was changed</param>
		/// <param name="messageText">Changed message text</param>
		/// <param name="messageAsHTML">Changed message text in HTML</param>
		/// <param name="editorUserIDIPAddress">IP address used to make the modification. This IP address is logged with the
		/// change to keep evidence who made which change from which IP address</param>
		/// <param name="messageAsXML">Message text as XML, which is the result of the parse action on MessageText.</param>
		/// <returns>True if succeeded, false otherwise</returns>
		/// <remarks>This routine is migrated to LLBLGen Pro</remarks>
        public static bool UpdateEditedMessage(int editorUserID, int editedMessageID, string messageText, string messageAsHTML, 
				string editorUserIDIPAddress, string messageAsXML)
		{
            // now save the message. First pull it from the db
			MessageEntity message = new MessageEntity(editedMessageID);

            //update the fields with the new passed values
			message.MessageText = messageText;
			message.MessageTextAsHTML = messageAsHTML;
			message.MessageTextAsXml = messageAsXML;
			return message.Save();
		}


		/// <summary>
		/// Re-parses all messages from start date till now or when amountToIndex is reached. This routine will read messagetext for a message,
		/// parse it, and update the MessageTextAsXML field with the parse result. 
		/// </summary>
		/// <param name="amountToParse">Amount to parse.</param>
		/// <param name="startDate">Start date.</param>
		/// <param name="reGenerateHTML">If true, the HTML is also re-generated and saved.</param>
		/// <returns>the amount of messages re-parsed</returns>
		public static int ReParseMessages(int amountToParse, DateTime startDate, bool reGenerateHTML, ParserData parserData)
		{
			// index is blocks of 100 messages.
			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(MessageFields.MessageID, MessageFields.MessageText)
						.Where(MessageFields.PostingDate >= new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 0));

			if(amountToParse <= 0)
			{
				// If we don't have a specific amount of messages to parse, then parse all messages posted till Now.
				q.AndWhere(MessageFields.PostingDate <= DateTime.Now);
			}

			TypedListDAO dao = new TypedListDAO();

			bool parsingFinished = false;
			int amountProcessed = 0;
			int pageSize = 100;
			int pageNo = 1;

			while(!parsingFinished)
			{
				q.Page(pageNo, pageSize);
				DataTable messagesToParse = dao.FetchAsDataTable(q);
				parsingFinished = (messagesToParse.Rows.Count <= 0);

				if(!parsingFinished)
				{
					foreach(DataRow row in messagesToParse.Rows)
					{
						MessageEntity directUpdater = new MessageEntity();
						directUpdater.IsNew = false;

						string messageXML = string.Empty;
						string messageHTML = string.Empty;
						TextParser.ReParseMessage((string)row["MessageText"], reGenerateHTML, parserData, out messageXML, out messageHTML);

						// use the directupdater entity to create an update query without fetching the entity first.
						directUpdater.Fields[(int)MessageFieldIndex.MessageID].ForcedCurrentValueWrite((int)row["MessageID"]);
						directUpdater.MessageTextAsXml = messageXML;

						if(reGenerateHTML)
						{
							directUpdater.MessageTextAsHTML=messageHTML;
						}
						directUpdater.Fields.IsDirty=true;

						// no transactional update.
						directUpdater.Save();
					}

					amountProcessed += messagesToParse.Rows.Count;
					pageNo++;

					if(amountToParse > 0)
					{
						parsingFinished = (amountToParse <= amountProcessed);
					}
				}
			}
			return amountProcessed;
		}


		/// <summary>
		/// Deletes the attachment with the id specified.
		/// </summary>
		/// <param name="attachmentID">The attachment ID.</param>
		public static void DeleteAttachment(int attachmentID)
		{
			// delete the attachment directly from the db, without loading it first into memory, so the attachment won't eat up memory unnecessary.
			AttachmentCollection attachments = new AttachmentCollection();
			attachments.DeleteMulti((AttachmentFields.AttachmentID == attachmentID));
		}


		/// <summary>
		/// Approves / revokes the approval of the attachment with ID passed in.
		/// </summary>
		/// <param name="attachmentID">The attachment ID.</param>
		/// <param name="approved">the new flag value for Approved</param>
		public static void ModifyAttachmentApproval(int attachmentID, bool approved)
		{
			// we'll update the approved flag directly in the db, so we don't load the whole attachment into memory. 
			AttachmentEntity updater = new AttachmentEntity();
			AttachmentCollection attachments = new AttachmentCollection();
			updater.Approved = approved;
			attachments.UpdateMulti(updater, (AttachmentFields.AttachmentID == attachmentID));
		}


		/// <summary>
		/// Adds a new attachment to the message with messageID specified. 
		/// </summary>
		/// <param name="messageID">The message ID.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="fileContents">The file contents.</param>
		/// <param name="approveValue">the value for the approved flag</param>
		public static void AddAttachment(int messageID, string fileName, byte[] fileContents, bool approveValue)
		{
			AttachmentEntity newAttachment = new AttachmentEntity();
			newAttachment.MessageID = messageID;
			newAttachment.Filename = fileName;
			newAttachment.Filecontents = fileContents;
			newAttachment.Filesize = fileContents.Length;
			newAttachment.Approved = approveValue;
			newAttachment.AddedOn = DateTime.Now;

			// save.
			newAttachment.Save();
		}


		/// <summary>
		/// Updates the user/forum/thread statistics after a message insert. Also makes sure if the thread isn't in a queue and the forum has a default support
		/// queue that the thread is added to that queue
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="userID">The user ID.</param>
		/// <param name="transactionToUse">The transaction to use.</param>
		/// <param name="postingDate">The posting date.</param>
		/// <param name="addToQueueIfRequired">if set to true, the thread will be added to the default queue of the forum the thread is in, if the forum
		/// has a default support queue and the thread isn't already in a queue.</param>
		/// <remarks>Leaves the passed in transaction open, so it doesn't commit/rollback, it just performs a set of actions inside the
		/// passed in transaction.</remarks>
		internal static void UpdateStatisticsAfterMessageInsert(int threadID, int userID, Transaction transactionToUse, DateTime postingDate, bool addToQueueIfRequired, bool subscribeToThread)
		{
			// user statistics
			UserEntity userUpdater = new UserEntity();
			// set the amountofpostings field to an expression so it will be increased with 1. 
			userUpdater.Fields[(int)UserFieldIndex.AmountOfPostings].ExpressionToApply = (UserFields.AmountOfPostings + 1);
			UserCollection users = new UserCollection();
			transactionToUse.Add(users);
			users.UpdateMulti(userUpdater, (UserFields.UserID == userID));	// update directly on the DB. 

			// thread statistics
			ThreadEntity threadUpdater = new ThreadEntity();
			threadUpdater.ThreadLastPostingDate = postingDate;
			threadUpdater.MarkedAsDone = false;
			ThreadCollection threads = new ThreadCollection();
			transactionToUse.Add(threads);
			threads.UpdateMulti(threadUpdater, (ThreadFields.ThreadID == threadID));

			// forum statistics. Load the forum from the DB, as we need it later on. Use a fieldcompareset predicate to fetch the forum as we don't know the 
			// forumID as we haven't fetched the thread
			ForumCollection forums = new ForumCollection();
			transactionToUse.Add(forums);
			// use a fieldcompare set predicate to select the forumid based on the thread. This filter is equal to
			// WHERE ForumID == (SELECT ForumID FROM Thread WHERE ThreadID=@ThreadID)
			var forumFilter = new FieldCompareSetPredicate(
								ForumFields.ForumID, ThreadFields.ForumID, SetOperator.Equal, (ThreadFields.ThreadID == threadID));
			forums.GetMulti(forumFilter);
			ForumEntity containingForum = null;
			if(forums.Count>0)
			{
				// forum found. There's just one.
				containingForum = forums[0];
				containingForum.ForumLastPostingDate = postingDate;
				// save the forum. Just save the collection
				forums.SaveMulti();
			}

			if(addToQueueIfRequired)
			{
				// If the thread involved isn't in a queue, place it in the default queue of the forum (if applicable)
				SupportQueueEntity containingQueue = SupportQueueGuiHelper.GetQueueOfThread(threadID, transactionToUse);
				if((containingQueue == null) && (containingForum != null) && (containingForum.DefaultSupportQueueID.HasValue))
				{
					// not in a queue, and the forum has a default queue. Add the thread to the queue of the forum
					SupportQueueManager.AddThreadToQueue(threadID, containingForum.DefaultSupportQueueID.Value, userID, transactionToUse);
				}
			}

            //subscribe to thread if indicated
            if(subscribeToThread)
            {
				UserManager.AddThreadToSubscriptions(threadID, userID, transactionToUse);
            }
		}
	}
}
