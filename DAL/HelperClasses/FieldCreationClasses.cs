///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL;

namespace SD.HnD.DAL.HelperClasses
{
	/// <summary>Field Creation Class for entity ActionRightEntity</summary>
	public partial class ActionRightFields
	{
		/// <summary>Creates a new ActionRightEntity.ActionRightDescription field instance</summary>
		public static EntityField ActionRightDescription
		{
			get { return (EntityField)EntityFieldFactory.Create(ActionRightFieldIndex.ActionRightDescription);}
		}
		/// <summary>Creates a new ActionRightEntity.ActionRightID field instance</summary>
		public static EntityField ActionRightID
		{
			get { return (EntityField)EntityFieldFactory.Create(ActionRightFieldIndex.ActionRightID);}
		}
		/// <summary>Creates a new ActionRightEntity.AppliesToForum field instance</summary>
		public static EntityField AppliesToForum
		{
			get { return (EntityField)EntityFieldFactory.Create(ActionRightFieldIndex.AppliesToForum);}
		}
		/// <summary>Creates a new ActionRightEntity.AppliesToSystem field instance</summary>
		public static EntityField AppliesToSystem
		{
			get { return (EntityField)EntityFieldFactory.Create(ActionRightFieldIndex.AppliesToSystem);}
		}
	}

	/// <summary>Field Creation Class for entity AttachmentEntity</summary>
	public partial class AttachmentFields
	{
		/// <summary>Creates a new AttachmentEntity.AddedOn field instance</summary>
		public static EntityField AddedOn
		{
			get { return (EntityField)EntityFieldFactory.Create(AttachmentFieldIndex.AddedOn);}
		}
		/// <summary>Creates a new AttachmentEntity.Approved field instance</summary>
		public static EntityField Approved
		{
			get { return (EntityField)EntityFieldFactory.Create(AttachmentFieldIndex.Approved);}
		}
		/// <summary>Creates a new AttachmentEntity.AttachmentID field instance</summary>
		public static EntityField AttachmentID
		{
			get { return (EntityField)EntityFieldFactory.Create(AttachmentFieldIndex.AttachmentID);}
		}
		/// <summary>Creates a new AttachmentEntity.Filecontents field instance</summary>
		public static EntityField Filecontents
		{
			get { return (EntityField)EntityFieldFactory.Create(AttachmentFieldIndex.Filecontents);}
		}
		/// <summary>Creates a new AttachmentEntity.Filename field instance</summary>
		public static EntityField Filename
		{
			get { return (EntityField)EntityFieldFactory.Create(AttachmentFieldIndex.Filename);}
		}
		/// <summary>Creates a new AttachmentEntity.Filesize field instance</summary>
		public static EntityField Filesize
		{
			get { return (EntityField)EntityFieldFactory.Create(AttachmentFieldIndex.Filesize);}
		}
		/// <summary>Creates a new AttachmentEntity.MessageID field instance</summary>
		public static EntityField MessageID
		{
			get { return (EntityField)EntityFieldFactory.Create(AttachmentFieldIndex.MessageID);}
		}
	}

	/// <summary>Field Creation Class for entity AuditActionEntity</summary>
	public partial class AuditActionFields
	{
		/// <summary>Creates a new AuditActionEntity.AuditActionDescription field instance</summary>
		public static EntityField AuditActionDescription
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditActionFieldIndex.AuditActionDescription);}
		}
		/// <summary>Creates a new AuditActionEntity.AuditActionID field instance</summary>
		public static EntityField AuditActionID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditActionFieldIndex.AuditActionID);}
		}
	}

	/// <summary>Field Creation Class for entity AuditDataCoreEntity</summary>
	public partial class AuditDataCoreFields
	{
		/// <summary>Creates a new AuditDataCoreEntity.AuditActionID field instance</summary>
		public static EntityField AuditActionID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataCoreFieldIndex.AuditActionID);}
		}
		/// <summary>Creates a new AuditDataCoreEntity.AuditDataID field instance</summary>
		public static EntityField AuditDataID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataCoreFieldIndex.AuditDataID);}
		}
		/// <summary>Creates a new AuditDataCoreEntity.AuditedOn field instance</summary>
		public static EntityField AuditedOn
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataCoreFieldIndex.AuditedOn);}
		}
		/// <summary>Creates a new AuditDataCoreEntity.UserID field instance</summary>
		public static EntityField UserID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataCoreFieldIndex.UserID);}
		}
	}

	/// <summary>Field Creation Class for entity AuditDataMessageRelatedEntity</summary>
	public partial class AuditDataMessageRelatedFields
	{
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditActionID field instance</summary>
		public static EntityField AuditActionID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataMessageRelatedFieldIndex.AuditActionID);}
		}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditDataID field instance</summary>
		public static EntityField AuditDataID_AuditDataCore
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataMessageRelatedFieldIndex.AuditDataID_AuditDataCore);}
		}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditedOn field instance</summary>
		public static EntityField AuditedOn
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataMessageRelatedFieldIndex.AuditedOn);}
		}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.UserID field instance</summary>
		public static EntityField UserID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataMessageRelatedFieldIndex.UserID);}
		}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.AuditDataID field instance</summary>
		public static EntityField AuditDataID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataMessageRelatedFieldIndex.AuditDataID);}
		}
		/// <summary>Creates a new AuditDataMessageRelatedEntity.MessageID field instance</summary>
		public static EntityField MessageID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataMessageRelatedFieldIndex.MessageID);}
		}
	}

	/// <summary>Field Creation Class for entity AuditDataThreadRelatedEntity</summary>
	public partial class AuditDataThreadRelatedFields
	{
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditActionID field instance</summary>
		public static EntityField AuditActionID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataThreadRelatedFieldIndex.AuditActionID);}
		}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditDataID field instance</summary>
		public static EntityField AuditDataID_AuditDataCore
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataThreadRelatedFieldIndex.AuditDataID_AuditDataCore);}
		}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditedOn field instance</summary>
		public static EntityField AuditedOn
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataThreadRelatedFieldIndex.AuditedOn);}
		}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.UserID field instance</summary>
		public static EntityField UserID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataThreadRelatedFieldIndex.UserID);}
		}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.AuditDataID field instance</summary>
		public static EntityField AuditDataID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataThreadRelatedFieldIndex.AuditDataID);}
		}
		/// <summary>Creates a new AuditDataThreadRelatedEntity.ThreadID field instance</summary>
		public static EntityField ThreadID
		{
			get { return (EntityField)EntityFieldFactory.Create(AuditDataThreadRelatedFieldIndex.ThreadID);}
		}
	}

	/// <summary>Field Creation Class for entity BookmarkEntity</summary>
	public partial class BookmarkFields
	{
		/// <summary>Creates a new BookmarkEntity.ThreadID field instance</summary>
		public static EntityField ThreadID
		{
			get { return (EntityField)EntityFieldFactory.Create(BookmarkFieldIndex.ThreadID);}
		}
		/// <summary>Creates a new BookmarkEntity.UserID field instance</summary>
		public static EntityField UserID
		{
			get { return (EntityField)EntityFieldFactory.Create(BookmarkFieldIndex.UserID);}
		}
	}

	/// <summary>Field Creation Class for entity ForumEntity</summary>
	public partial class ForumFields
	{
		/// <summary>Creates a new ForumEntity.DefaultSupportQueueID field instance</summary>
		public static EntityField DefaultSupportQueueID
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.DefaultSupportQueueID);}
		}
		/// <summary>Creates a new ForumEntity.DefaultThreadListInterval field instance</summary>
		public static EntityField DefaultThreadListInterval
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.DefaultThreadListInterval);}
		}
		/// <summary>Creates a new ForumEntity.ForumDescription field instance</summary>
		public static EntityField ForumDescription
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.ForumDescription);}
		}
		/// <summary>Creates a new ForumEntity.ForumID field instance</summary>
		public static EntityField ForumID
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.ForumID);}
		}
		/// <summary>Creates a new ForumEntity.ForumLastPostingDate field instance</summary>
		public static EntityField ForumLastPostingDate
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.ForumLastPostingDate);}
		}
		/// <summary>Creates a new ForumEntity.ForumName field instance</summary>
		public static EntityField ForumName
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.ForumName);}
		}
		/// <summary>Creates a new ForumEntity.HasRSSFeed field instance</summary>
		public static EntityField HasRSSFeed
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.HasRSSFeed);}
		}
		/// <summary>Creates a new ForumEntity.MaxAttachmentSize field instance</summary>
		public static EntityField MaxAttachmentSize
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.MaxAttachmentSize);}
		}
		/// <summary>Creates a new ForumEntity.MaxNoOfAttachmentsPerMessage field instance</summary>
		public static EntityField MaxNoOfAttachmentsPerMessage
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.MaxNoOfAttachmentsPerMessage);}
		}
		/// <summary>Creates a new ForumEntity.NewThreadWelcomeText field instance</summary>
		public static EntityField NewThreadWelcomeText
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.NewThreadWelcomeText);}
		}
		/// <summary>Creates a new ForumEntity.NewThreadWelcomeTextAsHTML field instance</summary>
		public static EntityField NewThreadWelcomeTextAsHTML
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.NewThreadWelcomeTextAsHTML);}
		}
		/// <summary>Creates a new ForumEntity.OrderNo field instance</summary>
		public static EntityField OrderNo
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.OrderNo);}
		}
		/// <summary>Creates a new ForumEntity.SectionID field instance</summary>
		public static EntityField SectionID
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumFieldIndex.SectionID);}
		}
	}

	/// <summary>Field Creation Class for entity ForumRoleForumActionRightEntity</summary>
	public partial class ForumRoleForumActionRightFields
	{
		/// <summary>Creates a new ForumRoleForumActionRightEntity.ActionRightID field instance</summary>
		public static EntityField ActionRightID
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumRoleForumActionRightFieldIndex.ActionRightID);}
		}
		/// <summary>Creates a new ForumRoleForumActionRightEntity.ForumID field instance</summary>
		public static EntityField ForumID
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumRoleForumActionRightFieldIndex.ForumID);}
		}
		/// <summary>Creates a new ForumRoleForumActionRightEntity.RoleID field instance</summary>
		public static EntityField RoleID
		{
			get { return (EntityField)EntityFieldFactory.Create(ForumRoleForumActionRightFieldIndex.RoleID);}
		}
	}

	/// <summary>Field Creation Class for entity IPBanEntity</summary>
	public partial class IPBanFields
	{
		/// <summary>Creates a new IPBanEntity.IPBanID field instance</summary>
		public static EntityField IPBanID
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.IPBanID);}
		}
		/// <summary>Creates a new IPBanEntity.IPBanSetByUserID field instance</summary>
		public static EntityField IPBanSetByUserID
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.IPBanSetByUserID);}
		}
		/// <summary>Creates a new IPBanEntity.IPBanSetOn field instance</summary>
		public static EntityField IPBanSetOn
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.IPBanSetOn);}
		}
		/// <summary>Creates a new IPBanEntity.IPSegment1 field instance</summary>
		public static EntityField IPSegment1
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.IPSegment1);}
		}
		/// <summary>Creates a new IPBanEntity.IPSegment2 field instance</summary>
		public static EntityField IPSegment2
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.IPSegment2);}
		}
		/// <summary>Creates a new IPBanEntity.IPSegment3 field instance</summary>
		public static EntityField IPSegment3
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.IPSegment3);}
		}
		/// <summary>Creates a new IPBanEntity.IPSegment4 field instance</summary>
		public static EntityField IPSegment4
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.IPSegment4);}
		}
		/// <summary>Creates a new IPBanEntity.Range field instance</summary>
		public static EntityField Range
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.Range);}
		}
		/// <summary>Creates a new IPBanEntity.Reason field instance</summary>
		public static EntityField Reason
		{
			get { return (EntityField)EntityFieldFactory.Create(IPBanFieldIndex.Reason);}
		}
	}

	/// <summary>Field Creation Class for entity MessageEntity</summary>
	public partial class MessageFields
	{
		/// <summary>Creates a new MessageEntity.ChangeTrackerStamp field instance</summary>
		public static EntityField ChangeTrackerStamp
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.ChangeTrackerStamp);}
		}
		/// <summary>Creates a new MessageEntity.MessageID field instance</summary>
		public static EntityField MessageID
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.MessageID);}
		}
		/// <summary>Creates a new MessageEntity.MessageText field instance</summary>
		public static EntityField MessageText
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.MessageText);}
		}
		/// <summary>Creates a new MessageEntity.MessageTextAsHTML field instance</summary>
		public static EntityField MessageTextAsHTML
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.MessageTextAsHTML);}
		}
		/// <summary>Creates a new MessageEntity.MessageTextAsXml field instance</summary>
		public static EntityField MessageTextAsXml
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.MessageTextAsXml);}
		}
		/// <summary>Creates a new MessageEntity.PostedByUserID field instance</summary>
		public static EntityField PostedByUserID
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.PostedByUserID);}
		}
		/// <summary>Creates a new MessageEntity.PostedFromIP field instance</summary>
		public static EntityField PostedFromIP
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.PostedFromIP);}
		}
		/// <summary>Creates a new MessageEntity.PostingDate field instance</summary>
		public static EntityField PostingDate
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.PostingDate);}
		}
		/// <summary>Creates a new MessageEntity.ThreadID field instance</summary>
		public static EntityField ThreadID
		{
			get { return (EntityField)EntityFieldFactory.Create(MessageFieldIndex.ThreadID);}
		}
	}

	/// <summary>Field Creation Class for entity RoleEntity</summary>
	public partial class RoleFields
	{
		/// <summary>Creates a new RoleEntity.RoleDescription field instance</summary>
		public static EntityField RoleDescription
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleFieldIndex.RoleDescription);}
		}
		/// <summary>Creates a new RoleEntity.RoleID field instance</summary>
		public static EntityField RoleID
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleFieldIndex.RoleID);}
		}
	}

	/// <summary>Field Creation Class for entity RoleAuditActionEntity</summary>
	public partial class RoleAuditActionFields
	{
		/// <summary>Creates a new RoleAuditActionEntity.AuditActionID field instance</summary>
		public static EntityField AuditActionID
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleAuditActionFieldIndex.AuditActionID);}
		}
		/// <summary>Creates a new RoleAuditActionEntity.RoleID field instance</summary>
		public static EntityField RoleID
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleAuditActionFieldIndex.RoleID);}
		}
	}

	/// <summary>Field Creation Class for entity RoleSystemActionRightEntity</summary>
	public partial class RoleSystemActionRightFields
	{
		/// <summary>Creates a new RoleSystemActionRightEntity.ActionRightID field instance</summary>
		public static EntityField ActionRightID
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleSystemActionRightFieldIndex.ActionRightID);}
		}
		/// <summary>Creates a new RoleSystemActionRightEntity.RoleID field instance</summary>
		public static EntityField RoleID
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleSystemActionRightFieldIndex.RoleID);}
		}
	}

	/// <summary>Field Creation Class for entity RoleUserEntity</summary>
	public partial class RoleUserFields
	{
		/// <summary>Creates a new RoleUserEntity.RoleID field instance</summary>
		public static EntityField RoleID
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleUserFieldIndex.RoleID);}
		}
		/// <summary>Creates a new RoleUserEntity.UserID field instance</summary>
		public static EntityField UserID
		{
			get { return (EntityField)EntityFieldFactory.Create(RoleUserFieldIndex.UserID);}
		}
	}

	/// <summary>Field Creation Class for entity SectionEntity</summary>
	public partial class SectionFields
	{
		/// <summary>Creates a new SectionEntity.OrderNo field instance</summary>
		public static EntityField OrderNo
		{
			get { return (EntityField)EntityFieldFactory.Create(SectionFieldIndex.OrderNo);}
		}
		/// <summary>Creates a new SectionEntity.SectionDescription field instance</summary>
		public static EntityField SectionDescription
		{
			get { return (EntityField)EntityFieldFactory.Create(SectionFieldIndex.SectionDescription);}
		}
		/// <summary>Creates a new SectionEntity.SectionID field instance</summary>
		public static EntityField SectionID
		{
			get { return (EntityField)EntityFieldFactory.Create(SectionFieldIndex.SectionID);}
		}
		/// <summary>Creates a new SectionEntity.SectionName field instance</summary>
		public static EntityField SectionName
		{
			get { return (EntityField)EntityFieldFactory.Create(SectionFieldIndex.SectionName);}
		}
	}

	/// <summary>Field Creation Class for entity SupportQueueEntity</summary>
	public partial class SupportQueueFields
	{
		/// <summary>Creates a new SupportQueueEntity.OrderNo field instance</summary>
		public static EntityField OrderNo
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueFieldIndex.OrderNo);}
		}
		/// <summary>Creates a new SupportQueueEntity.QueueDescription field instance</summary>
		public static EntityField QueueDescription
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueFieldIndex.QueueDescription);}
		}
		/// <summary>Creates a new SupportQueueEntity.QueueID field instance</summary>
		public static EntityField QueueID
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueFieldIndex.QueueID);}
		}
		/// <summary>Creates a new SupportQueueEntity.QueueName field instance</summary>
		public static EntityField QueueName
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueFieldIndex.QueueName);}
		}
	}

	/// <summary>Field Creation Class for entity SupportQueueThreadEntity</summary>
	public partial class SupportQueueThreadFields
	{
		/// <summary>Creates a new SupportQueueThreadEntity.ClaimedByUserID field instance</summary>
		public static EntityField ClaimedByUserID
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueThreadFieldIndex.ClaimedByUserID);}
		}
		/// <summary>Creates a new SupportQueueThreadEntity.ClaimedOn field instance</summary>
		public static EntityField ClaimedOn
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueThreadFieldIndex.ClaimedOn);}
		}
		/// <summary>Creates a new SupportQueueThreadEntity.PlacedInQueueByUserID field instance</summary>
		public static EntityField PlacedInQueueByUserID
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueThreadFieldIndex.PlacedInQueueByUserID);}
		}
		/// <summary>Creates a new SupportQueueThreadEntity.PlacedInQueueOn field instance</summary>
		public static EntityField PlacedInQueueOn
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueThreadFieldIndex.PlacedInQueueOn);}
		}
		/// <summary>Creates a new SupportQueueThreadEntity.QueueID field instance</summary>
		public static EntityField QueueID
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueThreadFieldIndex.QueueID);}
		}
		/// <summary>Creates a new SupportQueueThreadEntity.ThreadID field instance</summary>
		public static EntityField ThreadID
		{
			get { return (EntityField)EntityFieldFactory.Create(SupportQueueThreadFieldIndex.ThreadID);}
		}
	}

	/// <summary>Field Creation Class for entity SystemDataEntity</summary>
	public partial class SystemDataFields
	{
		/// <summary>Creates a new SystemDataEntity.AnonymousRole field instance</summary>
		public static EntityField AnonymousRole
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.AnonymousRole);}
		}
		/// <summary>Creates a new SystemDataEntity.DefaultRoleNewUser field instance</summary>
		public static EntityField DefaultRoleNewUser
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.DefaultRoleNewUser);}
		}
		/// <summary>Creates a new SystemDataEntity.DefaultUserTitleNewUser field instance</summary>
		public static EntityField DefaultUserTitleNewUser
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.DefaultUserTitleNewUser);}
		}
		/// <summary>Creates a new SystemDataEntity.HoursThresholdForActiveThreads field instance</summary>
		public static EntityField HoursThresholdForActiveThreads
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.HoursThresholdForActiveThreads);}
		}
		/// <summary>Creates a new SystemDataEntity.ID field instance</summary>
		public static EntityField ID
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.ID);}
		}
		/// <summary>Creates a new SystemDataEntity.MinNumberOfNonStickyVisibleThreads field instance</summary>
		public static EntityField MinNumberOfNonStickyVisibleThreads
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads);}
		}
		/// <summary>Creates a new SystemDataEntity.MinNumberOfThreadsToFetch field instance</summary>
		public static EntityField MinNumberOfThreadsToFetch
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.MinNumberOfThreadsToFetch);}
		}
		/// <summary>Creates a new SystemDataEntity.PageSizeSearchResults field instance</summary>
		public static EntityField PageSizeSearchResults
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.PageSizeSearchResults);}
		}
		/// <summary>Creates a new SystemDataEntity.SendReplyNotifications field instance</summary>
		public static EntityField SendReplyNotifications
		{
			get { return (EntityField)EntityFieldFactory.Create(SystemDataFieldIndex.SendReplyNotifications);}
		}
	}

	/// <summary>Field Creation Class for entity ThreadEntity</summary>
	public partial class ThreadFields
	{
		/// <summary>Creates a new ThreadEntity.ForumID field instance</summary>
		public static EntityField ForumID
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.ForumID);}
		}
		/// <summary>Creates a new ThreadEntity.IsClosed field instance</summary>
		public static EntityField IsClosed
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.IsClosed);}
		}
		/// <summary>Creates a new ThreadEntity.IsSticky field instance</summary>
		public static EntityField IsSticky
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.IsSticky);}
		}
		/// <summary>Creates a new ThreadEntity.MarkedAsDone field instance</summary>
		public static EntityField MarkedAsDone
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.MarkedAsDone);}
		}
		/// <summary>Creates a new ThreadEntity.Memo field instance</summary>
		public static EntityField Memo
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.Memo);}
		}
		/// <summary>Creates a new ThreadEntity.NumberOfViews field instance</summary>
		public static EntityField NumberOfViews
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.NumberOfViews);}
		}
		/// <summary>Creates a new ThreadEntity.StartedByUserID field instance</summary>
		public static EntityField StartedByUserID
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.StartedByUserID);}
		}
		/// <summary>Creates a new ThreadEntity.Subject field instance</summary>
		public static EntityField Subject
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.Subject);}
		}
		/// <summary>Creates a new ThreadEntity.ThreadID field instance</summary>
		public static EntityField ThreadID
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.ThreadID);}
		}
		/// <summary>Creates a new ThreadEntity.ThreadLastPostingDate field instance</summary>
		public static EntityField ThreadLastPostingDate
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadFieldIndex.ThreadLastPostingDate);}
		}
	}

	/// <summary>Field Creation Class for entity ThreadSubscriptionEntity</summary>
	public partial class ThreadSubscriptionFields
	{
		/// <summary>Creates a new ThreadSubscriptionEntity.ThreadID field instance</summary>
		public static EntityField ThreadID
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadSubscriptionFieldIndex.ThreadID);}
		}
		/// <summary>Creates a new ThreadSubscriptionEntity.UserID field instance</summary>
		public static EntityField UserID
		{
			get { return (EntityField)EntityFieldFactory.Create(ThreadSubscriptionFieldIndex.UserID);}
		}
	}

	/// <summary>Field Creation Class for entity UserEntity</summary>
	public partial class UserFields
	{
		/// <summary>Creates a new UserEntity.AmountOfPostings field instance</summary>
		public static EntityField AmountOfPostings
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.AmountOfPostings);}
		}
		/// <summary>Creates a new UserEntity.AutoSubscribeToThread field instance</summary>
		public static EntityField AutoSubscribeToThread
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.AutoSubscribeToThread);}
		}
		/// <summary>Creates a new UserEntity.DateOfBirth field instance</summary>
		public static EntityField DateOfBirth
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.DateOfBirth);}
		}
		/// <summary>Creates a new UserEntity.DefaultNumberOfMessagesPerPage field instance</summary>
		public static EntityField DefaultNumberOfMessagesPerPage
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.DefaultNumberOfMessagesPerPage);}
		}
		/// <summary>Creates a new UserEntity.EmailAddress field instance</summary>
		public static EntityField EmailAddress
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.EmailAddress);}
		}
		/// <summary>Creates a new UserEntity.EmailAddressIsPublic field instance</summary>
		public static EntityField EmailAddressIsPublic
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.EmailAddressIsPublic);}
		}
		/// <summary>Creates a new UserEntity.IconURL field instance</summary>
		public static EntityField IconURL
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.IconURL);}
		}
		/// <summary>Creates a new UserEntity.IPNumber field instance</summary>
		public static EntityField IPNumber
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.IPNumber);}
		}
		/// <summary>Creates a new UserEntity.IsBanned field instance</summary>
		public static EntityField IsBanned
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.IsBanned);}
		}
		/// <summary>Creates a new UserEntity.JoinDate field instance</summary>
		public static EntityField JoinDate
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.JoinDate);}
		}
		/// <summary>Creates a new UserEntity.LastVisitedDate field instance</summary>
		public static EntityField LastVisitedDate
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.LastVisitedDate);}
		}
		/// <summary>Creates a new UserEntity.Location field instance</summary>
		public static EntityField Location
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.Location);}
		}
		/// <summary>Creates a new UserEntity.NickName field instance</summary>
		public static EntityField NickName
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.NickName);}
		}
		/// <summary>Creates a new UserEntity.Occupation field instance</summary>
		public static EntityField Occupation
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.Occupation);}
		}
		/// <summary>Creates a new UserEntity.Password field instance</summary>
		public static EntityField Password
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.Password);}
		}
		/// <summary>Creates a new UserEntity.Signature field instance</summary>
		public static EntityField Signature
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.Signature);}
		}
		/// <summary>Creates a new UserEntity.SignatureAsHTML field instance</summary>
		public static EntityField SignatureAsHTML
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.SignatureAsHTML);}
		}
		/// <summary>Creates a new UserEntity.UserID field instance</summary>
		public static EntityField UserID
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.UserID);}
		}
		/// <summary>Creates a new UserEntity.UserTitleID field instance</summary>
		public static EntityField UserTitleID
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.UserTitleID);}
		}
		/// <summary>Creates a new UserEntity.Website field instance</summary>
		public static EntityField Website
		{
			get { return (EntityField)EntityFieldFactory.Create(UserFieldIndex.Website);}
		}
	}

	/// <summary>Field Creation Class for entity UserTitleEntity</summary>
	public partial class UserTitleFields
	{
		/// <summary>Creates a new UserTitleEntity.UserTitleDescription field instance</summary>
		public static EntityField UserTitleDescription
		{
			get { return (EntityField)EntityFieldFactory.Create(UserTitleFieldIndex.UserTitleDescription);}
		}
		/// <summary>Creates a new UserTitleEntity.UserTitleID field instance</summary>
		public static EntityField UserTitleID
		{
			get { return (EntityField)EntityFieldFactory.Create(UserTitleFieldIndex.UserTitleID);}
		}
	}
	

}