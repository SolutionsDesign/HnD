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
	/// <summary>Entity class which represents the entity 'AuditDataThreadRelated'.<br/><br/></summary>
	[Serializable]
	public partial class AuditDataThreadRelatedEntity : AuditDataCoreEntity
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private ThreadEntity _thread;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static AuditDataThreadRelatedEntityStaticMetaData _staticMetaData = new AuditDataThreadRelatedEntityStaticMetaData();
		private static AuditDataThreadRelatedRelations _relationsFactory = new AuditDataThreadRelatedRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public new static partial class MemberNames
		{
			/// <summary>Member name AuditAction</summary>
			public static readonly string AuditAction = "AuditAction";
			/// <summary>Member name Thread</summary>
			public static readonly string Thread = "Thread";
			/// <summary>Member name UserAudited</summary>
			public static readonly string UserAudited = "UserAudited";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class AuditDataThreadRelatedEntityStaticMetaData : AuditDataCoreEntityStaticMetaData
		{
			public AuditDataThreadRelatedEntityStaticMetaData()
			{
				SetEntityCoreInfo("AuditDataThreadRelatedEntity", InheritanceHierarchyType.TargetPerEntity, true, (int)SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity, typeof(AuditDataThreadRelatedEntity), typeof(AuditDataThreadRelatedEntityFactory), false);
				AddNavigatorMetaData<AuditDataThreadRelatedEntity, ThreadEntity>("Thread", "AuditDataThreadRelated", (a, b) => a._thread = b, a => a._thread, (a, b) => a.Thread = b, SD.HnD.DALAdapter.RelationClasses.StaticAuditDataThreadRelatedRelations.ThreadEntityUsingThreadIDStatic, ()=>new AuditDataThreadRelatedRelations().ThreadEntityUsingThreadID, null, new int[] { (int)AuditDataThreadRelatedFieldIndex.ThreadID }, null, true, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static AuditDataThreadRelatedEntity()
		{
		}

		/// <summary> CTor</summary>
		public AuditDataThreadRelatedEntity()
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AuditDataThreadRelatedEntity(IEntityFields2 fields) : base(fields)
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AuditDataThreadRelatedEntity</param>
		public AuditDataThreadRelatedEntity(IValidator validator) : base(validator)
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		public AuditDataThreadRelatedEntity(System.Int32 auditDataID) : base(auditDataID)
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		/// <param name="validator">The custom validator object for this AuditDataThreadRelatedEntity</param>
		public AuditDataThreadRelatedEntity(System.Int32 auditDataID, IValidator validator) : base(auditDataID, validator)
		{
			InitClassEmpty();
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AuditDataThreadRelatedEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Gets a predicateexpression which filters on this entity. Only useful in entity fetches</summary>
		/// <param name="negate">Optional flag to produce a NOT filter, (true), or a normal filter (false, default). </param>
		/// <returns>ready to use predicateexpression</returns>
		public new static IPredicateExpression GetEntityTypeFilter(bool negate=false) { return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter("AuditDataThreadRelatedEntity", negate); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThread() { return CreateRelationInfoForNavigator("Thread"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		private void InitClassEmpty()
		{
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public new static AuditDataThreadRelatedRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThread { get { return _staticMetaData.GetPrefetchPathElement("Thread", CommonEntityBase.CreateEntityCollection<ThreadEntity>()); } }

		/// <summary>The ThreadID property of the Entity AuditDataThreadRelated<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AuditDataThreadRelated"."ThreadID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)AuditDataThreadRelatedFieldIndex.ThreadID, true); }
			set { SetValue((int)AuditDataThreadRelatedFieldIndex.ThreadID, value); }
		}

		/// <summary>Gets / sets related entity of type 'ThreadEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
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
}

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: AuditDataThreadRelated. </summary>
	public partial class AuditDataThreadRelatedRelations: AuditDataCoreRelations
	{

		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and AuditActionEntity over the m:1 relation they have, using the relation between the fields: AuditDataThreadRelated.AuditActionID - AuditAction.AuditActionID</summary>
		public override IEntityRelation AuditActionEntityUsingAuditActionID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "AuditAction", false, new[] { AuditActionFields.AuditActionID, AuditDataThreadRelatedFields.AuditActionID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and ThreadEntity over the m:1 relation they have, using the relation between the fields: AuditDataThreadRelated.ThreadID - Thread.ThreadID</summary>
		public virtual IEntityRelation ThreadEntityUsingThreadID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Thread", false, new[] { ThreadFields.ThreadID, AuditDataThreadRelatedFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and UserEntity over the m:1 relation they have, using the relation between the fields: AuditDataThreadRelated.UserID - User.UserID</summary>
		public override IEntityRelation UserEntityUsingUserID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "UserAudited", false, new[] { UserFields.UserID, AuditDataThreadRelatedFields.UserID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and AuditDataCoreEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>
		internal IEntityRelation RelationToSuperTypeAuditDataCoreEntity
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateHierarchyRelation(false, new[] { AuditDataCoreFields.AuditDataID, AuditDataThreadRelatedFields.AuditDataID }); }
		}

		/// <inheritdoc/>
		public override IEntityRelation GetSubTypeRelation(string subTypeEntityName)
		{
			return null;
		}
		
		/// <inheritdoc/>
		public override IEntityRelation GetSuperTypeRelation()	{ return this.RelationToSuperTypeAuditDataCoreEntity; }

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAuditDataThreadRelatedRelations
	{
		internal static readonly IEntityRelation AuditActionEntityUsingAuditActionIDStatic = new AuditDataThreadRelatedRelations().AuditActionEntityUsingAuditActionID;
		internal static readonly IEntityRelation ThreadEntityUsingThreadIDStatic = new AuditDataThreadRelatedRelations().ThreadEntityUsingThreadID;
		internal static readonly IEntityRelation UserEntityUsingUserIDStatic = new AuditDataThreadRelatedRelations().UserEntityUsingUserID;

		/// <summary>CTor</summary>
		static StaticAuditDataThreadRelatedRelations() { }
	}
}
