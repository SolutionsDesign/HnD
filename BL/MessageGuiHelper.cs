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

using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.EntityClasses;
using System.Collections.Generic;
using System.Linq;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Message Gui
	/// </summary>
	public static class MessageGuiHelper
	{
		/// <summary>
		/// Gets the number of attachments related to the message with the id specified. 
		/// </summary>
		/// <param name="messageId"></param>
		/// <returns></returns>
		public static int GetTotalNumberOfAttachmentsOfMessage(int messageId) 
		{
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int>(new QueryFactory().Attachment.Where(AttachmentFields.MessageID == messageId).Select(Functions.CountRow()));
			}
		}

		/// <summary>
		/// Gets the number of postings in all threads of all forums on this system. 
		/// </summary>
		/// <returns>the total of all posts on the entire forum system</returns>
		public static int GetTotalNumberOfMessages()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchScalar<int>(new QueryFactory().Message.Select(Functions.CountRow()));
			}
		}


		/// <summary>
		/// Gets the total number of attachments to approve.
		/// </summary>
		/// <param name="accessableForums">The accessable forums by the user calling.</param>
		/// <param name="forumsWithApprovalRight">The forums the calling user has attachment approval rights.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums the calling user can view normal threads from others.</param>
		/// <param name="userID">The user ID of the calling user.</param>
		/// <returns>the # of attachments with the approval state which are approvable by the calling user</returns>
		public static int GetTotalNumberOfAttachmentsToApprove(List<int> accessableForums, List<int> forumsWithApprovalRight, List<int> forumsWithThreadsFromOthers, int userID)
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

			var qf = new QueryFactory();
			using(var adapter = new DataAccessAdapter())
			{
				// we've to filter the list of attachments based on the forums accessable by the calling user, the list of forums the calling user has approval rights
				// on and by the forums on which the user can see other user's threads. We'll create a predicate expression for this, and will add for each of these
				// filters a separate predicate to this predicate expression and specify AND, so they all have to be true 
				var q = qf.Create()
						  .Select(Functions.CountRow())
						  .From(qf.Attachment.InnerJoin(qf.Message).On(AttachmentFields.MessageID.Equal(MessageFields.MessageID))
											 .InnerJoin(qf.Thread).On(MessageFields.ThreadID.Equal(ThreadFields.ThreadID)))
						  .Where(MessageGuiHelper.CreateAttachmentFilter(accessableForums, forumsWithApprovalRight, forumsWithThreadsFromOthers, userID));
				return adapter.FetchScalar<int>(q);
			}
		}


		/// <summary>
		/// Gets the message entity with the ID passed in.
		/// </summary>
		/// <param name="messageID">The message ID.</param>
		/// <param name="prefetchThread">if set to <c>true</c> it will also prefetch the related thread entity.</param>
		/// <returns>
		/// Filled messageentity if found, otherwise null
		/// </returns>
		public static MessageEntity GetMessage(int messageID, bool prefetchThread = false)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var message = new MessageEntity(messageID);
				IPrefetchPath2 path = prefetchThread ? new PrefetchPath2(EntityType.MessageEntity) {MessageEntity.PrefetchPathThread} : null;
				return adapter.FetchEntity(message, path) ? message : null;
			}
		}


		/// <summary>
		/// Gets the attachments for the message with the messageid passed in. Attachments are sorted by AddedOn ascending.
		/// The result is returned as a dynamic list, because we don't want the actual attachment data. 
		/// </summary>
		/// <param name="messageID">The message ID.</param>
		/// <returns>Dataview with 0 or more attachments related to the message with the id passed in. The rows don't contain the actual attachment data</returns>
		public static DataView GetAttachmentsAsDataView(int messageID)
		{
			var q = new QueryFactory().Create()
						.Select(AttachmentFields.AttachmentID,
								AttachmentFields.Filename,
								AttachmentFields.Approved,
								AttachmentFields.Filesize,
								AttachmentFields.AddedOn)
						.Where(AttachmentFields.MessageID == messageID)
						.OrderBy(AttachmentFields.AddedOn.Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchAsDataTable(q).DefaultView;
			}
		}


		/// <summary>
		/// Gets the attachment with the attachmentid passed in
		/// </summary>
		/// <param name="messageID">The messageid of the message the attachment is related to</param>
		/// <param name="attachmentID">The attachment ID.</param>
		/// <returns>the attachment entity or null if not found</returns>
		public static AttachmentEntity GetAttachment(int messageID, int attachmentID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var attachment = new AttachmentEntity(attachmentID);
				if(adapter.FetchEntity(attachment))
				{
					if(attachment.MessageID != messageID)
					{
						attachment = null;
					}
				}
				else
				{
					attachment = null;
				}
				return attachment;
			}
		}


		/// <summary>
		/// Gets the message of the attachment with the attachmentid passed in.
		/// </summary>
		/// <param name="attachmentID">The attachment ID.</param>
		/// <returns>MessageEntity if found, otherwise null. MessageEntity has its Thread entity prefetched</returns>
		public static MessageEntity GetMessageWithAttachmentLogic(int attachmentID)
		{
			var qf = new QueryFactory();
			var q = qf.Message
						.From(QueryTarget.InnerJoin(qf.Attachment).On(MessageFields.MessageID == AttachmentFields.MessageID))
						.Where(AttachmentFields.AttachmentID == attachmentID)
						.Limit(1)
						.WithPath(MessageEntity.PrefetchPathThread);
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchFirst(q);
			}
		}


		/// <summary>
		/// Gets all message ids and related info for displaying of the messages which have at least 1 unapproved attachment.
		/// </summary>
		/// <param name="accessableForums">The accessable forums by the user calling.</param>
		/// <param name="forumsWithApprovalRight">The forums the calling user has attachment approval rights.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums the calling user can view normal threads from others.</param>
		/// <param name="userID">The user ID of the calling user.</param>
		/// <returns>List with objects with the data requested.</returns>
		public static List<AggregatedUnapprovedAttachmentRow> GetAllMessagesIDsWithUnapprovedAttachments(List<int> accessableForums, List<int> forumsWithApprovalRight, 
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
			var qf = new QueryFactory();

			// We've to filter the list of attachments based on the forums accessable by the calling user, the list of forums the calling user has approval 
			// rights on and by the forums on which the user can see other user's threads. We'll create a predicate expression for this, and will add 
			// for each of these filters a separate predicate to this predicate expression and specify AND, so they all have to be true 
			var q = qf.Create()
					  .Select<AggregatedUnapprovedAttachmentRow>(ThreadFields.Subject,
																 ForumFields.ForumName,
																 MessageFields.MessageID,
																 AttachmentFields.AddedOn)
					  .From(qf.Attachment
							  .InnerJoin(qf.Message).On(AttachmentFields.MessageID == MessageFields.MessageID)
							  .InnerJoin(qf.Thread).On(MessageFields.ThreadID == ThreadFields.ThreadID)
							  .InnerJoin(qf.Forum).On(ThreadFields.ForumID == ForumFields.ForumID))
					  .Where(MessageGuiHelper.CreateAttachmentFilter(accessableForums, forumsWithApprovalRight, forumsWithThreadsFromOthers, userID))
					  .OrderBy(ForumFields.ForumName.Ascending(), AttachmentFields.AddedOn.Ascending())
					  .Distinct();

			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(q);
			}
		}


		/// <summary>
		/// Creates the attachment filter. The filter filters on attachments with the specified approvalstate in the threads viewable by the calling user.
		/// </summary>
		/// <param name="accessableForums">The accessable forums.</param>
		/// <param name="forumsWithApprovalRight">The forums with approval right.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="userID">The user ID.</param>
		/// <returns>ready to use predicate expression for fetch actions on attachments with the approval state specified in the threads
		/// matching the forumID's.</returns>
		private static PredicateExpression CreateAttachmentFilter(List<int> accessableForums, List<int> forumsWithApprovalRight, List<int> forumsWithThreadsFromOthers, int userID)
		{
			var filter = new PredicateExpression();

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
			filter.AddWithAnd(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userID));
			// as last filter, we'll add a filter to only get the data for attachments which aren't approved yet.
			filter.AddWithAnd(AttachmentFields.Approved == false);
			return filter;
		}
	}
}
