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
	/// <summary>Entity class which represents the entity 'ActionRight'.<br/><br/></summary>
	[Serializable]
	public partial class ActionRightEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ForumRoleForumActionRightEntity> _forumRoleForumActionRights;
		private EntityCollection<RoleSystemActionRightEntity> _roleSystemActionRights;
		private EntityCollection<RoleEntity> _systemRightAssignedToRoles;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ForumRoleForumActionRights</summary>
			public static readonly string ForumRoleForumActionRights = "ForumRoleForumActionRights";
			/// <summary>Member name RoleSystemActionRights</summary>
			public static readonly string RoleSystemActionRights = "RoleSystemActionRights";
			/// <summary>Member name SystemRightAssignedToRoles</summary>
			public static readonly string SystemRightAssignedToRoles = "SystemRightAssignedToRoles";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ActionRightEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public ActionRightEntity():base("ActionRightEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ActionRightEntity(IEntityFields2 fields):base("ActionRightEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ActionRightEntity</param>
		public ActionRightEntity(IValidator validator):base("ActionRightEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ActionRightEntity(System.Int32 actionRightID):base("ActionRightEntity")
		{
			InitClassEmpty(null, null);
			this.ActionRightID = actionRightID;
		}

		/// <summary> CTor</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="validator">The custom validator object for this ActionRightEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ActionRightEntity(System.Int32 actionRightID, IValidator validator):base("ActionRightEntity")
		{
			InitClassEmpty(validator, null);
			this.ActionRightID = actionRightID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ActionRightEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_forumRoleForumActionRights = (EntityCollection<ForumRoleForumActionRightEntity>)info.GetValue("_forumRoleForumActionRights", typeof(EntityCollection<ForumRoleForumActionRightEntity>));
				_roleSystemActionRights = (EntityCollection<RoleSystemActionRightEntity>)info.GetValue("_roleSystemActionRights", typeof(EntityCollection<RoleSystemActionRightEntity>));
				_systemRightAssignedToRoles = (EntityCollection<RoleEntity>)info.GetValue("_systemRightAssignedToRoles", typeof(EntityCollection<RoleEntity>));
				this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "ForumRoleForumActionRights":
					this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)entity);
					break;
				case "RoleSystemActionRights":
					this.RoleSystemActionRights.Add((RoleSystemActionRightEntity)entity);
					break;
				case "SystemRightAssignedToRoles":
					this.SystemRightAssignedToRoles.IsReadOnly = false;
					this.SystemRightAssignedToRoles.Add((RoleEntity)entity);
					this.SystemRightAssignedToRoles.IsReadOnly = true;
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
				case "ForumRoleForumActionRights":
					toReturn.Add(Relations.ForumRoleForumActionRightEntityUsingActionRightID);
					break;
				case "RoleSystemActionRights":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingActionRightID);
					break;
				case "SystemRightAssignedToRoles":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingActionRightID, "ActionRightEntity__", "RoleSystemActionRight_", JoinHint.None);
					toReturn.Add(RoleSystemActionRightEntity.Relations.RoleEntityUsingRoleID, "RoleSystemActionRight_", string.Empty, JoinHint.None);
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
				case "ForumRoleForumActionRights":
					this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)relatedEntity);
					break;
				case "RoleSystemActionRights":
					this.RoleSystemActionRights.Add((RoleSystemActionRightEntity)relatedEntity);
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
				case "ForumRoleForumActionRights":
					this.PerformRelatedEntityRemoval(this.ForumRoleForumActionRights, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleSystemActionRights":
					this.PerformRelatedEntityRemoval(this.RoleSystemActionRights, relatedEntity, signalRelatedEntityManyToOne);
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
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ForumRoleForumActionRights);
			toReturn.Add(this.RoleSystemActionRights);
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
				info.AddValue("_forumRoleForumActionRights", ((_forumRoleForumActionRights!=null) && (_forumRoleForumActionRights.Count>0) && !this.MarkedForDeletion)?_forumRoleForumActionRights:null);
				info.AddValue("_roleSystemActionRights", ((_roleSystemActionRights!=null) && (_roleSystemActionRights.Count>0) && !this.MarkedForDeletion)?_roleSystemActionRights:null);
				info.AddValue("_systemRightAssignedToRoles", ((_systemRightAssignedToRoles!=null) && (_systemRightAssignedToRoles.Count>0) && !this.MarkedForDeletion)?_systemRightAssignedToRoles:null);
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ActionRightRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ForumRoleForumActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoForumRoleForumActionRights()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ForumRoleForumActionRightFields.ActionRightID, null, ComparisonOperator.Equal, this.ActionRightID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'RoleSystemActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleSystemActionRights()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleSystemActionRightFields.ActionRightID, null, ComparisonOperator.Equal, this.ActionRightID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemRightAssignedToRoles()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SystemRightAssignedToRoles"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionRightFields.ActionRightID, null, ComparisonOperator.Equal, this.ActionRightID, "ActionRightEntity__"));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ActionRightEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._forumRoleForumActionRights);
			collectionsQueue.Enqueue(this._roleSystemActionRights);
			collectionsQueue.Enqueue(this._systemRightAssignedToRoles);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._forumRoleForumActionRights = (EntityCollection<ForumRoleForumActionRightEntity>) collectionsQueue.Dequeue();
			this._roleSystemActionRights = (EntityCollection<RoleSystemActionRightEntity>) collectionsQueue.Dequeue();
			this._systemRightAssignedToRoles = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._forumRoleForumActionRights != null);
			toReturn |=(this._roleSystemActionRights != null);
			toReturn |= (this._systemRightAssignedToRoles != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ForumRoleForumActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumRoleForumActionRightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleSystemActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleSystemActionRightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ForumRoleForumActionRights", _forumRoleForumActionRights);
			toReturn.Add("RoleSystemActionRights", _roleSystemActionRights);
			toReturn.Add("SystemRightAssignedToRoles", _systemRightAssignedToRoles);
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
			_fieldsCustomProperties.Add("ActionRightID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ActionRightDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AppliesToForum", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AppliesToSystem", fieldHashtable);
		}
		#endregion

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ActionRightEntity</param>
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
		public  static ActionRightRelations Relations
		{
			get	{ return new ActionRightRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ForumRoleForumActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathForumRoleForumActionRights
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<ForumRoleForumActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumRoleForumActionRightEntityFactory))), (IEntityRelation)GetRelationsForField("ForumRoleForumActionRights")[0], (int)SD.HnD.DALAdapter.EntityType.ActionRightEntity, (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, 0, null, null, null, null, "ForumRoleForumActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleSystemActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleSystemActionRights
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<RoleSystemActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleSystemActionRightEntityFactory))), (IEntityRelation)GetRelationsForField("RoleSystemActionRights")[0], (int)SD.HnD.DALAdapter.EntityType.ActionRightEntity, (int)SD.HnD.DALAdapter.EntityType.RoleSystemActionRightEntity, 0, null, null, null, null, "RoleSystemActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemRightAssignedToRoles
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleSystemActionRightEntityUsingActionRightID;
				intermediateRelation.SetAliases(string.Empty, "RoleSystemActionRight_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.ActionRightEntity, (int)SD.HnD.DALAdapter.EntityType.RoleEntity, 0, null, null, GetRelationsForField("SystemRightAssignedToRoles"), null, "SystemRightAssignedToRoles", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
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

		/// <summary> The ActionRightID property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."ActionRightID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ActionRightID
		{
			get { return (System.Int32)GetValue((int)ActionRightFieldIndex.ActionRightID, true); }
			set	{ SetValue((int)ActionRightFieldIndex.ActionRightID, value); }
		}

		/// <summary> The ActionRightDescription property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."ActionRightDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ActionRightDescription
		{
			get { return (System.String)GetValue((int)ActionRightFieldIndex.ActionRightDescription, true); }
			set	{ SetValue((int)ActionRightFieldIndex.ActionRightDescription, value); }
		}

		/// <summary> The AppliesToForum property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."AppliesToForum"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AppliesToForum
		{
			get { return (System.Boolean)GetValue((int)ActionRightFieldIndex.AppliesToForum, true); }
			set	{ SetValue((int)ActionRightFieldIndex.AppliesToForum, value); }
		}

		/// <summary> The AppliesToSystem property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."AppliesToSystem"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AppliesToSystem
		{
			get { return (System.Boolean)GetValue((int)ActionRightFieldIndex.AppliesToSystem, true); }
			set	{ SetValue((int)ActionRightFieldIndex.AppliesToSystem, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ForumRoleForumActionRightEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ForumRoleForumActionRightEntity))]
		public virtual EntityCollection<ForumRoleForumActionRightEntity> ForumRoleForumActionRights
		{
			get { return GetOrCreateEntityCollection<ForumRoleForumActionRightEntity, ForumRoleForumActionRightEntityFactory>("ActionRight", true, false, ref _forumRoleForumActionRights);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleSystemActionRightEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(RoleSystemActionRightEntity))]
		public virtual EntityCollection<RoleSystemActionRightEntity> RoleSystemActionRights
		{
			get { return GetOrCreateEntityCollection<RoleSystemActionRightEntity, RoleSystemActionRightEntityFactory>("ActionRight", true, false, ref _roleSystemActionRights);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> SystemRightAssignedToRoles
		{
			get { return GetOrCreateEntityCollection<RoleEntity, RoleEntityFactory>("AssignedSystemActionRights", false, true, ref _systemRightAssignedToRoles);	}
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
			get { return (int)SD.HnD.DALAdapter.EntityType.ActionRightEntity; }
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
