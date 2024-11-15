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
	/// <summary>Entity class which represents the entity 'SupportQueueThread'.<br/><br/></summary>
	[Serializable]
	public partial class SupportQueueThreadEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private SupportQueueEntity _supportQueue;
		private UserEntity _claimedByUser;
		private UserEntity _placedInQueueByUser;
		private ThreadEntity _thread;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static SupportQueueThreadEntityStaticMetaData _staticMetaData = new SupportQueueThreadEntityStaticMetaData();
		private static SupportQueueThreadRelations _relationsFactory = new SupportQueueThreadRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name SupportQueue</summary>
			public static readonly string SupportQueue = "SupportQueue";
			/// <summary>Member name ClaimedByUser</summary>
			public static readonly string ClaimedByUser = "ClaimedByUser";
			/// <summary>Member name PlacedInQueueByUser</summary>
			public static readonly string PlacedInQueueByUser = "PlacedInQueueByUser";
			/// <summary>Member name Thread</summary>
			public static readonly string Thread = "Thread";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class SupportQueueThreadEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public SupportQueueThreadEntityStaticMetaData()
			{
				SetEntityCoreInfo("SupportQueueThreadEntity", InheritanceHierarchyType.None, false, (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, typeof(SupportQueueThreadEntity), typeof(SupportQueueThreadEntityFactory), false);
				AddNavigatorMetaData<SupportQueueThreadEntity, SupportQueueEntity>("SupportQueue", "SupportQueueThreads", (a, b) => a._supportQueue = b, a => a._supportQueue, (a, b) => a.SupportQueue = b, SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.SupportQueueEntityUsingQueueIDStatic, ()=>new SupportQueueThreadRelations().SupportQueueEntityUsingQueueID, null, new int[] { (int)SupportQueueThreadFieldIndex.QueueID }, null, true, (int)SD.HnD.DALAdapter.EntityType.SupportQueueEntity);
				AddNavigatorMetaData<SupportQueueThreadEntity, UserEntity>("ClaimedByUser", "SupportQueueThreadsClaimed", (a, b) => a._claimedByUser = b, a => a._claimedByUser, (a, b) => a.ClaimedByUser = b, SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingClaimedByUserIDStatic, ()=>new SupportQueueThreadRelations().UserEntityUsingClaimedByUserID, null, new int[] { (int)SupportQueueThreadFieldIndex.ClaimedByUserID }, null, true, (int)SD.HnD.DALAdapter.EntityType.UserEntity);
				AddNavigatorMetaData<SupportQueueThreadEntity, UserEntity>("PlacedInQueueByUser", "SupportQueueThreadsPlaced", (a, b) => a._placedInQueueByUser = b, a => a._placedInQueueByUser, (a, b) => a.PlacedInQueueByUser = b, SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingPlacedInQueueByUserIDStatic, ()=>new SupportQueueThreadRelations().UserEntityUsingPlacedInQueueByUserID, null, new int[] { (int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID }, null, true, (int)SD.HnD.DALAdapter.EntityType.UserEntity);
				AddNavigatorMetaData<SupportQueueThreadEntity, ThreadEntity>("Thread", "SupportQueueThread", (a, b) => a._thread = b, a => a._thread, (a, b) => a.Thread = b, SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.ThreadEntityUsingThreadIDStatic, ()=>new SupportQueueThreadRelations().ThreadEntityUsingThreadID, null, new int[] { (int)SupportQueueThreadFieldIndex.ThreadID }, null, false, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static SupportQueueThreadEntity()
		{
		}

		/// <summary> CTor</summary>
		public SupportQueueThreadEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SupportQueueThreadEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SupportQueueThreadEntity</param>
		public SupportQueueThreadEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID) : this(queueID, threadID, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="validator">The custom validator object for this SupportQueueThreadEntity</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.QueueID = queueID;
			this.ThreadID = threadID;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SupportQueueThreadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Method which will construct a filter (predicate expression) for the unique constraint defined on the fields: ThreadID .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCThreadID()
		{
			var filter = new PredicateExpression();
			filter.Add(SD.HnD.DALAdapter.HelperClasses.SupportQueueThreadFields.ThreadID == this.Fields.GetCurrentValue((int)SupportQueueThreadFieldIndex.ThreadID));
 			return filter;
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'SupportQueue' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSupportQueue() { return CreateRelationInfoForNavigator("SupportQueue"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClaimedByUser() { return CreateRelationInfoForNavigator("ClaimedByUser"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPlacedInQueueByUser() { return CreateRelationInfoForNavigator("PlacedInQueueByUser"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThread() { return CreateRelationInfoForNavigator("Thread"); }
		
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
		/// <param name="validator">The validator object for this SupportQueueThreadEntity</param>
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
		public static SupportQueueThreadRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueue' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSupportQueue { get { return _staticMetaData.GetPrefetchPathElement("SupportQueue", CommonEntityBase.CreateEntityCollection<SupportQueueEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClaimedByUser { get { return _staticMetaData.GetPrefetchPathElement("ClaimedByUser", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPlacedInQueueByUser { get { return _staticMetaData.GetPrefetchPathElement("PlacedInQueueByUser", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThread { get { return _staticMetaData.GetPrefetchPathElement("Thread", CommonEntityBase.CreateEntityCollection<ThreadEntity>()); } }

		/// <summary>The QueueID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."QueueID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		[Required]
		public virtual System.Int32 QueueID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.QueueID, true); }
			set { SetValue((int)SupportQueueThreadFieldIndex.QueueID, value); }
		}

		/// <summary>The ThreadID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ThreadID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		[Required]
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.ThreadID, true); }
			set { SetValue((int)SupportQueueThreadFieldIndex.ThreadID, value); }
		}

		/// <summary>The PlacedInQueueByUserID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."PlacedInQueueByUserID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 PlacedInQueueByUserID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, true); }
			set { SetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, value); }
		}

		/// <summary>The PlacedInQueueOn property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."PlacedInQueueOn".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.DateTime PlacedInQueueOn
		{
			get { return (System.DateTime)GetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueOn, true); }
			set { SetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueOn, value); }
		}

		/// <summary>The ClaimedByUserID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ClaimedByUserID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ClaimedByUserID
		{
			get { return (Nullable<System.Int32>)GetValue((int)SupportQueueThreadFieldIndex.ClaimedByUserID, false); }
			set { SetValue((int)SupportQueueThreadFieldIndex.ClaimedByUserID, value); }
		}

		/// <summary>The ClaimedOn property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ClaimedOn".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ClaimedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)SupportQueueThreadFieldIndex.ClaimedOn, false); }
			set { SetValue((int)SupportQueueThreadFieldIndex.ClaimedOn, value); }
		}

		/// <summary>Gets / sets related entity of type 'SupportQueueEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual SupportQueueEntity SupportQueue
		{
			get { return _supportQueue; }
			set { SetSingleRelatedEntityNavigator(value, "SupportQueue"); }
		}

		/// <summary>Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity ClaimedByUser
		{
			get { return _claimedByUser; }
			set { SetSingleRelatedEntityNavigator(value, "ClaimedByUser"); }
		}

		/// <summary>Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity PlacedInQueueByUser
		{
			get { return _placedInQueueByUser; }
			set { SetSingleRelatedEntityNavigator(value, "PlacedInQueueByUser"); }
		}

		/// <summary>Gets / sets related entity of type 'ThreadEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/></summary>
		[Browsable(true)]
		public virtual ThreadEntity Thread
		{
			get { return _thread; }
			set { SetSingleRelatedEntityNavigator(value, "Thread"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace SD.HnD.DALAdapter
{
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
}

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: SupportQueueThread. </summary>
	public partial class SupportQueueThreadRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and ThreadEntity over the 1:1 relation they have, using the relation between the fields: SupportQueueThread.ThreadID - Thread.ThreadID</summary>
		public virtual IEntityRelation ThreadEntityUsingThreadID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToOne, "Thread", false, new[] { ThreadFields.ThreadID, SupportQueueThreadFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and SupportQueueEntity over the m:1 relation they have, using the relation between the fields: SupportQueueThread.QueueID - SupportQueue.QueueID</summary>
		public virtual IEntityRelation SupportQueueEntityUsingQueueID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "SupportQueue", false, new[] { SupportQueueFields.QueueID, SupportQueueThreadFields.QueueID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and UserEntity over the m:1 relation they have, using the relation between the fields: SupportQueueThread.ClaimedByUserID - User.UserID</summary>
		public virtual IEntityRelation UserEntityUsingClaimedByUserID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "ClaimedByUser", false, new[] { UserFields.UserID, SupportQueueThreadFields.ClaimedByUserID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and UserEntity over the m:1 relation they have, using the relation between the fields: SupportQueueThread.PlacedInQueueByUserID - User.UserID</summary>
		public virtual IEntityRelation UserEntityUsingPlacedInQueueByUserID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "PlacedInQueueByUser", false, new[] { UserFields.UserID, SupportQueueThreadFields.PlacedInQueueByUserID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticSupportQueueThreadRelations
	{
		internal static readonly IEntityRelation ThreadEntityUsingThreadIDStatic = new SupportQueueThreadRelations().ThreadEntityUsingThreadID;
		internal static readonly IEntityRelation SupportQueueEntityUsingQueueIDStatic = new SupportQueueThreadRelations().SupportQueueEntityUsingQueueID;
		internal static readonly IEntityRelation UserEntityUsingClaimedByUserIDStatic = new SupportQueueThreadRelations().UserEntityUsingClaimedByUserID;
		internal static readonly IEntityRelation UserEntityUsingPlacedInQueueByUserIDStatic = new SupportQueueThreadRelations().UserEntityUsingPlacedInQueueByUserID;

		/// <summary>CTor</summary>
		static StaticSupportQueueThreadRelations() { }
	}
}
