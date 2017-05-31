﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.2.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SD.HnD.ReadOnlyElements.Persistence
{
	/// <summary>Static class for (extension) methods for fetching and projecting instances of SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto from the entity model.</summary>
	public static partial class MessageInThreadPersistence
	{
		#region Statics
		private static readonly System.Linq.Expressions.Expression<Func<SD.HnD.DALAdapter.EntityClasses.MessageEntity, SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<SD.HnD.DALAdapter.EntityClasses.MessageEntity, SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto> _compiledProjector = CreateProjectionFunc().Compile();
		#endregion	
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static MessageInThreadPersistence()
		{
		}
	
		/// <summary>Extension method which produces a projection to SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto which instances are projected from the 
		/// results of the specified baseQuery, which returns SD.HnD.DALAdapter.EntityClasses.MessageEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto instances</returns>
		public static IQueryable<SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto> ProjectToMessageInThreadDto(this IQueryable<SD.HnD.DALAdapter.EntityClasses.MessageEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}
		
		
		/// <summary>Extension method which produces a projection to SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto which instances are projected from the
		/// SD.HnD.DALAdapter.EntityClasses.MessageEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>SD.HnD.DALAdapter.EntityClasses.MessageEntity instance created from the specified entity instance</returns>
		public static SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto ProjectToMessageInThreadDto(this SD.HnD.DALAdapter.EntityClasses.MessageEntity entity)
		{
			return _compiledProjector(entity);
		}

		
		private static System.Linq.Expressions.Expression<Func<SD.HnD.DALAdapter.EntityClasses.MessageEntity, SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto>> CreateProjectionFunc()
		{
			return p__0 => new SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDto()
			{
				Attachments = p__0.Attachments.Select(p__1 => new SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDtoTypes.AttachmentDto()
				{
					AddedOn = p__1.AddedOn,
					Approved = p__1.Approved,
					AttachmentID = p__1.AttachmentID,
					Filename = p__1.Filename,
					Filesize = p__1.Filesize,
				}).ToList(),
				MessageID = p__0.MessageID,
				MessageTextAsHTML = p__0.MessageTextAsHTML,
				PostedByUser = new SD.HnD.ReadOnlyElements.DtoClasses.MessageInThreadDtoTypes.PostedByUserDto()
				{
					AmountOfPostings = p__0.PostedByUser.AmountOfPostings,
					IconURL = p__0.PostedByUser.IconURL,
					JoinDate = p__0.PostedByUser.JoinDate,
					Location = p__0.PostedByUser.Location,
					NickName = p__0.PostedByUser.NickName,
					Signature = p__0.PostedByUser.Signature,
					UserID = p__0.PostedByUser.UserID,
					UserTitleDescription = p__0.PostedByUser.UserTitle.UserTitleDescription,
				},
				PostedFromIP = p__0.PostedFromIP,
				PostingDate = p__0.PostingDate,
				ThreadID = p__0.ThreadID,
			};
		}
		
		
	}
}


