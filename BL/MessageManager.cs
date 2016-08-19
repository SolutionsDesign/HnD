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
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

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
			using(var adapter = new DataAccessAdapter())
			{
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "DeleteMessage");
				try
				{
					DeleteMessages(MessageFields.MessageID == messageID, adapter);
					adapter.Commit();
					return true;
				}
				catch
				{
					adapter.Rollback();
					throw;
				}
			}
		}


		/// <summary>
		/// Deletes all messages in threads which match the passed in filter. 
		/// </summary>
		/// <param name="threadFilter">The thread filter.</param>
		/// <param name="adapter">The adapter to use for persistence activity.</param>
		internal static void DeleteAllMessagesInThreads(PredicateExpression threadFilter, IDataAccessAdapter adapter)
		{
			// fabricate the messagefilter, based on the passed in filter on threads. We do this by creating a FieldCompareSetPredicate:
			// WHERE Message.ThreadID IN (SELECT ThreadID FROM Thread WHERE threadFilter)
			var messageFilter = MessageFields.ThreadID.In(new QueryFactory().Create()
																.Select(ThreadFields.ThreadID)
																.Where(threadFilter));
			DeleteMessages(messageFilter, adapter);
		}


		/// <summary>
		/// Deletes the messages matching the messagefilter passed in
		/// </summary>
		/// <param name="messageFilter">The message filter.</param>
		/// <param name="adapter">The adapter to use for persistence activity.</param>
		private static void DeleteMessages(IPredicate messageFilter, IDataAccessAdapter adapter)
		{
			// first delete all audit info for these message. This isn't done by a batch call directly on the db, as this is a targetperentity hierarchy
			// which can't be deleted directly into the database in all cases, so we first fetch the entities to delete. 
			var qf = new QueryFactory();
			var q = qf.AuditDataMessageRelated
							.Where(AuditDataMessageRelatedFields.MessageID.In(qf.Create()
																					.Select(MessageFields.MessageID)
																					.Where(messageFilter)));
			var messageAudits = adapter.FetchQuery(q);
			adapter.DeleteEntityCollection(messageAudits);

			// delete all attachments for this message. This can be done directly onto the db.
			adapter.DeleteEntitiesDirectly(typeof(AttachmentEntity),
										   new RelationPredicateBucket(AttachmentFields.MessageID.In(qf.Create()
																									   .Select(MessageFields.MessageID)
																									   .Where(messageFilter))));
			adapter.DeleteEntitiesDirectly(typeof(MessageEntity), new RelationPredicateBucket(messageFilter));
			// don't commit the transaction, leave that to the caller.
		}


		/// <summary>
		/// Updates the given message with the message passed, and logs the user passed as the changer of this message.
		/// </summary>
		/// <param name="editorUserID">ID of user who changed the message</param>
		/// <param name="editedMessageID">ID of message which was changed</param>
		/// <param name="messageText">Changed message text</param>
		/// <param name="messageAsHTML">Changed message text in HTML</param>
		/// <param name="editorUserIDIPAddress">IP address used to make the modification. This IP address is logged with the
		/// change to keep evidence who made which change from which IP address</param>
		/// <param name="messageAsXML">Message text as XML, which is the result of the parse action on MessageText.</param>
		/// <returns>True if succeeded, false otherwise</returns>
        public static bool UpdateEditedMessage(int editorUserID, int editedMessageID, string messageText, string messageAsHTML, string editorUserIDIPAddress, string messageAsXML)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// now save the message. First pull it from the db
				var message = new MessageEntity(editedMessageID);
				var result = adapter.FetchEntity(message);
				if(!result)
				{
					return false;
				}

				//update the fields with the new passed values
				message.MessageText = messageText;
				message.MessageTextAsHTML = messageAsHTML;
				message.MessageTextAsXml = messageAsXML;
				return adapter.SaveEntity(message);
			}
		}


		/// <summary>
		/// Re-parses all messages from start date till now or when amountToIndex is reached. This routine will read messagetext for a message,
		/// parse it, and update the MessageTextAsXML field with the parse result. It's mainly used to apply a change in html output for given input, e.g. when 
		/// xml templates for messages have been changed, and is not used often, hence it's simply processing one entity at a time, keeping the connection open.
		/// </summary>
		/// <param name="amountToParse">Amount to parse.</param>
		/// <param name="startDate">Start date.</param>
		/// <param name="reGenerateHTML">If true, the HTML is also re-generated and saved.</param>
		/// <param name="parserData">The parser data to use with the text parser to parse messages.</param>
		/// <returns>
		/// the amount of messages re-parsed
		/// </returns>
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

			bool parsingFinished = false;
			int amountProcessed = 0;
			int pageSize = 100;
			int pageNo = 1;
			using(var adapter = new DataAccessAdapter())
			{
				while(!parsingFinished)
				{
					q.Page(pageNo, pageSize);
					DataTable messagesToParse = adapter.FetchAsDataTable(q);
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

							// use the in-memory message entity to create an update query without fetching the entity first.
							directUpdater.Fields[(int)MessageFieldIndex.MessageID].ForcedCurrentValueWrite((int)row["MessageID"]);
							directUpdater.MessageTextAsXml = messageXML;

							if(reGenerateHTML)
							{
								directUpdater.MessageTextAsHTML = messageHTML;
							}
							directUpdater.Fields.IsDirty = true;
							adapter.SaveEntity(directUpdater);
						}

						amountProcessed += messagesToParse.Rows.Count;
						pageNo++;

						if(amountToParse > 0)
						{
							parsingFinished = (amountToParse <= amountProcessed);
						}
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
			// delete the attachment directly from the db, without loading it first into memory
			using(var adapter = new DataAccessAdapter())
			{
				adapter.DeleteEntitiesDirectly(typeof(AttachmentEntity), new RelationPredicateBucket(AttachmentFields.AttachmentID == attachmentID));
			}
		}


		/// <summary>
		/// Approves / revokes the approval of the attachment with ID passed in.
		/// </summary>
		/// <param name="attachmentID">The attachment ID.</param>
		/// <param name="approved">the new flag value for Approved</param>
		public static void ModifyAttachmentApproval(int attachmentID, bool approved)
		{
			// we'll update the approved flag directly in the db, so we don't have to load the entity into memory first. 
			using(var adapter = new DataAccessAdapter())
			{
				adapter.UpdateEntitiesDirectly(new AttachmentEntity {Approved = approved}, new RelationPredicateBucket(AttachmentFields.AttachmentID == attachmentID));
			}
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
			using(var adapter = new DataAccessAdapter())
			{
				adapter.SaveEntity(new AttachmentEntity
								   {
									   MessageID = messageID,
									   Filename = fileName,
									   Filecontents = fileContents,
									   Filesize = fileContents.Length,
									   Approved = approveValue,
									   AddedOn = DateTime.Now
								   });
			}
		}


		/// <summary>
		/// Updates the user/forum/thread statistics after a message insert. Also makes sure if the thread isn't in a queue and the forum has a default support
		/// queue that the thread is added to that queue
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="userID">The user ID.</param>
		/// <param name="adapter">The adapter to use, which is assumed to have a live transaction active</param>
		/// <param name="postingDate">The posting date.</param>
		/// <param name="addToQueueIfRequired">if set to true, the thread will be added to the default queue of the forum the thread is in, if the forum
		/// has a default support queue and the thread isn't already in a queue.</param>
		/// <param name="subscribeToThread">if set to <c>true</c> [subscribe to thread].</param>
		/// <remarks>
		/// Leaves the passed in transaction open, so it doesn't commit/rollback, it just performs a set of actions inside the
		/// passed in transaction.
		/// </remarks>
		internal static void UpdateStatisticsAfterMessageInsert(int threadID, int userID, IDataAccessAdapter adapter, DateTime postingDate, bool addToQueueIfRequired, bool subscribeToThread)
		{
			// user statistics
			var userUpdater = new UserEntity();
			// set the amountofpostings field to an expression so it will be increased with 1. Update the entity directly in the DB
			userUpdater.Fields[(int)UserFieldIndex.AmountOfPostings].ExpressionToApply = (UserFields.AmountOfPostings + 1);
			adapter.UpdateEntitiesDirectly(userUpdater, new RelationPredicateBucket(UserFields.UserID == userID));

			// thread statistics
			var threadUpdater = new ThreadEntity();
			threadUpdater.ThreadLastPostingDate = postingDate;
			threadUpdater.MarkedAsDone = false;
			adapter.UpdateEntitiesDirectly(threadUpdater, new RelationPredicateBucket(ThreadFields.ThreadID == threadID));

			// forum statistics. Load the forum from the DB, as we need it later on. Use a nested query to fetch the forum as we don't know the 
			// forumID as we haven't fetched the thread
			var qf = new QueryFactory();
			var q = qf.Forum
					  .Where(ForumFields.ForumID.In(qf.Create()
													  .Select(ThreadFields.ForumID)
													  .Where(ThreadFields.ThreadID.Equal(threadID))));
			var containingForum = adapter.FetchFirst(q);
			if(containingForum!=null)
			{
				containingForum.ForumLastPostingDate = postingDate;
				// save the forum.
				adapter.SaveEntity(containingForum);
				if(addToQueueIfRequired && containingForum.DefaultSupportQueueID.HasValue)
				{
					// If the thread involved isn't in a queue, place it in the default queue of the forum (if applicable)
					var containingQueue = SupportQueueGuiHelper.GetQueueOfThread(threadID, adapter);
					if(containingQueue == null)
					{
						// not in a queue, and the forum has a default queue. Add the thread to the queue of the forum
						SupportQueueManager.AddThreadToQueue(threadID, containingForum.DefaultSupportQueueID.Value, userID, adapter);
					}
				}
			}

			//subscribe to thread if indicated
			if(subscribeToThread)
            {
				UserManager.AddThreadToSubscriptions(threadID, userID, adapter);
            }
		}
	}
}
