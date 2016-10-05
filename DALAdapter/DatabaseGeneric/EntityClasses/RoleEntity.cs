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
	/// <summary>Entity class which represents the entity 'Role'.<br/><br/></summary>
	[Serializable]
	public partial class RoleEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ForumRoleForumActionRightEntity> _forumRoleForumActionRights;
		private EntityCollection<RoleAuditActionEntity> _roleAuditAction;
		private EntityCollection<RoleSystemActionRightEntity> _roleSystemActionRights;
		private EntityCollection<RoleUserEntity> _roleUser;
		private EntityCollection<SystemDataEntity> _systemDataAnonymousRole;
		private EntityCollection<SystemDataEntity> _systemDataDefaultRoleNewUser;
		private EntityCollection<ActionRightEntity> _assignedSystemActionRights;
		private EntityCollection<AuditActionEntity> _assignedAuditActions;
		private EntityCollection<UserEntity> _users;

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
			/// <summary>Member name RoleAuditAction</summary>
			public static readonly string RoleAuditAction = "RoleAuditAction";
			/// <summary>Member name RoleSystemActionRights</summary>
			public static readonly string RoleSystemActionRights = "RoleSystemActionRights";
			/// <summary>Member name RoleUser</summary>
			public static readonly string RoleUser = "RoleUser";
			/// <summary>Member name SystemDataAnonymousRole</summary>
			public static readonly string SystemDataAnonymousRole = "SystemDataAnonymousRole";
			/// <summary>Member name SystemDataDefaultRoleNewUser</summary>
			public static readonly string SystemDataDefaultRoleNewUser = "SystemDataDefaultRoleNewUser";
			/// <summary>Member name AssignedSystemActionRights</summary>
			public static readonly string AssignedSystemActionRights = "AssignedSystemActionRights";
			/// <summary>Member name AssignedAuditActions</summary>
			public static readonly string AssignedAuditActions = "AssignedAuditActions";
			/// <summary>Member name Users</summary>
			public static readonly string Users = "Users";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RoleEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public RoleEntity():base("RoleEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public RoleEntity(IEntityFields2 fields):base("RoleEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this RoleEntity</param>
		public RoleEntity(IValidator validator):base("RoleEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RoleEntity(System.Int32 roleID):base("RoleEntity")
		{
			InitClassEmpty(null, null);
			this.RoleID = roleID;
		}

		/// <summary> CTor</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="validator">The custom validator object for this RoleEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RoleEntity(System.Int32 roleID, IValidator validator):base("RoleEntity")
		{
			InitClassEmpty(validator, null);
			this.RoleID = roleID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected RoleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_forumRoleForumActionRights = (EntityCollection<ForumRoleForumActionRightEntity>)info.GetValue("_forumRoleForumActionRights", typeof(EntityCollection<ForumRoleForumActionRightEntity>));
				_roleAuditAction = (EntityCollection<RoleAuditActionEntity>)info.GetValue("_roleAuditAction", typeof(EntityCollection<RoleAuditActionEntity>));
				_roleSystemActionRights = (EntityCollection<RoleSystemActionRightEntity>)info.GetValue("_roleSystemActionRights", typeof(EntityCollection<RoleSystemActionRightEntity>));
				_roleUser = (EntityCollection<RoleUserEntity>)info.GetValue("_roleUser", typeof(EntityCollection<RoleUserEntity>));
				_systemDataAnonymousRole = (EntityCollection<SystemDataEntity>)info.GetValue("_systemDataAnonymousRole", typeof(EntityCollection<SystemDataEntity>));
				_systemDataDefaultRoleNewUser = (EntityCollection<SystemDataEntity>)info.GetValue("_systemDataDefaultRoleNewUser", typeof(EntityCollection<SystemDataEntity>));
				_assignedSystemActionRights = (EntityCollection<ActionRightEntity>)info.GetValue("_assignedSystemActionRights", typeof(EntityCollection<ActionRightEntity>));
				_assignedAuditActions = (EntityCollection<AuditActionEntity>)info.GetValue("_assignedAuditActions", typeof(EntityCollection<AuditActionEntity>));
				_users = (EntityCollection<UserEntity>)info.GetValue("_users", typeof(EntityCollection<UserEntity>));
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
				case "RoleAuditAction":
					this.RoleAuditAction.Add((RoleAuditActionEntity)entity);
					break;
				case "RoleSystemActionRights":
					this.RoleSystemActionRights.Add((RoleSystemActionRightEntity)entity);
					break;
				case "RoleUser":
					this.RoleUser.Add((RoleUserEntity)entity);
					break;
				case "SystemDataAnonymousRole":
					this.SystemDataAnonymousRole.Add((SystemDataEntity)entity);
					break;
				case "SystemDataDefaultRoleNewUser":
					this.SystemDataDefaultRoleNewUser.Add((SystemDataEntity)entity);
					break;
				case "AssignedSystemActionRights":
					this.AssignedSystemActionRights.IsReadOnly = false;
					this.AssignedSystemActionRights.Add((ActionRightEntity)entity);
					this.AssignedSystemActionRights.IsReadOnly = true;
					break;
				case "AssignedAuditActions":
					this.AssignedAuditActions.IsReadOnly = false;
					this.AssignedAuditActions.Add((AuditActionEntity)entity);
					this.AssignedAuditActions.IsReadOnly = true;
					break;
				case "Users":
					this.Users.IsReadOnly = false;
					this.Users.Add((UserEntity)entity);
					this.Users.IsReadOnly = true;
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
					toReturn.Add(Relations.ForumRoleForumActionRightEntityUsingRoleID);
					break;
				case "RoleAuditAction":
					toReturn.Add(Relations.RoleAuditActionEntityUsingRoleID);
					break;
				case "RoleSystemActionRights":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingRoleID);
					break;
				case "RoleUser":
					toReturn.Add(Relations.RoleUserEntityUsingRoleID);
					break;
				case "SystemDataAnonymousRole":
					toReturn.Add(Relations.SystemDataEntityUsingAnonymousRole);
					break;
				case "SystemDataDefaultRoleNewUser":
					toReturn.Add(Relations.SystemDataEntityUsingDefaultRoleNewUser);
					break;
				case "AssignedSystemActionRights":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingRoleID, "RoleEntity__", "RoleSystemActionRight_", JoinHint.None);
					toReturn.Add(RoleSystemActionRightEntity.Relations.ActionRightEntityUsingActionRightID, "RoleSystemActionRight_", string.Empty, JoinHint.None);
					break;
				case "AssignedAuditActions":
					toReturn.Add(Relations.RoleAuditActionEntityUsingRoleID, "RoleEntity__", "RoleAuditAction_", JoinHint.None);
					toReturn.Add(RoleAuditActionEntity.Relations.AuditActionEntityUsingAuditActionID, "RoleAuditAction_", string.Empty, JoinHint.None);
					break;
				case "Users":
					toReturn.Add(Relations.RoleUserEntityUsingRoleID, "RoleEntity__", "RoleUser_", JoinHint.None);
					toReturn.Add(RoleUserEntity.Relations.UserEntityUsingUserID, "RoleUser_", string.Empty, JoinHint.None);
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
				case "ForumRoleForumActionRights":
					this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)relatedEntity);
					break;
				case "RoleAuditAction":
					this.RoleAuditAction.Add((RoleAuditActionEntity)relatedEntity);
					break;
				case "RoleSystemActionRights":
					this.RoleSystemActionRights.Add((RoleSystemActionRightEntity)relatedEntity);
					break;
				case "RoleUser":
					this.RoleUser.Add((RoleUserEntity)relatedEntity);
					break;
				case "SystemDataAnonymousRole":
					this.SystemDataAnonymousRole.Add((SystemDataEntity)relatedEntity);
					break;
				case "SystemDataDefaultRoleNewUser":
					this.SystemDataDefaultRoleNewUser.Add((SystemDataEntity)relatedEntity);
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
				case "RoleAuditAction":
					this.PerformRelatedEntityRemoval(this.RoleAuditAction, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleSystemActionRights":
					this.PerformRelatedEntityRemoval(this.RoleSystemActionRights, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleUser":
					this.PerformRelatedEntityRemoval(this.RoleUser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemDataAnonymousRole":
					this.PerformRelatedEntityRemoval(this.SystemDataAnonymousRole, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemDataDefaultRoleNewUser":
					this.PerformRelatedEntityRemoval(this.SystemDataDefaultRoleNewUser, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.RoleAuditAction);
			toReturn.Add(this.RoleSystemActionRights);
			toReturn.Add(this.RoleUser);
			toReturn.Add(this.SystemDataAnonymousRole);
			toReturn.Add(this.SystemDataDefaultRoleNewUser);
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
				info.AddValue("_roleAuditAction", ((_roleAuditAction!=null) && (_roleAuditAction.Count>0) && !this.MarkedForDeletion)?_roleAuditAction:null);
				info.AddValue("_roleSystemActionRights", ((_roleSystemActionRights!=null) && (_roleSystemActionRights.Count>0) && !this.MarkedForDeletion)?_roleSystemActionRights:null);
				info.AddValue("_roleUser", ((_roleUser!=null) && (_roleUser.Count>0) && !this.MarkedForDeletion)?_roleUser:null);
				info.AddValue("_systemDataAnonymousRole", ((_systemDataAnonymousRole!=null) && (_systemDataAnonymousRole.Count>0) && !this.MarkedForDeletion)?_systemDataAnonymousRole:null);
				info.AddValue("_systemDataDefaultRoleNewUser", ((_systemDataDefaultRoleNewUser!=null) && (_systemDataDefaultRoleNewUser.Count>0) && !this.MarkedForDeletion)?_systemDataDefaultRoleNewUser:null);
				info.AddValue("_assignedSystemActionRights", ((_assignedSystemActionRights!=null) && (_assignedSystemActionRights.Count>0) && !this.MarkedForDeletion)?_assignedSystemActionRights:null);
				info.AddValue("_assignedAuditActions", ((_assignedAuditActions!=null) && (_assignedAuditActions.Count>0) && !this.MarkedForDeletion)?_assignedAuditActions:null);
				info.AddValue("_users", ((_users!=null) && (_users.Count>0) && !this.MarkedForDeletion)?_users:null);
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new RoleRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ForumRoleForumActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoForumRoleForumActionRights()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ForumRoleForumActionRightFields.RoleID, null, ComparisonOperator.Equal, this.RoleID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'RoleAuditAction' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleAuditAction()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleAuditActionFields.RoleID, null, ComparisonOperator.Equal, this.RoleID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'RoleSystemActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleSystemActionRights()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleSystemActionRightFields.RoleID, null, ComparisonOperator.Equal, this.RoleID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'RoleUser' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleUserFields.RoleID, null, ComparisonOperator.Equal, this.RoleID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'SystemData' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemDataAnonymousRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemDataFields.AnonymousRole, null, ComparisonOperator.Equal, this.RoleID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'SystemData' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemDataDefaultRoleNewUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemDataFields.DefaultRoleNewUser, null, ComparisonOperator.Equal, this.RoleID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssignedSystemActionRights()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AssignedSystemActionRights"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleID, null, ComparisonOperator.Equal, this.RoleID, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'AuditAction' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssignedAuditActions()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AssignedAuditActions"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleID, null, ComparisonOperator.Equal, this.RoleID, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("Users"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleID, null, ComparisonOperator.Equal, this.RoleID, "RoleEntity__"));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._forumRoleForumActionRights);
			collectionsQueue.Enqueue(this._roleAuditAction);
			collectionsQueue.Enqueue(this._roleSystemActionRights);
			collectionsQueue.Enqueue(this._roleUser);
			collectionsQueue.Enqueue(this._systemDataAnonymousRole);
			collectionsQueue.Enqueue(this._systemDataDefaultRoleNewUser);
			collectionsQueue.Enqueue(this._assignedSystemActionRights);
			collectionsQueue.Enqueue(this._assignedAuditActions);
			collectionsQueue.Enqueue(this._users);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._forumRoleForumActionRights = (EntityCollection<ForumRoleForumActionRightEntity>) collectionsQueue.Dequeue();
			this._roleAuditAction = (EntityCollection<RoleAuditActionEntity>) collectionsQueue.Dequeue();
			this._roleSystemActionRights = (EntityCollection<RoleSystemActionRightEntity>) collectionsQueue.Dequeue();
			this._roleUser = (EntityCollection<RoleUserEntity>) collectionsQueue.Dequeue();
			this._systemDataAnonymousRole = (EntityCollection<SystemDataEntity>) collectionsQueue.Dequeue();
			this._systemDataDefaultRoleNewUser = (EntityCollection<SystemDataEntity>) collectionsQueue.Dequeue();
			this._assignedSystemActionRights = (EntityCollection<ActionRightEntity>) collectionsQueue.Dequeue();
			this._assignedAuditActions = (EntityCollection<AuditActionEntity>) collectionsQueue.Dequeue();
			this._users = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._forumRoleForumActionRights != null);
			toReturn |=(this._roleAuditAction != null);
			toReturn |=(this._roleSystemActionRights != null);
			toReturn |=(this._roleUser != null);
			toReturn |=(this._systemDataAnonymousRole != null);
			toReturn |=(this._systemDataDefaultRoleNewUser != null);
			toReturn |= (this._assignedSystemActionRights != null);
			toReturn |= (this._assignedAuditActions != null);
			toReturn |= (this._users != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ForumRoleForumActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumRoleForumActionRightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleAuditActionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAuditActionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleSystemActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleSystemActionRightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemDataEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemDataEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionRightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AuditActionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditActionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
		}
#endif
		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ForumRoleForumActionRights", _forumRoleForumActionRights);
			toReturn.Add("RoleAuditAction", _roleAuditAction);
			toReturn.Add("RoleSystemActionRights", _roleSystemActionRights);
			toReturn.Add("RoleUser", _roleUser);
			toReturn.Add("SystemDataAnonymousRole", _systemDataAnonymousRole);
			toReturn.Add("SystemDataDefaultRoleNewUser", _systemDataDefaultRoleNewUser);
			toReturn.Add("AssignedSystemActionRights", _assignedSystemActionRights);
			toReturn.Add("AssignedAuditActions", _assignedAuditActions);
			toReturn.Add("Users", _users);
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
			_fieldsCustomProperties.Add("RoleID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RoleDescription", fieldHashtable);
		}
		#endregion

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this RoleEntity</param>
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
		public  static RoleRelations Relations
		{
			get	{ return new RoleRelations(); }
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
			get	{ return new PrefetchPathElement2( new EntityCollection<ForumRoleForumActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumRoleForumActionRightEntityFactory))), (IEntityRelation)GetRelationsForField("ForumRoleForumActionRights")[0], (int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, 0, null, null, null, null, "ForumRoleForumActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleAuditAction' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleAuditAction
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<RoleAuditActionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAuditActionEntityFactory))), (IEntityRelation)GetRelationsForField("RoleAuditAction")[0], (int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.RoleAuditActionEntity, 0, null, null, null, null, "RoleAuditAction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleSystemActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleSystemActionRights
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<RoleSystemActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleSystemActionRightEntityFactory))), (IEntityRelation)GetRelationsForField("RoleSystemActionRights")[0], (int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.RoleSystemActionRightEntity, 0, null, null, null, null, "RoleSystemActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleUser' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleUser
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<RoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleUserEntityFactory))), (IEntityRelation)GetRelationsForField("RoleUser")[0], (int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.RoleUserEntity, 0, null, null, null, null, "RoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemDataAnonymousRole
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<SystemDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemDataEntityFactory))), (IEntityRelation)GetRelationsForField("SystemDataAnonymousRole")[0], (int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.SystemDataEntity, 0, null, null, null, null, "SystemDataAnonymousRole", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemDataDefaultRoleNewUser
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<SystemDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemDataEntityFactory))), (IEntityRelation)GetRelationsForField("SystemDataDefaultRoleNewUser")[0], (int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.SystemDataEntity, 0, null, null, null, null, "SystemDataDefaultRoleNewUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssignedSystemActionRights
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleSystemActionRightEntityUsingRoleID;
				intermediateRelation.SetAliases(string.Empty, "RoleSystemActionRight_");
				return new PrefetchPathElement2(new EntityCollection<ActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionRightEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.ActionRightEntity, 0, null, null, GetRelationsForField("AssignedSystemActionRights"), null, "AssignedSystemActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AuditAction' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssignedAuditActions
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleAuditActionEntityUsingRoleID;
				intermediateRelation.SetAliases(string.Empty, "RoleAuditAction_");
				return new PrefetchPathElement2(new EntityCollection<AuditActionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditActionEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.AuditActionEntity, 0, null, null, GetRelationsForField("AssignedAuditActions"), null, "AssignedAuditActions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsers
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleUserEntityUsingRoleID;
				intermediateRelation.SetAliases(string.Empty, "RoleUser_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.RoleEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, GetRelationsForField("Users"), null, "Users", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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

		/// <summary> The RoleID property of the Entity Role<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Role"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 RoleID
		{
			get { return (System.Int32)GetValue((int)RoleFieldIndex.RoleID, true); }
			set	{ SetValue((int)RoleFieldIndex.RoleID, value); }
		}

		/// <summary> The RoleDescription property of the Entity Role<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Role"."RoleDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String RoleDescription
		{
			get { return (System.String)GetValue((int)RoleFieldIndex.RoleDescription, true); }
			set	{ SetValue((int)RoleFieldIndex.RoleDescription, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ForumRoleForumActionRightEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ForumRoleForumActionRightEntity))]
		public virtual EntityCollection<ForumRoleForumActionRightEntity> ForumRoleForumActionRights
		{
			get { return GetOrCreateEntityCollection<ForumRoleForumActionRightEntity, ForumRoleForumActionRightEntityFactory>("Role", true, false, ref _forumRoleForumActionRights);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleAuditActionEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(RoleAuditActionEntity))]
		public virtual EntityCollection<RoleAuditActionEntity> RoleAuditAction
		{
			get { return GetOrCreateEntityCollection<RoleAuditActionEntity, RoleAuditActionEntityFactory>("Role", true, false, ref _roleAuditAction);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleSystemActionRightEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(RoleSystemActionRightEntity))]
		public virtual EntityCollection<RoleSystemActionRightEntity> RoleSystemActionRights
		{
			get { return GetOrCreateEntityCollection<RoleSystemActionRightEntity, RoleSystemActionRightEntityFactory>("Role", true, false, ref _roleSystemActionRights);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleUserEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(RoleUserEntity))]
		public virtual EntityCollection<RoleUserEntity> RoleUser
		{
			get { return GetOrCreateEntityCollection<RoleUserEntity, RoleUserEntityFactory>("Role", true, false, ref _roleUser);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SystemDataEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(SystemDataEntity))]
		public virtual EntityCollection<SystemDataEntity> SystemDataAnonymousRole
		{
			get { return GetOrCreateEntityCollection<SystemDataEntity, SystemDataEntityFactory>("RoleForAnonymous", true, false, ref _systemDataAnonymousRole);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SystemDataEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(SystemDataEntity))]
		public virtual EntityCollection<SystemDataEntity> SystemDataDefaultRoleNewUser
		{
			get { return GetOrCreateEntityCollection<SystemDataEntity, SystemDataEntityFactory>("RoleForNewUser", true, false, ref _systemDataDefaultRoleNewUser);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionRightEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ActionRightEntity))]
		public virtual EntityCollection<ActionRightEntity> AssignedSystemActionRights
		{
			get { return GetOrCreateEntityCollection<ActionRightEntity, ActionRightEntityFactory>("SystemRightAssignedToRoles", false, true, ref _assignedSystemActionRights);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AuditActionEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(AuditActionEntity))]
		public virtual EntityCollection<AuditActionEntity> AssignedAuditActions
		{
			get { return GetOrCreateEntityCollection<AuditActionEntity, AuditActionEntityFactory>("RolesWithAuditAction", false, true, ref _assignedAuditActions);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> Users
		{
			get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("Roles", false, true, ref _users);	}
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
			get { return (int)SD.HnD.DALAdapter.EntityType.RoleEntity; }
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
