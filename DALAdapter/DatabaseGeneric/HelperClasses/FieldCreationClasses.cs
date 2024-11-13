﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.11.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.HelperClasses
{
	/// <summary>Field Creation Class for entity ActionRightEntity</summary>
	public partial class ActionRightFields
	{
		/// <summary>Creates a new ActionRightEntity.ActionRightID field instance</summary>
		public static EntityField2 ActionRightID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ActionRightFieldIndex.ActionRightID); }}
		/// <summary>Creates a new ActionRightEntity.ActionRightDescription field instance</summary>
		public static EntityField2 ActionRightDescription { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ActionRightFieldIndex.ActionRightDescription); }}
		/// <summary>Creates a new ActionRightEntity.AppliesToForum field instance</summary>
		public static EntityField2 AppliesToForum { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ActionRightFieldIndex.AppliesToForum); }}
		/// <summary>Creates a new ActionRightEntity.AppliesToSystem field instance</summary>
		public static EntityField2 AppliesToSystem { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ActionRightFieldIndex.AppliesToSystem); }}
	}

	/// <summary>Field Creation Class for entity AttachmentEntity</summary>
	public partial class AttachmentFields
	{
		/// <summary>Creates a new AttachmentEntity.AttachmentID field instance</summary>
		public static EntityField2 AttachmentID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AttachmentFieldIndex.AttachmentID); }}
		/// <summary>Creates a new AttachmentEntity.MessageID field instance</summary>
		public static EntityField2 MessageID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AttachmentFieldIndex.MessageID); }}
		/// <summary>Creates a new AttachmentEntity.Filename field instance</summary>
		public static EntityField2 Filename { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AttachmentFieldIndex.Filename); }}
		/// <summary>Creates a new AttachmentEntity.Approved field instance</summary>
		public static EntityField2 Approved { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AttachmentFieldIndex.Approved); }}
		/// <summary>Creates a new AttachmentEntity.Filecontents field instance</summary>
		public static EntityField2 Filecontents { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AttachmentFieldIndex.Filecontents); }}
		/// <summary>Creates a new AttachmentEntity.Filesize field instance</summary>
		public static EntityField2 Filesize { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AttachmentFieldIndex.Filesize); }}
		/// <summary>Creates a new AttachmentEntity.AddedOn field instance</summary>
		public static EntityField2 AddedOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AttachmentFieldIndex.AddedOn); }}
	}

	/// <summary>Field Creation Class for entity AuditActionEntity</summary>
	public partial class AuditActionFields
	{
		/// <summary>Creates a new AuditActionEntity.AuditActionID field instance</summary>
		public static EntityField2 AuditActionID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditActionFieldIndex.AuditActionID); }}
		/// <summary>Creates a new AuditActionEntity.AuditActionDescription field instance</summary>
		public static EntityField2 AuditActionDescription { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditActionFieldIndex.AuditActionDescription); }}
	}

	/// <summary>Field Creation Class for entity AuditDataCoreEntity</summary>
	public partial class AuditDataCoreFields
	{
		/// <summary>Creates a new AuditDataCoreEntity.AuditDataID field instance</summary>
		public static EntityField2 AuditDataID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataCoreFieldIndex.AuditDataID); }}
		/// <summary>Creates a new AuditDataCoreEntity.AuditActionID field instance</summary>
		public static EntityField2 AuditActionID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataCoreFieldIndex.AuditActionID); }}
		/// <summary>Creates a new AuditDataCoreEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataCoreFieldIndex.UserID); }}
		/// <summary>Creates a new AuditDataCoreEntity.AuditedOn field instance</summary>
		public static EntityField2 AuditedOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataCoreFieldIndex.AuditedOn); }}
	}

	/// <summary>Field Creation Class for entity AuditDataMessageRelatedEntity</summary>
	public partial class AuditDataMessageRelatedFields
	{
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditDataID field instance</summary>
		public static EntityField2 AuditDataID_AuditDataCore { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataMessageRelatedFieldIndex.AuditDataID_AuditDataCore); }}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditActionID field instance</summary>
		public static EntityField2 AuditActionID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataMessageRelatedFieldIndex.AuditActionID); }}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataMessageRelatedFieldIndex.UserID); }}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditedOn field instance</summary>
		public static EntityField2 AuditedOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataMessageRelatedFieldIndex.AuditedOn); }}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditDataID field instance</summary>
		public static EntityField2 AuditDataID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataMessageRelatedFieldIndex.AuditDataID); }}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.MessageID field instance</summary>
		public static EntityField2 MessageID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataMessageRelatedFieldIndex.MessageID); }}
	}

	/// <summary>Field Creation Class for entity AuditDataThreadRelatedEntity</summary>
	public partial class AuditDataThreadRelatedFields
	{
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditDataID field instance</summary>
		public static EntityField2 AuditDataID_AuditDataCore { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataThreadRelatedFieldIndex.AuditDataID_AuditDataCore); }}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditActionID field instance</summary>
		public static EntityField2 AuditActionID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataThreadRelatedFieldIndex.AuditActionID); }}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataThreadRelatedFieldIndex.UserID); }}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditedOn field instance</summary>
		public static EntityField2 AuditedOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataThreadRelatedFieldIndex.AuditedOn); }}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditDataID field instance</summary>
		public static EntityField2 AuditDataID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataThreadRelatedFieldIndex.AuditDataID); }}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.ThreadID field instance</summary>
		public static EntityField2 ThreadID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(AuditDataThreadRelatedFieldIndex.ThreadID); }}
	}

	/// <summary>Field Creation Class for entity BookmarkEntity</summary>
	public partial class BookmarkFields
	{
		/// <summary>Creates a new BookmarkEntity.ThreadID field instance</summary>
		public static EntityField2 ThreadID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(BookmarkFieldIndex.ThreadID); }}
		/// <summary>Creates a new BookmarkEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(BookmarkFieldIndex.UserID); }}
	}

	/// <summary>Field Creation Class for entity ForumEntity</summary>
	public partial class ForumFields
	{
		/// <summary>Creates a new ForumEntity.ForumID field instance</summary>
		public static EntityField2 ForumID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.ForumID); }}
		/// <summary>Creates a new ForumEntity.SectionID field instance</summary>
		public static EntityField2 SectionID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.SectionID); }}
		/// <summary>Creates a new ForumEntity.ForumName field instance</summary>
		public static EntityField2 ForumName { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.ForumName); }}
		/// <summary>Creates a new ForumEntity.ForumDescription field instance</summary>
		public static EntityField2 ForumDescription { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.ForumDescription); }}
		/// <summary>Creates a new ForumEntity.ForumLastPostingDate field instance</summary>
		public static EntityField2 ForumLastPostingDate { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.ForumLastPostingDate); }}
		/// <summary>Creates a new ForumEntity.HasRSSFeed field instance</summary>
		public static EntityField2 HasRSSFeed { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.HasRSSFeed); }}
		/// <summary>Creates a new ForumEntity.DefaultSupportQueueID field instance</summary>
		public static EntityField2 DefaultSupportQueueID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.DefaultSupportQueueID); }}
		/// <summary>Creates a new ForumEntity.OrderNo field instance</summary>
		public static EntityField2 OrderNo { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.OrderNo); }}
		/// <summary>Creates a new ForumEntity.MaxAttachmentSize field instance</summary>
		public static EntityField2 MaxAttachmentSize { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.MaxAttachmentSize); }}
		/// <summary>Creates a new ForumEntity.MaxNoOfAttachmentsPerMessage field instance</summary>
		public static EntityField2 MaxNoOfAttachmentsPerMessage { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.MaxNoOfAttachmentsPerMessage); }}
		/// <summary>Creates a new ForumEntity.NewThreadWelcomeText field instance</summary>
		public static EntityField2 NewThreadWelcomeText { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.NewThreadWelcomeText); }}
		/// <summary>Creates a new ForumEntity.NewThreadWelcomeTextAsHTML field instance</summary>
		public static EntityField2 NewThreadWelcomeTextAsHTML { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumFieldIndex.NewThreadWelcomeTextAsHTML); }}
	}

	/// <summary>Field Creation Class for entity ForumRoleForumActionRightEntity</summary>
	public partial class ForumRoleForumActionRightFields
	{
		/// <summary>Creates a new ForumRoleForumActionRightEntity.ForumID field instance</summary>
		public static EntityField2 ForumID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumRoleForumActionRightFieldIndex.ForumID); }}
		/// <summary>Creates a new ForumRoleForumActionRightEntity.RoleID field instance</summary>
		public static EntityField2 RoleID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumRoleForumActionRightFieldIndex.RoleID); }}
		/// <summary>Creates a new ForumRoleForumActionRightEntity.ActionRightID field instance</summary>
		public static EntityField2 ActionRightID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ForumRoleForumActionRightFieldIndex.ActionRightID); }}
	}

	/// <summary>Field Creation Class for entity IPBanEntity</summary>
	public partial class IPBanFields
	{
		/// <summary>Creates a new IPBanEntity.IPBanID field instance</summary>
		public static EntityField2 IPBanID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.IPBanID); }}
		/// <summary>Creates a new IPBanEntity.IPSegment1 field instance</summary>
		public static EntityField2 IPSegment1 { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.IPSegment1); }}
		/// <summary>Creates a new IPBanEntity.IPSegment2 field instance</summary>
		public static EntityField2 IPSegment2 { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.IPSegment2); }}
		/// <summary>Creates a new IPBanEntity.IPSegment3 field instance</summary>
		public static EntityField2 IPSegment3 { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.IPSegment3); }}
		/// <summary>Creates a new IPBanEntity.IPSegment4 field instance</summary>
		public static EntityField2 IPSegment4 { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.IPSegment4); }}
		/// <summary>Creates a new IPBanEntity.Range field instance</summary>
		public static EntityField2 Range { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.Range); }}
		/// <summary>Creates a new IPBanEntity.IPBanSetByUserID field instance</summary>
		public static EntityField2 IPBanSetByUserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.IPBanSetByUserID); }}
		/// <summary>Creates a new IPBanEntity.IPBanSetOn field instance</summary>
		public static EntityField2 IPBanSetOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.IPBanSetOn); }}
		/// <summary>Creates a new IPBanEntity.Reason field instance</summary>
		public static EntityField2 Reason { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(IPBanFieldIndex.Reason); }}
	}

	/// <summary>Field Creation Class for entity MessageEntity</summary>
	public partial class MessageFields
	{
		/// <summary>Creates a new MessageEntity.MessageID field instance</summary>
		public static EntityField2 MessageID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.MessageID); }}
		/// <summary>Creates a new MessageEntity.PostingDate field instance</summary>
		public static EntityField2 PostingDate { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.PostingDate); }}
		/// <summary>Creates a new MessageEntity.PostedByUserID field instance</summary>
		public static EntityField2 PostedByUserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.PostedByUserID); }}
		/// <summary>Creates a new MessageEntity.ThreadID field instance</summary>
		public static EntityField2 ThreadID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.ThreadID); }}
		/// <summary>Creates a new MessageEntity.PostedFromIP field instance</summary>
		public static EntityField2 PostedFromIP { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.PostedFromIP); }}
		/// <summary>Creates a new MessageEntity.ChangeTrackerStamp field instance</summary>
		public static EntityField2 ChangeTrackerStamp { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.ChangeTrackerStamp); }}
		/// <summary>Creates a new MessageEntity.MessageText field instance</summary>
		public static EntityField2 MessageText { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.MessageText); }}
		/// <summary>Creates a new MessageEntity.MessageTextAsHTML field instance</summary>
		public static EntityField2 MessageTextAsHTML { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(MessageFieldIndex.MessageTextAsHTML); }}
	}

	/// <summary>Field Creation Class for entity PasswordResetTokenEntity</summary>
	public partial class PasswordResetTokenFields
	{
		/// <summary>Creates a new PasswordResetTokenEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(PasswordResetTokenFieldIndex.UserID); }}
		/// <summary>Creates a new PasswordResetTokenEntity.PasswordResetToken field instance</summary>
		public static EntityField2 PasswordResetToken { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(PasswordResetTokenFieldIndex.PasswordResetToken); }}
		/// <summary>Creates a new PasswordResetTokenEntity.PasswordResetRequestedOn field instance</summary>
		public static EntityField2 PasswordResetRequestedOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(PasswordResetTokenFieldIndex.PasswordResetRequestedOn); }}
	}

	/// <summary>Field Creation Class for entity RoleEntity</summary>
	public partial class RoleFields
	{
		/// <summary>Creates a new RoleEntity.RoleID field instance</summary>
		public static EntityField2 RoleID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleFieldIndex.RoleID); }}
		/// <summary>Creates a new RoleEntity.RoleDescription field instance</summary>
		public static EntityField2 RoleDescription { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleFieldIndex.RoleDescription); }}
	}

	/// <summary>Field Creation Class for entity RoleAuditActionEntity</summary>
	public partial class RoleAuditActionFields
	{
		/// <summary>Creates a new RoleAuditActionEntity.AuditActionID field instance</summary>
		public static EntityField2 AuditActionID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleAuditActionFieldIndex.AuditActionID); }}
		/// <summary>Creates a new RoleAuditActionEntity.RoleID field instance</summary>
		public static EntityField2 RoleID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleAuditActionFieldIndex.RoleID); }}
	}

	/// <summary>Field Creation Class for entity RoleSystemActionRightEntity</summary>
	public partial class RoleSystemActionRightFields
	{
		/// <summary>Creates a new RoleSystemActionRightEntity.RoleID field instance</summary>
		public static EntityField2 RoleID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleSystemActionRightFieldIndex.RoleID); }}
		/// <summary>Creates a new RoleSystemActionRightEntity.ActionRightID field instance</summary>
		public static EntityField2 ActionRightID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleSystemActionRightFieldIndex.ActionRightID); }}
	}

	/// <summary>Field Creation Class for entity RoleUserEntity</summary>
	public partial class RoleUserFields
	{
		/// <summary>Creates a new RoleUserEntity.RoleID field instance</summary>
		public static EntityField2 RoleID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleUserFieldIndex.RoleID); }}
		/// <summary>Creates a new RoleUserEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(RoleUserFieldIndex.UserID); }}
	}

	/// <summary>Field Creation Class for entity SectionEntity</summary>
	public partial class SectionFields
	{
		/// <summary>Creates a new SectionEntity.SectionID field instance</summary>
		public static EntityField2 SectionID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SectionFieldIndex.SectionID); }}
		/// <summary>Creates a new SectionEntity.SectionName field instance</summary>
		public static EntityField2 SectionName { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SectionFieldIndex.SectionName); }}
		/// <summary>Creates a new SectionEntity.SectionDescription field instance</summary>
		public static EntityField2 SectionDescription { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SectionFieldIndex.SectionDescription); }}
		/// <summary>Creates a new SectionEntity.OrderNo field instance</summary>
		public static EntityField2 OrderNo { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SectionFieldIndex.OrderNo); }}
	}

	/// <summary>Field Creation Class for entity SupportQueueEntity</summary>
	public partial class SupportQueueFields
	{
		/// <summary>Creates a new SupportQueueEntity.QueueID field instance</summary>
		public static EntityField2 QueueID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueFieldIndex.QueueID); }}
		/// <summary>Creates a new SupportQueueEntity.QueueName field instance</summary>
		public static EntityField2 QueueName { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueFieldIndex.QueueName); }}
		/// <summary>Creates a new SupportQueueEntity.QueueDescription field instance</summary>
		public static EntityField2 QueueDescription { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueFieldIndex.QueueDescription); }}
		/// <summary>Creates a new SupportQueueEntity.OrderNo field instance</summary>
		public static EntityField2 OrderNo { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueFieldIndex.OrderNo); }}
	}

	/// <summary>Field Creation Class for entity SupportQueueThreadEntity</summary>
	public partial class SupportQueueThreadFields
	{
		/// <summary>Creates a new SupportQueueThreadEntity.QueueID field instance</summary>
		public static EntityField2 QueueID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueThreadFieldIndex.QueueID); }}
		/// <summary>Creates a new SupportQueueThreadEntity.ThreadID field instance</summary>
		public static EntityField2 ThreadID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueThreadFieldIndex.ThreadID); }}
		/// <summary>Creates a new SupportQueueThreadEntity.PlacedInQueueByUserID field instance</summary>
		public static EntityField2 PlacedInQueueByUserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueThreadFieldIndex.PlacedInQueueByUserID); }}
		/// <summary>Creates a new SupportQueueThreadEntity.PlacedInQueueOn field instance</summary>
		public static EntityField2 PlacedInQueueOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueThreadFieldIndex.PlacedInQueueOn); }}
		/// <summary>Creates a new SupportQueueThreadEntity.ClaimedByUserID field instance</summary>
		public static EntityField2 ClaimedByUserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueThreadFieldIndex.ClaimedByUserID); }}
		/// <summary>Creates a new SupportQueueThreadEntity.ClaimedOn field instance</summary>
		public static EntityField2 ClaimedOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SupportQueueThreadFieldIndex.ClaimedOn); }}
	}

	/// <summary>Field Creation Class for entity SystemDataEntity</summary>
	public partial class SystemDataFields
	{
		/// <summary>Creates a new SystemDataEntity.ID field instance</summary>
		public static EntityField2 ID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.ID); }}
		/// <summary>Creates a new SystemDataEntity.DefaultRoleNewUser field instance</summary>
		public static EntityField2 DefaultRoleNewUser { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.DefaultRoleNewUser); }}
		/// <summary>Creates a new SystemDataEntity.AnonymousRole field instance</summary>
		public static EntityField2 AnonymousRole { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.AnonymousRole); }}
		/// <summary>Creates a new SystemDataEntity.DefaultUserTitleNewUser field instance</summary>
		public static EntityField2 DefaultUserTitleNewUser { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.DefaultUserTitleNewUser); }}
		/// <summary>Creates a new SystemDataEntity.HoursThresholdForActiveThreads field instance</summary>
		public static EntityField2 HoursThresholdForActiveThreads { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.HoursThresholdForActiveThreads); }}
		/// <summary>Creates a new SystemDataEntity.PageSizeSearchResults field instance</summary>
		public static EntityField2 PageSizeSearchResults { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.PageSizeSearchResults); }}
		/// <summary>Creates a new SystemDataEntity.MinNumberOfThreadsToFetch field instance</summary>
		public static EntityField2 MinNumberOfThreadsToFetch { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.MinNumberOfThreadsToFetch); }}
		/// <summary>Creates a new SystemDataEntity.MinNumberOfNonStickyVisibleThreads field instance</summary>
		public static EntityField2 MinNumberOfNonStickyVisibleThreads { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads); }}
		/// <summary>Creates a new SystemDataEntity.SendReplyNotifications field instance</summary>
		public static EntityField2 SendReplyNotifications { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(SystemDataFieldIndex.SendReplyNotifications); }}
	}

	/// <summary>Field Creation Class for entity ThreadEntity</summary>
	public partial class ThreadFields
	{
		/// <summary>Creates a new ThreadEntity.ThreadID field instance</summary>
		public static EntityField2 ThreadID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.ThreadID); }}
		/// <summary>Creates a new ThreadEntity.ForumID field instance</summary>
		public static EntityField2 ForumID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.ForumID); }}
		/// <summary>Creates a new ThreadEntity.Subject field instance</summary>
		public static EntityField2 Subject { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.Subject); }}
		/// <summary>Creates a new ThreadEntity.StartedByUserID field instance</summary>
		public static EntityField2 StartedByUserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.StartedByUserID); }}
		/// <summary>Creates a new ThreadEntity.IsSticky field instance</summary>
		public static EntityField2 IsSticky { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.IsSticky); }}
		/// <summary>Creates a new ThreadEntity.IsClosed field instance</summary>
		public static EntityField2 IsClosed { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.IsClosed); }}
		/// <summary>Creates a new ThreadEntity.MarkedAsDone field instance</summary>
		public static EntityField2 MarkedAsDone { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.MarkedAsDone); }}
		/// <summary>Creates a new ThreadEntity.Memo field instance</summary>
		public static EntityField2 Memo { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadFieldIndex.Memo); }}
	}

	/// <summary>Field Creation Class for entity ThreadStatisticsEntity</summary>
	public partial class ThreadStatisticsFields
	{
		/// <summary>Creates a new ThreadStatisticsEntity.ThreadID field instance</summary>
		public static EntityField2 ThreadID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadStatisticsFieldIndex.ThreadID); }}
		/// <summary>Creates a new ThreadStatisticsEntity.LastMessageID field instance</summary>
		public static EntityField2 LastMessageID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadStatisticsFieldIndex.LastMessageID); }}
		/// <summary>Creates a new ThreadStatisticsEntity.NumberOfMessages field instance</summary>
		public static EntityField2 NumberOfMessages { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadStatisticsFieldIndex.NumberOfMessages); }}
		/// <summary>Creates a new ThreadStatisticsEntity.NumberOfViews field instance</summary>
		public static EntityField2 NumberOfViews { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadStatisticsFieldIndex.NumberOfViews); }}
	}

	/// <summary>Field Creation Class for entity ThreadSubscriptionEntity</summary>
	public partial class ThreadSubscriptionFields
	{
		/// <summary>Creates a new ThreadSubscriptionEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadSubscriptionFieldIndex.UserID); }}
		/// <summary>Creates a new ThreadSubscriptionEntity.ThreadID field instance</summary>
		public static EntityField2 ThreadID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ThreadSubscriptionFieldIndex.ThreadID); }}
	}

	/// <summary>Field Creation Class for entity UserEntity</summary>
	public partial class UserFields
	{
		/// <summary>Creates a new UserEntity.UserID field instance</summary>
		public static EntityField2 UserID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.UserID); }}
		/// <summary>Creates a new UserEntity.NickName field instance</summary>
		public static EntityField2 NickName { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.NickName); }}
		/// <summary>Creates a new UserEntity.Password field instance</summary>
		public static EntityField2 Password { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Password); }}
		/// <summary>Creates a new UserEntity.IsBanned field instance</summary>
		public static EntityField2 IsBanned { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.IsBanned); }}
		/// <summary>Creates a new UserEntity.IPNumber field instance</summary>
		public static EntityField2 IPNumber { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.IPNumber); }}
		/// <summary>Creates a new UserEntity.Signature field instance</summary>
		public static EntityField2 Signature { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Signature); }}
		/// <summary>Creates a new UserEntity.IconURL field instance</summary>
		public static EntityField2 IconURL { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.IconURL); }}
		/// <summary>Creates a new UserEntity.EmailAddress field instance</summary>
		public static EntityField2 EmailAddress { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.EmailAddress); }}
		/// <summary>Creates a new UserEntity.UserTitleID field instance</summary>
		public static EntityField2 UserTitleID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.UserTitleID); }}
		/// <summary>Creates a new UserEntity.DateOfBirth field instance</summary>
		public static EntityField2 DateOfBirth { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.DateOfBirth); }}
		/// <summary>Creates a new UserEntity.Occupation field instance</summary>
		public static EntityField2 Occupation { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Occupation); }}
		/// <summary>Creates a new UserEntity.Location field instance</summary>
		public static EntityField2 Location { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Location); }}
		/// <summary>Creates a new UserEntity.Website field instance</summary>
		public static EntityField2 Website { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Website); }}
		/// <summary>Creates a new UserEntity.JoinDate field instance</summary>
		public static EntityField2 JoinDate { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.JoinDate); }}
		/// <summary>Creates a new UserEntity.AmountOfPostings field instance</summary>
		public static EntityField2 AmountOfPostings { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.AmountOfPostings); }}
		/// <summary>Creates a new UserEntity.EmailAddressIsPublic field instance</summary>
		public static EntityField2 EmailAddressIsPublic { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.EmailAddressIsPublic); }}
		/// <summary>Creates a new UserEntity.LastVisitedDate field instance</summary>
		public static EntityField2 LastVisitedDate { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.LastVisitedDate); }}
		/// <summary>Creates a new UserEntity.AutoSubscribeToThread field instance</summary>
		public static EntityField2 AutoSubscribeToThread { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.AutoSubscribeToThread); }}
		/// <summary>Creates a new UserEntity.DefaultNumberOfMessagesPerPage field instance</summary>
		public static EntityField2 DefaultNumberOfMessagesPerPage { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.DefaultNumberOfMessagesPerPage); }}
	}

	/// <summary>Field Creation Class for entity UserTitleEntity</summary>
	public partial class UserTitleFields
	{
		/// <summary>Creates a new UserTitleEntity.UserTitleID field instance</summary>
		public static EntityField2 UserTitleID { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserTitleFieldIndex.UserTitleID); }}
		/// <summary>Creates a new UserTitleEntity.UserTitleDescription field instance</summary>
		public static EntityField2 UserTitleDescription { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserTitleFieldIndex.UserTitleDescription); }}
	}
	

}