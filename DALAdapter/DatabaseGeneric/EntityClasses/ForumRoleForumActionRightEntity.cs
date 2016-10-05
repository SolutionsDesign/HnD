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
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
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
	/// <summary>Entity class which represents the entity 'ForumRoleForumActionRight'.<br/><br/></summary>
	[Serializable]
	public partial class ForumRoleForumActionRightEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ActionRightEntity _actionRight;
		private ForumEntity _forum;
		private RoleEntity _role;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ActionRight</summary>
			public static readonly string ActionRight = "ActionRight";
			/// <summary>Member name Forum</summary>
			public static readonly string Forum = "Forum";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ForumRoleForumActionRightEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public ForumRoleForumActionRightEntity():base("ForumRoleForumActionRightEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ForumRoleForumActionRightEntity(IEntityFields2 fields):base("ForumRoleForumActionRightEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ForumRoleForumActionRightEntity</param>
		public ForumRoleForumActionRightEntity(IValidator validator):base("ForumRoleForumActionRightEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ForumRoleForumActionRightEntity(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID):base("ForumRoleForumActionRightEntity")
		{
			InitClassEmpty(null, null);
			this.ForumID = forumID;
			this.RoleID = roleID;
			this.ActionRightID = actionRightID;
		}

		/// <summary> CTor</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="validator">The custom validator object for this ForumRoleForumActionRightEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ForumRoleForumActionRightEntity(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IValidator validator):base("ForumRoleForumActionRightEntity")
		{
			InitClassEmpty(validator, null);
			this.ForumID = forumID;
			this.RoleID = roleID;
			this.ActionRightID = actionRightID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ForumRoleForumActionRightEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_actionRight = (ActionRightEntity)info.GetValue("_actionRight", typeof(ActionRightEntity));
				if(_actionRight!=null)
				{
					_actionRight.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_forum = (ForumEntity)info.GetValue("_forum", typeof(ForumEntity));
				if(_forum!=null)
				{
					_forum.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_role = (RoleEntity)info.GetValue("_role", typeof(RoleEntity));
				if(_role!=null)
				{
					_role.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ForumRoleForumActionRightFieldIndex)fieldIndex)
			{
				case ForumRoleForumActionRightFieldIndex.ForumID:
					DesetupSyncForum(true, false);
					break;
				case ForumRoleForumActionRightFieldIndex.RoleID:
					DesetupSyncRole(true, false);
					break;
				case ForumRoleForumActionRightFieldIndex.ActionRightID:
					DesetupSyncActionRight(true, false);
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
				case "ActionRight":
					this.ActionRight = (ActionRightEntity)entity;
					break;
				case "Forum":
					this.Forum = (ForumEntity)entity;
					break;
				case "Role":
					this.Role = (RoleEntity)entity;
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
				case "ActionRight":
					toReturn.Add(Relations.ActionRightEntityUsingActionRightID);
					break;
				case "Forum":
					toReturn.Add(Relations.ForumEntityUsingForumID);
					break;
				case "Role":
					toReturn.Add(Relations.RoleEntityUsingRoleID);
					break;
				default:
					break;				
			}
			return toReturn;
		}
#if !CF
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
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "ActionRight":
					SetupSyncActionRight(relatedEntity);
					break;
				case "Forum":
					SetupSyncForum(relatedEntity);
					break;
				case "Role":
					SetupSyncRole(relatedEntity);
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
				case "ActionRight":
					DesetupSyncActionRight(false, true);
					break;
				case "Forum":
					DesetupSyncForum(false, true);
					break;
				case "Role":
					DesetupSyncRole(false, true);
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
			if(_actionRight!=null)
			{
				toReturn.Add(_actionRight);
			}
			if(_forum!=null)
			{
				toReturn.Add(_forum);
			}
			if(_role!=null)
			{
				toReturn.Add(_role);
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
				info.AddValue("_actionRight", (!this.MarkedForDeletion?_actionRight:null));
				info.AddValue("_forum", (!this.MarkedForDeletion?_forum:null));
				info.AddValue("_role", (!this.MarkedForDeletion?_role:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ForumRoleForumActionRightRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'ActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionRight()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionRightFields.ActionRightID, null, ComparisonOperator.Equal, this.ActionRightID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Forum' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoForum()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ForumFields.ForumID, null, ComparisonOperator.Equal, this.ForumID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleID, null, ComparisonOperator.Equal, this.RoleID));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ForumRoleForumActionRightEntityFactory));
		}
#if !CF
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
#endif
		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ActionRight", _actionRight);
			toReturn.Add("Forum", _forum);
			toReturn.Add("Role", _role);
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
			_fieldsCustomProperties.Add("ForumID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RoleID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ActionRightID", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _actionRight</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncActionRight(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _actionRight, new PropertyChangedEventHandler( OnActionRightPropertyChanged ), "ActionRight", SD.HnD.DALAdapter.RelationClasses.StaticForumRoleForumActionRightRelations.ActionRightEntityUsingActionRightIDStatic, true, signalRelatedEntity, "ForumRoleForumActionRights", resetFKFields, new int[] { (int)ForumRoleForumActionRightFieldIndex.ActionRightID } );
			_actionRight = null;
		}

		/// <summary> setups the sync logic for member _actionRight</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncActionRight(IEntityCore relatedEntity)
		{
			if(_actionRight!=relatedEntity)
			{
				DesetupSyncActionRight(true, true);
				_actionRight = (ActionRightEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _actionRight, new PropertyChangedEventHandler( OnActionRightPropertyChanged ), "ActionRight", SD.HnD.DALAdapter.RelationClasses.StaticForumRoleForumActionRightRelations.ActionRightEntityUsingActionRightIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnActionRightPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _forum</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncForum(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", SD.HnD.DALAdapter.RelationClasses.StaticForumRoleForumActionRightRelations.ForumEntityUsingForumIDStatic, true, signalRelatedEntity, "ForumRoleForumActionRights", resetFKFields, new int[] { (int)ForumRoleForumActionRightFieldIndex.ForumID } );
			_forum = null;
		}

		/// <summary> setups the sync logic for member _forum</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncForum(IEntityCore relatedEntity)
		{
			if(_forum!=relatedEntity)
			{
				DesetupSyncForum(true, true);
				_forum = (ForumEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", SD.HnD.DALAdapter.RelationClasses.StaticForumRoleForumActionRightRelations.ForumEntityUsingForumIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnForumPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _role</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRole(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", SD.HnD.DALAdapter.RelationClasses.StaticForumRoleForumActionRightRelations.RoleEntityUsingRoleIDStatic, true, signalRelatedEntity, "ForumRoleForumActionRights", resetFKFields, new int[] { (int)ForumRoleForumActionRightFieldIndex.RoleID } );
			_role = null;
		}

		/// <summary> setups the sync logic for member _role</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRole(IEntityCore relatedEntity)
		{
			if(_role!=relatedEntity)
			{
				DesetupSyncRole(true, true);
				_role = (RoleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", SD.HnD.DALAdapter.RelationClasses.StaticForumRoleForumActionRightRelations.RoleEntityUsingRoleIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRolePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ForumRoleForumActionRightEntity</param>
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
		public  static ForumRoleForumActionRightRelations Relations
		{
			get	{ return new ForumRoleForumActionRightRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionRight
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ActionRightEntityFactory))),	(IEntityRelation)GetRelationsForField("ActionRight")[0], (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, (int)SD.HnD.DALAdapter.EntityType.ActionRightEntity, 0, null, null, null, null, "ActionRight", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Forum' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathForum
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ForumEntityFactory))),	(IEntityRelation)GetRelationsForField("Forum")[0], (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, (int)SD.HnD.DALAdapter.EntityType.ForumEntity, 0, null, null, null, null, "Forum", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),	(IEntityRelation)GetRelationsForField("Role")[0], (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, (int)SD.HnD.DALAdapter.EntityType.RoleEntity, 0, null, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The ForumID property of the Entity ForumRoleForumActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ForumRoleForumActionRight"."ForumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ForumRoleForumActionRightFieldIndex.ForumID, true); }
			set	{ SetValue((int)ForumRoleForumActionRightFieldIndex.ForumID, value); }
		}

		/// <summary> The RoleID property of the Entity ForumRoleForumActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ForumRoleForumActionRight"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 RoleID
		{
			get { return (System.Int32)GetValue((int)ForumRoleForumActionRightFieldIndex.RoleID, true); }
			set	{ SetValue((int)ForumRoleForumActionRightFieldIndex.RoleID, value); }
		}

		/// <summary> The ActionRightID property of the Entity ForumRoleForumActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ForumRoleForumActionRight"."ActionRightID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ActionRightID
		{
			get { return (System.Int32)GetValue((int)ForumRoleForumActionRightFieldIndex.ActionRightID, true); }
			set	{ SetValue((int)ForumRoleForumActionRightFieldIndex.ActionRightID, value); }
		}

		/// <summary> Gets / sets related entity of type 'ActionRightEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ActionRightEntity ActionRight
		{
			get	{ return _actionRight; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncActionRight(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ForumRoleForumActionRights", "ActionRight", _actionRight, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ForumEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ForumEntity Forum
		{
			get	{ return _forum; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncForum(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ForumRoleForumActionRights", "Forum", _forum, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual RoleEntity Role
		{
			get	{ return _role; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncRole(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ForumRoleForumActionRights", "Role", _role, true); 
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
			get { return (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity; }
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
