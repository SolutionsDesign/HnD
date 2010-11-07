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

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL;
using System.Collections.Generic;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Message Gui
	/// </summary>
	public static class MessageGuiHelper
	{
		/// <summary>
		/// Gets the number of postings in all threads of all forums on this system. 
		/// </summary>
		/// <returns>the total of all posts on the entire forum system</returns>
		public static int GetTotalNumberOfMessages()
		{
			MessageCollection messages = new MessageCollection();
			return messages.GetDbCount();
		}


		/// <summary>
		/// Gets the total number of attachments to approve.
		/// </summary>
		/// <param name="accessableForums">The accessable forums by the user calling.</param>
		/// <param name="forumsWithApprovalRight">The forums the calling user has attachment approval rights.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums the calling user can view normal threads from others.</param>
		/// <param name="userID">The user ID of the calling user.</param>
		/// <returns>the # of attachments with the approval state which are approvable by the calling user</returns>
		public static int GetTotalNumberOfAttachmentsToApprove(List<int> accessableForums, List<int> forumsWithApprovalRight,
				List<int> forumsWithThreadsFromOthers, int userID)
		{
			if((accessableForums == null) || (accessableForums.Count <= 0))
			{
				// doesn't have access to any forum, return
				return 0;
			}
			if((forumsWithApprovalRight == null) || (forumsWithApprovalRight.Count <= 0))
			{
				// doesn't have a forum with attachment approval right
				return 0;
			}

			// we'll use a GetDBCount call, where we'll specify a filter. 

			// we've to join attachment - message - thread, so we've to create a RelationCollection with the necessary relations. 
			RelationCollection relations = new RelationCollection();
			relations.Add(AttachmentEntity.Relations.MessageEntityUsingMessageID);
			relations.Add(MessageEntity.Relations.ThreadEntityUsingThreadID);

			// we've to filter the list of attachments based on the forums accessable by the calling user, the list of forums the calling user has approval rights
			// on and by the forums on which the user can see other user's threads. We'll create a predicate expression for this, and will add for each of these
			// filters a separate predicate to this predicate expression and specify AND, so they all have to be true 
			PredicateExpression filter = CreateAttachmentFilter(accessableForums, forumsWithApprovalRight, forumsWithThreadsFromOthers, userID, false);

			AttachmentCollection attachments = new AttachmentCollection();
			return attachments.GetDbCount(filter, relations);
		}


		/// <summary>
		/// Gets the message entity with the ID passed in. 
		/// </summary>
		/// <param name="messageID">The message ID.</param>
		/// <returns>Filled messageentity if found, otherwise null</returns>
		public static MessageEntity GetMessage(int messageID)
		{
			// load the entity from the database
			MessageEntity message = new MessageEntity(messageID);

			//check if the entity is new (not found in the database), then return null.
			if(message.IsNew == true)
			{
				return null;
			}

			return message;
		}


		/// <summary>
		/// Gets the attachments for the message with the messageid passed in. Attachments are sorted by AddedOn ascending.
		/// The result is returned as a dynamic list, because we don't want the actual attachment data. 
		/// </summary>
		/// <param name="messageID">The message ID.</param>
		/// <returns>Dataview with 0 or more attachments related to the message with the id passed in. The rows don't contain the actual attachment data</returns>
		public static DataView GetAttachmentsAsDataView(int messageID)
		{
			ResultsetFields fields = new ResultsetFields(5);
			fields.DefineField(AttachmentFields.AttachmentID, 0);
			fields.DefineField(AttachmentFields.Filename, 1);
			fields.DefineField(AttachmentFields.Approved, 2);
			fields.DefineField(AttachmentFields.Filesize, 3);
			fields.DefineField(AttachmentFields.AddedOn, 4);

			DataTable attachments = new DataTable();
			TypedListDAO dao = new TypedListDAO();
			SortExpression sorter = new SortExpression(AttachmentFields.AddedOn | SortOperator.Ascending);
			dao.GetMultiAsDataTable(fields, attachments, 0, sorter, (AttachmentFields.MessageID == messageID), null, true, null, null, 0, 0);
			return attachments.DefaultView;
		}


		/// <summary>
		/// Gets the attachment with the attachmentid passed in
		/// </summary>
		/// <param name="attachmentID">The attachment ID.</param>
		/// <returns>the attachment entity or null if not found</returns>
		public static AttachmentEntity GetAttachment(int attachmentID)
		{
			AttachmentEntity toReturn = new AttachmentEntity(attachmentID);
			if(toReturn.IsNew)
			{
				// not found
				return null;
			}
			return toReturn;
		}


		/// <summary>
		/// Gets the message of the attachment with the attachmentid passed in.
		/// </summary>
		/// <param name="attachmentID">The attachment ID.</param>
		/// <returns>MessageEntity if found, otherwise null. MessageEntity has its Thread entity prefetched</returns>
		public static MessageEntity GetMessageWithAttachmentLogic(int attachmentID)
		{
			// we're going to use a message collection so we can use a filter on a related entity. 
			// we're not going to utilize lazy loading, as that would require the attachment to be loaded into memory, but that could potentially be expensive
			// for memory, so we'll avoid that
			MessageCollection messages = new MessageCollection();
			RelationCollection relations = new RelationCollection();
			relations.Add(MessageEntity.Relations.AttachmentEntityUsingMessageID);
			// we're going to use a prefetch path as well, to prefetch the thread entity as well.
			PrefetchPath path = new PrefetchPath((int)EntityType.MessageEntity);
			path.Add(MessageEntity.PrefetchPathThread);
			messages.GetMulti((AttachmentFields.AttachmentID == attachmentID), 0, null, relations, path);
			if(messages.Count > 0)
			{
				// found it
				return messages[0];
			}
			else
			{
				// not found,
				return null;
			}
		}


		/// <summary>
		/// Gets all attachments which have to be approved as data view, filtered on the two passed in list of forum id's.
		/// It doesn't return the file contents for each attachment, it just returns the other data of each attachment, as well as some other related data.
		/// </summary>
		/// <param name="accessableForums">The accessable forums by the user calling.</param>
		/// <param name="forumsWithApprovalRight">The forums the calling user has attachment approval rights.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums the calling user can view normal threads from others.</param>
		/// <param name="userID">The user ID of the calling user.</param>
		/// <returns>DataView with the data requested.</returns>
		public static DataView GetAllAttachmentsToApproveAsDataView(List<int> accessableForums, List<int> forumsWithApprovalRight,
				List<int> forumsWithThreadsFromOthers, int userID)
		{
			if((accessableForums == null) || (accessableForums.Count <= 0))
			{
				// doesn't have access to any forum, return
				return null;
			}
			if((forumsWithApprovalRight == null) || (forumsWithApprovalRight.Count <= 0))
			{
				// doesn't have a forum with attachment approval right
				return null;
			}

			// we'll use a dynamic list for the data to return. This is similar to GetAttachmentsAsDataView, however now we'll add more data + we'll
			// filter on more things. The data we'll add is the ForumID of the thread containing the messagee the attachment is attached to, as well as
			// the userid of the poster of the message the attachment is attached to, and the threadid of the thread the message is in.
			ResultsetFields fields = new ResultsetFields(9);
			fields.DefineField(AttachmentFields.AttachmentID, 0);
			fields.DefineField(AttachmentFields.MessageID, 1);
			fields.DefineField(AttachmentFields.Filename, 2);
			fields.DefineField(AttachmentFields.Approved, 3);
			fields.DefineField(AttachmentFields.Filesize, 4);
			fields.DefineField(AttachmentFields.AddedOn, 5);
			fields.DefineField(MessageFields.PostedByUserID, 6);
			fields.DefineField(ThreadFields.ForumID, 7);
			fields.DefineField(ThreadFields.ThreadID, 8);

			// we've to join attachment - message - thread, so we've to create a RelationCollection with the necessary relations. 
			RelationCollection relations = new RelationCollection();
			relations.Add(AttachmentEntity.Relations.MessageEntityUsingMessageID);
			relations.Add(MessageEntity.Relations.ThreadEntityUsingThreadID);

			// we've to filter the list of attachments based on the forums accessable by the calling user, the list of forums the calling user has approval rights
			// on and by the forums on which the user can see other user's threads. We'll create a predicate expression for this, and will add for each of these
			// filters a separate predicate to this predicate expression and specify AND, so they all have to be true 
			PredicateExpression filter = CreateAttachmentFilter(accessableForums, forumsWithApprovalRight, forumsWithThreadsFromOthers, userID, false);
			
			DataTable attachments = new DataTable();
			TypedListDAO dao = new TypedListDAO();
			// The results will be sorted on the date the attachments were added, ascending, so the oldest will be on top.
			SortExpression sorter = new SortExpression(AttachmentFields.AddedOn | SortOperator.Ascending);
			dao.GetMultiAsDataTable(fields, attachments, 0, sorter, filter, relations, true, null, null, 0, 0);
			return attachments.DefaultView;
		}


		/// <summary>
		/// Creates the attachment filter. The filter filters on attachments with the specified approvalstate in the threads viewable by the calling user.
		/// </summary>
		/// <param name="accessableForums">The accessable forums.</param>
		/// <param name="forumsWithApprovalRight">The forums with approval right.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="userID">The user ID.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>ready to use predicate expression for fetch actions on attachments with the approval state specified in the threads
		/// matching the forumID's.</returns>
		private static PredicateExpression CreateAttachmentFilter(List<int> accessableForums, List<int> forumsWithApprovalRight,
				List<int> forumsWithThreadsFromOthers, int userID, bool approvalState)
		{
			PredicateExpression filter = new PredicateExpression();

			// specify the filter for the accessable forums. Do this by a fieldcomparerange predicate and filter on Thread.ForumID. As 'accessableForums' is a list
			// the following statement will create a fieldcomparerange predicate for us.
			if(accessableForums.Count == 1)
			{
				// optimization, specify the only value instead of the range, so we won't get a WHERE Field IN (@param) query which is slow on some
				// databases, but we'll get a WHERE Field == @param
				filter.Add(ThreadFields.ForumID == accessableForums[0]);
			}
			else
			{
				filter.Add(ThreadFields.ForumID == accessableForums);
			}
			// specify the filter for the forums with approval rights:
			if(forumsWithApprovalRight.Count == 1)
			{
				// optimization, specify the only value instead of the range, so we won't get a WHERE Field IN (@param) query which is slow on some
				// databases, but we'll get a WHERE Field == @param
				filter.Add(ThreadFields.ForumID == forumsWithApprovalRight[0]);
			}
			else
			{
				filter.Add(ThreadFields.ForumID == forumsWithApprovalRight);
			}
			// Also filter on the threads viewable by the passed in userid, which is the caller of the method. If a forum isn't in the list of
			// forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should be counted / taken into account. 
			PredicateExpression threadFilter = new PredicateExpression();
			if((forumsWithThreadsFromOthers != null) && (forumsWithThreadsFromOthers.Count > 0))
			{
				PredicateExpression onlyOwnThreadsFilter = new PredicateExpression();

				// accept only those threads who aren't in the forumsWithThreadsFromOthers list and which are either started by userID or sticky.
				// the filter on the threads not in the forums listed in the forumsWithThreadsFromOthers
				if(forumsWithThreadsFromOthers.Count == 1)
				{
					// optimization, specify the only value instead of the range, so we won't get a WHERE Field IN (@param) query which is slow on some
					// databases, but we'll get a WHERE Field == @param
					// accept all threads which are in a forum located in the forumsWithThreadsFromOthers list 
					threadFilter.Add((ThreadFields.ForumID == forumsWithThreadsFromOthers[0]));
					onlyOwnThreadsFilter.Add(ThreadFields.ForumID != forumsWithThreadsFromOthers[0]);
				}
				else
				{
					// accept all threads which are in a forum located in the forumsWithThreadsFromOthers list 
					threadFilter.Add((ThreadFields.ForumID == forumsWithThreadsFromOthers));
					onlyOwnThreadsFilter.Add(ThreadFields.ForumID != forumsWithThreadsFromOthers);
				}
				// the filter on either sticky or threads started by the calling user
				onlyOwnThreadsFilter.AddWithAnd(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID == userID));
				threadFilter.AddWithOr(onlyOwnThreadsFilter);
			}
			else
			{
				// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
				// sticky threads or threads started by the calling user.
				threadFilter.Add(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID == userID));
			}
			filter.AddWithAnd(threadFilter);
			// as last filter, we'll add a filter to only get the data for attachments which aren't approved yet.
			filter.AddWithAnd(AttachmentFields.Approved == false);

			return filter;
		}
	}
}
