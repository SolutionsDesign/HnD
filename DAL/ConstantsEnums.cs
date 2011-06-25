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

namespace SD.HnD.DAL
{
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ActionRight.</summary>
	public enum ActionRightFieldIndex
	{
		///<summary>ActionRightDescription. </summary>
		ActionRightDescription,
		///<summary>ActionRightID. </summary>
		ActionRightID,
		///<summary>AppliesToForum. </summary>
		AppliesToForum,
		///<summary>AppliesToSystem. </summary>
		AppliesToSystem,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Attachment.</summary>
	public enum AttachmentFieldIndex
	{
		///<summary>AddedOn. </summary>
		AddedOn,
		///<summary>Approved. </summary>
		Approved,
		///<summary>AttachmentID. </summary>
		AttachmentID,
		///<summary>Filecontents. </summary>
		Filecontents,
		///<summary>Filename. </summary>
		Filename,
		///<summary>Filesize. </summary>
		Filesize,
		///<summary>MessageID. </summary>
		MessageID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AuditAction.</summary>
	public enum AuditActionFieldIndex
	{
		///<summary>AuditActionDescription. </summary>
		AuditActionDescription,
		///<summary>AuditActionID. </summary>
		AuditActionID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AuditDataCore.</summary>
	public enum AuditDataCoreFieldIndex
	{
		///<summary>AuditActionID. </summary>
		AuditActionID,
		///<summary>AuditDataID. </summary>
		AuditDataID,
		///<summary>AuditedOn. </summary>
		AuditedOn,
		///<summary>UserID. </summary>
		UserID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AuditDataMessageRelated.</summary>
	public enum AuditDataMessageRelatedFieldIndex
	{
		///<summary>AuditActionID. Inherited from AuditDataCore</summary>
		AuditActionID,
		///<summary>AuditDataID. Inherited from AuditDataCore</summary>
		AuditDataID_AuditDataCore,
		///<summary>AuditedOn. Inherited from AuditDataCore</summary>
		AuditedOn,
		///<summary>UserID. Inherited from AuditDataCore</summary>
		UserID,
		///<summary>AuditDataID. </summary>
		AuditDataID,
		///<summary>MessageID. </summary>
		MessageID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AuditDataThreadRelated.</summary>
	public enum AuditDataThreadRelatedFieldIndex
	{
		///<summary>AuditActionID. Inherited from AuditDataCore</summary>
		AuditActionID,
		///<summary>AuditDataID. Inherited from AuditDataCore</summary>
		AuditDataID_AuditDataCore,
		///<summary>AuditedOn. Inherited from AuditDataCore</summary>
		AuditedOn,
		///<summary>UserID. Inherited from AuditDataCore</summary>
		UserID,
		///<summary>AuditDataID. </summary>
		AuditDataID,
		///<summary>ThreadID. </summary>
		ThreadID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Bookmark.</summary>
	public enum BookmarkFieldIndex
	{
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>UserID. </summary>
		UserID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Forum.</summary>
	public enum ForumFieldIndex
	{
		///<summary>DefaultSupportQueueID. </summary>
		DefaultSupportQueueID,
		///<summary>DefaultThreadListInterval. </summary>
		DefaultThreadListInterval,
		///<summary>ForumDescription. </summary>
		ForumDescription,
		///<summary>ForumID. </summary>
		ForumID,
		///<summary>ForumLastPostingDate. </summary>
		ForumLastPostingDate,
		///<summary>ForumName. </summary>
		ForumName,
		///<summary>HasRSSFeed. </summary>
		HasRSSFeed,
		///<summary>MaxAttachmentSize. </summary>
		MaxAttachmentSize,
		///<summary>MaxNoOfAttachmentsPerMessage. </summary>
		MaxNoOfAttachmentsPerMessage,
		///<summary>NewThreadWelcomeText. </summary>
		NewThreadWelcomeText,
		///<summary>NewThreadWelcomeTextAsHTML. </summary>
		NewThreadWelcomeTextAsHTML,
		///<summary>OrderNo. </summary>
		OrderNo,
		///<summary>SectionID. </summary>
		SectionID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ForumRoleForumActionRight.</summary>
	public enum ForumRoleForumActionRightFieldIndex
	{
		///<summary>ActionRightID. </summary>
		ActionRightID,
		///<summary>ForumID. </summary>
		ForumID,
		///<summary>RoleID. </summary>
		RoleID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IPBan.</summary>
	public enum IPBanFieldIndex
	{
		///<summary>IPBanID. </summary>
		IPBanID,
		///<summary>IPBanSetByUserID. </summary>
		IPBanSetByUserID,
		///<summary>IPBanSetOn. </summary>
		IPBanSetOn,
		///<summary>IPSegment1. </summary>
		IPSegment1,
		///<summary>IPSegment2. </summary>
		IPSegment2,
		///<summary>IPSegment3. </summary>
		IPSegment3,
		///<summary>IPSegment4. </summary>
		IPSegment4,
		///<summary>Range. </summary>
		Range,
		///<summary>Reason. </summary>
		Reason,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Message.</summary>
	public enum MessageFieldIndex
	{
		///<summary>ChangeTrackerStamp. </summary>
		ChangeTrackerStamp,
		///<summary>MessageID. </summary>
		MessageID,
		///<summary>MessageText. </summary>
		MessageText,
		///<summary>MessageTextAsHTML. </summary>
		MessageTextAsHTML,
		///<summary>MessageTextAsXml. </summary>
		MessageTextAsXml,
		///<summary>PostedByUserID. </summary>
		PostedByUserID,
		///<summary>PostedFromIP. </summary>
		PostedFromIP,
		///<summary>PostingDate. </summary>
		PostingDate,
		///<summary>ThreadID. </summary>
		ThreadID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Role.</summary>
	public enum RoleFieldIndex
	{
		///<summary>RoleDescription. </summary>
		RoleDescription,
		///<summary>RoleID. </summary>
		RoleID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RoleAuditAction.</summary>
	public enum RoleAuditActionFieldIndex
	{
		///<summary>AuditActionID. </summary>
		AuditActionID,
		///<summary>RoleID. </summary>
		RoleID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RoleSystemActionRight.</summary>
	public enum RoleSystemActionRightFieldIndex
	{
		///<summary>ActionRightID. </summary>
		ActionRightID,
		///<summary>RoleID. </summary>
		RoleID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RoleUser.</summary>
	public enum RoleUserFieldIndex
	{
		///<summary>RoleID. </summary>
		RoleID,
		///<summary>UserID. </summary>
		UserID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Section.</summary>
	public enum SectionFieldIndex
	{
		///<summary>OrderNo. </summary>
		OrderNo,
		///<summary>SectionDescription. </summary>
		SectionDescription,
		///<summary>SectionID. </summary>
		SectionID,
		///<summary>SectionName. </summary>
		SectionName,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SupportQueue.</summary>
	public enum SupportQueueFieldIndex
	{
		///<summary>OrderNo. </summary>
		OrderNo,
		///<summary>QueueDescription. </summary>
		QueueDescription,
		///<summary>QueueID. </summary>
		QueueID,
		///<summary>QueueName. </summary>
		QueueName,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SupportQueueThread.</summary>
	public enum SupportQueueThreadFieldIndex
	{
		///<summary>ClaimedByUserID. </summary>
		ClaimedByUserID,
		///<summary>ClaimedOn. </summary>
		ClaimedOn,
		///<summary>PlacedInQueueByUserID. </summary>
		PlacedInQueueByUserID,
		///<summary>PlacedInQueueOn. </summary>
		PlacedInQueueOn,
		///<summary>QueueID. </summary>
		QueueID,
		///<summary>ThreadID. </summary>
		ThreadID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SystemData.</summary>
	public enum SystemDataFieldIndex
	{
		///<summary>AnonymousRole. </summary>
		AnonymousRole,
		///<summary>DefaultRoleNewUser. </summary>
		DefaultRoleNewUser,
		///<summary>DefaultUserTitleNewUser. </summary>
		DefaultUserTitleNewUser,
		///<summary>HoursThresholdForActiveThreads. </summary>
		HoursThresholdForActiveThreads,
		///<summary>ID. </summary>
		ID,
		///<summary>MinNumberOfNonStickyVisibleThreads. </summary>
		MinNumberOfNonStickyVisibleThreads,
		///<summary>MinNumberOfThreadsToFetch. </summary>
		MinNumberOfThreadsToFetch,
		///<summary>PageSizeSearchResults. </summary>
		PageSizeSearchResults,
		///<summary>SendReplyNotifications. </summary>
		SendReplyNotifications,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Thread.</summary>
	public enum ThreadFieldIndex
	{
		///<summary>ForumID. </summary>
		ForumID,
		///<summary>IsClosed. </summary>
		IsClosed,
		///<summary>IsSticky. </summary>
		IsSticky,
		///<summary>MarkedAsDone. </summary>
		MarkedAsDone,
		///<summary>Memo. </summary>
		Memo,
		///<summary>NumberOfViews. </summary>
		NumberOfViews,
		///<summary>StartedByUserID. </summary>
		StartedByUserID,
		///<summary>Subject. </summary>
		Subject,
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>ThreadLastPostingDate. </summary>
		ThreadLastPostingDate,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ThreadSubscription.</summary>
	public enum ThreadSubscriptionFieldIndex
	{
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>UserID. </summary>
		UserID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: User.</summary>
	public enum UserFieldIndex
	{
		///<summary>AmountOfPostings. </summary>
		AmountOfPostings,
		///<summary>AutoSubscribeToThread. </summary>
		AutoSubscribeToThread,
		///<summary>DateOfBirth. </summary>
		DateOfBirth,
		///<summary>DefaultNumberOfMessagesPerPage. </summary>
		DefaultNumberOfMessagesPerPage,
		///<summary>EmailAddress. </summary>
		EmailAddress,
		///<summary>EmailAddressIsPublic. </summary>
		EmailAddressIsPublic,
		///<summary>IconURL. </summary>
		IconURL,
		///<summary>IPNumber. </summary>
		IPNumber,
		///<summary>IsBanned. </summary>
		IsBanned,
		///<summary>JoinDate. </summary>
		JoinDate,
		///<summary>LastVisitedDate. </summary>
		LastVisitedDate,
		///<summary>Location. </summary>
		Location,
		///<summary>NickName. </summary>
		NickName,
		///<summary>Occupation. </summary>
		Occupation,
		///<summary>Password. </summary>
		Password,
		///<summary>Signature. </summary>
		Signature,
		///<summary>SignatureAsHTML. </summary>
		SignatureAsHTML,
		///<summary>UserID. </summary>
		UserID,
		///<summary>UserTitleID. </summary>
		UserTitleID,
		///<summary>Website. </summary>
		Website,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserTitle.</summary>
	public enum UserTitleFieldIndex
	{
		///<summary>UserTitleDescription. </summary>
		UserTitleDescription,
		///<summary>UserTitleID. </summary>
		UserTitleID,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>Index enum to fast-access TypedList Fields in the Columns collection of the Typed List: ForumMessages</summary>
	public enum ForumMessagesTypedListFieldIndex
	{
		///<summary>MessageID</summary>
		MessageID,
		///<summary>PostingDate</summary>
		PostingDate,
		///<summary>MessageTextAsHTML</summary>
		MessageTextAsHTML,
		///<summary>ThreadID</summary>
		ThreadID,
		///<summary>Subject</summary>
		Subject,
		///<summary>EmailAddress</summary>
		EmailAddress,
		///<summary>EmailAddressIsPublic</summary>
		EmailAddressIsPublic,
		///<summary>NickName</summary>
		NickName,
		///<summary>MessageText</summary>
		MessageText,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access TypedList Fields in the Columns collection of the Typed List: ForumsWithSectionName</summary>
	public enum ForumsWithSectionNameTypedListFieldIndex
	{
		///<summary>ForumID</summary>
		ForumID,
		///<summary>ForumName</summary>
		ForumName,
		///<summary>SectionName</summary>
		SectionName,
		///<summary>ForumDescription</summary>
		ForumDescription,
		///<summary>SectionID</summary>
		SectionID,
		///<summary>ForumOrderNo</summary>
		ForumOrderNo,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access TypedList Fields in the Columns collection of the Typed List: MessagesInThread</summary>
	public enum MessagesInThreadTypedListFieldIndex
	{
		///<summary>MessageID</summary>
		MessageID,
		///<summary>PostingDate</summary>
		PostingDate,
		///<summary>MessageTextAsHTML</summary>
		MessageTextAsHTML,
		///<summary>ThreadID</summary>
		ThreadID,
		///<summary>PostedFromIP</summary>
		PostedFromIP,
		///<summary>UserID</summary>
		UserID,
		///<summary>NickName</summary>
		NickName,
		///<summary>SignatureAsHTML</summary>
		SignatureAsHTML,
		///<summary>IconURL</summary>
		IconURL,
		///<summary>Location</summary>
		Location,
		///<summary>JoinDate</summary>
		JoinDate,
		///<summary>AmountOfPostings</summary>
		AmountOfPostings,
		///<summary>UserTitleDescription</summary>
		UserTitleDescription,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access TypedList Fields in the Columns collection of the Typed List: SearchResult</summary>
	public enum SearchResultTypedListFieldIndex
	{
		///<summary>ThreadID</summary>
		ThreadID,
		///<summary>Subject</summary>
		Subject,
		///<summary>ForumName</summary>
		ForumName,
		///<summary>SectionName</summary>
		SectionName,
		///<summary>ThreadLastPostingDate</summary>
		ThreadLastPostingDate,
		/// <summary></summary>
		AmountOfFields
	}

	/// <summary>Enum definition for all the entity types defined in this namespace. Used by the entityfields factory.</summary>
	public enum EntityType
	{
		///<summary>ActionRight</summary>
		ActionRightEntity,
		///<summary>Attachment</summary>
		AttachmentEntity,
		///<summary>AuditAction</summary>
		AuditActionEntity,
		///<summary>AuditDataCore</summary>
		AuditDataCoreEntity,
		///<summary>AuditDataMessageRelated</summary>
		AuditDataMessageRelatedEntity,
		///<summary>AuditDataThreadRelated</summary>
		AuditDataThreadRelatedEntity,
		///<summary>Bookmark</summary>
		BookmarkEntity,
		///<summary>Forum</summary>
		ForumEntity,
		///<summary>ForumRoleForumActionRight</summary>
		ForumRoleForumActionRightEntity,
		///<summary>IPBan</summary>
		IPBanEntity,
		///<summary>Message</summary>
		MessageEntity,
		///<summary>Role</summary>
		RoleEntity,
		///<summary>RoleAuditAction</summary>
		RoleAuditActionEntity,
		///<summary>RoleSystemActionRight</summary>
		RoleSystemActionRightEntity,
		///<summary>RoleUser</summary>
		RoleUserEntity,
		///<summary>Section</summary>
		SectionEntity,
		///<summary>SupportQueue</summary>
		SupportQueueEntity,
		///<summary>SupportQueueThread</summary>
		SupportQueueThreadEntity,
		///<summary>SystemData</summary>
		SystemDataEntity,
		///<summary>Thread</summary>
		ThreadEntity,
		///<summary>ThreadSubscription</summary>
		ThreadSubscriptionEntity,
		///<summary>User</summary>
		UserEntity,
		///<summary>UserTitle</summary>
		UserTitleEntity
	}


	#region Custom ConstantsEnums Code
	
	// __LLBLGENPRO_USER_CODE_REGION_START CustomUserConstants
	// __LLBLGENPRO_USER_CODE_REGION_END
	#endregion

	#region Included code

	#endregion
}

