///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Data;
using System.Xml.Serialization;
using SD.HnD.DAL;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.RelationClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity base class which represents the base class for the entity 'Attachment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class AttachmentEntityBase : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private MessageEntity _belongsToMessage;
		private bool	_alwaysFetchBelongsToMessage, _alreadyFetchedBelongsToMessage, _belongsToMessageReturnsNewIfNotFound;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BelongsToMessage</summary>
			public static readonly string BelongsToMessage = "BelongsToMessage";



		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AttachmentEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public AttachmentEntityBase()
		{
			InitClassEmpty(null);
		}

	
		/// <summary>CTor</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		public AttachmentEntityBase(System.Int32 attachmentID)
		{
			InitClassFetch(attachmentID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public AttachmentEntityBase(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(attachmentID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="validator">The custom validator object for this AttachmentEntity</param>
		public AttachmentEntityBase(System.Int32 attachmentID, IValidator validator)
		{
			InitClassFetch(attachmentID, validator, null);
		}
	

		/// <summary>Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AttachmentEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{


			_belongsToMessage = (MessageEntity)info.GetValue("_belongsToMessage", typeof(MessageEntity));
			if(_belongsToMessage!=null)
			{
				_belongsToMessage.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_belongsToMessageReturnsNewIfNotFound = info.GetBoolean("_belongsToMessageReturnsNewIfNotFound");
			_alwaysFetchBelongsToMessage = info.GetBoolean("_alwaysFetchBelongsToMessage");
			_alreadyFetchedBelongsToMessage = info.GetBoolean("_alreadyFetchedBelongsToMessage");

			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AttachmentFieldIndex)fieldIndex)
			{
				case AttachmentFieldIndex.MessageID:
					DesetupSyncBelongsToMessage(true, false);
					_alreadyFetchedBelongsToMessage = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
		
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{


			_alreadyFetchedBelongsToMessage = (_belongsToMessage != null);

		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return AttachmentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "BelongsToMessage":
					toReturn.Add(AttachmentEntity.Relations.MessageEntityUsingMessageID);
					break;



				default:

					break;				
			}
			return toReturn;
		}



		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{


			info.AddValue("_belongsToMessage", (!this.MarkedForDeletion?_belongsToMessage:null));
			info.AddValue("_belongsToMessageReturnsNewIfNotFound", _belongsToMessageReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchBelongsToMessage", _alwaysFetchBelongsToMessage);
			info.AddValue("_alreadyFetchedBelongsToMessage", _alreadyFetchedBelongsToMessage);

			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity entity)
		{
			switch(propertyName)
			{
				case "BelongsToMessage":
					_alreadyFetchedBelongsToMessage = true;
					this.BelongsToMessage = (MessageEntity)entity;
					break;



				default:

					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "BelongsToMessage":
					SetupSyncBelongsToMessage(relatedEntity);
					break;


				default:

					break;
			}
		}
		
		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "BelongsToMessage":
					DesetupSyncBelongsToMessage(false, true);
					break;


				default:

					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();


			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_belongsToMessage!=null)
			{
				toReturn.Add(_belongsToMessage);
			}


			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();


			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID)
		{
			return FetchUsingPK(attachmentID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(attachmentID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(attachmentID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(attachmentID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.AttachmentID, null, null, null);
		}

		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AttachmentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AttachmentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AttachmentRelations().GetAllRelations();
		}




		/// <summary> Retrieves the related entity of type 'MessageEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'MessageEntity' which is related to this entity.</returns>
		public MessageEntity GetSingleBelongsToMessage()
		{
			return GetSingleBelongsToMessage(false);
		}

		/// <summary> Retrieves the related entity of type 'MessageEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'MessageEntity' which is related to this entity.</returns>
		public virtual MessageEntity GetSingleBelongsToMessage(bool forceFetch)
		{
			if( ( !_alreadyFetchedBelongsToMessage || forceFetch || _alwaysFetchBelongsToMessage) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(AttachmentEntity.Relations.MessageEntityUsingMessageID);

				MessageEntity newEntity = new MessageEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.MessageID);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (MessageEntity)base.ActiveContext.Get(newEntity);
					}
					this.BelongsToMessage = newEntity;
				}
				else
				{
					if(_belongsToMessageReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_belongsToMessage == null)))
						{
							this.BelongsToMessage = newEntity;
						}
					}
					else
					{
						this.BelongsToMessage = null;
					}
				}
				_alreadyFetchedBelongsToMessage = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _belongsToMessage;
		}


		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			AttachmentDAO dao = (AttachmentDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_belongsToMessage!=null)
			{
				_belongsToMessage.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			AttachmentDAO dao = (AttachmentDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			AttachmentDAO dao = (AttachmentDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction, updateRestriction);
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		protected virtual void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			base.Fields = CreateFields();
			base.IsNew=true;
			base.Validator = validatorToUse;

			InitClassMembers();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(SD.HnD.DAL.EntityType.AttachmentEntity);
		}
		
		/// <summary>Creates a new transaction object</summary>
		/// <param name="levelOfIsolation">The level of isolation.</param>
		/// <param name="name">The name.</param>
		protected override ITransaction CreateTransaction( IsolationLevel levelOfIsolation, string name )
		{
			return new Transaction(levelOfIsolation, name);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BelongsToMessage", _belongsToMessage);



			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="validator">The validator object for this AttachmentEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 attachmentID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			base.Validator = validator;
			InitClassMembers();
			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(attachmentID, prefetchPathToUse, null, null);
			base.IsNew = !wasSuccesful;

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{


			_belongsToMessage = null;
			_belongsToMessageReturnsNewIfNotFound = true;
			_alwaysFetchBelongsToMessage = false;
			_alreadyFetchedBelongsToMessage = false;


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

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachmentID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MessageID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Filename", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Approved", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Filecontents", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Filesize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddedOn", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _belongsToMessage</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBelongsToMessage(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _belongsToMessage, new PropertyChangedEventHandler( OnBelongsToMessagePropertyChanged ), "BelongsToMessage", AttachmentEntity.Relations.MessageEntityUsingMessageID, true, signalRelatedEntity, "Attachments", resetFKFields, new int[] { (int)AttachmentFieldIndex.MessageID } );		
			_belongsToMessage = null;
		}
		
		/// <summary> setups the sync logic for member _belongsToMessage</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBelongsToMessage(IEntity relatedEntity)
		{
			if(_belongsToMessage!=relatedEntity)
			{		
				DesetupSyncBelongsToMessage(true, true);
				_belongsToMessage = (MessageEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _belongsToMessage, new PropertyChangedEventHandler( OnBelongsToMessagePropertyChanged ), "BelongsToMessage", AttachmentEntity.Relations.MessageEntityUsingMessageID, true, ref _alreadyFetchedBelongsToMessage, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBelongsToMessagePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)AttachmentFieldIndex.AttachmentID].ForcedCurrentValueWrite(attachmentID);
				dao.FetchExisting(this, base.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (base.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}


		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateAttachmentDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new AttachmentEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AttachmentRelations Relations
		{
			get	{ return new AttachmentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Message' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathBelongsToMessage
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.MessageCollection(),
					(IEntityRelation)GetRelationsForField("BelongsToMessage")[0], (int)SD.HnD.DAL.EntityType.AttachmentEntity, (int)SD.HnD.DAL.EntityType.MessageEntity, 0, null, null, null, "BelongsToMessage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "AttachmentEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AttachmentEntity.CustomProperties;}
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
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return AttachmentEntity.FieldsCustomProperties;}
		}

		/// <summary> The AttachmentID property of the Entity Attachment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attachment"."AttachmentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AttachmentID
		{
			get { return (System.Int32)GetValue((int)AttachmentFieldIndex.AttachmentID, true); }
			set	{ SetValue((int)AttachmentFieldIndex.AttachmentID, value, true); }
		}
		/// <summary> The MessageID property of the Entity Attachment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attachment"."MessageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 MessageID
		{
			get { return (System.Int32)GetValue((int)AttachmentFieldIndex.MessageID, true); }
			set	{ SetValue((int)AttachmentFieldIndex.MessageID, value, true); }
		}
		/// <summary> The Filename property of the Entity Attachment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attachment"."Filename"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Filename
		{
			get { return (System.String)GetValue((int)AttachmentFieldIndex.Filename, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Filename, value, true); }
		}
		/// <summary> The Approved property of the Entity Attachment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attachment"."Approved"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 1, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Approved
		{
			get { return (System.Boolean)GetValue((int)AttachmentFieldIndex.Approved, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Approved, value, true); }
		}
		/// <summary> The Filecontents property of the Entity Attachment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attachment"."Filecontents"<br/>
		/// Table field type characteristics (type, precision, scale, length): Image, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte[] Filecontents
		{
			get { return (System.Byte[])GetValue((int)AttachmentFieldIndex.Filecontents, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Filecontents, value, true); }
		}
		/// <summary> The Filesize property of the Entity Attachment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attachment"."Filesize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Filesize
		{
			get { return (System.Int32)GetValue((int)AttachmentFieldIndex.Filesize, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Filesize, value, true); }
		}
		/// <summary> The AddedOn property of the Entity Attachment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attachment"."AddedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 23, 3, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AddedOn
		{
			get { return (System.DateTime)GetValue((int)AttachmentFieldIndex.AddedOn, true); }
			set	{ SetValue((int)AttachmentFieldIndex.AddedOn, value, true); }
		}



		/// <summary> Gets / sets related entity of type 'MessageEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleBelongsToMessage()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual MessageEntity BelongsToMessage
		{
			get	{ return GetSingleBelongsToMessage(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBelongsToMessage(value);
				}
				else
				{
					if(value==null)
					{
						if(_belongsToMessage != null)
						{
							_belongsToMessage.UnsetRelatedEntity(this, "Attachments");
						}
					}
					else
					{
						if(_belongsToMessage!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Attachments");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for BelongsToMessage. When set to true, BelongsToMessage is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time BelongsToMessage is accessed. You can always execute
		/// a forced fetch by calling GetSingleBelongsToMessage(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchBelongsToMessage
		{
			get	{ return _alwaysFetchBelongsToMessage; }
			set	{ _alwaysFetchBelongsToMessage = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property BelongsToMessage already has been fetched. Setting this property to false when BelongsToMessage has been fetched
		/// will set BelongsToMessage to null as well. Setting this property to true while BelongsToMessage hasn't been fetched disables lazy loading for BelongsToMessage</summary>
		[Browsable(false)]
		public bool AlreadyFetchedBelongsToMessage
		{
			get { return _alreadyFetchedBelongsToMessage;}
			set 
			{
				if(_alreadyFetchedBelongsToMessage && !value)
				{
					this.BelongsToMessage = null;
				}
				_alreadyFetchedBelongsToMessage = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property BelongsToMessage is not found
		/// in the database. When set to true, BelongsToMessage will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool BelongsToMessageReturnsNewIfNotFound
		{
			get	{ return _belongsToMessageReturnsNewIfNotFound; }
			set { _belongsToMessageReturnsNewIfNotFound = value; }	
		}



		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary>Returns the SD.HnD.DAL.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)SD.HnD.DAL.EntityType.AttachmentEntity; }
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
