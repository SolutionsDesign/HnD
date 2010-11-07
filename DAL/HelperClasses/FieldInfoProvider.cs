///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>
	/// Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal sealed class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private FieldInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			base.InitClass( (23 + 0));
			InitActionRightEntityInfos();
			InitAttachmentEntityInfos();
			InitAuditActionEntityInfos();
			InitAuditDataCoreEntityInfos();
			InitAuditDataMessageRelatedEntityInfos();
			InitAuditDataThreadRelatedEntityInfos();
			InitBookmarkEntityInfos();
			InitForumEntityInfos();
			InitForumRoleForumActionRightEntityInfos();
			InitIPBanEntityInfos();
			InitMessageEntityInfos();
			InitRoleEntityInfos();
			InitRoleAuditActionEntityInfos();
			InitRoleSystemActionRightEntityInfos();
			InitRoleUserEntityInfos();
			InitSectionEntityInfos();
			InitSupportQueueEntityInfos();
			InitSupportQueueThreadEntityInfos();
			InitSystemDataEntityInfos();
			InitThreadEntityInfos();
			InitThreadSubscriptionEntityInfos();
			InitUserEntityInfos();
			InitUserTitleEntityInfos();

			base.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits ActionRightEntity's FieldInfo objects</summary>
		private void InitActionRightEntityInfos()
		{
			base.AddElementFieldInfo("ActionRightEntity", "ActionRightID", typeof(System.Int32), true, false, false, false,  (int)ActionRightFieldIndex.ActionRightID, 0, 0, 10);
			base.AddElementFieldInfo("ActionRightEntity", "ActionRightDescription", typeof(System.String), false, false, false, false,  (int)ActionRightFieldIndex.ActionRightDescription, 50, 0, 0);
			base.AddElementFieldInfo("ActionRightEntity", "AppliesToForum", typeof(System.Boolean), false, false, false, false,  (int)ActionRightFieldIndex.AppliesToForum, 0, 0, 1);
			base.AddElementFieldInfo("ActionRightEntity", "AppliesToSystem", typeof(System.Boolean), false, false, false, false,  (int)ActionRightFieldIndex.AppliesToSystem, 0, 0, 1);
		}
		/// <summary>Inits AttachmentEntity's FieldInfo objects</summary>
		private void InitAttachmentEntityInfos()
		{
			base.AddElementFieldInfo("AttachmentEntity", "AttachmentID", typeof(System.Int32), true, false, true, false,  (int)AttachmentFieldIndex.AttachmentID, 0, 0, 10);
			base.AddElementFieldInfo("AttachmentEntity", "MessageID", typeof(System.Int32), false, true, false, false,  (int)AttachmentFieldIndex.MessageID, 0, 0, 10);
			base.AddElementFieldInfo("AttachmentEntity", "Filename", typeof(System.String), false, false, false, true,  (int)AttachmentFieldIndex.Filename, 255, 0, 0);
			base.AddElementFieldInfo("AttachmentEntity", "Approved", typeof(System.Boolean), false, false, false, false,  (int)AttachmentFieldIndex.Approved, 0, 0, 1);
			base.AddElementFieldInfo("AttachmentEntity", "Filecontents", typeof(System.Byte[]), false, false, false, false,  (int)AttachmentFieldIndex.Filecontents, 2147483647, 0, 0);
			base.AddElementFieldInfo("AttachmentEntity", "Filesize", typeof(System.Int32), false, false, false, false,  (int)AttachmentFieldIndex.Filesize, 0, 0, 10);
			base.AddElementFieldInfo("AttachmentEntity", "AddedOn", typeof(System.DateTime), false, false, false, false,  (int)AttachmentFieldIndex.AddedOn, 0, 3, 23);
		}
		/// <summary>Inits AuditActionEntity's FieldInfo objects</summary>
		private void InitAuditActionEntityInfos()
		{
			base.AddElementFieldInfo("AuditActionEntity", "AuditActionID", typeof(System.Int32), true, false, false, false,  (int)AuditActionFieldIndex.AuditActionID, 0, 0, 10);
			base.AddElementFieldInfo("AuditActionEntity", "AuditActionDescription", typeof(System.String), false, false, false, true,  (int)AuditActionFieldIndex.AuditActionDescription, 50, 0, 0);
		}
		/// <summary>Inits AuditDataCoreEntity's FieldInfo objects</summary>
		private void InitAuditDataCoreEntityInfos()
		{
			base.AddElementFieldInfo("AuditDataCoreEntity", "AuditDataID", typeof(System.Int32), true, false, true, false,  (int)AuditDataCoreFieldIndex.AuditDataID, 0, 0, 10);
			base.AddElementFieldInfo("AuditDataCoreEntity", "AuditActionID", typeof(System.Int32), false, true, false, false,  (int)AuditDataCoreFieldIndex.AuditActionID, 0, 0, 10);
			base.AddElementFieldInfo("AuditDataCoreEntity", "UserID", typeof(System.Int32), false, true, false, false,  (int)AuditDataCoreFieldIndex.UserID, 0, 0, 10);
			base.AddElementFieldInfo("AuditDataCoreEntity", "AuditedOn", typeof(System.DateTime), false, false, false, false,  (int)AuditDataCoreFieldIndex.AuditedOn, 0, 3, 23);
		}
		/// <summary>Inits AuditDataMessageRelatedEntity's FieldInfo objects</summary>
		private void InitAuditDataMessageRelatedEntityInfos()
		{
			base.AddElementFieldInfo("AuditDataMessageRelatedEntity", "AuditDataID", typeof(System.Int32), true, false, false, false,  (int)AuditDataMessageRelatedFieldIndex.AuditDataID, 0, 0, 10);
			base.AddElementFieldInfo("AuditDataMessageRelatedEntity", "MessageID", typeof(System.Int32), false, true, false, false,  (int)AuditDataMessageRelatedFieldIndex.MessageID, 0, 0, 10);
		}
		/// <summary>Inits AuditDataThreadRelatedEntity's FieldInfo objects</summary>
		private void InitAuditDataThreadRelatedEntityInfos()
		{
			base.AddElementFieldInfo("AuditDataThreadRelatedEntity", "AuditDataID", typeof(System.Int32), true, false, false, false,  (int)AuditDataThreadRelatedFieldIndex.AuditDataID, 0, 0, 10);
			base.AddElementFieldInfo("AuditDataThreadRelatedEntity", "ThreadID", typeof(System.Int32), false, true, false, false,  (int)AuditDataThreadRelatedFieldIndex.ThreadID, 0, 0, 10);
		}
		/// <summary>Inits BookmarkEntity's FieldInfo objects</summary>
		private void InitBookmarkEntityInfos()
		{
			base.AddElementFieldInfo("BookmarkEntity", "ThreadID", typeof(System.Int32), true, true, false, false,  (int)BookmarkFieldIndex.ThreadID, 0, 0, 10);
			base.AddElementFieldInfo("BookmarkEntity", "UserID", typeof(System.Int32), true, true, false, false,  (int)BookmarkFieldIndex.UserID, 0, 0, 10);
		}
		/// <summary>Inits ForumEntity's FieldInfo objects</summary>
		private void InitForumEntityInfos()
		{
			base.AddElementFieldInfo("ForumEntity", "ForumID", typeof(System.Int32), true, false, true, false,  (int)ForumFieldIndex.ForumID, 0, 0, 10);
			base.AddElementFieldInfo("ForumEntity", "SectionID", typeof(System.Int32), false, true, false, false,  (int)ForumFieldIndex.SectionID, 0, 0, 10);
			base.AddElementFieldInfo("ForumEntity", "ForumName", typeof(System.String), false, false, false, false,  (int)ForumFieldIndex.ForumName, 50, 0, 0);
			base.AddElementFieldInfo("ForumEntity", "ForumDescription", typeof(System.String), false, false, false, false,  (int)ForumFieldIndex.ForumDescription, 250, 0, 0);
			base.AddElementFieldInfo("ForumEntity", "ForumLastPostingDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ForumFieldIndex.ForumLastPostingDate, 0, 3, 23);
			base.AddElementFieldInfo("ForumEntity", "HasRSSFeed", typeof(System.Boolean), false, false, false, false,  (int)ForumFieldIndex.HasRSSFeed, 0, 0, 1);
			base.AddElementFieldInfo("ForumEntity", "DefaultSupportQueueID", typeof(Nullable<System.Int32>), false, true, false, true,  (int)ForumFieldIndex.DefaultSupportQueueID, 0, 0, 10);
			base.AddElementFieldInfo("ForumEntity", "DefaultThreadListInterval", typeof(System.Byte), false, false, false, false,  (int)ForumFieldIndex.DefaultThreadListInterval, 0, 0, 3);
			base.AddElementFieldInfo("ForumEntity", "OrderNo", typeof(System.Int16), false, false, false, false,  (int)ForumFieldIndex.OrderNo, 0, 0, 5);
			base.AddElementFieldInfo("ForumEntity", "MaxAttachmentSize", typeof(System.Int32), false, false, false, true,  (int)ForumFieldIndex.MaxAttachmentSize, 0, 0, 10);
			base.AddElementFieldInfo("ForumEntity", "MaxNoOfAttachmentsPerMessage", typeof(System.Int16), false, false, false, true,  (int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, 0, 0, 5);
			base.AddElementFieldInfo("ForumEntity", "NewThreadWelcomeText", typeof(System.String), false, false, false, true,  (int)ForumFieldIndex.NewThreadWelcomeText, 1073741823, 0, 0);
			base.AddElementFieldInfo("ForumEntity", "NewThreadWelcomeTextAsHTML", typeof(System.String), false, false, false, true,  (int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, 1073741823, 0, 0);
		}
		/// <summary>Inits ForumRoleForumActionRightEntity's FieldInfo objects</summary>
		private void InitForumRoleForumActionRightEntityInfos()
		{
			base.AddElementFieldInfo("ForumRoleForumActionRightEntity", "ForumID", typeof(System.Int32), true, true, false, false,  (int)ForumRoleForumActionRightFieldIndex.ForumID, 0, 0, 10);
			base.AddElementFieldInfo("ForumRoleForumActionRightEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)ForumRoleForumActionRightFieldIndex.RoleID, 0, 0, 10);
			base.AddElementFieldInfo("ForumRoleForumActionRightEntity", "ActionRightID", typeof(System.Int32), true, true, false, false,  (int)ForumRoleForumActionRightFieldIndex.ActionRightID, 0, 0, 10);
		}
		/// <summary>Inits IPBanEntity's FieldInfo objects</summary>
		private void InitIPBanEntityInfos()
		{
			base.AddElementFieldInfo("IPBanEntity", "IPBanID", typeof(System.Int32), true, false, true, false,  (int)IPBanFieldIndex.IPBanID, 0, 0, 10);
			base.AddElementFieldInfo("IPBanEntity", "IPSegment1", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment1, 0, 0, 3);
			base.AddElementFieldInfo("IPBanEntity", "IPSegment2", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment2, 0, 0, 3);
			base.AddElementFieldInfo("IPBanEntity", "IPSegment3", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment3, 0, 0, 3);
			base.AddElementFieldInfo("IPBanEntity", "IPSegment4", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment4, 0, 0, 3);
			base.AddElementFieldInfo("IPBanEntity", "Range", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.Range, 0, 0, 3);
			base.AddElementFieldInfo("IPBanEntity", "IPBanSetByUserID", typeof(System.Int32), false, true, false, false,  (int)IPBanFieldIndex.IPBanSetByUserID, 0, 0, 10);
			base.AddElementFieldInfo("IPBanEntity", "IPBanSetOn", typeof(System.DateTime), false, false, false, false,  (int)IPBanFieldIndex.IPBanSetOn, 0, 3, 23);
			base.AddElementFieldInfo("IPBanEntity", "Reason", typeof(System.String), false, false, false, false,  (int)IPBanFieldIndex.Reason, 1073741823, 0, 0);
		}
		/// <summary>Inits MessageEntity's FieldInfo objects</summary>
		private void InitMessageEntityInfos()
		{
			base.AddElementFieldInfo("MessageEntity", "MessageID", typeof(System.Int32), true, false, true, false,  (int)MessageFieldIndex.MessageID, 0, 0, 10);
			base.AddElementFieldInfo("MessageEntity", "PostingDate", typeof(System.DateTime), false, false, false, false,  (int)MessageFieldIndex.PostingDate, 0, 3, 23);
			base.AddElementFieldInfo("MessageEntity", "PostedByUserID", typeof(System.Int32), false, true, false, false,  (int)MessageFieldIndex.PostedByUserID, 0, 0, 10);
			base.AddElementFieldInfo("MessageEntity", "ThreadID", typeof(System.Int32), false, true, false, false,  (int)MessageFieldIndex.ThreadID, 0, 0, 10);
			base.AddElementFieldInfo("MessageEntity", "PostedFromIP", typeof(System.String), false, false, false, false,  (int)MessageFieldIndex.PostedFromIP, 25, 0, 0);
			base.AddElementFieldInfo("MessageEntity", "ChangeTrackerStamp", typeof(System.Byte[]), false, false, true, false,  (int)MessageFieldIndex.ChangeTrackerStamp, 8, 0, 0);
			base.AddElementFieldInfo("MessageEntity", "MessageText", typeof(System.String), false, false, false, true,  (int)MessageFieldIndex.MessageText, 1073741823, 0, 0);
			base.AddElementFieldInfo("MessageEntity", "MessageTextAsHTML", typeof(System.String), false, false, false, true,  (int)MessageFieldIndex.MessageTextAsHTML, 1073741823, 0, 0);
			base.AddElementFieldInfo("MessageEntity", "MessageTextAsXml", typeof(System.String), false, false, false, true,  (int)MessageFieldIndex.MessageTextAsXml, 1073741823, 0, 0);
		}
		/// <summary>Inits RoleEntity's FieldInfo objects</summary>
		private void InitRoleEntityInfos()
		{
			base.AddElementFieldInfo("RoleEntity", "RoleID", typeof(System.Int32), true, false, true, false,  (int)RoleFieldIndex.RoleID, 0, 0, 10);
			base.AddElementFieldInfo("RoleEntity", "RoleDescription", typeof(System.String), false, false, false, false,  (int)RoleFieldIndex.RoleDescription, 50, 0, 0);
		}
		/// <summary>Inits RoleAuditActionEntity's FieldInfo objects</summary>
		private void InitRoleAuditActionEntityInfos()
		{
			base.AddElementFieldInfo("RoleAuditActionEntity", "AuditActionID", typeof(System.Int32), true, true, false, false,  (int)RoleAuditActionFieldIndex.AuditActionID, 0, 0, 10);
			base.AddElementFieldInfo("RoleAuditActionEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)RoleAuditActionFieldIndex.RoleID, 0, 0, 10);
		}
		/// <summary>Inits RoleSystemActionRightEntity's FieldInfo objects</summary>
		private void InitRoleSystemActionRightEntityInfos()
		{
			base.AddElementFieldInfo("RoleSystemActionRightEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)RoleSystemActionRightFieldIndex.RoleID, 0, 0, 10);
			base.AddElementFieldInfo("RoleSystemActionRightEntity", "ActionRightID", typeof(System.Int32), true, true, false, false,  (int)RoleSystemActionRightFieldIndex.ActionRightID, 0, 0, 10);
		}
		/// <summary>Inits RoleUserEntity's FieldInfo objects</summary>
		private void InitRoleUserEntityInfos()
		{
			base.AddElementFieldInfo("RoleUserEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)RoleUserFieldIndex.RoleID, 0, 0, 10);
			base.AddElementFieldInfo("RoleUserEntity", "UserID", typeof(System.Int32), true, true, false, false,  (int)RoleUserFieldIndex.UserID, 0, 0, 10);
		}
		/// <summary>Inits SectionEntity's FieldInfo objects</summary>
		private void InitSectionEntityInfos()
		{
			base.AddElementFieldInfo("SectionEntity", "SectionID", typeof(System.Int32), true, false, true, false,  (int)SectionFieldIndex.SectionID, 0, 0, 10);
			base.AddElementFieldInfo("SectionEntity", "SectionName", typeof(System.String), false, false, false, false,  (int)SectionFieldIndex.SectionName, 50, 0, 0);
			base.AddElementFieldInfo("SectionEntity", "SectionDescription", typeof(System.String), false, false, false, false,  (int)SectionFieldIndex.SectionDescription, 250, 0, 0);
			base.AddElementFieldInfo("SectionEntity", "OrderNo", typeof(System.Int16), false, false, false, false,  (int)SectionFieldIndex.OrderNo, 0, 0, 5);
		}
		/// <summary>Inits SupportQueueEntity's FieldInfo objects</summary>
		private void InitSupportQueueEntityInfos()
		{
			base.AddElementFieldInfo("SupportQueueEntity", "QueueID", typeof(System.Int32), true, false, true, false,  (int)SupportQueueFieldIndex.QueueID, 0, 0, 10);
			base.AddElementFieldInfo("SupportQueueEntity", "QueueName", typeof(System.String), false, false, false, true,  (int)SupportQueueFieldIndex.QueueName, 50, 0, 0);
			base.AddElementFieldInfo("SupportQueueEntity", "QueueDescription", typeof(System.String), false, false, false, true,  (int)SupportQueueFieldIndex.QueueDescription, 250, 0, 0);
			base.AddElementFieldInfo("SupportQueueEntity", "OrderNo", typeof(System.Int16), false, false, false, false,  (int)SupportQueueFieldIndex.OrderNo, 0, 0, 5);
		}
		/// <summary>Inits SupportQueueThreadEntity's FieldInfo objects</summary>
		private void InitSupportQueueThreadEntityInfos()
		{
			base.AddElementFieldInfo("SupportQueueThreadEntity", "QueueID", typeof(System.Int32), true, true, false, false,  (int)SupportQueueThreadFieldIndex.QueueID, 0, 0, 10);
			base.AddElementFieldInfo("SupportQueueThreadEntity", "ThreadID", typeof(System.Int32), true, true, false, false,  (int)SupportQueueThreadFieldIndex.ThreadID, 0, 0, 10);
			base.AddElementFieldInfo("SupportQueueThreadEntity", "PlacedInQueueByUserID", typeof(System.Int32), false, true, false, false,  (int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, 0, 0, 10);
			base.AddElementFieldInfo("SupportQueueThreadEntity", "PlacedInQueueOn", typeof(System.DateTime), false, false, false, false,  (int)SupportQueueThreadFieldIndex.PlacedInQueueOn, 0, 3, 23);
			base.AddElementFieldInfo("SupportQueueThreadEntity", "ClaimedByUserID", typeof(Nullable<System.Int32>), false, true, false, true,  (int)SupportQueueThreadFieldIndex.ClaimedByUserID, 0, 0, 10);
			base.AddElementFieldInfo("SupportQueueThreadEntity", "ClaimedOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)SupportQueueThreadFieldIndex.ClaimedOn, 0, 3, 23);
		}
		/// <summary>Inits SystemDataEntity's FieldInfo objects</summary>
		private void InitSystemDataEntityInfos()
		{
			base.AddElementFieldInfo("SystemDataEntity", "ID", typeof(System.Int32), true, false, true, false,  (int)SystemDataFieldIndex.ID, 0, 0, 10);
			base.AddElementFieldInfo("SystemDataEntity", "DefaultRoleNewUser", typeof(System.Int32), false, true, false, false,  (int)SystemDataFieldIndex.DefaultRoleNewUser, 0, 0, 10);
			base.AddElementFieldInfo("SystemDataEntity", "AnonymousRole", typeof(System.Int32), false, true, false, false,  (int)SystemDataFieldIndex.AnonymousRole, 0, 0, 10);
			base.AddElementFieldInfo("SystemDataEntity", "DefaultUserTitleNewUser", typeof(System.Int32), false, false, false, false,  (int)SystemDataFieldIndex.DefaultUserTitleNewUser, 0, 0, 10);
			base.AddElementFieldInfo("SystemDataEntity", "HoursThresholdForActiveThreads", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.HoursThresholdForActiveThreads, 0, 0, 5);
			base.AddElementFieldInfo("SystemDataEntity", "PageSizeSearchResults", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.PageSizeSearchResults, 0, 0, 5);
			base.AddElementFieldInfo("SystemDataEntity", "MinNumberOfThreadsToFetch", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, 0, 0, 5);
			base.AddElementFieldInfo("SystemDataEntity", "MinNumberOfNonStickyVisibleThreads", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, 0, 0, 5);
			base.AddElementFieldInfo("SystemDataEntity", "SendReplyNotifications", typeof(System.Boolean), false, false, false, false,  (int)SystemDataFieldIndex.SendReplyNotifications, 0, 0, 1);
		}
		/// <summary>Inits ThreadEntity's FieldInfo objects</summary>
		private void InitThreadEntityInfos()
		{
			base.AddElementFieldInfo("ThreadEntity", "ThreadID", typeof(System.Int32), true, false, true, false,  (int)ThreadFieldIndex.ThreadID, 0, 0, 10);
			base.AddElementFieldInfo("ThreadEntity", "ForumID", typeof(System.Int32), false, true, false, false,  (int)ThreadFieldIndex.ForumID, 0, 0, 10);
			base.AddElementFieldInfo("ThreadEntity", "Subject", typeof(System.String), false, false, false, false,  (int)ThreadFieldIndex.Subject, 250, 0, 0);
			base.AddElementFieldInfo("ThreadEntity", "StartedByUserID", typeof(System.Int32), false, true, false, false,  (int)ThreadFieldIndex.StartedByUserID, 0, 0, 10);
			base.AddElementFieldInfo("ThreadEntity", "ThreadLastPostingDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ThreadFieldIndex.ThreadLastPostingDate, 0, 3, 23);
			base.AddElementFieldInfo("ThreadEntity", "IsSticky", typeof(System.Boolean), false, false, false, false,  (int)ThreadFieldIndex.IsSticky, 0, 0, 1);
			base.AddElementFieldInfo("ThreadEntity", "IsClosed", typeof(System.Boolean), false, false, false, false,  (int)ThreadFieldIndex.IsClosed, 0, 0, 1);
			base.AddElementFieldInfo("ThreadEntity", "MarkedAsDone", typeof(System.Boolean), false, false, false, false,  (int)ThreadFieldIndex.MarkedAsDone, 0, 0, 1);
			base.AddElementFieldInfo("ThreadEntity", "NumberOfViews", typeof(Nullable<System.Int32>), false, false, false, true,  (int)ThreadFieldIndex.NumberOfViews, 0, 0, 10);
			base.AddElementFieldInfo("ThreadEntity", "Memo", typeof(System.String), false, false, false, true,  (int)ThreadFieldIndex.Memo, 1073741823, 0, 0);
		}
		/// <summary>Inits ThreadSubscriptionEntity's FieldInfo objects</summary>
		private void InitThreadSubscriptionEntityInfos()
		{
			base.AddElementFieldInfo("ThreadSubscriptionEntity", "UserID", typeof(System.Int32), true, true, false, false,  (int)ThreadSubscriptionFieldIndex.UserID, 0, 0, 10);
			base.AddElementFieldInfo("ThreadSubscriptionEntity", "ThreadID", typeof(System.Int32), true, true, false, false,  (int)ThreadSubscriptionFieldIndex.ThreadID, 0, 0, 10);
		}
		/// <summary>Inits UserEntity's FieldInfo objects</summary>
		private void InitUserEntityInfos()
		{
			base.AddElementFieldInfo("UserEntity", "UserID", typeof(System.Int32), true, false, true, false,  (int)UserFieldIndex.UserID, 0, 0, 10);
			base.AddElementFieldInfo("UserEntity", "NickName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.NickName, 20, 0, 0);
			base.AddElementFieldInfo("UserEntity", "Password", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Password, 30, 0, 0);
			base.AddElementFieldInfo("UserEntity", "IsBanned", typeof(System.Boolean), false, false, false, false,  (int)UserFieldIndex.IsBanned, 0, 0, 1);
			base.AddElementFieldInfo("UserEntity", "IPNumber", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.IPNumber, 25, 0, 0);
			base.AddElementFieldInfo("UserEntity", "Signature", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Signature, 250, 0, 0);
			base.AddElementFieldInfo("UserEntity", "IconURL", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.IconURL, 250, 0, 0);
			base.AddElementFieldInfo("UserEntity", "EmailAddress", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.EmailAddress, 200, 0, 0);
			base.AddElementFieldInfo("UserEntity", "UserTitleID", typeof(System.Int32), false, true, false, false,  (int)UserFieldIndex.UserTitleID, 0, 0, 10);
			base.AddElementFieldInfo("UserEntity", "DateOfBirth", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.DateOfBirth, 0, 3, 23);
			base.AddElementFieldInfo("UserEntity", "Occupation", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Occupation, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "Location", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Location, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "Website", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Website, 200, 0, 0);
			base.AddElementFieldInfo("UserEntity", "SignatureAsHTML", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.SignatureAsHTML, 1024, 0, 0);
			base.AddElementFieldInfo("UserEntity", "JoinDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.JoinDate, 0, 3, 23);
			base.AddElementFieldInfo("UserEntity", "AmountOfPostings", typeof(Nullable<System.Int32>), false, false, false, true,  (int)UserFieldIndex.AmountOfPostings, 0, 0, 10);
			base.AddElementFieldInfo("UserEntity", "EmailAddressIsPublic", typeof(Nullable<System.Boolean>), false, false, false, true,  (int)UserFieldIndex.EmailAddressIsPublic, 0, 0, 1);
			base.AddElementFieldInfo("UserEntity", "LastVisitedDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.LastVisitedDate, 0, 3, 23);
			base.AddElementFieldInfo("UserEntity", "AutoSubscribeToThread", typeof(System.Boolean), false, false, false, true,  (int)UserFieldIndex.AutoSubscribeToThread, 0, 0, 1);
			base.AddElementFieldInfo("UserEntity", "DefaultNumberOfMessagesPerPage", typeof(System.Int16), false, false, false, true,  (int)UserFieldIndex.DefaultNumberOfMessagesPerPage, 0, 0, 5);
		}
		/// <summary>Inits UserTitleEntity's FieldInfo objects</summary>
		private void InitUserTitleEntityInfos()
		{
			base.AddElementFieldInfo("UserTitleEntity", "UserTitleID", typeof(System.Int32), true, false, true, false,  (int)UserTitleFieldIndex.UserTitleID, 0, 0, 10);
			base.AddElementFieldInfo("UserTitleEntity", "UserTitleDescription", typeof(System.String), false, false, false, false,  (int)UserTitleFieldIndex.UserTitleDescription, 50, 0, 0);
		}
		
	}
}




