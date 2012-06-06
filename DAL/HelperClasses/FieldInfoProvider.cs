///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
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
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

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
			this.InitClass( (23 + 0));
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

			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits ActionRightEntity's FieldInfo objects</summary>
		private void InitActionRightEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ActionRightFieldIndex), "ActionRightEntity");
			this.AddElementFieldInfo("ActionRightEntity", "ActionRightID", typeof(System.Int32), true, false, false, false,  (int)ActionRightFieldIndex.ActionRightID, 0, 0, 10);
			this.AddElementFieldInfo("ActionRightEntity", "ActionRightDescription", typeof(System.String), false, false, false, false,  (int)ActionRightFieldIndex.ActionRightDescription, 50, 0, 0);
			this.AddElementFieldInfo("ActionRightEntity", "AppliesToForum", typeof(System.Boolean), false, false, false, false,  (int)ActionRightFieldIndex.AppliesToForum, 0, 0, 0);
			this.AddElementFieldInfo("ActionRightEntity", "AppliesToSystem", typeof(System.Boolean), false, false, false, false,  (int)ActionRightFieldIndex.AppliesToSystem, 0, 0, 0);
		}
		/// <summary>Inits AttachmentEntity's FieldInfo objects</summary>
		private void InitAttachmentEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AttachmentFieldIndex), "AttachmentEntity");
			this.AddElementFieldInfo("AttachmentEntity", "AttachmentID", typeof(System.Int32), true, false, true, false,  (int)AttachmentFieldIndex.AttachmentID, 0, 0, 10);
			this.AddElementFieldInfo("AttachmentEntity", "MessageID", typeof(System.Int32), false, true, false, false,  (int)AttachmentFieldIndex.MessageID, 0, 0, 10);
			this.AddElementFieldInfo("AttachmentEntity", "Filename", typeof(System.String), false, false, false, false,  (int)AttachmentFieldIndex.Filename, 255, 0, 0);
			this.AddElementFieldInfo("AttachmentEntity", "Approved", typeof(System.Boolean), false, false, false, false,  (int)AttachmentFieldIndex.Approved, 0, 0, 0);
			this.AddElementFieldInfo("AttachmentEntity", "Filecontents", typeof(System.Byte[]), false, false, false, false,  (int)AttachmentFieldIndex.Filecontents, 2147483647, 0, 0);
			this.AddElementFieldInfo("AttachmentEntity", "Filesize", typeof(System.Int32), false, false, false, false,  (int)AttachmentFieldIndex.Filesize, 0, 0, 10);
			this.AddElementFieldInfo("AttachmentEntity", "AddedOn", typeof(System.DateTime), false, false, false, false,  (int)AttachmentFieldIndex.AddedOn, 0, 0, 0);
		}
		/// <summary>Inits AuditActionEntity's FieldInfo objects</summary>
		private void InitAuditActionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AuditActionFieldIndex), "AuditActionEntity");
			this.AddElementFieldInfo("AuditActionEntity", "AuditActionID", typeof(System.Int32), true, false, false, false,  (int)AuditActionFieldIndex.AuditActionID, 0, 0, 10);
			this.AddElementFieldInfo("AuditActionEntity", "AuditActionDescription", typeof(System.String), false, false, false, false,  (int)AuditActionFieldIndex.AuditActionDescription, 50, 0, 0);
		}
		/// <summary>Inits AuditDataCoreEntity's FieldInfo objects</summary>
		private void InitAuditDataCoreEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AuditDataCoreFieldIndex), "AuditDataCoreEntity");
			this.AddElementFieldInfo("AuditDataCoreEntity", "AuditDataID", typeof(System.Int32), true, false, true, false,  (int)AuditDataCoreFieldIndex.AuditDataID, 0, 0, 10);
			this.AddElementFieldInfo("AuditDataCoreEntity", "AuditActionID", typeof(System.Int32), false, true, false, false,  (int)AuditDataCoreFieldIndex.AuditActionID, 0, 0, 10);
			this.AddElementFieldInfo("AuditDataCoreEntity", "UserID", typeof(System.Int32), false, true, false, false,  (int)AuditDataCoreFieldIndex.UserID, 0, 0, 10);
			this.AddElementFieldInfo("AuditDataCoreEntity", "AuditedOn", typeof(System.DateTime), false, false, false, false,  (int)AuditDataCoreFieldIndex.AuditedOn, 0, 0, 0);
		}
		/// <summary>Inits AuditDataMessageRelatedEntity's FieldInfo objects</summary>
		private void InitAuditDataMessageRelatedEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AuditDataMessageRelatedFieldIndex), "AuditDataMessageRelatedEntity");
			this.AddElementFieldInfo("AuditDataMessageRelatedEntity", "AuditDataID", typeof(System.Int32), true, false, true, false,  (int)AuditDataMessageRelatedFieldIndex.AuditDataID, 0, 0, 10);
			this.AddElementFieldInfo("AuditDataMessageRelatedEntity", "MessageID", typeof(System.Int32), false, true, false, false,  (int)AuditDataMessageRelatedFieldIndex.MessageID, 0, 0, 10);
		}
		/// <summary>Inits AuditDataThreadRelatedEntity's FieldInfo objects</summary>
		private void InitAuditDataThreadRelatedEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AuditDataThreadRelatedFieldIndex), "AuditDataThreadRelatedEntity");
			this.AddElementFieldInfo("AuditDataThreadRelatedEntity", "AuditDataID", typeof(System.Int32), true, false, true, false,  (int)AuditDataThreadRelatedFieldIndex.AuditDataID, 0, 0, 10);
			this.AddElementFieldInfo("AuditDataThreadRelatedEntity", "ThreadID", typeof(System.Int32), false, true, false, false,  (int)AuditDataThreadRelatedFieldIndex.ThreadID, 0, 0, 10);
		}
		/// <summary>Inits BookmarkEntity's FieldInfo objects</summary>
		private void InitBookmarkEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(BookmarkFieldIndex), "BookmarkEntity");
			this.AddElementFieldInfo("BookmarkEntity", "ThreadID", typeof(System.Int32), true, true, false, false,  (int)BookmarkFieldIndex.ThreadID, 0, 0, 10);
			this.AddElementFieldInfo("BookmarkEntity", "UserID", typeof(System.Int32), true, true, false, false,  (int)BookmarkFieldIndex.UserID, 0, 0, 10);
		}
		/// <summary>Inits ForumEntity's FieldInfo objects</summary>
		private void InitForumEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ForumFieldIndex), "ForumEntity");
			this.AddElementFieldInfo("ForumEntity", "ForumID", typeof(System.Int32), true, false, true, false,  (int)ForumFieldIndex.ForumID, 0, 0, 10);
			this.AddElementFieldInfo("ForumEntity", "SectionID", typeof(System.Int32), false, true, false, false,  (int)ForumFieldIndex.SectionID, 0, 0, 10);
			this.AddElementFieldInfo("ForumEntity", "ForumName", typeof(System.String), false, false, false, false,  (int)ForumFieldIndex.ForumName, 50, 0, 0);
			this.AddElementFieldInfo("ForumEntity", "ForumDescription", typeof(System.String), false, false, false, false,  (int)ForumFieldIndex.ForumDescription, 250, 0, 0);
			this.AddElementFieldInfo("ForumEntity", "ForumLastPostingDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ForumFieldIndex.ForumLastPostingDate, 0, 0, 0);
			this.AddElementFieldInfo("ForumEntity", "HasRSSFeed", typeof(System.Boolean), false, false, false, false,  (int)ForumFieldIndex.HasRSSFeed, 0, 0, 0);
			this.AddElementFieldInfo("ForumEntity", "DefaultSupportQueueID", typeof(Nullable<System.Int32>), false, true, false, true,  (int)ForumFieldIndex.DefaultSupportQueueID, 0, 0, 10);
			this.AddElementFieldInfo("ForumEntity", "DefaultThreadListInterval", typeof(System.Byte), false, false, false, false,  (int)ForumFieldIndex.DefaultThreadListInterval, 0, 0, 3);
			this.AddElementFieldInfo("ForumEntity", "OrderNo", typeof(System.Int16), false, false, false, false,  (int)ForumFieldIndex.OrderNo, 0, 0, 5);
			this.AddElementFieldInfo("ForumEntity", "MaxAttachmentSize", typeof(System.Int32), false, false, false, true,  (int)ForumFieldIndex.MaxAttachmentSize, 0, 0, 10);
			this.AddElementFieldInfo("ForumEntity", "MaxNoOfAttachmentsPerMessage", typeof(System.Int16), false, false, false, true,  (int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, 0, 0, 5);
			this.AddElementFieldInfo("ForumEntity", "NewThreadWelcomeText", typeof(System.String), false, false, false, true,  (int)ForumFieldIndex.NewThreadWelcomeText, 1073741823, 0, 0);
			this.AddElementFieldInfo("ForumEntity", "NewThreadWelcomeTextAsHTML", typeof(System.String), false, false, false, true,  (int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, 1073741823, 0, 0);
		}
		/// <summary>Inits ForumRoleForumActionRightEntity's FieldInfo objects</summary>
		private void InitForumRoleForumActionRightEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ForumRoleForumActionRightFieldIndex), "ForumRoleForumActionRightEntity");
			this.AddElementFieldInfo("ForumRoleForumActionRightEntity", "ForumID", typeof(System.Int32), true, true, false, false,  (int)ForumRoleForumActionRightFieldIndex.ForumID, 0, 0, 10);
			this.AddElementFieldInfo("ForumRoleForumActionRightEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)ForumRoleForumActionRightFieldIndex.RoleID, 0, 0, 10);
			this.AddElementFieldInfo("ForumRoleForumActionRightEntity", "ActionRightID", typeof(System.Int32), true, true, false, false,  (int)ForumRoleForumActionRightFieldIndex.ActionRightID, 0, 0, 10);
		}
		/// <summary>Inits IPBanEntity's FieldInfo objects</summary>
		private void InitIPBanEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(IPBanFieldIndex), "IPBanEntity");
			this.AddElementFieldInfo("IPBanEntity", "IPBanID", typeof(System.Int32), true, false, true, false,  (int)IPBanFieldIndex.IPBanID, 0, 0, 10);
			this.AddElementFieldInfo("IPBanEntity", "IPSegment1", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment1, 0, 0, 3);
			this.AddElementFieldInfo("IPBanEntity", "IPSegment2", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment2, 0, 0, 3);
			this.AddElementFieldInfo("IPBanEntity", "IPSegment3", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment3, 0, 0, 3);
			this.AddElementFieldInfo("IPBanEntity", "IPSegment4", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.IPSegment4, 0, 0, 3);
			this.AddElementFieldInfo("IPBanEntity", "Range", typeof(System.Byte), false, false, false, false,  (int)IPBanFieldIndex.Range, 0, 0, 3);
			this.AddElementFieldInfo("IPBanEntity", "IPBanSetByUserID", typeof(System.Int32), false, true, false, false,  (int)IPBanFieldIndex.IPBanSetByUserID, 0, 0, 10);
			this.AddElementFieldInfo("IPBanEntity", "IPBanSetOn", typeof(System.DateTime), false, false, false, false,  (int)IPBanFieldIndex.IPBanSetOn, 0, 0, 0);
			this.AddElementFieldInfo("IPBanEntity", "Reason", typeof(System.String), false, false, false, false,  (int)IPBanFieldIndex.Reason, 1073741823, 0, 0);
		}
		/// <summary>Inits MessageEntity's FieldInfo objects</summary>
		private void InitMessageEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(MessageFieldIndex), "MessageEntity");
			this.AddElementFieldInfo("MessageEntity", "MessageID", typeof(System.Int32), true, false, true, false,  (int)MessageFieldIndex.MessageID, 0, 0, 10);
			this.AddElementFieldInfo("MessageEntity", "PostingDate", typeof(System.DateTime), false, false, false, false,  (int)MessageFieldIndex.PostingDate, 0, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "PostedByUserID", typeof(System.Int32), false, true, false, false,  (int)MessageFieldIndex.PostedByUserID, 0, 0, 10);
			this.AddElementFieldInfo("MessageEntity", "ThreadID", typeof(System.Int32), false, true, false, false,  (int)MessageFieldIndex.ThreadID, 0, 0, 10);
			this.AddElementFieldInfo("MessageEntity", "PostedFromIP", typeof(System.String), false, false, false, false,  (int)MessageFieldIndex.PostedFromIP, 25, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "ChangeTrackerStamp", typeof(System.Byte[]), false, false, true, false,  (int)MessageFieldIndex.ChangeTrackerStamp, 8, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "MessageText", typeof(System.String), false, false, false, true,  (int)MessageFieldIndex.MessageText, 1073741823, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "MessageTextAsHTML", typeof(System.String), false, false, false, true,  (int)MessageFieldIndex.MessageTextAsHTML, 1073741823, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "MessageTextAsXml", typeof(System.String), false, false, false, true,  (int)MessageFieldIndex.MessageTextAsXml, 1073741823, 0, 0);
		}
		/// <summary>Inits RoleEntity's FieldInfo objects</summary>
		private void InitRoleEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RoleFieldIndex), "RoleEntity");
			this.AddElementFieldInfo("RoleEntity", "RoleID", typeof(System.Int32), true, false, true, false,  (int)RoleFieldIndex.RoleID, 0, 0, 10);
			this.AddElementFieldInfo("RoleEntity", "RoleDescription", typeof(System.String), false, false, false, false,  (int)RoleFieldIndex.RoleDescription, 50, 0, 0);
		}
		/// <summary>Inits RoleAuditActionEntity's FieldInfo objects</summary>
		private void InitRoleAuditActionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RoleAuditActionFieldIndex), "RoleAuditActionEntity");
			this.AddElementFieldInfo("RoleAuditActionEntity", "AuditActionID", typeof(System.Int32), true, true, false, false,  (int)RoleAuditActionFieldIndex.AuditActionID, 0, 0, 10);
			this.AddElementFieldInfo("RoleAuditActionEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)RoleAuditActionFieldIndex.RoleID, 0, 0, 10);
		}
		/// <summary>Inits RoleSystemActionRightEntity's FieldInfo objects</summary>
		private void InitRoleSystemActionRightEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RoleSystemActionRightFieldIndex), "RoleSystemActionRightEntity");
			this.AddElementFieldInfo("RoleSystemActionRightEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)RoleSystemActionRightFieldIndex.RoleID, 0, 0, 10);
			this.AddElementFieldInfo("RoleSystemActionRightEntity", "ActionRightID", typeof(System.Int32), true, true, false, false,  (int)RoleSystemActionRightFieldIndex.ActionRightID, 0, 0, 10);
		}
		/// <summary>Inits RoleUserEntity's FieldInfo objects</summary>
		private void InitRoleUserEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RoleUserFieldIndex), "RoleUserEntity");
			this.AddElementFieldInfo("RoleUserEntity", "RoleID", typeof(System.Int32), true, true, false, false,  (int)RoleUserFieldIndex.RoleID, 0, 0, 10);
			this.AddElementFieldInfo("RoleUserEntity", "UserID", typeof(System.Int32), true, true, false, false,  (int)RoleUserFieldIndex.UserID, 0, 0, 10);
		}
		/// <summary>Inits SectionEntity's FieldInfo objects</summary>
		private void InitSectionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SectionFieldIndex), "SectionEntity");
			this.AddElementFieldInfo("SectionEntity", "SectionID", typeof(System.Int32), true, false, true, false,  (int)SectionFieldIndex.SectionID, 0, 0, 10);
			this.AddElementFieldInfo("SectionEntity", "SectionName", typeof(System.String), false, false, false, false,  (int)SectionFieldIndex.SectionName, 50, 0, 0);
			this.AddElementFieldInfo("SectionEntity", "SectionDescription", typeof(System.String), false, false, false, false,  (int)SectionFieldIndex.SectionDescription, 250, 0, 0);
			this.AddElementFieldInfo("SectionEntity", "OrderNo", typeof(System.Int16), false, false, false, false,  (int)SectionFieldIndex.OrderNo, 0, 0, 5);
		}
		/// <summary>Inits SupportQueueEntity's FieldInfo objects</summary>
		private void InitSupportQueueEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SupportQueueFieldIndex), "SupportQueueEntity");
			this.AddElementFieldInfo("SupportQueueEntity", "QueueID", typeof(System.Int32), true, false, true, false,  (int)SupportQueueFieldIndex.QueueID, 0, 0, 10);
			this.AddElementFieldInfo("SupportQueueEntity", "QueueName", typeof(System.String), false, false, false, false,  (int)SupportQueueFieldIndex.QueueName, 50, 0, 0);
			this.AddElementFieldInfo("SupportQueueEntity", "QueueDescription", typeof(System.String), false, false, false, false,  (int)SupportQueueFieldIndex.QueueDescription, 250, 0, 0);
			this.AddElementFieldInfo("SupportQueueEntity", "OrderNo", typeof(System.Int16), false, false, false, false,  (int)SupportQueueFieldIndex.OrderNo, 0, 0, 5);
		}
		/// <summary>Inits SupportQueueThreadEntity's FieldInfo objects</summary>
		private void InitSupportQueueThreadEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SupportQueueThreadFieldIndex), "SupportQueueThreadEntity");
			this.AddElementFieldInfo("SupportQueueThreadEntity", "QueueID", typeof(System.Int32), true, true, false, false,  (int)SupportQueueThreadFieldIndex.QueueID, 0, 0, 10);
			this.AddElementFieldInfo("SupportQueueThreadEntity", "ThreadID", typeof(System.Int32), true, true, false, false,  (int)SupportQueueThreadFieldIndex.ThreadID, 0, 0, 10);
			this.AddElementFieldInfo("SupportQueueThreadEntity", "PlacedInQueueByUserID", typeof(System.Int32), false, true, false, false,  (int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, 0, 0, 10);
			this.AddElementFieldInfo("SupportQueueThreadEntity", "PlacedInQueueOn", typeof(System.DateTime), false, false, false, false,  (int)SupportQueueThreadFieldIndex.PlacedInQueueOn, 0, 0, 0);
			this.AddElementFieldInfo("SupportQueueThreadEntity", "ClaimedByUserID", typeof(Nullable<System.Int32>), false, true, false, true,  (int)SupportQueueThreadFieldIndex.ClaimedByUserID, 0, 0, 10);
			this.AddElementFieldInfo("SupportQueueThreadEntity", "ClaimedOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)SupportQueueThreadFieldIndex.ClaimedOn, 0, 0, 0);
		}
		/// <summary>Inits SystemDataEntity's FieldInfo objects</summary>
		private void InitSystemDataEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SystemDataFieldIndex), "SystemDataEntity");
			this.AddElementFieldInfo("SystemDataEntity", "ID", typeof(System.Int32), true, false, true, false,  (int)SystemDataFieldIndex.ID, 0, 0, 10);
			this.AddElementFieldInfo("SystemDataEntity", "DefaultRoleNewUser", typeof(System.Int32), false, true, false, false,  (int)SystemDataFieldIndex.DefaultRoleNewUser, 0, 0, 10);
			this.AddElementFieldInfo("SystemDataEntity", "AnonymousRole", typeof(System.Int32), false, true, false, false,  (int)SystemDataFieldIndex.AnonymousRole, 0, 0, 10);
			this.AddElementFieldInfo("SystemDataEntity", "DefaultUserTitleNewUser", typeof(System.Int32), false, false, false, false,  (int)SystemDataFieldIndex.DefaultUserTitleNewUser, 0, 0, 10);
			this.AddElementFieldInfo("SystemDataEntity", "HoursThresholdForActiveThreads", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.HoursThresholdForActiveThreads, 0, 0, 5);
			this.AddElementFieldInfo("SystemDataEntity", "PageSizeSearchResults", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.PageSizeSearchResults, 0, 0, 5);
			this.AddElementFieldInfo("SystemDataEntity", "MinNumberOfThreadsToFetch", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, 0, 0, 5);
			this.AddElementFieldInfo("SystemDataEntity", "MinNumberOfNonStickyVisibleThreads", typeof(System.Int16), false, false, false, false,  (int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, 0, 0, 5);
			this.AddElementFieldInfo("SystemDataEntity", "SendReplyNotifications", typeof(System.Boolean), false, false, false, false,  (int)SystemDataFieldIndex.SendReplyNotifications, 0, 0, 0);
		}
		/// <summary>Inits ThreadEntity's FieldInfo objects</summary>
		private void InitThreadEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ThreadFieldIndex), "ThreadEntity");
			this.AddElementFieldInfo("ThreadEntity", "ThreadID", typeof(System.Int32), true, false, true, false,  (int)ThreadFieldIndex.ThreadID, 0, 0, 10);
			this.AddElementFieldInfo("ThreadEntity", "ForumID", typeof(System.Int32), false, true, false, false,  (int)ThreadFieldIndex.ForumID, 0, 0, 10);
			this.AddElementFieldInfo("ThreadEntity", "Subject", typeof(System.String), false, false, false, false,  (int)ThreadFieldIndex.Subject, 250, 0, 0);
			this.AddElementFieldInfo("ThreadEntity", "StartedByUserID", typeof(System.Int32), false, true, false, false,  (int)ThreadFieldIndex.StartedByUserID, 0, 0, 10);
			this.AddElementFieldInfo("ThreadEntity", "ThreadLastPostingDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ThreadFieldIndex.ThreadLastPostingDate, 0, 0, 0);
			this.AddElementFieldInfo("ThreadEntity", "IsSticky", typeof(System.Boolean), false, false, false, false,  (int)ThreadFieldIndex.IsSticky, 0, 0, 0);
			this.AddElementFieldInfo("ThreadEntity", "IsClosed", typeof(System.Boolean), false, false, false, false,  (int)ThreadFieldIndex.IsClosed, 0, 0, 0);
			this.AddElementFieldInfo("ThreadEntity", "MarkedAsDone", typeof(System.Boolean), false, false, false, false,  (int)ThreadFieldIndex.MarkedAsDone, 0, 0, 0);
			this.AddElementFieldInfo("ThreadEntity", "NumberOfViews", typeof(Nullable<System.Int32>), false, false, false, true,  (int)ThreadFieldIndex.NumberOfViews, 0, 0, 10);
			this.AddElementFieldInfo("ThreadEntity", "Memo", typeof(System.String), false, false, false, true,  (int)ThreadFieldIndex.Memo, 1073741823, 0, 0);
		}
		/// <summary>Inits ThreadSubscriptionEntity's FieldInfo objects</summary>
		private void InitThreadSubscriptionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ThreadSubscriptionFieldIndex), "ThreadSubscriptionEntity");
			this.AddElementFieldInfo("ThreadSubscriptionEntity", "UserID", typeof(System.Int32), true, true, false, false,  (int)ThreadSubscriptionFieldIndex.UserID, 0, 0, 10);
			this.AddElementFieldInfo("ThreadSubscriptionEntity", "ThreadID", typeof(System.Int32), true, true, false, false,  (int)ThreadSubscriptionFieldIndex.ThreadID, 0, 0, 10);
		}
		/// <summary>Inits UserEntity's FieldInfo objects</summary>
		private void InitUserEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserFieldIndex), "UserEntity");
			this.AddElementFieldInfo("UserEntity", "UserID", typeof(System.Int32), true, false, true, false,  (int)UserFieldIndex.UserID, 0, 0, 10);
			this.AddElementFieldInfo("UserEntity", "NickName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.NickName, 20, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Password", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Password, 30, 0, 0);
			this.AddElementFieldInfo("UserEntity", "IsBanned", typeof(System.Boolean), false, false, false, false,  (int)UserFieldIndex.IsBanned, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "IPNumber", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.IPNumber, 25, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Signature", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Signature, 250, 0, 0);
			this.AddElementFieldInfo("UserEntity", "IconURL", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.IconURL, 250, 0, 0);
			this.AddElementFieldInfo("UserEntity", "EmailAddress", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.EmailAddress, 200, 0, 0);
			this.AddElementFieldInfo("UserEntity", "UserTitleID", typeof(System.Int32), false, true, false, false,  (int)UserFieldIndex.UserTitleID, 0, 0, 10);
			this.AddElementFieldInfo("UserEntity", "DateOfBirth", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.DateOfBirth, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Occupation", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Occupation, 100, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Location", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Location, 100, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Website", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.Website, 200, 0, 0);
			this.AddElementFieldInfo("UserEntity", "SignatureAsHTML", typeof(System.String), false, false, false, true,  (int)UserFieldIndex.SignatureAsHTML, 1024, 0, 0);
			this.AddElementFieldInfo("UserEntity", "JoinDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.JoinDate, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "AmountOfPostings", typeof(Nullable<System.Int32>), false, false, false, true,  (int)UserFieldIndex.AmountOfPostings, 0, 0, 10);
			this.AddElementFieldInfo("UserEntity", "EmailAddressIsPublic", typeof(Nullable<System.Boolean>), false, false, false, true,  (int)UserFieldIndex.EmailAddressIsPublic, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "LastVisitedDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.LastVisitedDate, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "AutoSubscribeToThread", typeof(System.Boolean), false, false, false, true,  (int)UserFieldIndex.AutoSubscribeToThread, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "DefaultNumberOfMessagesPerPage", typeof(System.Int16), false, false, false, true,  (int)UserFieldIndex.DefaultNumberOfMessagesPerPage, 0, 0, 5);
		}
		/// <summary>Inits UserTitleEntity's FieldInfo objects</summary>
		private void InitUserTitleEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserTitleFieldIndex), "UserTitleEntity");
			this.AddElementFieldInfo("UserTitleEntity", "UserTitleID", typeof(System.Int32), true, false, true, false,  (int)UserTitleFieldIndex.UserTitleID, 0, 0, 10);
			this.AddElementFieldInfo("UserTitleEntity", "UserTitleDescription", typeof(System.String), false, false, false, false,  (int)UserTitleFieldIndex.UserTitleDescription, 50, 0, 0);
		}
		
	}
}




