///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.HelperClasses
{
	/// <summary>
	/// Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal sealed class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			base.InitClass((23 + 0));
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
			InitRoleEntityMappings();
			InitRoleAuditActionEntityMappings();
			InitRoleSystemActionRightEntityMappings();
			InitRoleUserEntityMappings();
			InitSectionEntityMappings();
			InitSupportQueueEntityMappings();
			InitSupportQueueThreadEntityMappings();
			InitSystemDataEntityMappings();
			InitThreadEntityMappings();
			InitThreadSubscriptionEntityMappings();
			InitUserEntityMappings();
			InitUserTitleEntityMappings();

		}


		/// <summary>Inits ActionRightEntity's mappings</summary>
		private void InitActionRightEntityMappings()
		{
			base.AddElementMapping( "ActionRightEntity", "HnD", @"dbo", "ActionRight", 4 );
			base.AddElementFieldMapping( "ActionRightEntity", "ActionRightID", "ActionRightID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ActionRightEntity", "ActionRightDescription", "ActionRightDescription", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ActionRightEntity", "AppliesToForum", "AppliesToForum", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 2 );
			base.AddElementFieldMapping( "ActionRightEntity", "AppliesToSystem", "AppliesToSystem", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits AttachmentEntity's mappings</summary>
		private void InitAttachmentEntityMappings()
		{
			base.AddElementMapping( "AttachmentEntity", "HnD", @"dbo", "Attachment", 7 );
			base.AddElementFieldMapping( "AttachmentEntity", "AttachmentID", "AttachmentID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AttachmentEntity", "MessageID", "MessageID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AttachmentEntity", "Filename", "Filename", true, (int)SqlDbType.NVarChar, 255, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "AttachmentEntity", "Approved", "Approved", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "AttachmentEntity", "Filecontents", "Filecontents", false, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 4 );
			base.AddElementFieldMapping( "AttachmentEntity", "Filesize", "Filesize", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "AttachmentEntity", "AddedOn", "AddedOn", false, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 6 );
		}
		/// <summary>Inits AuditActionEntity's mappings</summary>
		private void InitAuditActionEntityMappings()
		{
			base.AddElementMapping( "AuditActionEntity", "HnD", @"dbo", "AuditAction", 2 );
			base.AddElementFieldMapping( "AuditActionEntity", "AuditActionID", "AuditActionID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AuditActionEntity", "AuditActionDescription", "AuditActionDescription", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits AuditDataCoreEntity's mappings</summary>
		private void InitAuditDataCoreEntityMappings()
		{
			base.AddElementMapping( "AuditDataCoreEntity", "HnD", @"dbo", "AuditDataCore", 4 );
			base.AddElementFieldMapping( "AuditDataCoreEntity", "AuditDataID", "AuditDataID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AuditDataCoreEntity", "AuditActionID", "AuditActionID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AuditDataCoreEntity", "UserID", "UserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "AuditDataCoreEntity", "AuditedOn", "AuditedOn", false, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 3 );
		}
		/// <summary>Inits AuditDataMessageRelatedEntity's mappings</summary>
		private void InitAuditDataMessageRelatedEntityMappings()
		{
			base.AddElementMapping( "AuditDataMessageRelatedEntity", "HnD", @"dbo", "AuditDataMessageRelated", 2 );
			base.AddElementFieldMapping( "AuditDataMessageRelatedEntity", "AuditDataID", "AuditDataID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AuditDataMessageRelatedEntity", "MessageID", "MessageID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AuditDataThreadRelatedEntity's mappings</summary>
		private void InitAuditDataThreadRelatedEntityMappings()
		{
			base.AddElementMapping( "AuditDataThreadRelatedEntity", "HnD", @"dbo", "AuditDataThreadRelated", 2 );
			base.AddElementFieldMapping( "AuditDataThreadRelatedEntity", "AuditDataID", "AuditDataID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AuditDataThreadRelatedEntity", "ThreadID", "ThreadID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits BookmarkEntity's mappings</summary>
		private void InitBookmarkEntityMappings()
		{
			base.AddElementMapping( "BookmarkEntity", "HnD", @"dbo", "Bookmark", 2 );
			base.AddElementFieldMapping( "BookmarkEntity", "ThreadID", "ThreadID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "BookmarkEntity", "UserID", "UserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits ForumEntity's mappings</summary>
		private void InitForumEntityMappings()
		{
			base.AddElementMapping( "ForumEntity", "HnD", @"dbo", "Forum", 13 );
			base.AddElementFieldMapping( "ForumEntity", "ForumID", "ForumID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ForumEntity", "SectionID", "SectionID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "ForumEntity", "ForumName", "ForumName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ForumEntity", "ForumDescription", "ForumDescription", false, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "ForumEntity", "ForumLastPostingDate", "ForumLastPostingDate", true, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "ForumEntity", "HasRSSFeed", "HasRSSFeed", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 5 );
			base.AddElementFieldMapping( "ForumEntity", "DefaultSupportQueueID", "DefaultSupportQueueID", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "ForumEntity", "DefaultThreadListInterval", "DefaultThreadListInterval", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 7 );
			base.AddElementFieldMapping( "ForumEntity", "OrderNo", "OrderNo", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 8 );
			base.AddElementFieldMapping( "ForumEntity", "MaxAttachmentSize", "MaxAttachmentSize", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 9 );
			base.AddElementFieldMapping( "ForumEntity", "MaxNoOfAttachmentsPerMessage", "MaxNoOfAttachmentsPerMessage", true, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 10 );
			base.AddElementFieldMapping( "ForumEntity", "NewThreadWelcomeText", "NewThreadWelcomeText", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "ForumEntity", "NewThreadWelcomeTextAsHTML", "NewThreadWelcomeTextAsHTML", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 12 );
		}
		/// <summary>Inits ForumRoleForumActionRightEntity's mappings</summary>
		private void InitForumRoleForumActionRightEntityMappings()
		{
			base.AddElementMapping( "ForumRoleForumActionRightEntity", "HnD", @"dbo", "ForumRoleForumActionRight", 3 );
			base.AddElementFieldMapping( "ForumRoleForumActionRightEntity", "ForumID", "ForumID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ForumRoleForumActionRightEntity", "RoleID", "RoleID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "ForumRoleForumActionRightEntity", "ActionRightID", "ActionRightID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits IPBanEntity's mappings</summary>
		private void InitIPBanEntityMappings()
		{
			base.AddElementMapping( "IPBanEntity", "HnD", @"dbo", "IPBan", 9 );
			base.AddElementFieldMapping( "IPBanEntity", "IPBanID", "IPBanID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "IPBanEntity", "IPSegment1", "IPSegment1", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 1 );
			base.AddElementFieldMapping( "IPBanEntity", "IPSegment2", "IPSegment2", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 2 );
			base.AddElementFieldMapping( "IPBanEntity", "IPSegment3", "IPSegment3", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 3 );
			base.AddElementFieldMapping( "IPBanEntity", "IPSegment4", "IPSegment4", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 4 );
			base.AddElementFieldMapping( "IPBanEntity", "Range", "Range", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 5 );
			base.AddElementFieldMapping( "IPBanEntity", "IPBanSetByUserID", "IPBanSetByUserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "IPBanEntity", "IPBanSetOn", "IPBanSetOn", false, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 7 );
			base.AddElementFieldMapping( "IPBanEntity", "Reason", "Reason", false, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 8 );
		}
		/// <summary>Inits MessageEntity's mappings</summary>
		private void InitMessageEntityMappings()
		{
			base.AddElementMapping( "MessageEntity", "HnD", @"dbo", "Message", 9 );
			base.AddElementFieldMapping( "MessageEntity", "MessageID", "MessageID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "MessageEntity", "PostingDate", "PostingDate", false, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 1 );
			base.AddElementFieldMapping( "MessageEntity", "PostedByUserID", "PostedByUserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "MessageEntity", "ThreadID", "ThreadID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "MessageEntity", "PostedFromIP", "PostedFromIP", false, (int)SqlDbType.VarChar, 25, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "MessageEntity", "ChangeTrackerStamp", "ChangeTrackerStamp", false, (int)SqlDbType.Timestamp, 8, 0, 0, false, "", null, typeof(System.Byte[]), 5 );
			base.AddElementFieldMapping( "MessageEntity", "MessageText", "MessageText", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "MessageEntity", "MessageTextAsHTML", "MessageTextAsHTML", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "MessageEntity", "MessageTextAsXml", "MessageTextAsXml", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 8 );
		}
		/// <summary>Inits RoleEntity's mappings</summary>
		private void InitRoleEntityMappings()
		{
			base.AddElementMapping( "RoleEntity", "HnD", @"dbo", "Role", 2 );
			base.AddElementFieldMapping( "RoleEntity", "RoleID", "RoleID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RoleEntity", "RoleDescription", "RoleDescription", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits RoleAuditActionEntity's mappings</summary>
		private void InitRoleAuditActionEntityMappings()
		{
			base.AddElementMapping( "RoleAuditActionEntity", "HnD", @"dbo", "RoleAuditAction", 2 );
			base.AddElementFieldMapping( "RoleAuditActionEntity", "AuditActionID", "AuditActionID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RoleAuditActionEntity", "RoleID", "RoleID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits RoleSystemActionRightEntity's mappings</summary>
		private void InitRoleSystemActionRightEntityMappings()
		{
			base.AddElementMapping( "RoleSystemActionRightEntity", "HnD", @"dbo", "RoleSystemActionRight", 2 );
			base.AddElementFieldMapping( "RoleSystemActionRightEntity", "RoleID", "RoleID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RoleSystemActionRightEntity", "ActionRightID", "ActionRightID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits RoleUserEntity's mappings</summary>
		private void InitRoleUserEntityMappings()
		{
			base.AddElementMapping( "RoleUserEntity", "HnD", @"dbo", "RoleUser", 2 );
			base.AddElementFieldMapping( "RoleUserEntity", "RoleID", "RoleID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RoleUserEntity", "UserID", "UserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits SectionEntity's mappings</summary>
		private void InitSectionEntityMappings()
		{
			base.AddElementMapping( "SectionEntity", "HnD", @"dbo", "Section", 4 );
			base.AddElementFieldMapping( "SectionEntity", "SectionID", "SectionID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "SectionEntity", "SectionName", "SectionName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "SectionEntity", "SectionDescription", "SectionDescription", false, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "SectionEntity", "OrderNo", "OrderNo", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 3 );
		}
		/// <summary>Inits SupportQueueEntity's mappings</summary>
		private void InitSupportQueueEntityMappings()
		{
			base.AddElementMapping( "SupportQueueEntity", "HnD", @"dbo", "SupportQueue", 4 );
			base.AddElementFieldMapping( "SupportQueueEntity", "QueueID", "QueueID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "SupportQueueEntity", "QueueName", "QueueName", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "SupportQueueEntity", "QueueDescription", "QueueDescription", true, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "SupportQueueEntity", "OrderNo", "OrderNo", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 3 );
		}
		/// <summary>Inits SupportQueueThreadEntity's mappings</summary>
		private void InitSupportQueueThreadEntityMappings()
		{
			base.AddElementMapping( "SupportQueueThreadEntity", "HnD", @"dbo", "SupportQueueThread", 6 );
			base.AddElementFieldMapping( "SupportQueueThreadEntity", "QueueID", "QueueID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "SupportQueueThreadEntity", "ThreadID", "ThreadID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "SupportQueueThreadEntity", "PlacedInQueueByUserID", "PlacedInQueueByUserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "SupportQueueThreadEntity", "PlacedInQueueOn", "PlacedInQueueOn", false, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "SupportQueueThreadEntity", "ClaimedByUserID", "ClaimedByUserID", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "SupportQueueThreadEntity", "ClaimedOn", "ClaimedOn", true, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 5 );
		}
		/// <summary>Inits SystemDataEntity's mappings</summary>
		private void InitSystemDataEntityMappings()
		{
			base.AddElementMapping( "SystemDataEntity", "HnD", @"dbo", "SystemData", 9 );
			base.AddElementFieldMapping( "SystemDataEntity", "ID", "ID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "SystemDataEntity", "DefaultRoleNewUser", "DefaultRoleNewUser", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "SystemDataEntity", "AnonymousRole", "AnonymousRole", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "SystemDataEntity", "DefaultUserTitleNewUser", "DefaultUserTitleNewUser", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "SystemDataEntity", "HoursThresholdForActiveThreads", "HoursThresholdForActiveThreads", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 4 );
			base.AddElementFieldMapping( "SystemDataEntity", "PageSizeSearchResults", "PageSizeSearchResults", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 5 );
			base.AddElementFieldMapping( "SystemDataEntity", "MinNumberOfThreadsToFetch", "MinNumberOfThreadsToFetch", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 6 );
			base.AddElementFieldMapping( "SystemDataEntity", "MinNumberOfNonStickyVisibleThreads", "MinNumberOfNonStickyVisibleThreads", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 7 );
			base.AddElementFieldMapping( "SystemDataEntity", "SendReplyNotifications", "SendReplyNotifications", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 8 );
		}
		/// <summary>Inits ThreadEntity's mappings</summary>
		private void InitThreadEntityMappings()
		{
			base.AddElementMapping( "ThreadEntity", "HnD", @"dbo", "Thread", 10 );
			base.AddElementFieldMapping( "ThreadEntity", "ThreadID", "ThreadID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ThreadEntity", "ForumID", "ForumID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "ThreadEntity", "Subject", "Subject", false, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ThreadEntity", "StartedByUserID", "StartedByUserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "ThreadEntity", "ThreadLastPostingDate", "ThreadLastPostingDate", true, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "ThreadEntity", "IsSticky", "IsSticky", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 5 );
			base.AddElementFieldMapping( "ThreadEntity", "IsClosed", "IsClosed", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 6 );
			base.AddElementFieldMapping( "ThreadEntity", "MarkedAsDone", "MarkedAsDone", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 7 );
			base.AddElementFieldMapping( "ThreadEntity", "NumberOfViews", "NumberOfViews", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
			base.AddElementFieldMapping( "ThreadEntity", "Memo", "Memo", true, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 9 );
		}
		/// <summary>Inits ThreadSubscriptionEntity's mappings</summary>
		private void InitThreadSubscriptionEntityMappings()
		{
			base.AddElementMapping( "ThreadSubscriptionEntity", "HnD", @"dbo", "ThreadSubscription", 2 );
			base.AddElementFieldMapping( "ThreadSubscriptionEntity", "UserID", "UserID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ThreadSubscriptionEntity", "ThreadID", "ThreadID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits UserEntity's mappings</summary>
		private void InitUserEntityMappings()
		{
			base.AddElementMapping( "UserEntity", "HnD", @"dbo", "User", 20 );
			base.AddElementFieldMapping( "UserEntity", "UserID", "UserID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserEntity", "NickName", "NickName", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "UserEntity", "Password", "Password", false, (int)SqlDbType.NVarChar, 30, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "UserEntity", "IsBanned", "IsBanned", false, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "UserEntity", "IPNumber", "IPNumber", false, (int)SqlDbType.VarChar, 25, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "UserEntity", "Signature", "Signature", true, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "UserEntity", "IconURL", "IconURL", true, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "UserEntity", "EmailAddress", "EmailAddress", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "UserEntity", "UserTitleID", "UserTitleID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
			base.AddElementFieldMapping( "UserEntity", "DateOfBirth", "DateOfBirth", true, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 9 );
			base.AddElementFieldMapping( "UserEntity", "Occupation", "Occupation", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "UserEntity", "Location", "Location", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "UserEntity", "Website", "Website", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "UserEntity", "SignatureAsHTML", "SignatureAsHTML", true, (int)SqlDbType.NVarChar, 1024, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "UserEntity", "JoinDate", "JoinDate", true, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 14 );
			base.AddElementFieldMapping( "UserEntity", "AmountOfPostings", "AmountOfPostings", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 15 );
			base.AddElementFieldMapping( "UserEntity", "EmailAddressIsPublic", "EmailAddressIsPublic", true, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 16 );
			base.AddElementFieldMapping( "UserEntity", "LastVisitedDate", "LastVisitedDate", true, (int)SqlDbType.DateTime, 0, 3, 23, false, "", null, typeof(System.DateTime), 17 );
			base.AddElementFieldMapping( "UserEntity", "AutoSubscribeToThread", "AutoSubscribeToThread", true, (int)SqlDbType.Bit, 0, 0, 1, false, "", null, typeof(System.Boolean), 18 );
			base.AddElementFieldMapping( "UserEntity", "DefaultNumberOfMessagesPerPage", "DefaultNumberOfMessagesPerPage", true, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 19 );
		}
		/// <summary>Inits UserTitleEntity's mappings</summary>
		private void InitUserTitleEntityMappings()
		{
			base.AddElementMapping( "UserTitleEntity", "HnD", @"dbo", "UserTitle", 2 );
			base.AddElementFieldMapping( "UserTitleEntity", "UserTitleID", "UserTitleID", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserTitleEntity", "UserTitleDescription", "UserTitleDescription", false, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}

	}
}