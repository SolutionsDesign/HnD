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
	/// <summary>Entity class which represents the entity 'IPBan'.<br/><br/></summary>
	[Serializable]
	public partial class IPBanEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private UserEntity _setByUser;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static IPBanEntityStaticMetaData _staticMetaData = new IPBanEntityStaticMetaData();
		private static IPBanRelations _relationsFactory = new IPBanRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name SetByUser</summary>
			public static readonly string SetByUser = "SetByUser";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class IPBanEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public IPBanEntityStaticMetaData()
			{
				SetEntityCoreInfo("IPBanEntity", InheritanceHierarchyType.None, false, (int)SD.HnD.DALAdapter.EntityType.IPBanEntity, typeof(IPBanEntity), typeof(IPBanEntityFactory), false);
				AddNavigatorMetaData<IPBanEntity, UserEntity>("SetByUser", "IPBansSet", (a, b) => a._setByUser = b, a => a._setByUser, (a, b) => a.SetByUser = b, SD.HnD.DALAdapter.RelationClasses.StaticIPBanRelations.UserEntityUsingIPBanSetByUserIDStatic, ()=>new IPBanRelations().UserEntityUsingIPBanSetByUserID, new string[] { "SetByUserNickName" }, new int[] { (int)IPBanFieldIndex.IPBanSetByUserID }, a => a.OnSetByUserPropertyChanged, true, (int)SD.HnD.DALAdapter.EntityType.UserEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static IPBanEntity()
		{
		}

		/// <summary> CTor</summary>
		public IPBanEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public IPBanEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this IPBanEntity</param>
		public IPBanEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		public IPBanEntity(System.Int32 iPBanID) : this(iPBanID, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="validator">The custom validator object for this IPBanEntity</param>
		public IPBanEntity(System.Int32 iPBanID, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.IPBanID = iPBanID;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected IPBanEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSetByUser() { return CreateRelationInfoForNavigator("SetByUser"); }
		
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

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSetByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				case "NickName":
					this.OnPropertyChanged("SetByUserNickName");
					break;
			}
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this IPBanEntity</param>
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
		public static IPBanRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSetByUser { get { return _staticMetaData.GetPrefetchPathElement("SetByUser", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>The IPBanID property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPBanID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		[Required]
		public virtual System.Int32 IPBanID
		{
			get { return (System.Int32)GetValue((int)IPBanFieldIndex.IPBanID, true); }
			set { SetValue((int)IPBanFieldIndex.IPBanID, value); }
		}

		/// <summary>The IPSegment1 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment1".<br/>Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Byte IPSegment1
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment1, true); }
			set { SetValue((int)IPBanFieldIndex.IPSegment1, value); }
		}

		/// <summary>The IPSegment2 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment2".<br/>Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Byte IPSegment2
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment2, true); }
			set { SetValue((int)IPBanFieldIndex.IPSegment2, value); }
		}

		/// <summary>The IPSegment3 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment3".<br/>Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Byte IPSegment3
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment3, true); }
			set { SetValue((int)IPBanFieldIndex.IPSegment3, value); }
		}

		/// <summary>The IPSegment4 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment4".<br/>Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Byte IPSegment4
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment4, true); }
			set { SetValue((int)IPBanFieldIndex.IPSegment4, value); }
		}

		/// <summary>The Range property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."Range".<br/>Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Byte Range
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.Range, true); }
			set { SetValue((int)IPBanFieldIndex.Range, value); }
		}

		/// <summary>The IPBanSetByUserID property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPBanSetByUserID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 IPBanSetByUserID
		{
			get { return (System.Int32)GetValue((int)IPBanFieldIndex.IPBanSetByUserID, true); }
			set { SetValue((int)IPBanFieldIndex.IPBanSetByUserID, value); }
		}

		/// <summary>The IPBanSetOn property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPBanSetOn".<br/>Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.DateTime IPBanSetOn
		{
			get { return (System.DateTime)GetValue((int)IPBanFieldIndex.IPBanSetOn, true); }
			set { SetValue((int)IPBanFieldIndex.IPBanSetOn, value); }
		}

		/// <summary>The Reason property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."Reason".<br/>Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[StringLength(1073741823)]
		[MinLength(2)]
		public virtual System.String Reason
		{
			get { return (System.String)GetValue((int)IPBanFieldIndex.Reason, true); }
			set { SetValue((int)IPBanFieldIndex.Reason, value); }
		}

		/// <summary>Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity SetByUser
		{
			get { return _setByUser; }
			set { SetSingleRelatedEntityNavigator(value, "SetByUser"); }
		}
 
		/// <summary>Gets / Sets the value of the related field this.SetByUser.NickName.<br/><br/></summary>
		public virtual System.String SetByUserNickName
		{
			get { return this.SetByUser==null ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : this.SetByUser.NickName; }
			set
			{
				UserEntity relatedEntity = this.SetByUser;
				if(relatedEntity!=null)
				{
					relatedEntity.NickName = value;
				}				
			}
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace SD.HnD.DALAdapter
{
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
}

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: IPBan. </summary>
	public partial class IPBanRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between IPBanEntity and UserEntity over the m:1 relation they have, using the relation between the fields: IPBan.IPBanSetByUserID - User.UserID</summary>
		public virtual IEntityRelation UserEntityUsingIPBanSetByUserID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "SetByUser", false, new[] { UserFields.UserID, IPBanFields.IPBanSetByUserID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticIPBanRelations
	{
		internal static readonly IEntityRelation UserEntityUsingIPBanSetByUserIDStatic = new IPBanRelations().UserEntityUsingIPBanSetByUserID;

		/// <summary>CTor</summary>
		static StaticIPBanRelations() { }
	}
}
