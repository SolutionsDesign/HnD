﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.11.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	internal static class PersistenceInfoProviderSingleton
	{
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton() {	}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance() { return _providerInstance; }
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal partial class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass();
			InitActionRightEntityMappings();
			InitAttachmentEntityMappings();
			InitAuditActionEntityMappings();
			InitAuditDataCoreEntityMappings();
			InitAuditDataMessageRelatedEntityMappings();
			InitAuditDataThreadRelatedEntityMappings();
			InitBookmarkEntityMappings();
			InitForumEntityMappings();
			InitForumRoleForumActionRightEntityMappings();
			InitIPBanEntityMappings();
			InitMessageEntityMappings();
			InitPasswordResetTokenEntityMappings();
			InitRoleEntityMappings();
			InitRoleAuditActionEntityMappings();
			InitRoleSystemActionRightEntityMappings();
			InitRoleUserEntityMappings();
			InitSectionEntityMappings();
			InitSupportQueueEntityMappings();
			InitSupportQueueThreadEntityMappings();
			InitSystemDataEntityMappings();
			InitThreadEntityMappings();
			InitThreadStatisticsEntityMappings();
			InitThreadSubscriptionEntityMappings();
			InitUserEntityMappings();
			InitUserTitleEntityMappings();
		}

		/// <summary>Inits ActionRightEntity's mappings</summary>
		private void InitActionRightEntityMappings()
		{
			this.AddElementMapping("ActionRightEntity", @"HnD", @"dbo", "ActionRight", 4, 0);
			this.AddElementFieldMapping("ActionRightEntity", "ActionRightID", "ActionRightID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ActionRightEntity", "ActionRightDescription", "ActionRightDescription", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("ActionRightEntity", "AppliesToForum", "AppliesToForum", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 2);
			this.AddElementFieldMapping("ActionRightEntity", "AppliesToSystem", "AppliesToSystem", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 3);
		}

		/// <summary>Inits AttachmentEntity's mappings</summary>
		private void InitAttachmentEntityMappings()
		{
			this.AddElementMapping("AttachmentEntity", @"HnD", @"dbo", "Attachment", 7, 0);
			this.AddElementFieldMapping("AttachmentEntity", "AttachmentID", "AttachmentID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("AttachmentEntity", "MessageID", "MessageID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("AttachmentEntity", "Filename", "Filename", false, "NVarChar", 255, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("AttachmentEntity", "Approved", "Approved", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 3);
			this.AddElementFieldMapping("AttachmentEntity", "Filecontents", "Filecontents", false, "Image", 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 4);
			this.AddElementFieldMapping("AttachmentEntity", "Filesize", "Filesize", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 5);
			this.AddElementFieldMapping("AttachmentEntity", "AddedOn", "AddedOn", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 6);
		}

		/// <summary>Inits AuditActionEntity's mappings</summary>
		private void InitAuditActionEntityMappings()
		{
			this.AddElementMapping("AuditActionEntity", @"HnD", @"dbo", "AuditAction", 2, 0);
			this.AddElementFieldMapping("AuditActionEntity", "AuditActionID", "AuditActionID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("AuditActionEntity", "AuditActionDescription", "AuditActionDescription", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1);
		}

		/// <summary>Inits AuditDataCoreEntity's mappings</summary>
		private void InitAuditDataCoreEntityMappings()
		{
			this.AddElementMapping("AuditDataCoreEntity", @"HnD", @"dbo", "AuditDataCore", 4, 0);
			this.AddElementFieldMapping("AuditDataCoreEntity", "AuditDataID", "AuditDataID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("AuditDataCoreEntity", "AuditActionID", "AuditActionID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("AuditDataCoreEntity", "UserID", "UserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("AuditDataCoreEntity", "AuditedOn", "AuditedOn", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3);
		}

		/// <summary>Inits AuditDataMessageRelatedEntity's mappings</summary>
		private void InitAuditDataMessageRelatedEntityMappings()
		{
			this.AddElementMapping("AuditDataMessageRelatedEntity", @"HnD", @"dbo", "AuditDataMessageRelated", 2, 0);
			this.AddElementFieldMapping("AuditDataMessageRelatedEntity", "AuditDataID", "AuditDataID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("AuditDataMessageRelatedEntity", "MessageID", "MessageID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
		}

		/// <summary>Inits AuditDataThreadRelatedEntity's mappings</summary>
		private void InitAuditDataThreadRelatedEntityMappings()
		{
			this.AddElementMapping("AuditDataThreadRelatedEntity", @"HnD", @"dbo", "AuditDataThreadRelated", 2, 0);
			this.AddElementFieldMapping("AuditDataThreadRelatedEntity", "AuditDataID", "AuditDataID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("AuditDataThreadRelatedEntity", "ThreadID", "ThreadID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
		}

		/// <summary>Inits BookmarkEntity's mappings</summary>
		private void InitBookmarkEntityMappings()
		{
			this.AddElementMapping("BookmarkEntity", @"HnD", @"dbo", "Bookmark", 2, 0);
			this.AddElementFieldMapping("BookmarkEntity", "ThreadID", "ThreadID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("BookmarkEntity", "UserID", "UserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
		}

		/// <summary>Inits ForumEntity's mappings</summary>
		private void InitForumEntityMappings()
		{
			this.AddElementMapping("ForumEntity", @"HnD", @"dbo", "Forum", 12, 0);
			this.AddElementFieldMapping("ForumEntity", "ForumID", "ForumID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ForumEntity", "SectionID", "SectionID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("ForumEntity", "ForumName", "ForumName", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("ForumEntity", "ForumDescription", "ForumDescription", false, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 3);
			this.AddElementFieldMapping("ForumEntity", "ForumLastPostingDate", "ForumLastPostingDate", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 4);
			this.AddElementFieldMapping("ForumEntity", "HasRSSFeed", "HasRSSFeed", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 5);
			this.AddElementFieldMapping("ForumEntity", "DefaultSupportQueueID", "DefaultSupportQueueID", true, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 6);
			this.AddElementFieldMapping("ForumEntity", "OrderNo", "OrderNo", false, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 7);
			this.AddElementFieldMapping("ForumEntity", "MaxAttachmentSize", "MaxAttachmentSize", true, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 8);
			this.AddElementFieldMapping("ForumEntity", "MaxNoOfAttachmentsPerMessage", "MaxNoOfAttachmentsPerMessage", true, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 9);
			this.AddElementFieldMapping("ForumEntity", "NewThreadWelcomeText", "NewThreadWelcomeText", true, "NText", 1073741823, 0, 0, false, "", null, typeof(System.String), 10);
			this.AddElementFieldMapping("ForumEntity", "NewThreadWelcomeTextAsHTML", "NewThreadWelcomeTextAsHTML", true, "NText", 1073741823, 0, 0, false, "", null, typeof(System.String), 11);
		}

		/// <summary>Inits ForumRoleForumActionRightEntity's mappings</summary>
		private void InitForumRoleForumActionRightEntityMappings()
		{
			this.AddElementMapping("ForumRoleForumActionRightEntity", @"HnD", @"dbo", "ForumRoleForumActionRight", 3, 0);
			this.AddElementFieldMapping("ForumRoleForumActionRightEntity", "ForumID", "ForumID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ForumRoleForumActionRightEntity", "RoleID", "RoleID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("ForumRoleForumActionRightEntity", "ActionRightID", "ActionRightID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
		}

		/// <summary>Inits IPBanEntity's mappings</summary>
		private void InitIPBanEntityMappings()
		{
			this.AddElementMapping("IPBanEntity", @"HnD", @"dbo", "IPBan", 9, 0);
			this.AddElementFieldMapping("IPBanEntity", "IPBanID", "IPBanID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("IPBanEntity", "IPSegment1", "IPSegment1", false, "TinyInt", 0, 3, 0, false, "", null, typeof(System.Byte), 1);
			this.AddElementFieldMapping("IPBanEntity", "IPSegment2", "IPSegment2", false, "TinyInt", 0, 3, 0, false, "", null, typeof(System.Byte), 2);
			this.AddElementFieldMapping("IPBanEntity", "IPSegment3", "IPSegment3", false, "TinyInt", 0, 3, 0, false, "", null, typeof(System.Byte), 3);
			this.AddElementFieldMapping("IPBanEntity", "IPSegment4", "IPSegment4", false, "TinyInt", 0, 3, 0, false, "", null, typeof(System.Byte), 4);
			this.AddElementFieldMapping("IPBanEntity", "Range", "Range", false, "TinyInt", 0, 3, 0, false, "", null, typeof(System.Byte), 5);
			this.AddElementFieldMapping("IPBanEntity", "IPBanSetByUserID", "IPBanSetByUserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 6);
			this.AddElementFieldMapping("IPBanEntity", "IPBanSetOn", "IPBanSetOn", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 7);
			this.AddElementFieldMapping("IPBanEntity", "Reason", "Reason", false, "NText", 1073741823, 0, 0, false, "", null, typeof(System.String), 8);
		}

		/// <summary>Inits MessageEntity's mappings</summary>
		private void InitMessageEntityMappings()
		{
			this.AddElementMapping("MessageEntity", @"HnD", @"dbo", "Message", 8, 0);
			this.AddElementFieldMapping("MessageEntity", "MessageID", "MessageID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("MessageEntity", "PostingDate", "PostingDate", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1);
			this.AddElementFieldMapping("MessageEntity", "PostedByUserID", "PostedByUserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("MessageEntity", "ThreadID", "ThreadID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 3);
			this.AddElementFieldMapping("MessageEntity", "PostedFromIP", "PostedFromIP", false, "VarChar", 25, 0, 0, false, "", null, typeof(System.String), 4);
			this.AddElementFieldMapping("MessageEntity", "ChangeTrackerStamp", "ChangeTrackerStamp", false, "Timestamp", 8, 0, 0, false, "", null, typeof(System.Byte[]), 5);
			this.AddElementFieldMapping("MessageEntity", "MessageText", "MessageText", true, "NText", 1073741823, 0, 0, false, "", null, typeof(System.String), 6);
			this.AddElementFieldMapping("MessageEntity", "MessageTextAsHTML", "MessageTextAsHTML", true, "NText", 1073741823, 0, 0, false, "", null, typeof(System.String), 7);
		}

		/// <summary>Inits PasswordResetTokenEntity's mappings</summary>
		private void InitPasswordResetTokenEntityMappings()
		{
			this.AddElementMapping("PasswordResetTokenEntity", @"HnD", @"dbo", "PasswordResetToken", 3, 0);
			this.AddElementFieldMapping("PasswordResetTokenEntity", "UserID", "UserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("PasswordResetTokenEntity", "PasswordResetToken", "PasswordResetToken", false, "UniqueIdentifier", 0, 0, 0, false, "", null, typeof(System.Guid), 1);
			this.AddElementFieldMapping("PasswordResetTokenEntity", "PasswordResetRequestedOn", "PasswordResetRequestedOn", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 2);
		}

		/// <summary>Inits RoleEntity's mappings</summary>
		private void InitRoleEntityMappings()
		{
			this.AddElementMapping("RoleEntity", @"HnD", @"dbo", "Role", 2, 0);
			this.AddElementFieldMapping("RoleEntity", "RoleID", "RoleID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("RoleEntity", "RoleDescription", "RoleDescription", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1);
		}

		/// <summary>Inits RoleAuditActionEntity's mappings</summary>
		private void InitRoleAuditActionEntityMappings()
		{
			this.AddElementMapping("RoleAuditActionEntity", @"HnD", @"dbo", "RoleAuditAction", 2, 0);
			this.AddElementFieldMapping("RoleAuditActionEntity", "AuditActionID", "AuditActionID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("RoleAuditActionEntity", "RoleID", "RoleID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
		}

		/// <summary>Inits RoleSystemActionRightEntity's mappings</summary>
		private void InitRoleSystemActionRightEntityMappings()
		{
			this.AddElementMapping("RoleSystemActionRightEntity", @"HnD", @"dbo", "RoleSystemActionRight", 2, 0);
			this.AddElementFieldMapping("RoleSystemActionRightEntity", "RoleID", "RoleID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("RoleSystemActionRightEntity", "ActionRightID", "ActionRightID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
		}

		/// <summary>Inits RoleUserEntity's mappings</summary>
		private void InitRoleUserEntityMappings()
		{
			this.AddElementMapping("RoleUserEntity", @"HnD", @"dbo", "RoleUser", 2, 0);
			this.AddElementFieldMapping("RoleUserEntity", "RoleID", "RoleID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("RoleUserEntity", "UserID", "UserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
		}

		/// <summary>Inits SectionEntity's mappings</summary>
		private void InitSectionEntityMappings()
		{
			this.AddElementMapping("SectionEntity", @"HnD", @"dbo", "Section", 4, 0);
			this.AddElementFieldMapping("SectionEntity", "SectionID", "SectionID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("SectionEntity", "SectionName", "SectionName", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("SectionEntity", "SectionDescription", "SectionDescription", false, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("SectionEntity", "OrderNo", "OrderNo", false, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 3);
		}

		/// <summary>Inits SupportQueueEntity's mappings</summary>
		private void InitSupportQueueEntityMappings()
		{
			this.AddElementMapping("SupportQueueEntity", @"HnD", @"dbo", "SupportQueue", 4, 0);
			this.AddElementFieldMapping("SupportQueueEntity", "QueueID", "QueueID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("SupportQueueEntity", "QueueName", "QueueName", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("SupportQueueEntity", "QueueDescription", "QueueDescription", false, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("SupportQueueEntity", "OrderNo", "OrderNo", false, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 3);
		}

		/// <summary>Inits SupportQueueThreadEntity's mappings</summary>
		private void InitSupportQueueThreadEntityMappings()
		{
			this.AddElementMapping("SupportQueueThreadEntity", @"HnD", @"dbo", "SupportQueueThread", 6, 0);
			this.AddElementFieldMapping("SupportQueueThreadEntity", "QueueID", "QueueID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("SupportQueueThreadEntity", "ThreadID", "ThreadID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("SupportQueueThreadEntity", "PlacedInQueueByUserID", "PlacedInQueueByUserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("SupportQueueThreadEntity", "PlacedInQueueOn", "PlacedInQueueOn", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3);
			this.AddElementFieldMapping("SupportQueueThreadEntity", "ClaimedByUserID", "ClaimedByUserID", true, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 4);
			this.AddElementFieldMapping("SupportQueueThreadEntity", "ClaimedOn", "ClaimedOn", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 5);
		}

		/// <summary>Inits SystemDataEntity's mappings</summary>
		private void InitSystemDataEntityMappings()
		{
			this.AddElementMapping("SystemDataEntity", @"HnD", @"dbo", "SystemData", 9, 0);
			this.AddElementFieldMapping("SystemDataEntity", "ID", "ID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("SystemDataEntity", "DefaultRoleNewUser", "DefaultRoleNewUser", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("SystemDataEntity", "AnonymousRole", "AnonymousRole", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("SystemDataEntity", "DefaultUserTitleNewUser", "DefaultUserTitleNewUser", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 3);
			this.AddElementFieldMapping("SystemDataEntity", "HoursThresholdForActiveThreads", "HoursThresholdForActiveThreads", false, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 4);
			this.AddElementFieldMapping("SystemDataEntity", "PageSizeSearchResults", "PageSizeSearchResults", false, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 5);
			this.AddElementFieldMapping("SystemDataEntity", "MinNumberOfThreadsToFetch", "MinNumberOfThreadsToFetch", false, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 6);
			this.AddElementFieldMapping("SystemDataEntity", "MinNumberOfNonStickyVisibleThreads", "MinNumberOfNonStickyVisibleThreads", false, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 7);
			this.AddElementFieldMapping("SystemDataEntity", "SendReplyNotifications", "SendReplyNotifications", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 8);
		}

		/// <summary>Inits ThreadEntity's mappings</summary>
		private void InitThreadEntityMappings()
		{
			this.AddElementMapping("ThreadEntity", @"HnD", @"dbo", "Thread", 8, 0);
			this.AddElementFieldMapping("ThreadEntity", "ThreadID", "ThreadID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ThreadEntity", "ForumID", "ForumID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("ThreadEntity", "Subject", "Subject", false, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("ThreadEntity", "StartedByUserID", "StartedByUserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 3);
			this.AddElementFieldMapping("ThreadEntity", "IsSticky", "IsSticky", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 4);
			this.AddElementFieldMapping("ThreadEntity", "IsClosed", "IsClosed", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 5);
			this.AddElementFieldMapping("ThreadEntity", "MarkedAsDone", "MarkedAsDone", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 6);
			this.AddElementFieldMapping("ThreadEntity", "Memo", "Memo", true, "NText", 1073741823, 0, 0, false, "", null, typeof(System.String), 7);
		}

		/// <summary>Inits ThreadStatisticsEntity's mappings</summary>
		private void InitThreadStatisticsEntityMappings()
		{
			this.AddElementMapping("ThreadStatisticsEntity", @"HnD", @"dbo", "ThreadStatistics", 4, 0);
			this.AddElementFieldMapping("ThreadStatisticsEntity", "ThreadID", "ThreadID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ThreadStatisticsEntity", "LastMessageID", "LastMessageID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("ThreadStatisticsEntity", "NumberOfMessages", "NumberOfMessages", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("ThreadStatisticsEntity", "NumberOfViews", "NumberOfViews", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 3);
		}

		/// <summary>Inits ThreadSubscriptionEntity's mappings</summary>
		private void InitThreadSubscriptionEntityMappings()
		{
			this.AddElementMapping("ThreadSubscriptionEntity", @"HnD", @"dbo", "ThreadSubscription", 2, 0);
			this.AddElementFieldMapping("ThreadSubscriptionEntity", "UserID", "UserID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ThreadSubscriptionEntity", "ThreadID", "ThreadID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
		}

		/// <summary>Inits UserEntity's mappings</summary>
		private void InitUserEntityMappings()
		{
			this.AddElementMapping("UserEntity", @"HnD", @"dbo", "User", 19, 0);
			this.AddElementFieldMapping("UserEntity", "UserID", "UserID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("UserEntity", "NickName", "NickName", false, "NVarChar", 20, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("UserEntity", "Password", "Password", false, "NVarChar", 128, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("UserEntity", "IsBanned", "IsBanned", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 3);
			this.AddElementFieldMapping("UserEntity", "IPNumber", "IPNumber", false, "VarChar", 25, 0, 0, false, "", null, typeof(System.String), 4);
			this.AddElementFieldMapping("UserEntity", "Signature", "Signature", true, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 5);
			this.AddElementFieldMapping("UserEntity", "IconURL", "IconURL", true, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 6);
			this.AddElementFieldMapping("UserEntity", "EmailAddress", "EmailAddress", true, "NVarChar", 200, 0, 0, false, "", null, typeof(System.String), 7);
			this.AddElementFieldMapping("UserEntity", "UserTitleID", "UserTitleID", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 8);
			this.AddElementFieldMapping("UserEntity", "DateOfBirth", "DateOfBirth", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 9);
			this.AddElementFieldMapping("UserEntity", "Occupation", "Occupation", true, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 10);
			this.AddElementFieldMapping("UserEntity", "Location", "Location", true, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 11);
			this.AddElementFieldMapping("UserEntity", "Website", "Website", true, "NVarChar", 200, 0, 0, false, "", null, typeof(System.String), 12);
			this.AddElementFieldMapping("UserEntity", "JoinDate", "JoinDate", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 13);
			this.AddElementFieldMapping("UserEntity", "AmountOfPostings", "AmountOfPostings", true, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 14);
			this.AddElementFieldMapping("UserEntity", "EmailAddressIsPublic", "EmailAddressIsPublic", true, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 15);
			this.AddElementFieldMapping("UserEntity", "LastVisitedDate", "LastVisitedDate", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 16);
			this.AddElementFieldMapping("UserEntity", "AutoSubscribeToThread", "AutoSubscribeToThread", true, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 17);
			this.AddElementFieldMapping("UserEntity", "DefaultNumberOfMessagesPerPage", "DefaultNumberOfMessagesPerPage", true, "SmallInt", 0, 5, 0, false, "", null, typeof(System.Int16), 18);
		}

		/// <summary>Inits UserTitleEntity's mappings</summary>
		private void InitUserTitleEntityMappings()
		{
			this.AddElementMapping("UserTitleEntity", @"HnD", @"dbo", "UserTitle", 2, 0);
			this.AddElementFieldMapping("UserTitleEntity", "UserTitleID", "UserTitleID", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("UserTitleEntity", "UserTitleDescription", "UserTitleDescription", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 1);
		}

	}
}
