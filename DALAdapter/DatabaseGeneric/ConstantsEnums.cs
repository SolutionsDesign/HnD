///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.0
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;

namespace SD.HnD.DALAdapter
{
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ActionRight.</summary>
	public enum ActionRightFieldIndex
	{
		///<summary>ActionRightID. </summary>
		ActionRightID,
		///<summary>ActionRightDescription. </summary>
		ActionRightDescription,
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
		///<summary>AttachmentID. </summary>
		AttachmentID,
		///<summary>MessageID. </summary>
		MessageID,
		///<summary>Filename. </summary>
		Filename,
		///<summary>Approved. </summary>
		Approved,
		///<summary>Filecontents. </summary>
		Filecontents,
		///<summary>Filesize. </summary>
		Filesize,
		///<summary>AddedOn. </summary>
		AddedOn,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AuditAction.</summary>
	public enum AuditActionFieldIndex
	{
		///<summary>AuditActionID. </summary>
		AuditActionID,
		///<summary>AuditActionDescription. </summary>
		AuditActionDescription,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AuditDataCore.</summary>
	public enum AuditDataCoreFieldIndex
	{
		///<summary>AuditDataID. </summary>
		AuditDataID,
		///<summary>AuditActionID. </summary>
		AuditActionID,
		///<summary>UserID. </summary>
		UserID,
		///<summary>AuditedOn. </summary>
		AuditedOn,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AuditDataMessageRelated.</summary>
	public enum AuditDataMessageRelatedFieldIndex
	{
		///<summary>AuditDataID. Inherited from AuditDataCore</summary>
		AuditDataID_AuditDataCore,
		///<summary>AuditActionID. Inherited from AuditDataCore</summary>
		AuditActionID,
		///<summary>UserID. Inherited from AuditDataCore</summary>
		UserID,
		///<summary>AuditedOn. Inherited from AuditDataCore</summary>
		AuditedOn,
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
		///<summary>AuditDataID. Inherited from AuditDataCore</summary>
		AuditDataID_AuditDataCore,
		///<summary>AuditActionID. Inherited from AuditDataCore</summary>
		AuditActionID,
		///<summary>UserID. Inherited from AuditDataCore</summary>
		UserID,
		///<summary>AuditedOn. Inherited from AuditDataCore</summary>
		AuditedOn,
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
		///<summary>ForumID. </summary>
		ForumID,
		///<summary>SectionID. </summary>
		SectionID,
		///<summary>ForumName. </summary>
		ForumName,
		///<summary>ForumDescription. </summary>
		ForumDescription,
		///<summary>ForumLastPostingDate. </summary>
		ForumLastPostingDate,
		///<summary>HasRSSFeed. </summary>
		HasRSSFeed,
		///<summary>DefaultSupportQueueID. </summary>
		DefaultSupportQueueID,
		///<summary>DefaultThreadListInterval. </summary>
		DefaultThreadListInterval,
		///<summary>OrderNo. </summary>
		OrderNo,
		///<summary>MaxAttachmentSize. </summary>
		MaxAttachmentSize,
		///<summary>MaxNoOfAttachmentsPerMessage. </summary>
		MaxNoOfAttachmentsPerMessage,
		///<summary>NewThreadWelcomeText. </summary>
		NewThreadWelcomeText,
		///<summary>NewThreadWelcomeTextAsHTML. </summary>
		NewThreadWelcomeTextAsHTML,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ForumRoleForumActionRight.</summary>
	public enum ForumRoleForumActionRightFieldIndex
	{
		///<summary>ForumID. </summary>
		ForumID,
		///<summary>RoleID. </summary>
		RoleID,
		///<summary>ActionRightID. </summary>
		ActionRightID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IPBan.</summary>
	public enum IPBanFieldIndex
	{
		///<summary>IPBanID. </summary>
		IPBanID,
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
		///<summary>IPBanSetByUserID. </summary>
		IPBanSetByUserID,
		///<summary>IPBanSetOn. </summary>
		IPBanSetOn,
		///<summary>Reason. </summary>
		Reason,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Message.</summary>
	public enum MessageFieldIndex
	{
		///<summary>MessageID. </summary>
		MessageID,
		///<summary>PostingDate. </summary>
		PostingDate,
		///<summary>PostedByUserID. </summary>
		PostedByUserID,
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>PostedFromIP. </summary>
		PostedFromIP,
		///<summary>ChangeTrackerStamp. </summary>
		ChangeTrackerStamp,
		///<summary>MessageText. </summary>
		MessageText,
		///<summary>MessageTextAsHTML. </summary>
		MessageTextAsHTML,
		///<summary>MessageTextAsXml. </summary>
		MessageTextAsXml,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Role.</summary>
	public enum RoleFieldIndex
	{
		///<summary>RoleID. </summary>
		RoleID,
		///<summary>RoleDescription. </summary>
		RoleDescription,
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
		///<summary>RoleID. </summary>
		RoleID,
		///<summary>ActionRightID. </summary>
		ActionRightID,
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
		///<summary>SectionID. </summary>
		SectionID,
		///<summary>SectionName. </summary>
		SectionName,
		///<summary>SectionDescription. </summary>
		SectionDescription,
		///<summary>OrderNo. </summary>
		OrderNo,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SupportQueue.</summary>
	public enum SupportQueueFieldIndex
	{
		///<summary>QueueID. </summary>
		QueueID,
		///<summary>QueueName. </summary>
		QueueName,
		///<summary>QueueDescription. </summary>
		QueueDescription,
		///<summary>OrderNo. </summary>
		OrderNo,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SupportQueueThread.</summary>
	public enum SupportQueueThreadFieldIndex
	{
		///<summary>QueueID. </summary>
		QueueID,
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>PlacedInQueueByUserID. </summary>
		PlacedInQueueByUserID,
		///<summary>PlacedInQueueOn. </summary>
		PlacedInQueueOn,
		///<summary>ClaimedByUserID. </summary>
		ClaimedByUserID,
		///<summary>ClaimedOn. </summary>
		ClaimedOn,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SystemData.</summary>
	public enum SystemDataFieldIndex
	{
		///<summary>ID. </summary>
		ID,
		///<summary>DefaultRoleNewUser. </summary>
		DefaultRoleNewUser,
		///<summary>AnonymousRole. </summary>
		AnonymousRole,
		///<summary>DefaultUserTitleNewUser. </summary>
		DefaultUserTitleNewUser,
		///<summary>HoursThresholdForActiveThreads. </summary>
		HoursThresholdForActiveThreads,
		///<summary>PageSizeSearchResults. </summary>
		PageSizeSearchResults,
		///<summary>MinNumberOfThreadsToFetch. </summary>
		MinNumberOfThreadsToFetch,
		///<summary>MinNumberOfNonStickyVisibleThreads. </summary>
		MinNumberOfNonStickyVisibleThreads,
		///<summary>SendReplyNotifications. </summary>
		SendReplyNotifications,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Thread.</summary>
	public enum ThreadFieldIndex
	{
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>ForumID. </summary>
		ForumID,
		///<summary>Subject. </summary>
		Subject,
		///<summary>StartedByUserID. </summary>
		StartedByUserID,
		///<summary>ThreadLastPostingDate. </summary>
		ThreadLastPostingDate,
		///<summary>IsSticky. </summary>
		IsSticky,
		///<summary>IsClosed. </summary>
		IsClosed,
		///<summary>MarkedAsDone. </summary>
		MarkedAsDone,
		///<summary>NumberOfViews. </summary>
		NumberOfViews,
		///<summary>Memo. </summary>
		Memo,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ThreadSubscription.</summary>
	public enum ThreadSubscriptionFieldIndex
	{
		///<summary>UserID. </summary>
		UserID,
		///<summary>ThreadID. </summary>
		ThreadID,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: User.</summary>
	public enum UserFieldIndex
	{
		///<summary>UserID. </summary>
		UserID,
		///<summary>NickName. </summary>
		NickName,
		///<summary>Password. </summary>
		Password,
		///<summary>IsBanned. </summary>
		IsBanned,
		///<summary>IPNumber. </summary>
		IPNumber,
		///<summary>Signature. </summary>
		Signature,
		///<summary>IconURL. </summary>
		IconURL,
		///<summary>EmailAddress. </summary>
		EmailAddress,
		///<summary>UserTitleID. </summary>
		UserTitleID,
		///<summary>DateOfBirth. </summary>
		DateOfBirth,
		///<summary>Occupation. </summary>
		Occupation,
		///<summary>Location. </summary>
		Location,
		///<summary>Website. </summary>
		Website,
		///<summary>SignatureAsHTML. </summary>
		SignatureAsHTML,
		///<summary>JoinDate. </summary>
		JoinDate,
		///<summary>AmountOfPostings. </summary>
		AmountOfPostings,
		///<summary>EmailAddressIsPublic. </summary>
		EmailAddressIsPublic,
		///<summary>LastVisitedDate. </summary>
		LastVisitedDate,
		///<summary>AutoSubscribeToThread. </summary>
		AutoSubscribeToThread,
		///<summary>DefaultNumberOfMessagesPerPage. </summary>
		DefaultNumberOfMessagesPerPage,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserTitle.</summary>
	public enum UserTitleFieldIndex
	{
		///<summary>UserTitleID. </summary>
		UserTitleID,
		///<summary>UserTitleDescription. </summary>
		UserTitleDescription,
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

