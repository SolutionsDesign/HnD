﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.7.</auto-generated>
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
	/// <summary>Entity class which represents the entity 'SystemData'.<br/><br/></summary>
	[Serializable]
	public partial class SystemDataEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private RoleEntity _roleForAnonymous;
		private RoleEntity _roleForNewUser;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static SystemDataEntityStaticMetaData _staticMetaData = new SystemDataEntityStaticMetaData();
		private static SystemDataRelations _relationsFactory = new SystemDataRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name RoleForAnonymous</summary>
			public static readonly string RoleForAnonymous = "RoleForAnonymous";
			/// <summary>Member name RoleForNewUser</summary>
			public static readonly string RoleForNewUser = "RoleForNewUser";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class SystemDataEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public SystemDataEntityStaticMetaData()
			{
				SetEntityCoreInfo("SystemDataEntity", InheritanceHierarchyType.None, false, (int)SD.HnD.DALAdapter.EntityType.SystemDataEntity, typeof(SystemDataEntity), typeof(SystemDataEntityFactory), false);
				AddNavigatorMetaData<SystemDataEntity, RoleEntity>("RoleForAnonymous", "SystemDataAnonymousRole", (a, b) => a._roleForAnonymous = b, a => a._roleForAnonymous, (a, b) => a.RoleForAnonymous = b, SD.HnD.DALAdapter.RelationClasses.StaticSystemDataRelations.RoleEntityUsingAnonymousRoleStatic, ()=>new SystemDataRelations().RoleEntityUsingAnonymousRole, null, new int[] { (int)SystemDataFieldIndex.AnonymousRole }, null, true, (int)SD.HnD.DALAdapter.EntityType.RoleEntity);
				AddNavigatorMetaData<SystemDataEntity, RoleEntity>("RoleForNewUser", "SystemDataDefaultRoleNewUser", (a, b) => a._roleForNewUser = b, a => a._roleForNewUser, (a, b) => a.RoleForNewUser = b, SD.HnD.DALAdapter.RelationClasses.StaticSystemDataRelations.RoleEntityUsingDefaultRoleNewUserStatic, ()=>new SystemDataRelations().RoleEntityUsingDefaultRoleNewUser, null, new int[] { (int)SystemDataFieldIndex.DefaultRoleNewUser }, null, true, (int)SD.HnD.DALAdapter.EntityType.RoleEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static SystemDataEntity()
		{
		}

		/// <summary> CTor</summary>
		public SystemDataEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SystemDataEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SystemDataEntity</param>
		public SystemDataEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		public SystemDataEntity(System.Int32 iD) : this(iD, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="validator">The custom validator object for this SystemDataEntity</param>
		public SystemDataEntity(System.Int32 iD, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SystemDataEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleForAnonymous() { return CreateRelationInfoForNavigator("RoleForAnonymous"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleForNewUser() { return CreateRelationInfoForNavigator("RoleForNewUser"); }
		
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
		/// <param name="validator">The validator object for this SystemDataEntity</param>
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
		public static SystemDataRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleForAnonymous { get { return _staticMetaData.GetPrefetchPathElement("RoleForAnonymous", CommonEntityBase.CreateEntityCollection<RoleEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleForNewUser { get { return _staticMetaData.GetPrefetchPathElement("RoleForNewUser", CommonEntityBase.CreateEntityCollection<RoleEntity>()); } }

		/// <summary>The ID property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."ID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		[Required]
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.ID, true); }
			set { SetValue((int)SystemDataFieldIndex.ID, value); }		}

		/// <summary>The DefaultRoleNewUser property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."DefaultRoleNewUser".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 DefaultRoleNewUser
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.DefaultRoleNewUser, true); }
			set	{ SetValue((int)SystemDataFieldIndex.DefaultRoleNewUser, value); }
		}

		/// <summary>The AnonymousRole property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."AnonymousRole".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 AnonymousRole
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.AnonymousRole, true); }
			set	{ SetValue((int)SystemDataFieldIndex.AnonymousRole, value); }
		}

		/// <summary>The DefaultUserTitleNewUser property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."DefaultUserTitleNewUser".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 DefaultUserTitleNewUser
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.DefaultUserTitleNewUser, true); }
			set	{ SetValue((int)SystemDataFieldIndex.DefaultUserTitleNewUser, value); }
		}

		/// <summary>The HoursThresholdForActiveThreads property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."HoursThresholdForActiveThreads".<br/>Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[Range(1, 1000)]
		public virtual System.Int16 HoursThresholdForActiveThreads
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.HoursThresholdForActiveThreads, true); }
			set	{ SetValue((int)SystemDataFieldIndex.HoursThresholdForActiveThreads, value); }
		}

		/// <summary>The PageSizeSearchResults property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."PageSizeSearchResults".<br/>Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[Range(2, 1000)]
		public virtual System.Int16 PageSizeSearchResults
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.PageSizeSearchResults, true); }
			set	{ SetValue((int)SystemDataFieldIndex.PageSizeSearchResults, value); }
		}

		/// <summary>The MinNumberOfThreadsToFetch property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."MinNumberOfThreadsToFetch".<br/>Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[Range(1, 1000)]
		public virtual System.Int16 MinNumberOfThreadsToFetch
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, true); }
			set	{ SetValue((int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, value); }
		}

		/// <summary>The MinNumberOfNonStickyVisibleThreads property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."MinNumberOfNonStickyVisibleThreads".<br/>Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[Range(1, 1000)]
		public virtual System.Int16 MinNumberOfNonStickyVisibleThreads
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, true); }
			set	{ SetValue((int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, value); }
		}

		/// <summary>The SendReplyNotifications property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."SendReplyNotifications".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Boolean SendReplyNotifications
		{
			get { return (System.Boolean)GetValue((int)SystemDataFieldIndex.SendReplyNotifications, true); }
			set	{ SetValue((int)SystemDataFieldIndex.SendReplyNotifications, value); }
		}

		/// <summary>Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual RoleEntity RoleForAnonymous
		{
			get { return _roleForAnonymous; }
			set { SetSingleRelatedEntityNavigator(value, "RoleForAnonymous"); }
		}

		/// <summary>Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual RoleEntity RoleForNewUser
		{
			get { return _roleForNewUser; }
			set { SetSingleRelatedEntityNavigator(value, "RoleForNewUser"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace SD.HnD.DALAdapter
{
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
}

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: SystemData. </summary>
	public partial class SystemDataRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between SystemDataEntity and RoleEntity over the m:1 relation they have, using the relation between the fields: SystemData.AnonymousRole - Role.RoleID</summary>
		public virtual IEntityRelation RoleEntityUsingAnonymousRole
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "RoleForAnonymous", false, new[] { RoleFields.RoleID, SystemDataFields.AnonymousRole }); }
		}

		/// <summary>Returns a new IEntityRelation object, between SystemDataEntity and RoleEntity over the m:1 relation they have, using the relation between the fields: SystemData.DefaultRoleNewUser - Role.RoleID</summary>
		public virtual IEntityRelation RoleEntityUsingDefaultRoleNewUser
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "RoleForNewUser", false, new[] { RoleFields.RoleID, SystemDataFields.DefaultRoleNewUser }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticSystemDataRelations
	{
		internal static readonly IEntityRelation RoleEntityUsingAnonymousRoleStatic = new SystemDataRelations().RoleEntityUsingAnonymousRole;
		internal static readonly IEntityRelation RoleEntityUsingDefaultRoleNewUserStatic = new SystemDataRelations().RoleEntityUsingDefaultRoleNewUser;

		/// <summary>CTor</summary>
		static StaticSystemDataRelations() { }
	}
}
