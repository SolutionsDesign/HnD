/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
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
using System.Data;
using System.Threading.Tasks;
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
		/// <param name="messageId">The ID of the message to delete</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static async Task<bool> DeleteMessageAsync(int messageId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "DeleteMessage").ConfigureAwait(false);
				try
				{
					await DeleteMessagesAsync(MessageFields.MessageID.Equal(messageId), adapter);
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
		internal static Task DeleteAllMessagesInThreadsAsync(PredicateExpression threadFilter, IDataAccessAdapter adapter)
		{
			// Create the messagefilter, based on the passed in filter on threads. We do this by creating a FieldCompareSetPredicate:
			// WHERE Message.ThreadID IN (SELECT ThreadID FROM Thread WHERE threadFilter)
			var messageFilter = MessageFields.ThreadID.In(new QueryFactory().Create().Select(ThreadFields.ThreadID).Where(threadFilter));
			return DeleteMessagesAsync(messageFilter, adapter);
		}


		/// <summary>
		/// Deletes the messages matching the messagefilter passed in
		/// </summary>
		/// <param name="messageFilter">The message filter.</param>
		/// <param name="adapter">The adapter to use for persistence activity.</param>
		/// <remarks>The caller has to have started a transaction on the passed in adapter</remarks>
		private static async Task DeleteMessagesAsync(IPredicate messageFilter, IDataAccessAdapter adapter)
		{
			// first delete all audit info for these message. This isn't done by a batch call directly on the db, as this is a targetperentity hierarchy
			// which can't be deleted directly into the database in all cases, so we first fetch the entities to delete. 
			var qf = new QueryFactory();
			var q = qf.AuditDataMessageRelated.Where(AuditDataMessageRelatedFields.MessageID.In(qf.Create()
																								  .Select(MessageFields.MessageID)
																								  .Where(messageFilter)));
			var messageAudits = await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			await adapter.DeleteEntityCollectionAsync(messageAudits).ConfigureAwait(false);

			// delete all attachments for this message. This can be done directly onto the db.
			await adapter.DeleteEntitiesDirectlyAsync(typeof(AttachmentEntity),
													  new RelationPredicateBucket(AttachmentFields.MessageID.In(qf.Create()
																												  .Select(MessageFields.MessageID)
																												  .Where(messageFilter))))
						 .ConfigureAwait(false);
			await adapter.DeleteEntitiesDirectlyAsync(typeof(MessageEntity), new RelationPredicateBucket(messageFilter)).ConfigureAwait(false);

			// don't commit the transaction, leave that to the caller.
		}


		/// <summary>
		/// Updates the given message with the message passed, and logs the user passed as the changer of this message.
		/// </summary>
		/// <param name="editorUserId">ID of user who changed the message</param>
		/// <param name="editedMessageId">ID of message which was changed</param>
		/// <param name="messageText">Changed message text</param>
		/// <param name="messageAsHTML">Changed message text in HTML</param>
		/// <param name="editorUserIDIPAddress">IP address used to make the modification. This IP address is logged with the
		/// change to keep evidence who made which change from which IP address</param>
		/// <param name="messageAsXML">Message text as XML, which is the result of the parse action on MessageText.</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static async Task<bool> UpdateEditedMessageAsync(int editorUserId, int editedMessageId, string messageText, string messageAsHTML,
																string editorUserIDIPAddress, string messageAsXML)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// now save the message. First pull it from the db
				var q = new QueryFactory().Message.Where(MessageFields.MessageID.Equal(editedMessageId));
				var message = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
				if(message == null)
				{
					return false;
				}

				//update the fields with the new passed values
				message.MessageText = messageText;
				message.MessageTextAsHTML = messageAsHTML;
				return await adapter.SaveEntityAsync(message).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Re-parses all messages. This routine will read messagetext for a message, parse its markdown to HTML, and update the MessageTextAsHTML field with
		/// the parse result directly. It's mainly used to apply a change in html output for given input, e.g. when
		/// markdown to HTML for messages have been changed, and is not used often, hence it's simply processing one entity at a time, keeping the connection open. It's not 
		/// fetching all entities and then persisting them again, as that would be potentially harmful for memory as a forum system can have a lot of messages. 
		/// </summary>
		/// <param name="emojiFilenamesPerName">the emojiname to filename mappings</param>
		/// <param name="smileyMappings">The shortcut to emoji mappings for the old smileys</param>
		/// <param name="consoleLogger">to log low-level feedback. For development. In release builds it's not used.</param>
		/// <returns>
		/// the amount of messages re-parsed
		/// </returns>
		public static async Task<int> ReParseMessagesAsync(Dictionary<string, string> emojiFilenamesPerName, Dictionary<string, string> smileyMappings,
														   Action<string> consoleLogger)
		{
			// index is blocks of 100 messages.
			var q = new QueryFactory().Create().Select(MessageFields.MessageID, MessageFields.MessageText);

			var parsingFinished = false;
			var amountProcessed = 0;
			var pageSize = 200;
			var pageNo = 1;
			using(var adapter = new DataAccessAdapter())
			{
				adapter.BatchSize = pageSize;
				while(!parsingFinished)
				{
					q.Page(pageNo, pageSize);
					var messagesToParse = await adapter.FetchQueryAsync(q).ConfigureAwait(false);
					parsingFinished = (messagesToParse.Count <= 0);

					if(!parsingFinished)
					{
						foreach(var row in messagesToParse)
						{
							var directUpdater = new MessageEntity();
							directUpdater.IsNew = false;

							try
							{
								// use the in-memory message entity to create an update query without fetching the entity first.
								// we're fetching an array of 2 values per row. We don't do a typed projection as we just want the data to be as small as possible
								directUpdater.Fields[(int)MessageFieldIndex.MessageID].ForcedCurrentValueWrite((int)row[0]);
								directUpdater.MessageTextAsHTML = HnDGeneralUtils.TransformMarkdownToHtml((string)row[1], emojiFilenamesPerName, smileyMappings);
								directUpdater.Fields.IsDirty = true;
							}
							catch(Exception ex)
							{
#if DEBUG
								consoleLogger(string.Format("Exception occurred at msgid: {0}\n{1}", (int)row[0], ex.Message));
								throw;
#endif
							}

							await adapter.SaveEntityAsync(directUpdater).ConfigureAwait(false);
						}

						amountProcessed += messagesToParse.Count;
						pageNo++;
					}
#if DEBUG
					if(pageNo % 10 == 0)
					{
						consoleLogger(string.Format("{0} messages done...", amountProcessed));
					}
#endif
				}
			}

			return amountProcessed;
		}


		/// <summary>
		/// Deletes the attachment with the id specified.
		/// </summary>
		/// <param name="messageId">the messageid of the message the attachment belongs to</param>
		/// <param name="attachmentId">The attachment ID.</param>
		public static async Task DeleteAttachmentAsync(int messageId, int attachmentId)
		{
			// delete the attachment directly from the db, without loading it first into memory
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.DeleteEntitiesDirectlyAsync(typeof(AttachmentEntity),
														  new RelationPredicateBucket(AttachmentFields.AttachmentID.Equal(attachmentId)
																									  .And(AttachmentFields.MessageID.Equal(messageId))))
							 .ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Toggles the approval of the attachment with ID passed in. Optionally audits the change if userIdForAuditing is set to a value of 1 or higher
		/// </summary>
		/// <param name="messageId">the id of the message the attachment is assigned to</param>
		/// <param name="attachmentId">The attachment ID.</param>
		/// <param name="userIdForAuditing">THe user id for the auditing action if the change was successful. If 0 or lower, it's ignored and no auditing will take place</param>
		/// <returns>tuple with two flags: toggleResult and newState. toggleResult can be true if operation was successful, false otherwise. If false, newState is undefined.</returns>
		public static async Task<(bool toggleResult, bool newState)> ToggleAttachmentApprovalAsync(int messageId, int attachmentId, int userIdForAuditing)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// fetch the attachment, but exclude the file contents, as we don't need that and it can be quite big
				var q = new QueryFactory().Attachment.Where(AttachmentFields.AttachmentID.Equal(attachmentId).And(AttachmentFields.MessageID.Equal(messageId)))
										  .Exclude(AttachmentFields.Filecontents);
				var attachment = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
				if(attachment == null)
				{
					// not found
					return (false, false);
				}

				if(userIdForAuditing > 0)
				{
					await SecurityManager.AuditApproveAttachmentAsync(userIdForAuditing, attachmentId);
				}

				attachment.Approved = !attachment.Approved;
				var newState = attachment.Approved;
				await adapter.SaveEntityAsync(attachment).ConfigureAwait(false);
				return (true, newState);
			}
		}


		/// <summary>
		/// Adds a new attachment to the message with messageID specified. 
		/// </summary>
		/// <param name="messageID">The message ID.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="fileContents">The file contents.</param>
		/// <param name="approveValue">the value for the approved flag</param>
		public static async Task AddAttachmentAsync(int messageID, string fileName, byte[] fileContents, bool approveValue)
		{
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.SaveEntityAsync(new AttachmentEntity
											  {
												  MessageID = messageID,
												  Filename = fileName,
												  Filecontents = fileContents,
												  Filesize = fileContents.Length,
												  Approved = approveValue,
												  AddedOn = DateTime.Now
											  }).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Updates the user/forum/thread statistics after a message insert. Also makes sure if the thread isn't in a queue and the forum has a default support
		/// queue that the thread is added to that queue
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="userId">The user ID.</param>
		/// <param name="adapter">The adapter to use, which is assumed to have a live transaction active</param>
		/// <param name="postingDate">The posting date.</param>
		/// <param name="addToQueueIfRequired">if set to true, the thread will be added to the default queue of the forum the thread is in, if the forum
		/// has a default support queue and the thread isn't already in a queue.</param>
		/// <param name="subscribeToThread">if set to <c>true</c> [subscribe to thread].</param>
		/// <remarks>
		/// Leaves the passed in transaction open, so it doesn't commit/rollback, it just performs a set of actions inside the
		/// passed in transaction.
		/// </remarks>
		internal static async Task UpdateStatisticsAfterMessageInsert(int threadId, int userId, IDataAccessAdapter adapter, DateTime postingDate, bool addToQueueIfRequired,
																	  bool subscribeToThread)
		{
			// user statistics
			var userUpdater = new UserEntity();

			// set the amountofpostings field to an expression so it will be increased with 1. Update the entity directly in the DB
			userUpdater.Fields[(int)UserFieldIndex.AmountOfPostings].ExpressionToApply = (UserFields.AmountOfPostings + 1);
			await adapter.UpdateEntitiesDirectlyAsync(userUpdater, new RelationPredicateBucket(UserFields.UserID.Equal(userId)))
						 .ConfigureAwait(false);

			// thread statistics
			var threadUpdater = new ThreadEntity {ThreadLastPostingDate = postingDate, MarkedAsDone = false};
			await adapter.UpdateEntitiesDirectlyAsync(threadUpdater, new RelationPredicateBucket(ThreadFields.ThreadID.Equal(threadId)))
						 .ConfigureAwait(false);

			// forum statistics. Load the forum from the DB, as we need it later on. Use a nested query to fetch the forum as we don't know the 
			// forumID as we haven't fetched the thread
			var qf = new QueryFactory();
			var q = qf.Forum
					  .Where(ForumFields.ForumID.In(qf.Create()
													  .Select(ThreadFields.ForumID)
													  .Where(ThreadFields.ThreadID.Equal(threadId))));
			var containingForum = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			if(containingForum != null)
			{
				containingForum.ForumLastPostingDate = postingDate;

				// save the forum.
				await adapter.SaveEntityAsync(containingForum, true).ConfigureAwait(false);
				if(addToQueueIfRequired && containingForum.DefaultSupportQueueID.HasValue)
				{
					// If the thread involved isn't in a queue, place it in the default queue of the forum (if applicable)
					var containingQueue = await SupportQueueGuiHelper.GetQueueOfThreadAsync(threadId, adapter);
					if(containingQueue == null)
					{
						// not in a queue, and the forum has a default queue. Add the thread to the queue of the forum
						await SupportQueueManager.AddThreadToQueueAsync(threadId, containingForum.DefaultSupportQueueID.Value, userId, adapter);
					}
				}
			}

			//subscribe to thread if indicated
			if(subscribeToThread)
			{
				await UserManager.AddThreadToSubscriptionsAsync(threadId, userId, adapter);
			}
		}
	}
}