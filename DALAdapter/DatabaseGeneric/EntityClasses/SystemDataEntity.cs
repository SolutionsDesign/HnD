///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.2
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.RelationClasses;

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
		#region Class Member Declarations
		private RoleEntity _roleForAnonymous;
		private RoleEntity _roleForNewUser;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name RoleForAnonymous</summary>
			public static readonly string RoleForAnonymous = "RoleForAnonymous";
			/// <summary>Member name RoleForNewUser</summary>
			public static readonly string RoleForNewUser = "RoleForNewUser";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SystemDataEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public SystemDataEntity():base("SystemDataEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SystemDataEntity(IEntityFields2 fields):base("SystemDataEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SystemDataEntity</param>
		public SystemDataEntity(IValidator validator):base("SystemDataEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SystemDataEntity(System.Int32 iD):base("SystemDataEntity")
		{
			InitClassEmpty(null, null);
			this.ID = iD;
		}

		/// <summary> CTor</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="validator">The custom validator object for this SystemDataEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SystemDataEntity(System.Int32 iD, IValidator validator):base("SystemDataEntity")
		{
			InitClassEmpty(validator, null);
			this.ID = iD;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SystemDataEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_roleForAnonymous = (RoleEntity)info.GetValue("_roleForAnonymous", typeof(RoleEntity));
				if(_roleForAnonymous!=null)
				{
					_roleForAnonymous.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_roleForNewUser = (RoleEntity)info.GetValue("_roleForNewUser", typeof(RoleEntity));
				if(_roleForNewUser!=null)
				{
					_roleForNewUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((SystemDataFieldIndex)fieldIndex)
			{
				case SystemDataFieldIndex.DefaultRoleNewUser:
					DesetupSyncRoleForNewUser(true, false);
					break;
				case SystemDataFieldIndex.AnonymousRole:
					DesetupSyncRoleForAnonymous(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "RoleForAnonymous":
					this.RoleForAnonymous = (RoleEntity)entity;
					break;
				case "RoleForNewUser":
					this.RoleForNewUser = (RoleEntity)entity;
					break;
				default:
					this.OnSetRelatedEntityProperty(propertyName, entity);
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		protected override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		internal static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "RoleForAnonymous":
					toReturn.Add(Relations.RoleEntityUsingAnonymousRole);
					break;
				case "RoleForNewUser":
					toReturn.Add(Relations.RoleEntityUsingDefaultRoleNewUser);
					break;
				default:
					break;				
			}
			return toReturn;
		}

		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it/ will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		protected override bool CheckOneWayRelations(string propertyName)
		{
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));
				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "RoleForAnonymous":
					SetupSyncRoleForAnonymous(relatedEntity);
					break;
				case "RoleForNewUser":
					SetupSyncRoleForNewUser(relatedEntity);
					break;
				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		protected override void UnsetRelatedEntity(IEntityCore relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "RoleForAnonymous":
					DesetupSyncRoleForAnonymous(false, true);
					break;
				case "RoleForNewUser":
					DesetupSyncRoleForNewUser(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_roleForAnonymous!=null)
			{
				toReturn.Add(_roleForAnonymous);
			}
			if(_roleForNewUser!=null)
			{
				toReturn.Add(_roleForNewUser);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			return toReturn;
		}

		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_roleForAnonymous", (!this.MarkedForDeletion?_roleForAnonymous:null));
				info.AddValue("_roleForNewUser", (!this.MarkedForDeletion?_roleForNewUser:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new SystemDataRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleForAnonymous()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleID, null, ComparisonOperator.Equal, this.AnonymousRole));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleForNewUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleID, null, ComparisonOperator.Equal, this.DefaultRoleNewUser));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(SystemDataEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("RoleForAnonymous", _roleForAnonymous);
			toReturn.Add("RoleForNewUser", _roleForNewUser);
			return toReturn;
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}


		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();
			Dictionary<string, string> fieldHashtable;
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultRoleNewUser", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AnonymousRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultUserTitleNewUser", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("HoursThresholdForActiveThreads", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PageSizeSearchResults", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MinNumberOfThreadsToFetch", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MinNumberOfNonStickyVisibleThreads", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SendReplyNotifications", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _roleForAnonymous</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRoleForAnonymous(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _roleForAnonymous, new PropertyChangedEventHandler( OnRoleForAnonymousPropertyChanged ), "RoleForAnonymous", SD.HnD.DALAdapter.RelationClasses.StaticSystemDataRelations.RoleEntityUsingAnonymousRoleStatic, true, signalRelatedEntity, "SystemDataAnonymousRole", resetFKFields, new int[] { (int)SystemDataFieldIndex.AnonymousRole } );
			_roleForAnonymous = null;
		}

		/// <summary> setups the sync logic for member _roleForAnonymous</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRoleForAnonymous(IEntityCore relatedEntity)
		{
			if(_roleForAnonymous!=relatedEntity)
			{
				DesetupSyncRoleForAnonymous(true, true);
				_roleForAnonymous = (RoleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _roleForAnonymous, new PropertyChangedEventHandler( OnRoleForAnonymousPropertyChanged ), "RoleForAnonymous", SD.HnD.DALAdapter.RelationClasses.StaticSystemDataRelations.RoleEntityUsingAnonymousRoleStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRoleForAnonymousPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _roleForNewUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRoleForNewUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _roleForNewUser, new PropertyChangedEventHandler( OnRoleForNewUserPropertyChanged ), "RoleForNewUser", SD.HnD.DALAdapter.RelationClasses.StaticSystemDataRelations.RoleEntityUsingDefaultRoleNewUserStatic, true, signalRelatedEntity, "SystemDataDefaultRoleNewUser", resetFKFields, new int[] { (int)SystemDataFieldIndex.DefaultRoleNewUser } );
			_roleForNewUser = null;
		}

		/// <summary> setups the sync logic for member _roleForNewUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRoleForNewUser(IEntityCore relatedEntity)
		{
			if(_roleForNewUser!=relatedEntity)
			{
				DesetupSyncRoleForNewUser(true, true);
				_roleForNewUser = (RoleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _roleForNewUser, new PropertyChangedEventHandler( OnRoleForNewUserPropertyChanged ), "RoleForNewUser", SD.HnD.DALAdapter.RelationClasses.StaticSystemDataRelations.RoleEntityUsingDefaultRoleNewUserStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRoleForNewUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
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

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static SystemDataRelations Relations
		{
			get	{ return new SystemDataRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleForAnonymous
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),	(IEntityRelation)GetRelationsForField("RoleForAnonymous")[0], (int)SD.HnD.DALAdapter.EntityType.SystemDataEntity, (int)SD.HnD.DALAdapter.EntityType.RoleEntity, 0, null, null, null, null, "RoleForAnonymous", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleForNewUser
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),	(IEntityRelation)GetRelationsForField("RoleForNewUser")[0], (int)SD.HnD.DALAdapter.EntityType.SystemDataEntity, (int)SD.HnD.DALAdapter.EntityType.RoleEntity, 0, null, null, null, null, "RoleForNewUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return FieldsCustomProperties;}
		}

		/// <summary> The ID property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.ID, true); }
			set	{ SetValue((int)SystemDataFieldIndex.ID, value); }
		}

		/// <summary> The DefaultRoleNewUser property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."DefaultRoleNewUser"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 DefaultRoleNewUser
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.DefaultRoleNewUser, true); }
			set	{ SetValue((int)SystemDataFieldIndex.DefaultRoleNewUser, value); }
		}

		/// <summary> The AnonymousRole property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."AnonymousRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AnonymousRole
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.AnonymousRole, true); }
			set	{ SetValue((int)SystemDataFieldIndex.AnonymousRole, value); }
		}

		/// <summary> The DefaultUserTitleNewUser property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."DefaultUserTitleNewUser"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 DefaultUserTitleNewUser
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.DefaultUserTitleNewUser, true); }
			set	{ SetValue((int)SystemDataFieldIndex.DefaultUserTitleNewUser, value); }
		}

		/// <summary> The HoursThresholdForActiveThreads property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."HoursThresholdForActiveThreads"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 HoursThresholdForActiveThreads
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.HoursThresholdForActiveThreads, true); }
			set	{ SetValue((int)SystemDataFieldIndex.HoursThresholdForActiveThreads, value); }
		}

		/// <summary> The PageSizeSearchResults property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."PageSizeSearchResults"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 PageSizeSearchResults
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.PageSizeSearchResults, true); }
			set	{ SetValue((int)SystemDataFieldIndex.PageSizeSearchResults, value); }
		}

		/// <summary> The MinNumberOfThreadsToFetch property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."MinNumberOfThreadsToFetch"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 MinNumberOfThreadsToFetch
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, true); }
			set	{ SetValue((int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, value); }
		}

		/// <summary> The MinNumberOfNonStickyVisibleThreads property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."MinNumberOfNonStickyVisibleThreads"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 MinNumberOfNonStickyVisibleThreads
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, true); }
			set	{ SetValue((int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, value); }
		}

		/// <summary> The SendReplyNotifications property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."SendReplyNotifications"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendReplyNotifications
		{
			get { return (System.Boolean)GetValue((int)SystemDataFieldIndex.SendReplyNotifications, true); }
			set	{ SetValue((int)SystemDataFieldIndex.SendReplyNotifications, value); }
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual RoleEntity RoleForAnonymous
		{
			get	{ return _roleForAnonymous; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncRoleForAnonymous(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SystemDataAnonymousRole", "RoleForAnonymous", _roleForAnonymous, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual RoleEntity RoleForNewUser
		{
			get	{ return _roleForNewUser; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncRoleForNewUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SystemDataDefaultRoleNewUser", "RoleForNewUser", _roleForNewUser, true); 
				}
			}
		}
	
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the SD.HnD.DALAdapter.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)SD.HnD.DALAdapter.EntityType.SystemDataEntity; }
		}

		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
