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
	/// <summary>Entity class which represents the entity 'Forum'.<br/><br/></summary>
	[Serializable]
	public partial class ForumEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ForumRoleForumActionRightEntity> _forumRoleForumActionRights;
		private EntityCollection<ThreadEntity> _threads;
		private EntityCollection<UserEntity> _usersWhoStartedThreads;
		private SectionEntity _section;
		private SupportQueueEntity _defaultSupportQueue;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

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
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ForumEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public ForumEntity():base("ForumEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ForumEntity(IEntityFields2 fields):base("ForumEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ForumEntity</param>
		public ForumEntity(IValidator validator):base("ForumEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ForumEntity(System.Int32 forumID):base("ForumEntity")
		{
			InitClassEmpty(null, null);
			this.ForumID = forumID;
		}

		/// <summary> CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="validator">The custom validator object for this ForumEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ForumEntity(System.Int32 forumID, IValidator validator):base("ForumEntity")
		{
			InitClassEmpty(validator, null);
			this.ForumID = forumID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ForumEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_forumRoleForumActionRights = (EntityCollection<ForumRoleForumActionRightEntity>)info.GetValue("_forumRoleForumActionRights", typeof(EntityCollection<ForumRoleForumActionRightEntity>));
				_threads = (EntityCollection<ThreadEntity>)info.GetValue("_threads", typeof(EntityCollection<ThreadEntity>));
				_usersWhoStartedThreads = (EntityCollection<UserEntity>)info.GetValue("_usersWhoStartedThreads", typeof(EntityCollection<UserEntity>));
				_section = (SectionEntity)info.GetValue("_section", typeof(SectionEntity));
				if(_section!=null)
				{
					_section.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_defaultSupportQueue = (SupportQueueEntity)info.GetValue("_defaultSupportQueue", typeof(SupportQueueEntity));
				if(_defaultSupportQueue!=null)
				{
					_defaultSupportQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ForumFieldIndex)fieldIndex)
			{
				case ForumFieldIndex.SectionID:
					DesetupSyncSection(true, false);
					break;
				case ForumFieldIndex.DefaultSupportQueueID:
					DesetupSyncDefaultSupportQueue(true, false);
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
				case "Section":
					this.Section = (SectionEntity)entity;
					break;
				case "DefaultSupportQueue":
					this.DefaultSupportQueue = (SupportQueueEntity)entity;
					break;
				case "ForumRoleForumActionRights":
					this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)entity);
					break;
				case "Threads":
					this.Threads.Add((ThreadEntity)entity);
					break;
				case "UsersWhoStartedThreads":
					this.UsersWhoStartedThreads.IsReadOnly = false;
					this.UsersWhoStartedThreads.Add((UserEntity)entity);
					this.UsersWhoStartedThreads.IsReadOnly = true;
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
				case "Section":
					toReturn.Add(Relations.SectionEntityUsingSectionID);
					break;
				case "DefaultSupportQueue":
					toReturn.Add(Relations.SupportQueueEntityUsingDefaultSupportQueueID);
					break;
				case "ForumRoleForumActionRights":
					toReturn.Add(Relations.ForumRoleForumActionRightEntityUsingForumID);
					break;
				case "Threads":
					toReturn.Add(Relations.ThreadEntityUsingForumID);
					break;
				case "UsersWhoStartedThreads":
					toReturn.Add(Relations.ThreadEntityUsingForumID, "ForumEntity__", "Thread_", JoinHint.None);
					toReturn.Add(ThreadEntity.Relations.UserEntityUsingStartedByUserID, "Thread_", string.Empty, JoinHint.None);
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
				case "Section":
					SetupSyncSection(relatedEntity);
					break;
				case "DefaultSupportQueue":
					SetupSyncDefaultSupportQueue(relatedEntity);
					break;
				case "ForumRoleForumActionRights":
					this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)relatedEntity);
					break;
				case "Threads":
					this.Threads.Add((ThreadEntity)relatedEntity);
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
				case "Section":
					DesetupSyncSection(false, true);
					break;
				case "DefaultSupportQueue":
					DesetupSyncDefaultSupportQueue(false, true);
					break;
				case "ForumRoleForumActionRights":
					this.PerformRelatedEntityRemoval(this.ForumRoleForumActionRights, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Threads":
					this.PerformRelatedEntityRemoval(this.Threads, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_section!=null)
			{
				toReturn.Add(_section);
			}
			if(_defaultSupportQueue!=null)
			{
				toReturn.Add(_defaultSupportQueue);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ForumRoleForumActionRights);
			toReturn.Add(this.Threads);
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
				info.AddValue("_threads", ((_threads!=null) && (_threads.Count>0) && !this.MarkedForDeletion)?_threads:null);
				info.AddValue("_usersWhoStartedThreads", ((_usersWhoStartedThreads!=null) && (_usersWhoStartedThreads.Count>0) && !this.MarkedForDeletion)?_usersWhoStartedThreads:null);
				info.AddValue("_section", (!this.MarkedForDeletion?_section:null));
				info.AddValue("_defaultSupportQueue", (!this.MarkedForDeletion?_defaultSupportQueue:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ForumRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ForumRoleForumActionRight' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoForumRoleForumActionRights()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ForumRoleForumActionRightFields.ForumID, null, ComparisonOperator.Equal, this.ForumID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThreads()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadFields.ForumID, null, ComparisonOperator.Equal, this.ForumID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoStartedThreads()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UsersWhoStartedThreads"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ForumFields.ForumID, null, ComparisonOperator.Equal, this.ForumID, "ForumEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Section' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSection()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SectionFields.SectionID, null, ComparisonOperator.Equal, this.SectionID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'SupportQueue' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDefaultSupportQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SupportQueueFields.QueueID, null, ComparisonOperator.Equal, this.DefaultSupportQueueID));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ForumEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._forumRoleForumActionRights);
			collectionsQueue.Enqueue(this._threads);
			collectionsQueue.Enqueue(this._usersWhoStartedThreads);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._forumRoleForumActionRights = (EntityCollection<ForumRoleForumActionRightEntity>) collectionsQueue.Dequeue();
			this._threads = (EntityCollection<ThreadEntity>) collectionsQueue.Dequeue();
			this._usersWhoStartedThreads = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._forumRoleForumActionRights != null);
			toReturn |=(this._threads != null);
			toReturn |= (this._usersWhoStartedThreads != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ForumRoleForumActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumRoleForumActionRightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Section", _section);
			toReturn.Add("DefaultSupportQueue", _defaultSupportQueue);
			toReturn.Add("ForumRoleForumActionRights", _forumRoleForumActionRights);
			toReturn.Add("Threads", _threads);
			toReturn.Add("UsersWhoStartedThreads", _usersWhoStartedThreads);
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
			_fieldsCustomProperties.Add("SectionID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ForumName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ForumDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ForumLastPostingDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("HasRSSFeed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultSupportQueueID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultThreadListInterval", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrderNo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MaxAttachmentSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MaxNoOfAttachmentsPerMessage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NewThreadWelcomeText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NewThreadWelcomeTextAsHTML", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _section</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSection(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _section, new PropertyChangedEventHandler( OnSectionPropertyChanged ), "Section", SD.HnD.DALAdapter.RelationClasses.StaticForumRelations.SectionEntityUsingSectionIDStatic, true, signalRelatedEntity, "Forums", resetFKFields, new int[] { (int)ForumFieldIndex.SectionID } );
			_section = null;
		}

		/// <summary> setups the sync logic for member _section</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSection(IEntityCore relatedEntity)
		{
			if(_section!=relatedEntity)
			{
				DesetupSyncSection(true, true);
				_section = (SectionEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _section, new PropertyChangedEventHandler( OnSectionPropertyChanged ), "Section", SD.HnD.DALAdapter.RelationClasses.StaticForumRelations.SectionEntityUsingSectionIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSectionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _defaultSupportQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDefaultSupportQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _defaultSupportQueue, new PropertyChangedEventHandler( OnDefaultSupportQueuePropertyChanged ), "DefaultSupportQueue", SD.HnD.DALAdapter.RelationClasses.StaticForumRelations.SupportQueueEntityUsingDefaultSupportQueueIDStatic, true, signalRelatedEntity, "DefaultForForums", resetFKFields, new int[] { (int)ForumFieldIndex.DefaultSupportQueueID } );
			_defaultSupportQueue = null;
		}

		/// <summary> setups the sync logic for member _defaultSupportQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDefaultSupportQueue(IEntityCore relatedEntity)
		{
			if(_defaultSupportQueue!=relatedEntity)
			{
				DesetupSyncDefaultSupportQueue(true, true);
				_defaultSupportQueue = (SupportQueueEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _defaultSupportQueue, new PropertyChangedEventHandler( OnDefaultSupportQueuePropertyChanged ), "DefaultSupportQueue", SD.HnD.DALAdapter.RelationClasses.StaticForumRelations.SupportQueueEntityUsingDefaultSupportQueueIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDefaultSupportQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
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

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ForumRelations Relations
		{
			get	{ return new ForumRelations(); }
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
			get	{ return new PrefetchPathElement2( new EntityCollection<ForumRoleForumActionRightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumRoleForumActionRightEntityFactory))), (IEntityRelation)GetRelationsForField("ForumRoleForumActionRights")[0], (int)SD.HnD.DALAdapter.EntityType.ForumEntity, (int)SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, 0, null, null, null, null, "ForumRoleForumActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThreads
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))), (IEntityRelation)GetRelationsForField("Threads")[0], (int)SD.HnD.DALAdapter.EntityType.ForumEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, 0, null, null, null, null, "Threads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoStartedThreads
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadEntityUsingForumID;
				intermediateRelation.SetAliases(string.Empty, "Thread_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.ForumEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoStartedThreads"), null, "UsersWhoStartedThreads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Section' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSection
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SectionEntityFactory))),	(IEntityRelation)GetRelationsForField("Section")[0], (int)SD.HnD.DALAdapter.EntityType.ForumEntity, (int)SD.HnD.DALAdapter.EntityType.SectionEntity, 0, null, null, null, null, "Section", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueue' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDefaultSupportQueue
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueEntityFactory))),	(IEntityRelation)GetRelationsForField("DefaultSupportQueue")[0], (int)SD.HnD.DALAdapter.EntityType.ForumEntity, (int)SD.HnD.DALAdapter.EntityType.SupportQueueEntity, 0, null, null, null, null, "DefaultSupportQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The ForumID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.ForumID, true); }
			set	{ SetValue((int)ForumFieldIndex.ForumID, value); }
		}

		/// <summary> The SectionID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."SectionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 SectionID
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.SectionID, true); }
			set	{ SetValue((int)ForumFieldIndex.SectionID, value); }
		}

		/// <summary> The ForumName property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ForumName
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.ForumName, true); }
			set	{ SetValue((int)ForumFieldIndex.ForumName, value); }
		}

		/// <summary> The ForumDescription property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ForumDescription
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.ForumDescription, true); }
			set	{ SetValue((int)ForumFieldIndex.ForumDescription, value); }
		}

		/// <summary> The ForumLastPostingDate property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumLastPostingDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ForumLastPostingDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ForumFieldIndex.ForumLastPostingDate, false); }
			set	{ SetValue((int)ForumFieldIndex.ForumLastPostingDate, value); }
		}

		/// <summary> The HasRSSFeed property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."HasRSSFeed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean HasRSSFeed
		{
			get { return (System.Boolean)GetValue((int)ForumFieldIndex.HasRSSFeed, true); }
			set	{ SetValue((int)ForumFieldIndex.HasRSSFeed, value); }
		}

		/// <summary> The DefaultSupportQueueID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."DefaultSupportQueueID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DefaultSupportQueueID
		{
			get { return (Nullable<System.Int32>)GetValue((int)ForumFieldIndex.DefaultSupportQueueID, false); }
			set	{ SetValue((int)ForumFieldIndex.DefaultSupportQueueID, value); }
		}

		/// <summary> The DefaultThreadListInterval property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."DefaultThreadListInterval"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte DefaultThreadListInterval
		{
			get { return (System.Byte)GetValue((int)ForumFieldIndex.DefaultThreadListInterval, true); }
			set	{ SetValue((int)ForumFieldIndex.DefaultThreadListInterval, value); }
		}

		/// <summary> The OrderNo property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."OrderNo"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 OrderNo
		{
			get { return (System.Int16)GetValue((int)ForumFieldIndex.OrderNo, true); }
			set	{ SetValue((int)ForumFieldIndex.OrderNo, value); }
		}

		/// <summary> The MaxAttachmentSize property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."MaxAttachmentSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int32 MaxAttachmentSize
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.MaxAttachmentSize, true); }
			set	{ SetValue((int)ForumFieldIndex.MaxAttachmentSize, value); }
		}

		/// <summary> The MaxNoOfAttachmentsPerMessage property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."MaxNoOfAttachmentsPerMessage"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int16 MaxNoOfAttachmentsPerMessage
		{
			get { return (System.Int16)GetValue((int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, true); }
			set	{ SetValue((int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, value); }
		}

		/// <summary> The NewThreadWelcomeText property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."NewThreadWelcomeText"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NewThreadWelcomeText
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.NewThreadWelcomeText, true); }
			set	{ SetValue((int)ForumFieldIndex.NewThreadWelcomeText, value); }
		}

		/// <summary> The NewThreadWelcomeTextAsHTML property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."NewThreadWelcomeTextAsHTML"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NewThreadWelcomeTextAsHTML
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, true); }
			set	{ SetValue((int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ForumRoleForumActionRightEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ForumRoleForumActionRightEntity))]
		public virtual EntityCollection<ForumRoleForumActionRightEntity> ForumRoleForumActionRights
		{
			get { return GetOrCreateEntityCollection<ForumRoleForumActionRightEntity, ForumRoleForumActionRightEntityFactory>("Forum", true, false, ref _forumRoleForumActionRights);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ThreadEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadEntity))]
		public virtual EntityCollection<ThreadEntity> Threads
		{
			get { return GetOrCreateEntityCollection<ThreadEntity, ThreadEntityFactory>("Forum", true, false, ref _threads);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoStartedThreads
		{
			get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("StartedThreadsInForums", false, true, ref _usersWhoStartedThreads);	}
		}

		/// <summary> Gets / sets related entity of type 'SectionEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual SectionEntity Section
		{
			get	{ return _section; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncSection(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Forums", "Section", _section, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SupportQueueEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual SupportQueueEntity DefaultSupportQueue
		{
			get	{ return _defaultSupportQueue; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncDefaultSupportQueue(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "DefaultForForums", "DefaultSupportQueue", _defaultSupportQueue, true); 
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
			get { return (int)SD.HnD.DALAdapter.EntityType.ForumEntity; }
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
