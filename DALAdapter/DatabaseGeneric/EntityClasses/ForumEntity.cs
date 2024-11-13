﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.11.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.RelationClasses;
using System.ComponentModel.DataAnnotations;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'Forum'.<br/><br/></summary>
	[Serializable]
	public partial class ForumEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private EntityCollection<ForumRoleForumActionRightEntity> _forumRoleForumActionRights;
		private EntityCollection<ThreadEntity> _threads;
		private EntityCollection<UserEntity> _usersWhoStartedThreads;
		private SectionEntity _section;
		private SupportQueueEntity _defaultSupportQueue;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static ForumEntityStaticMetaData _staticMetaData = new ForumEntityStaticMetaData();
		private static ForumRelations _relationsFactory = new ForumRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Section</summary>
			public static readonly string Section = "Section";
			/// <summary>Member name DefaultSupportQueue</summary>
			public static readonly string DefaultSupportQueue = "DefaultSupportQueue";
			/// <summary>Member name ForumRoleForumActionRights</summary>
			public static readonly string ForumRoleForumActionRights = "ForumRoleForumActionRights";
			/// <summary>Member name Threads</summary>
			public static readonly string Threads = "Threads";
			/// <summary>Member name UsersWhoStartedThreads</summary>
			public static readonly string UsersWhoStartedThreads = "UsersWhoStartedThreads";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class ForumEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public ForumEntityStaticMetaData()
			{
				SetEntityCoreInfo("ForumEntity", InheritanceHierarchyType.None, false, (int)SD.HnD.DALAdapter.EntityType.ForumEntity, typeof(ForumEntity), typeof(ForumEntityFactory), false);
				AddNavigatorMetaData<ForumEntity, EntityCollection<ForumRoleForumActionRightEntity>>("ForumRoleForumActionRights", a => a._forumRoleForumActionRights, (a, b) => a._forumRoleForumActionRights = b, a => a.ForumRoleForumActionRights, () => new ForumRelations().ForumRoleForumActionRightEntityUsingForumID, typeof(ForumRoleForumActionRightEntity), (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity);
				AddNavigatorMetaData<ForumEntity, EntityCollection<ThreadEntity>>("Threads", a => a._threads, (a, b) => a._threads = b, a => a.Threads, () => new ForumRelations().ThreadEntityUsingForumID, typeof(ThreadEntity), (int)SD.HnD.DALAdapter.EntityType.ThreadEntity);
				AddNavigatorMetaData<ForumEntity, SectionEntity>("Section", "Forums", (a, b) => a._section = b, a => a._section, (a, b) => a.Section = b, SD.HnD.DALAdapter.RelationClasses.StaticForumRelations.SectionEntityUsingSectionIDStatic, ()=>new ForumRelations().SectionEntityUsingSectionID, null, new int[] { (int)ForumFieldIndex.SectionID }, null, true, (int)SD.HnD.DALAdapter.EntityType.SectionEntity);
				AddNavigatorMetaData<ForumEntity, SupportQueueEntity>("DefaultSupportQueue", "DefaultForForums", (a, b) => a._defaultSupportQueue = b, a => a._defaultSupportQueue, (a, b) => a.DefaultSupportQueue = b, SD.HnD.DALAdapter.RelationClasses.StaticForumRelations.SupportQueueEntityUsingDefaultSupportQueueIDStatic, ()=>new ForumRelations().SupportQueueEntityUsingDefaultSupportQueueID, null, new int[] { (int)ForumFieldIndex.DefaultSupportQueueID }, null, true, (int)SD.HnD.DALAdapter.EntityType.SupportQueueEntity);
				AddNavigatorMetaData<ForumEntity, EntityCollection<UserEntity>>("UsersWhoStartedThreads", a => a._usersWhoStartedThreads, (a, b) => a._usersWhoStartedThreads = b, a => a.UsersWhoStartedThreads, () => new ForumRelations().ThreadEntityUsingForumID, () => new ThreadRelations().UserEntityUsingStartedByUserID, "ForumEntity__", "Thread_", typeof(UserEntity), (int)SD.HnD.DALAdapter.EntityType.UserEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static ForumEntity()
		{
		}

		/// <summary> CTor</summary>
		public ForumEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ForumEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ForumEntity</param>
		public ForumEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		public ForumEntity(System.Int32 forumID) : this(forumID, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="validator">The custom validator object for this ForumEntity</param>
		public ForumEntity(System.Int32 forumID, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ForumID = forumID;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ForumRoleForumActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoForumRoleForumActionRights() { return CreateRelationInfoForNavigator("ForumRoleForumActionRights"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThreads() { return CreateRelationInfoForNavigator("Threads"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoStartedThreads() { return CreateRelationInfoForNavigator("UsersWhoStartedThreads"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Section' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSection() { return CreateRelationInfoForNavigator("Section"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'SupportQueue' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDefaultSupportQueue() { return CreateRelationInfoForNavigator("DefaultSupportQueue"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ForumEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static ForumRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ForumRoleForumActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathForumRoleForumActionRights { get { return _staticMetaData.GetPrefetchPathElement("ForumRoleForumActionRights", CommonEntityBase.CreateEntityCollection<ForumRoleForumActionRightEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThreads { get { return _staticMetaData.GetPrefetchPathElement("Threads", CommonEntityBase.CreateEntityCollection<ThreadEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoStartedThreads { get { return _staticMetaData.GetPrefetchPathElement("UsersWhoStartedThreads", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Section' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSection { get { return _staticMetaData.GetPrefetchPathElement("Section", CommonEntityBase.CreateEntityCollection<SectionEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueue' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDefaultSupportQueue { get { return _staticMetaData.GetPrefetchPathElement("DefaultSupportQueue", CommonEntityBase.CreateEntityCollection<SupportQueueEntity>()); } }

		/// <summary>The ForumID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		[Required]
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.ForumID, true); }
			set { SetValue((int)ForumFieldIndex.ForumID, value); }
		}

		/// <summary>The SectionID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."SectionID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 SectionID
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.SectionID, true); }
			set { SetValue((int)ForumFieldIndex.SectionID, value); }
		}

		/// <summary>The ForumName property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumName".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[StringLength(50)]
		[MinLength(2)]
		public virtual System.String ForumName
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.ForumName, true); }
			set { SetValue((int)ForumFieldIndex.ForumName, value); }
		}

		/// <summary>The ForumDescription property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumDescription".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[StringLength(250)]
		[MinLength(2)]
		public virtual System.String ForumDescription
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.ForumDescription, true); }
			set { SetValue((int)ForumFieldIndex.ForumDescription, value); }
		}

		/// <summary>The ForumLastPostingDate property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumLastPostingDate".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ForumLastPostingDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ForumFieldIndex.ForumLastPostingDate, false); }
			set { SetValue((int)ForumFieldIndex.ForumLastPostingDate, value); }
		}

		/// <summary>The HasRSSFeed property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."HasRSSFeed".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Boolean HasRSSFeed
		{
			get { return (System.Boolean)GetValue((int)ForumFieldIndex.HasRSSFeed, true); }
			set { SetValue((int)ForumFieldIndex.HasRSSFeed, value); }
		}

		/// <summary>The DefaultSupportQueueID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."DefaultSupportQueueID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DefaultSupportQueueID
		{
			get { return (Nullable<System.Int32>)GetValue((int)ForumFieldIndex.DefaultSupportQueueID, false); }
			set { SetValue((int)ForumFieldIndex.DefaultSupportQueueID, value); }
		}

		/// <summary>The OrderNo property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."OrderNo".<br/>Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int16 OrderNo
		{
			get { return (System.Int16)GetValue((int)ForumFieldIndex.OrderNo, true); }
			set { SetValue((int)ForumFieldIndex.OrderNo, value); }
		}

		/// <summary>The MaxAttachmentSize property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."MaxAttachmentSize".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int32 MaxAttachmentSize
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.MaxAttachmentSize, true); }
			set { SetValue((int)ForumFieldIndex.MaxAttachmentSize, value); }
		}

		/// <summary>The MaxNoOfAttachmentsPerMessage property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."MaxNoOfAttachmentsPerMessage".<br/>Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int16 MaxNoOfAttachmentsPerMessage
		{
			get { return (System.Int16)GetValue((int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, true); }
			set { SetValue((int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, value); }
		}

		/// <summary>The NewThreadWelcomeText property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."NewThreadWelcomeText".<br/>Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		[StringLength(1073741823)]
		public virtual System.String NewThreadWelcomeText
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.NewThreadWelcomeText, true); }
			set { SetValue((int)ForumFieldIndex.NewThreadWelcomeText, value); }
		}

		/// <summary>The NewThreadWelcomeTextAsHTML property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."NewThreadWelcomeTextAsHTML".<br/>Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		[StringLength(1073741823)]
		public virtual System.String NewThreadWelcomeTextAsHTML
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, true); }
			set { SetValue((int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'ForumRoleForumActionRightEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ForumRoleForumActionRightEntity))]
		public virtual EntityCollection<ForumRoleForumActionRightEntity> ForumRoleForumActionRights { get { return GetOrCreateEntityCollection<ForumRoleForumActionRightEntity, ForumRoleForumActionRightEntityFactory>("Forum", true, false, ref _forumRoleForumActionRights); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'ThreadEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadEntity))]
		public virtual EntityCollection<ThreadEntity> Threads { get { return GetOrCreateEntityCollection<ThreadEntity, ThreadEntityFactory>("Forum", true, false, ref _threads); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoStartedThreads { get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("StartedThreadsInForums", false, true, ref _usersWhoStartedThreads); } }

		/// <summary>Gets / sets related entity of type 'SectionEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual SectionEntity Section
		{
			get { return _section; }
			set { SetSingleRelatedEntityNavigator(value, "Section"); }
		}

		/// <summary>Gets / sets related entity of type 'SupportQueueEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual SupportQueueEntity DefaultSupportQueue
		{
			get { return _defaultSupportQueue; }
			set { SetSingleRelatedEntityNavigator(value, "DefaultSupportQueue"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace SD.HnD.DALAdapter
{
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
}

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Forum. </summary>
	public partial class ForumRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between ForumEntity and ForumRoleForumActionRightEntity over the 1:n relation they have, using the relation between the fields: Forum.ForumID - ForumRoleForumActionRight.ForumID</summary>
		public virtual IEntityRelation ForumRoleForumActionRightEntityUsingForumID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "ForumRoleForumActionRights", true, new[] { ForumFields.ForumID, ForumRoleForumActionRightFields.ForumID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ForumEntity and ThreadEntity over the 1:n relation they have, using the relation between the fields: Forum.ForumID - Thread.ForumID</summary>
		public virtual IEntityRelation ThreadEntityUsingForumID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "Threads", true, new[] { ForumFields.ForumID, ThreadFields.ForumID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ForumEntity and SectionEntity over the m:1 relation they have, using the relation between the fields: Forum.SectionID - Section.SectionID</summary>
		public virtual IEntityRelation SectionEntityUsingSectionID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Section", false, new[] { SectionFields.SectionID, ForumFields.SectionID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ForumEntity and SupportQueueEntity over the m:1 relation they have, using the relation between the fields: Forum.DefaultSupportQueueID - SupportQueue.QueueID</summary>
		public virtual IEntityRelation SupportQueueEntityUsingDefaultSupportQueueID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "DefaultSupportQueue", false, new[] { SupportQueueFields.QueueID, ForumFields.DefaultSupportQueueID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticForumRelations
	{
		internal static readonly IEntityRelation ForumRoleForumActionRightEntityUsingForumIDStatic = new ForumRelations().ForumRoleForumActionRightEntityUsingForumID;
		internal static readonly IEntityRelation ThreadEntityUsingForumIDStatic = new ForumRelations().ThreadEntityUsingForumID;
		internal static readonly IEntityRelation SectionEntityUsingSectionIDStatic = new ForumRelations().SectionEntityUsingSectionID;
		internal static readonly IEntityRelation SupportQueueEntityUsingDefaultSupportQueueIDStatic = new ForumRelations().SupportQueueEntityUsingDefaultSupportQueueID;

		/// <summary>CTor</summary>
		static StaticForumRelations() { }
	}
}
