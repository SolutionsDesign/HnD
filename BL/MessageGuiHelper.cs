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
using System.Data;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.EntityClasses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.HnD.BL.TypedDataClasses;
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
		public static async Task<int> GetTotalNumberOfAttachmentsOfMessageAsync(int messageId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Attachment.Where(AttachmentFields.MessageID.Equal(messageId)).Select(Functions.CountRow());
				return await adapter.FetchScalarAsync<int>(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the number of postings in all threads of all forums on this system. 
		/// </summary>
		/// <returns>the total of all posts on the entire forum system</returns>
		public static async Task<int> GetTotalNumberOfMessagesAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchScalarAsync<int>(new QueryFactory().Message.Select(Functions.CountRow())).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the total number of attachments to approve, without any filter.
		/// </summary>
		/// <returns></returns>
		public static int GetTotalNumberOfAttachmentsToApprove()
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Attachment.Where(AttachmentFields.Approved.Equal(false)).Select(Functions.CountRow());
				return adapter.FetchScalar<int>(q);
			}
		}


		/// <summary>
		/// Gets the message entity with the ID passed in.
		/// </summary>
		/// <param name="messageId">The message ID.</param>
		/// <param name="prefetchThread">if set to <c>true</c> it will also prefetch the related thread entity.</param>
		/// <returns>
		/// Filled messageentity if found, otherwise null
		/// </returns>
		public static async Task<MessageEntity> GetMessageAsync(int messageId, bool prefetchThread = false)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Message.Where(MessageFields.MessageID.Equal(messageId));
				if(prefetchThread)
				{
					q.WithPath(MessageEntity.PrefetchPathThread);
				}

				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the attachment with the attachmentid passed in
		/// </summary>
		/// <param name="messageId">The messageid of the message the attachment is related to</param>
		/// <param name="attachmentId">The attachment ID.</param>
		/// <returns>the attachment entity or null if not found</returns>
		public static async Task<AttachmentEntity> GetAttachmentAsync(int messageId, int attachmentId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Attachment.Where(AttachmentFields.AttachmentID.Equal(attachmentId).And(AttachmentFields.MessageID.Equal(messageId)));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the message of the attachment with the attachmentid passed in.
		/// </summary>
		/// <param name="attachmentId">The attachment ID.</param>
		/// <returns>MessageEntity if found, otherwise null. MessageEntity has its Thread entity prefetched</returns>
		public static async Task<MessageEntity> GetMessageWithAttachmentLogicAsync(int attachmentId)
		{
			var qf = new QueryFactory();
			var q = qf.Message
					  .From(QueryTarget.InnerJoin(qf.Attachment).On(MessageFields.MessageID.Equal(AttachmentFields.MessageID)))
					  .Where(AttachmentFields.AttachmentID.Equal(attachmentId))
					  .Limit(1)
					  .WithPath(MessageEntity.PrefetchPathThread);
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets all message ids and related info for displaying of the messages which have at least 1 unapproved attachment.
		/// </summary>
		/// <param name="accessableForums">The accessable forums by the user calling.</param>
		/// <param name="forumsWithApprovalRight">The forums the calling user has attachment approval rights.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums the calling user can view normal threads from others.</param>
		/// <param name="userId">The user ID of the calling user.</param>
		/// <returns>List with objects with the data requested.</returns>
		public static async Task<List<AggregatedUnapprovedAttachmentRow>> GetAllMessagesIDsWithUnapprovedAttachments(List<int> accessableForums,
																													 List<int> forumsWithApprovalRight,
																													 List<int> forumsWithThreadsFromOthers, int userId)
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
							  .InnerJoin(qf.Message).On(AttachmentFields.MessageID.Equal(MessageFields.MessageID))
							  .InnerJoin(qf.Thread).On(MessageFields.ThreadID.Equal(ThreadFields.ThreadID))
							  .InnerJoin(qf.Forum).On(ThreadFields.ForumID.Equal(ForumFields.ForumID)))
					  .Where(MessageGuiHelper.CreateAttachmentFilter(accessableForums, forumsWithApprovalRight, forumsWithThreadsFromOthers, userId))
					  .OrderBy(ForumFields.ForumName.Ascending(), AttachmentFields.AddedOn.Ascending())
					  .Distinct();

			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Creates the attachment filter. The filter filters on attachments with the specified approvalstate in the threads viewable by the calling user.
		/// </summary>
		/// <param name="accessableForums">The accessable forums.</param>
		/// <param name="forumsWithApprovalRight">The forums with approval right.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="userId">The user ID.</param>
		/// <returns>ready to use predicate expression for fetch actions on attachments with the approval state specified in the threads
		/// matching the forumID's.</returns>
		private static PredicateExpression CreateAttachmentFilter(List<int> accessableForums, List<int> forumsWithApprovalRight, List<int> forumsWithThreadsFromOthers,
																  int userId)
		{
			var filter = new PredicateExpression();

			// specify the filter for the accessable forums. Do this by a fieldcomparerange predicate and filter on Thread.ForumID. As 'accessableForums' is a list
			// the following statement will create a fieldcomparerange predicate for us.
			if(accessableForums.Count == 1)
			{
				// optimization, specify the only value instead of the range, so we won't get a WHERE Field IN (@param) query which is slow on some
				// databases, but we'll get a WHERE Field == @param
				filter.Add(ThreadFields.ForumID.Equal(accessableForums[0]));
			}
			else
			{
				filter.Add(ThreadFields.ForumID.In(accessableForums));
			}

			// specify the filter for the forums with approval rights:
			if(forumsWithApprovalRight.Count == 1)
			{
				// optimization, specify the only value instead of the range, so we won't get a WHERE Field IN (@param) query which is slow on some
				// databases, but we'll get a WHERE Field == @param
				filter.Add(ThreadFields.ForumID.Equal(forumsWithApprovalRight[0]));
			}
			else
			{
				filter.Add(ThreadFields.ForumID.In(forumsWithApprovalRight));
			}

			// Also filter on the threads viewable by the passed in userid, which is the caller of the method. If a forum isn't in the list of
			// forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should be counted / taken into account. 
			filter.AddWithAnd(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userId));

			// as last filter, we'll add a filter to only get the data for attachments which aren't approved yet.
			filter.AddWithAnd(AttachmentFields.Approved.Equal(false));
			return filter;
		}
	}
}