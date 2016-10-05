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
	/// <summary>Entity class which represents the entity 'Message'.<br/><br/></summary>
	[Serializable]
	public partial class MessageEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AttachmentEntity> _attachments;
		private EntityCollection<AuditDataMessageRelatedEntity> _auditDataMessageRelated;
		private ThreadEntity _thread;
		private UserEntity _postedByUser;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Thread</summary>
			public static readonly string Thread = "Thread";
			/// <summary>Member name PostedByUser</summary>
			public static readonly string PostedByUser = "PostedByUser";
			/// <summary>Member name Attachments</summary>
			public static readonly string Attachments = "Attachments";
			/// <summary>Member name AuditDataMessageRelated</summary>
			public static readonly string AuditDataMessageRelated = "AuditDataMessageRelated";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MessageEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public MessageEntity():base("MessageEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MessageEntity(IEntityFields2 fields):base("MessageEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MessageEntity</param>
		public MessageEntity(IValidator validator):base("MessageEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MessageEntity(System.Int32 messageID):base("MessageEntity")
		{
			InitClassEmpty(null, null);
			this.MessageID = messageID;
		}

		/// <summary> CTor</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="validator">The custom validator object for this MessageEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MessageEntity(System.Int32 messageID, IValidator validator):base("MessageEntity")
		{
			InitClassEmpty(validator, null);
			this.MessageID = messageID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MessageEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_attachments = (EntityCollection<AttachmentEntity>)info.GetValue("_attachments", typeof(EntityCollection<AttachmentEntity>));
				_auditDataMessageRelated = (EntityCollection<AuditDataMessageRelatedEntity>)info.GetValue("_auditDataMessageRelated", typeof(EntityCollection<AuditDataMessageRelatedEntity>));
				_thread = (ThreadEntity)info.GetValue("_thread", typeof(ThreadEntity));
				if(_thread!=null)
				{
					_thread.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_postedByUser = (UserEntity)info.GetValue("_postedByUser", typeof(UserEntity));
				if(_postedByUser!=null)
				{
					_postedByUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MessageFieldIndex)fieldIndex)
			{
				case MessageFieldIndex.PostedByUserID:
					DesetupSyncPostedByUser(true, false);
					break;
				case MessageFieldIndex.ThreadID:
					DesetupSyncThread(true, false);
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
				case "Thread":
					this.Thread = (ThreadEntity)entity;
					break;
				case "PostedByUser":
					this.PostedByUser = (UserEntity)entity;
					break;
				case "Attachments":
					this.Attachments.Add((AttachmentEntity)entity);
					break;
				case "AuditDataMessageRelated":
					this.AuditDataMessageRelated.Add((AuditDataMessageRelatedEntity)entity);
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
				case "Thread":
					toReturn.Add(Relations.ThreadEntityUsingThreadID);
					break;
				case "PostedByUser":
					toReturn.Add(Relations.UserEntityUsingPostedByUserID);
					break;
				case "Attachments":
					toReturn.Add(Relations.AttachmentEntityUsingMessageID);
					break;
				case "AuditDataMessageRelated":
					toReturn.Add(Relations.AuditDataMessageRelatedEntityUsingMessageID);
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
				case "Thread":
					SetupSyncThread(relatedEntity);
					break;
				case "PostedByUser":
					SetupSyncPostedByUser(relatedEntity);
					break;
				case "Attachments":
					this.Attachments.Add((AttachmentEntity)relatedEntity);
					break;
				case "AuditDataMessageRelated":
					this.AuditDataMessageRelated.Add((AuditDataMessageRelatedEntity)relatedEntity);
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
				case "Thread":
					DesetupSyncThread(false, true);
					break;
				case "PostedByUser":
					DesetupSyncPostedByUser(false, true);
					break;
				case "Attachments":
					this.PerformRelatedEntityRemoval(this.Attachments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AuditDataMessageRelated":
					this.PerformRelatedEntityRemoval(this.AuditDataMessageRelated, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_thread!=null)
			{
				toReturn.Add(_thread);
			}
			if(_postedByUser!=null)
			{
				toReturn.Add(_postedByUser);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Attachments);
			toReturn.Add(this.AuditDataMessageRelated);
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
				info.AddValue("_attachments", ((_attachments!=null) && (_attachments.Count>0) && !this.MarkedForDeletion)?_attachments:null);
				info.AddValue("_auditDataMessageRelated", ((_auditDataMessageRelated!=null) && (_auditDataMessageRelated.Count>0) && !this.MarkedForDeletion)?_auditDataMessageRelated:null);
				info.AddValue("_thread", (!this.MarkedForDeletion?_thread:null));
				info.AddValue("_postedByUser", (!this.MarkedForDeletion?_postedByUser:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new MessageRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Attachment' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAttachments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AttachmentFields.MessageID, null, ComparisonOperator.Equal, this.MessageID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'AuditDataMessageRelated' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAuditDataMessageRelated()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AuditDataMessageRelatedFields.MessageID, null, ComparisonOperator.Equal, this.MessageID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThread()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPostedByUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.PostedByUserID));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(MessageEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._attachments);
			collectionsQueue.Enqueue(this._auditDataMessageRelated);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._attachments = (EntityCollection<AttachmentEntity>) collectionsQueue.Dequeue();
			this._auditDataMessageRelated = (EntityCollection<AuditDataMessageRelatedEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._attachments != null);
			toReturn |=(this._auditDataMessageRelated != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AttachmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AttachmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AuditDataMessageRelatedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditDataMessageRelatedEntityFactory))) : null);
		}
#endif
		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Thread", _thread);
			toReturn.Add("PostedByUser", _postedByUser);
			toReturn.Add("Attachments", _attachments);
			toReturn.Add("AuditDataMessageRelated", _auditDataMessageRelated);
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
			_fieldsCustomProperties.Add("MessageID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PostingDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PostedByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PostedFromIP", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ChangeTrackerStamp", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MessageText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MessageTextAsHTML", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _thread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DALAdapter.RelationClasses.StaticMessageRelations.ThreadEntityUsingThreadIDStatic, true, signalRelatedEntity, "Messages", resetFKFields, new int[] { (int)MessageFieldIndex.ThreadID } );
			_thread = null;
		}

		/// <summary> setups the sync logic for member _thread</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncThread(IEntityCore relatedEntity)
		{
			if(_thread!=relatedEntity)
			{
				DesetupSyncThread(true, true);
				_thread = (ThreadEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DALAdapter.RelationClasses.StaticMessageRelations.ThreadEntityUsingThreadIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnThreadPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _postedByUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPostedByUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _postedByUser, new PropertyChangedEventHandler( OnPostedByUserPropertyChanged ), "PostedByUser", SD.HnD.DALAdapter.RelationClasses.StaticMessageRelations.UserEntityUsingPostedByUserIDStatic, true, signalRelatedEntity, "PostedMessages", resetFKFields, new int[] { (int)MessageFieldIndex.PostedByUserID } );
			_postedByUser = null;
		}

		/// <summary> setups the sync logic for member _postedByUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPostedByUser(IEntityCore relatedEntity)
		{
			if(_postedByUser!=relatedEntity)
			{
				DesetupSyncPostedByUser(true, true);
				_postedByUser = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _postedByUser, new PropertyChangedEventHandler( OnPostedByUserPropertyChanged ), "PostedByUser", SD.HnD.DALAdapter.RelationClasses.StaticMessageRelations.UserEntityUsingPostedByUserIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPostedByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MessageEntity</param>
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
		public  static MessageRelations Relations
		{
			get	{ return new MessageRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Attachment' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAttachments
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<AttachmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AttachmentEntityFactory))), (IEntityRelation)GetRelationsForField("Attachments")[0], (int)SD.HnD.DALAdapter.EntityType.MessageEntity, (int)SD.HnD.DALAdapter.EntityType.AttachmentEntity, 0, null, null, null, null, "Attachments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AuditDataMessageRelated' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAuditDataMessageRelated
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<AuditDataMessageRelatedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditDataMessageRelatedEntityFactory))), (IEntityRelation)GetRelationsForField("AuditDataMessageRelated")[0], (int)SD.HnD.DALAdapter.EntityType.MessageEntity, (int)SD.HnD.DALAdapter.EntityType.AuditDataMessageRelatedEntity, 0, null, null, null, null, "AuditDataMessageRelated", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThread
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))),	(IEntityRelation)GetRelationsForField("Thread")[0], (int)SD.HnD.DALAdapter.EntityType.MessageEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, 0, null, null, null, null, "Thread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPostedByUser
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),	(IEntityRelation)GetRelationsForField("PostedByUser")[0], (int)SD.HnD.DALAdapter.EntityType.MessageEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, null, null, "PostedByUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The MessageID property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."MessageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 MessageID
		{
			get { return (System.Int32)GetValue((int)MessageFieldIndex.MessageID, true); }
			set	{ SetValue((int)MessageFieldIndex.MessageID, value); }
		}

		/// <summary> The PostingDate property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."PostingDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime PostingDate
		{
			get { return (System.DateTime)GetValue((int)MessageFieldIndex.PostingDate, true); }
			set	{ SetValue((int)MessageFieldIndex.PostingDate, value); }
		}

		/// <summary> The PostedByUserID property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."PostedByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PostedByUserID
		{
			get { return (System.Int32)GetValue((int)MessageFieldIndex.PostedByUserID, true); }
			set	{ SetValue((int)MessageFieldIndex.PostedByUserID, value); }
		}

		/// <summary> The ThreadID property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."ThreadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)MessageFieldIndex.ThreadID, true); }
			set	{ SetValue((int)MessageFieldIndex.ThreadID, value); }
		}

		/// <summary> The PostedFromIP property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."PostedFromIP"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PostedFromIP
		{
			get { return (System.String)GetValue((int)MessageFieldIndex.PostedFromIP, true); }
			set	{ SetValue((int)MessageFieldIndex.PostedFromIP, value); }
		}

		/// <summary> The ChangeTrackerStamp property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."ChangeTrackerStamp"<br/>
		/// Table field type characteristics (type, precision, scale, length): Timestamp, 0, 0, 8<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte[] ChangeTrackerStamp
		{
			get { return (System.Byte[])GetValue((int)MessageFieldIndex.ChangeTrackerStamp, true); }

		}

		/// <summary> The MessageText property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."MessageText"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MessageText
		{
			get { return (System.String)GetValue((int)MessageFieldIndex.MessageText, true); }
			set	{ SetValue((int)MessageFieldIndex.MessageText, value); }
		}

		/// <summary> The MessageTextAsHTML property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."MessageTextAsHTML"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MessageTextAsHTML
		{
			get { return (System.String)GetValue((int)MessageFieldIndex.MessageTextAsHTML, true); }
			set	{ SetValue((int)MessageFieldIndex.MessageTextAsHTML, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AttachmentEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(AttachmentEntity))]
		public virtual EntityCollection<AttachmentEntity> Attachments
		{
			get { return GetOrCreateEntityCollection<AttachmentEntity, AttachmentEntityFactory>("BelongsToMessage", true, false, ref _attachments);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AuditDataMessageRelatedEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(AuditDataMessageRelatedEntity))]
		public virtual EntityCollection<AuditDataMessageRelatedEntity> AuditDataMessageRelated
		{
			get { return GetOrCreateEntityCollection<AuditDataMessageRelatedEntity, AuditDataMessageRelatedEntityFactory>("Message", true, false, ref _auditDataMessageRelated);	}
		}

		/// <summary> Gets / sets related entity of type 'ThreadEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ThreadEntity Thread
		{
			get	{ return _thread; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncThread(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Messages", "Thread", _thread, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity PostedByUser
		{
			get	{ return _postedByUser; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncPostedByUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "PostedMessages", "PostedByUser", _postedByUser, true); 
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
			get { return (int)SD.HnD.DALAdapter.EntityType.MessageEntity; }
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
