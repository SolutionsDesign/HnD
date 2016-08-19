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
	
	/// <summary>Entity class which represents the entity 'SupportQueueThread'.<br/><br/></summary>
	[Serializable]
	public partial class SupportQueueThreadEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private SupportQueueEntity _supportQueue;
		private UserEntity _claimedByUser;
		private UserEntity _placedInQueueByUser;
		private ThreadEntity _thread;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

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
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SupportQueueThreadEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public SupportQueueThreadEntity():base("SupportQueueThreadEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SupportQueueThreadEntity(IEntityFields2 fields):base("SupportQueueThreadEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SupportQueueThreadEntity</param>
		public SupportQueueThreadEntity(IValidator validator):base("SupportQueueThreadEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID):base("SupportQueueThreadEntity")
		{
			InitClassEmpty(null, null);
			this.QueueID = queueID;
			this.ThreadID = threadID;
		}

		/// <summary> CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="validator">The custom validator object for this SupportQueueThreadEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID, IValidator validator):base("SupportQueueThreadEntity")
		{
			InitClassEmpty(validator, null);
			this.QueueID = queueID;
			this.ThreadID = threadID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SupportQueueThreadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_supportQueue = (SupportQueueEntity)info.GetValue("_supportQueue", typeof(SupportQueueEntity));
				if(_supportQueue!=null)
				{
					_supportQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_claimedByUser = (UserEntity)info.GetValue("_claimedByUser", typeof(UserEntity));
				if(_claimedByUser!=null)
				{
					_claimedByUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_placedInQueueByUser = (UserEntity)info.GetValue("_placedInQueueByUser", typeof(UserEntity));
				if(_placedInQueueByUser!=null)
				{
					_placedInQueueByUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_thread = (ThreadEntity)info.GetValue("_thread", typeof(ThreadEntity));
				if(_thread!=null)
				{
					_thread.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((SupportQueueThreadFieldIndex)fieldIndex)
			{
				case SupportQueueThreadFieldIndex.QueueID:
					DesetupSyncSupportQueue(true, false);
					break;
				case SupportQueueThreadFieldIndex.ThreadID:
					DesetupSyncThread(true, false);
					break;
				case SupportQueueThreadFieldIndex.PlacedInQueueByUserID:
					DesetupSyncPlacedInQueueByUser(true, false);
					break;
				case SupportQueueThreadFieldIndex.ClaimedByUserID:
					DesetupSyncClaimedByUser(true, false);
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
				case "SupportQueue":
					this.SupportQueue = (SupportQueueEntity)entity;
					break;
				case "ClaimedByUser":
					this.ClaimedByUser = (UserEntity)entity;
					break;
				case "PlacedInQueueByUser":
					this.PlacedInQueueByUser = (UserEntity)entity;
					break;
				case "Thread":
					this.Thread = (ThreadEntity)entity;
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
				case "SupportQueue":
					toReturn.Add(Relations.SupportQueueEntityUsingQueueID);
					break;
				case "ClaimedByUser":
					toReturn.Add(Relations.UserEntityUsingClaimedByUserID);
					break;
				case "PlacedInQueueByUser":
					toReturn.Add(Relations.UserEntityUsingPlacedInQueueByUserID);
					break;
				case "Thread":
					toReturn.Add(Relations.ThreadEntityUsingThreadID);
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
				case "SupportQueue":
					SetupSyncSupportQueue(relatedEntity);
					break;
				case "ClaimedByUser":
					SetupSyncClaimedByUser(relatedEntity);
					break;
				case "PlacedInQueueByUser":
					SetupSyncPlacedInQueueByUser(relatedEntity);
					break;
				case "Thread":
					SetupSyncThread(relatedEntity);
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
				case "SupportQueue":
					DesetupSyncSupportQueue(false, true);
					break;
				case "ClaimedByUser":
					DesetupSyncClaimedByUser(false, true);
					break;
				case "PlacedInQueueByUser":
					DesetupSyncPlacedInQueueByUser(false, true);
					break;
				case "Thread":
					DesetupSyncThread(false, true);
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
			if(_supportQueue!=null)
			{
				toReturn.Add(_supportQueue);
			}
			if(_claimedByUser!=null)
			{
				toReturn.Add(_claimedByUser);
			}
			if(_placedInQueueByUser!=null)
			{
				toReturn.Add(_placedInQueueByUser);
			}

			if(_thread!=null)
			{
				toReturn.Add(_thread);
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
				info.AddValue("_supportQueue", (!this.MarkedForDeletion?_supportQueue:null));
				info.AddValue("_claimedByUser", (!this.MarkedForDeletion?_claimedByUser:null));
				info.AddValue("_placedInQueueByUser", (!this.MarkedForDeletion?_placedInQueueByUser:null));
				info.AddValue("_thread", (!this.MarkedForDeletion?_thread:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// ThreadID .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCThreadID()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(SD.HnD.DALAdapter.HelperClasses.SupportQueueThreadFields.ThreadID == this.Fields.GetCurrentValue((int)SupportQueueThreadFieldIndex.ThreadID));
 			return filter;
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new SupportQueueThreadRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'SupportQueue' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSupportQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SupportQueueFields.QueueID, null, ComparisonOperator.Equal, this.QueueID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClaimedByUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.ClaimedByUserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPlacedInQueueByUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.PlacedInQueueByUserID));
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
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueThreadEntityFactory));
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
			toReturn.Add("SupportQueue", _supportQueue);
			toReturn.Add("ClaimedByUser", _claimedByUser);
			toReturn.Add("PlacedInQueueByUser", _placedInQueueByUser);
			toReturn.Add("Thread", _thread);
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
			_fieldsCustomProperties.Add("QueueID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PlacedInQueueByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PlacedInQueueOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ClaimedByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ClaimedOn", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _supportQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSupportQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _supportQueue, new PropertyChangedEventHandler( OnSupportQueuePropertyChanged ), "SupportQueue", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.SupportQueueEntityUsingQueueIDStatic, true, signalRelatedEntity, "SupportQueueThreads", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.QueueID } );
			_supportQueue = null;
		}

		/// <summary> setups the sync logic for member _supportQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSupportQueue(IEntityCore relatedEntity)
		{
			if(_supportQueue!=relatedEntity)
			{
				DesetupSyncSupportQueue(true, true);
				_supportQueue = (SupportQueueEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _supportQueue, new PropertyChangedEventHandler( OnSupportQueuePropertyChanged ), "SupportQueue", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.SupportQueueEntityUsingQueueIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSupportQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _claimedByUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncClaimedByUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _claimedByUser, new PropertyChangedEventHandler( OnClaimedByUserPropertyChanged ), "ClaimedByUser", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingClaimedByUserIDStatic, true, signalRelatedEntity, "SupportQueueThreadsClaimed", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.ClaimedByUserID } );
			_claimedByUser = null;
		}

		/// <summary> setups the sync logic for member _claimedByUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncClaimedByUser(IEntityCore relatedEntity)
		{
			if(_claimedByUser!=relatedEntity)
			{
				DesetupSyncClaimedByUser(true, true);
				_claimedByUser = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _claimedByUser, new PropertyChangedEventHandler( OnClaimedByUserPropertyChanged ), "ClaimedByUser", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingClaimedByUserIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClaimedByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _placedInQueueByUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPlacedInQueueByUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _placedInQueueByUser, new PropertyChangedEventHandler( OnPlacedInQueueByUserPropertyChanged ), "PlacedInQueueByUser", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingPlacedInQueueByUserIDStatic, true, signalRelatedEntity, "SupportQueueThreadsPlaced", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID } );
			_placedInQueueByUser = null;
		}

		/// <summary> setups the sync logic for member _placedInQueueByUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPlacedInQueueByUser(IEntityCore relatedEntity)
		{
			if(_placedInQueueByUser!=relatedEntity)
			{
				DesetupSyncPlacedInQueueByUser(true, true);
				_placedInQueueByUser = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _placedInQueueByUser, new PropertyChangedEventHandler( OnPlacedInQueueByUserPropertyChanged ), "PlacedInQueueByUser", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingPlacedInQueueByUserIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPlacedInQueueByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _thread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.ThreadEntityUsingThreadIDStatic, true, signalRelatedEntity, "SupportQueueThread", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.ThreadID } );
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
				this.PerformSetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DALAdapter.RelationClasses.StaticSupportQueueThreadRelations.ThreadEntityUsingThreadIDStatic, true, new string[] {  } );
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

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
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

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static SupportQueueThreadRelations Relations
		{
			get	{ return new SupportQueueThreadRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueue' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSupportQueue
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueEntityFactory))),	(IEntityRelation)GetRelationsForField("SupportQueue")[0], (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DALAdapter.EntityType.SupportQueueEntity, 0, null, null, null, null, "SupportQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClaimedByUser
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),	(IEntityRelation)GetRelationsForField("ClaimedByUser")[0], (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, null, null, "ClaimedByUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPlacedInQueueByUser
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),	(IEntityRelation)GetRelationsForField("PlacedInQueueByUser")[0], (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, null, null, "PlacedInQueueByUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThread
		{
			get { return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))), (IEntityRelation)GetRelationsForField("Thread")[0], (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, 0, null, null, null, null, "Thread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);	}
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

		/// <summary> The QueueID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."QueueID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 QueueID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.QueueID, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.QueueID, value); }
		}

		/// <summary> The ThreadID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ThreadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.ThreadID, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.ThreadID, value); }
		}

		/// <summary> The PlacedInQueueByUserID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."PlacedInQueueByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PlacedInQueueByUserID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, value); }
		}

		/// <summary> The PlacedInQueueOn property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."PlacedInQueueOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime PlacedInQueueOn
		{
			get { return (System.DateTime)GetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueOn, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueOn, value); }
		}

		/// <summary> The ClaimedByUserID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ClaimedByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ClaimedByUserID
		{
			get { return (Nullable<System.Int32>)GetValue((int)SupportQueueThreadFieldIndex.ClaimedByUserID, false); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.ClaimedByUserID, value); }
		}

		/// <summary> The ClaimedOn property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ClaimedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ClaimedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)SupportQueueThreadFieldIndex.ClaimedOn, false); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.ClaimedOn, value); }
		}

		/// <summary> Gets / sets related entity of type 'SupportQueueEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual SupportQueueEntity SupportQueue
		{
			get	{ return _supportQueue; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncSupportQueue(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportQueueThreads", "SupportQueue", _supportQueue, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity ClaimedByUser
		{
			get	{ return _claimedByUser; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncClaimedByUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportQueueThreadsClaimed", "ClaimedByUser", _claimedByUser, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity PlacedInQueueByUser
		{
			get	{ return _placedInQueueByUser; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncPlacedInQueueByUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportQueueThreadsPlaced", "PlacedInQueueByUser", _placedInQueueByUser, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ThreadEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/>
		/// </summary>
		[Browsable(true)]
		public virtual ThreadEntity Thread
		{
			get { return _thread; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncThread(value);
					CallSetRelatedEntityDuringDeserialization(value, "SupportQueueThread");
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_thread !=null);
						DesetupSyncThread(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("Thread");
						}
					}
					else
					{
						if(_thread!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SupportQueueThread");
							SetupSyncThread(value);
						}
					}
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
			get { return (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity; }
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
