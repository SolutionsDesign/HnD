﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.9.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using System.Linq;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec.AdapterSpecific;
using SD.LLBLGen.Pro.QuerySpec;

namespace SD.HnD.DALAdapter.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory : QueryFactoryBase2
	{
		/// <summary>Creates and returns a new EntityQuery for the ActionRight entity</summary>
		public EntityQuery<ActionRightEntity> ActionRight { get { return Create<ActionRightEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the Attachment entity</summary>
		public EntityQuery<AttachmentEntity> Attachment { get { return Create<AttachmentEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the AuditAction entity</summary>
		public EntityQuery<AuditActionEntity> AuditAction { get { return Create<AuditActionEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the AuditDataCore entity</summary>
		public EntityQuery<AuditDataCoreEntity> AuditDataCore { get { return Create<AuditDataCoreEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the AuditDataMessageRelated entity</summary>
		public EntityQuery<AuditDataMessageRelatedEntity> AuditDataMessageRelated { get { return Create<AuditDataMessageRelatedEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the AuditDataThreadRelated entity</summary>
		public EntityQuery<AuditDataThreadRelatedEntity> AuditDataThreadRelated { get { return Create<AuditDataThreadRelatedEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the Bookmark entity</summary>
		public EntityQuery<BookmarkEntity> Bookmark { get { return Create<BookmarkEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the Forum entity</summary>
		public EntityQuery<ForumEntity> Forum { get { return Create<ForumEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the ForumRoleForumActionRight entity</summary>
		public EntityQuery<ForumRoleForumActionRightEntity> ForumRoleForumActionRight { get { return Create<ForumRoleForumActionRightEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the IPBan entity</summary>
		public EntityQuery<IPBanEntity> IPBan { get { return Create<IPBanEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the Message entity</summary>
		public EntityQuery<MessageEntity> Message { get { return Create<MessageEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the PasswordResetToken entity</summary>
		public EntityQuery<PasswordResetTokenEntity> PasswordResetToken { get { return Create<PasswordResetTokenEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the Role entity</summary>
		public EntityQuery<RoleEntity> Role { get { return Create<RoleEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the RoleAuditAction entity</summary>
		public EntityQuery<RoleAuditActionEntity> RoleAuditAction { get { return Create<RoleAuditActionEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the RoleSystemActionRight entity</summary>
		public EntityQuery<RoleSystemActionRightEntity> RoleSystemActionRight { get { return Create<RoleSystemActionRightEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the RoleUser entity</summary>
		public EntityQuery<RoleUserEntity> RoleUser { get { return Create<RoleUserEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the Section entity</summary>
		public EntityQuery<SectionEntity> Section { get { return Create<SectionEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the SupportQueue entity</summary>
		public EntityQuery<SupportQueueEntity> SupportQueue { get { return Create<SupportQueueEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the SupportQueueThread entity</summary>
		public EntityQuery<SupportQueueThreadEntity> SupportQueueThread { get { return Create<SupportQueueThreadEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the SystemData entity</summary>
		public EntityQuery<SystemDataEntity> SystemData { get { return Create<SystemDataEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the Thread entity</summary>
		public EntityQuery<ThreadEntity> Thread { get { return Create<ThreadEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the ThreadStatistics entity</summary>
		public EntityQuery<ThreadStatisticsEntity> ThreadStatistics { get { return Create<ThreadStatisticsEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the ThreadSubscription entity</summary>
		public EntityQuery<ThreadSubscriptionEntity> ThreadSubscription { get { return Create<ThreadSubscriptionEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the User entity</summary>
		public EntityQuery<UserEntity> User { get { return Create<UserEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the UserTitle entity</summary>
		public EntityQuery<UserTitleEntity> UserTitle { get { return Create<UserTitleEntity>(); } }

		/// <inheritdoc/>
		protected override IElementCreatorCore CreateElementCreator() { return new ElementCreator(); }
 
		/// <summary>Gets the query to fetch the typed list ForumMessages</summary>
		/// <param name="root">Optional. If specified (not null) it's used as the root of the query to fetch the typed list, otherwise a new EntityQuery(Of MessageEntity) is used</param>
		/// <returns>Dynamic Query which fetches <see cref="SD.HnD.DALAdapter.TypedListClasses.ForumMessagesRow"/> instances </returns>
		public DynamicQuery<SD.HnD.DALAdapter.TypedListClasses.ForumMessagesRow> GetForumMessagesTypedList(EntityQuery<MessageEntity> root=null)
		{
			var rootOfQuery = root ?? this.Message;
			return this.Create()
						.Select(() => new SD.HnD.DALAdapter.TypedListClasses.ForumMessagesRow()
								{
									MessageID = MessageFields.MessageID.ToValue<System.Int32>(),
									PostingDate = MessageFields.PostingDate.ToValue<System.DateTime>(),
									MessageTextAsHTML = MessageFields.MessageTextAsHTML.ToValue<System.String>(),
									ThreadID = MessageFields.ThreadID.ToValue<System.Int32>(),
									Subject = ThreadFields.Subject.ToValue<System.String>(),
									EmailAddress = UserFields.EmailAddress.ToValue<System.String>(),
									EmailAddressIsPublic = UserFields.EmailAddressIsPublic.ToValue<Nullable<System.Boolean>>(),
									NickName = UserFields.NickName.ToValue<System.String>(),
									MessageText = MessageFields.MessageText.ToValue<System.String>()
								})
						.From(rootOfQuery
								.InnerJoin(this.Thread).On(MessageFields.ThreadID.Equal(ThreadFields.ThreadID))
								.InnerJoin(this.User).On(MessageFields.PostedByUserID.Equal(UserFields.UserID))
								.InnerJoin(this.Forum).On(ThreadFields.ForumID.Equal(ForumFields.ForumID)));
		}

		/// <summary>Gets the query to fetch the typed list ForumsWithSectionName</summary>
		/// <param name="root">Optional. If specified (not null) it's used as the root of the query to fetch the typed list, otherwise a new EntityQuery(Of ForumEntity) is used</param>
		/// <returns>Dynamic Query which fetches <see cref="SD.HnD.DALAdapter.TypedListClasses.ForumsWithSectionNameRow"/> instances </returns>
		public DynamicQuery<SD.HnD.DALAdapter.TypedListClasses.ForumsWithSectionNameRow> GetForumsWithSectionNameTypedList(EntityQuery<ForumEntity> root=null)
		{
			var rootOfQuery = root ?? this.Forum;
			return this.Create()
						.Select(() => new SD.HnD.DALAdapter.TypedListClasses.ForumsWithSectionNameRow()
								{
									ForumID = ForumFields.ForumID.ToValue<System.Int32>(),
									ForumName = ForumFields.ForumName.ToValue<System.String>(),
									SectionName = SectionFields.SectionName.ToValue<System.String>(),
									ForumDescription = ForumFields.ForumDescription.ToValue<System.String>(),
									SectionID = SectionFields.SectionID.ToValue<System.Int32>(),
									ForumOrderNo = ForumFields.OrderNo.As("ForumOrderNo").ToValue<System.Int16>()
								})
						.From(rootOfQuery
								.InnerJoin(this.Section).On(ForumFields.SectionID.Equal(SectionFields.SectionID)));
		}

		/// <summary>Gets the query to fetch the typed list SearchResult</summary>
		/// <param name="root">Optional. If specified (not null) it's used as the root of the query to fetch the typed list, otherwise a new EntityQuery(Of MessageEntity) is used</param>
		/// <returns>Dynamic Query which fetches <see cref="SD.HnD.DALAdapter.TypedListClasses.SearchResultRow"/> instances </returns>
		public DynamicQuery<SD.HnD.DALAdapter.TypedListClasses.SearchResultRow> GetSearchResultTypedList(EntityQuery<MessageEntity> root=null)
		{
			var rootOfQuery = root ?? this.Message;
			return this.Create()
						.Select(() => new SD.HnD.DALAdapter.TypedListClasses.SearchResultRow()
								{
									ThreadID = ThreadFields.ThreadID.ToValue<System.Int32>(),
									Subject = ThreadFields.Subject.ToValue<System.String>(),
									ForumName = ForumFields.ForumName.ToValue<System.String>(),
									SectionName = SectionFields.SectionName.ToValue<System.String>(),
									ThreadLastPostingDate = MessageFields.PostingDate.As("ThreadLastPostingDate").Source("LastMessage").ToValue<System.DateTime>()
								})
						.From(rootOfQuery
								.InnerJoin(this.Thread).On(MessageFields.ThreadID.Equal(ThreadFields.ThreadID))
								.InnerJoin(this.Forum).On(ThreadFields.ForumID.Equal(ForumFields.ForumID))
								.InnerJoin(this.ThreadStatistics).On(ThreadFields.ThreadID.Equal(ThreadStatisticsFields.ThreadID))
								.InnerJoin(this.Section).On(ForumFields.SectionID.Equal(SectionFields.SectionID))
								.InnerJoin(this.Message.As("LastMessage")).On(ThreadStatisticsFields.LastMessageID.Equal(MessageFields.MessageID.Source("LastMessage"))));
		}

		/// <summary>Gets the query to fetch the typed list UserProfileInfo</summary>
		/// <param name="root">Optional. If specified (not null) it's used as the root of the query to fetch the typed list, otherwise a new EntityQuery(Of UserEntity) is used</param>
		/// <returns>Dynamic Query which fetches <see cref="SD.HnD.DALAdapter.TypedListClasses.UserProfileInfoRow"/> instances </returns>
		public DynamicQuery<SD.HnD.DALAdapter.TypedListClasses.UserProfileInfoRow> GetUserProfileInfoTypedList(EntityQuery<UserEntity> root=null)
		{
			var rootOfQuery = root ?? this.User;
			return this.Create()
						.Select(() => new SD.HnD.DALAdapter.TypedListClasses.UserProfileInfoRow()
								{
									AmountOfPostings = UserFields.AmountOfPostings.ToValue<Nullable<System.Int32>>(),
									DateOfBirth = UserFields.DateOfBirth.ToValue<Nullable<System.DateTime>>(),
									EmailAddress = UserFields.EmailAddress.ToValue<System.String>(),
									EmailAddressIsPublic = UserFields.EmailAddressIsPublic.ToValue<Nullable<System.Boolean>>(),
									IconURL = UserFields.IconURL.ToValue<System.String>(),
									IPNumber = UserFields.IPNumber.ToValue<System.String>(),
									IsBanned = UserFields.IsBanned.ToValue<System.Boolean>(),
									JoinDate = UserFields.JoinDate.ToValue<Nullable<System.DateTime>>(),
									LastVisitedDate = UserFields.LastVisitedDate.ToValue<Nullable<System.DateTime>>(),
									Location = UserFields.Location.ToValue<System.String>(),
									NickName = UserFields.NickName.ToValue<System.String>(),
									Occupation = UserFields.Occupation.ToValue<System.String>(),
									Signature = UserFields.Signature.ToValue<System.String>(),
									UserID = UserFields.UserID.ToValue<System.Int32>(),
									Website = UserFields.Website.ToValue<System.String>(),
									UserTitleDescription = UserTitleFields.UserTitleDescription.ToValue<System.String>()
								})
						.From(rootOfQuery
								.InnerJoin(this.UserTitle).On(UserFields.UserTitleID.Equal(UserTitleFields.UserTitleID)));
		}

	}
}