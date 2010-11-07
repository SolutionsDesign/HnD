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
	/// <summary>Entity base class which represents the base class for the entity 'SupportQueue'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class SupportQueueEntityBase : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.ForumCollection	_defaultForForums;
		private bool	_alwaysFetchDefaultForForums, _alreadyFetchedDefaultForForums;
		private SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection	_supportQueueThreads;
		private bool	_alwaysFetchSupportQueueThreads, _alreadyFetchedSupportQueueThreads;



		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{

			/// <summary>Member name DefaultForForums</summary>
			public static readonly string DefaultForForums = "DefaultForForums";
			/// <summary>Member name SupportQueueThreads</summary>
			public static readonly string SupportQueueThreads = "SupportQueueThreads";


		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SupportQueueEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public SupportQueueEntityBase()
		{
			InitClassEmpty(null);
		}

	
		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		public SupportQueueEntityBase(System.Int32 queueID)
		{
			InitClassFetch(queueID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public SupportQueueEntityBase(System.Int32 queueID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(queueID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <param name="validator">The custom validator object for this SupportQueueEntity</param>
		public SupportQueueEntityBase(System.Int32 queueID, IValidator validator)
		{
			InitClassFetch(queueID, validator, null);
		}
	

		/// <summary>Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SupportQueueEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_defaultForForums = (SD.HnD.DAL.CollectionClasses.ForumCollection)info.GetValue("_defaultForForums", typeof(SD.HnD.DAL.CollectionClasses.ForumCollection));
			_alwaysFetchDefaultForForums = info.GetBoolean("_alwaysFetchDefaultForForums");
			_alreadyFetchedDefaultForForums = info.GetBoolean("_alreadyFetchedDefaultForForums");
			_supportQueueThreads = (SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection)info.GetValue("_supportQueueThreads", typeof(SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection));
			_alwaysFetchSupportQueueThreads = info.GetBoolean("_alwaysFetchSupportQueueThreads");
			_alreadyFetchedSupportQueueThreads = info.GetBoolean("_alreadyFetchedSupportQueueThreads");



			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((SupportQueueFieldIndex)fieldIndex)
			{
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
			_alreadyFetchedDefaultForForums = (_defaultForForums.Count > 0);
			_alreadyFetchedSupportQueueThreads = (_supportQueueThreads.Count > 0);



		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return SupportQueueEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "DefaultForForums":
					toReturn.Add(SupportQueueEntity.Relations.ForumEntityUsingDefaultSupportQueueID);
					break;
				case "SupportQueueThreads":
					toReturn.Add(SupportQueueEntity.Relations.SupportQueueThreadEntityUsingQueueID);
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
			info.AddValue("_defaultForForums", (!this.MarkedForDeletion?_defaultForForums:null));
			info.AddValue("_alwaysFetchDefaultForForums", _alwaysFetchDefaultForForums);
			info.AddValue("_alreadyFetchedDefaultForForums", _alreadyFetchedDefaultForForums);
			info.AddValue("_supportQueueThreads", (!this.MarkedForDeletion?_supportQueueThreads:null));
			info.AddValue("_alwaysFetchSupportQueueThreads", _alwaysFetchSupportQueueThreads);
			info.AddValue("_alreadyFetchedSupportQueueThreads", _alreadyFetchedSupportQueueThreads);



			
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

				case "DefaultForForums":
					_alreadyFetchedDefaultForForums = true;
					if(entity!=null)
					{
						this.DefaultForForums.Add((ForumEntity)entity);
					}
					break;
				case "SupportQueueThreads":
					_alreadyFetchedSupportQueueThreads = true;
					if(entity!=null)
					{
						this.SupportQueueThreads.Add((SupportQueueThreadEntity)entity);
					}
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

				case "DefaultForForums":
					_defaultForForums.Add((ForumEntity)relatedEntity);
					break;
				case "SupportQueueThreads":
					_supportQueueThreads.Add((SupportQueueThreadEntity)relatedEntity);
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

				case "DefaultForForums":
					base.PerformRelatedEntityRemoval(_defaultForForums, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportQueueThreads":
					base.PerformRelatedEntityRemoval(_supportQueueThreads, relatedEntity, signalRelatedEntityManyToOne);
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



			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_defaultForForums);
			toReturn.Add(_supportQueueThreads);

			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID)
		{
			return FetchUsingPK(queueID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(queueID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(queueID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(queueID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.QueueID, null, null, null);
		}

		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(SupportQueueFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(SupportQueueFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new SupportQueueRelations().GetAllRelations();
		}


		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ForumEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ForumCollection GetMultiDefaultForForums(bool forceFetch)
		{
			return GetMultiDefaultForForums(forceFetch, _defaultForForums.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ForumEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ForumCollection GetMultiDefaultForForums(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiDefaultForForums(forceFetch, _defaultForForums.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ForumCollection GetMultiDefaultForForums(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiDefaultForForums(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.ForumCollection GetMultiDefaultForForums(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedDefaultForForums || forceFetch || _alwaysFetchDefaultForForums) && !base.IsSerializing && !base.IsDeserializing && !base.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_defaultForForums.ParticipatesInTransaction)
					{
						base.Transaction.Add(_defaultForForums);
					}
				}
				_defaultForForums.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_defaultForForums.EntityFactoryToUse = entityFactoryToUse;
				}
				_defaultForForums.GetMultiManyToOne(null, this, filter);
				_defaultForForums.SuppressClearInGetMulti=false;
				_alreadyFetchedDefaultForForums = true;
			}
			return _defaultForForums;
		}

		/// <summary> Sets the collection parameters for the collection for 'DefaultForForums'. These settings will be taken into account
		/// when the property DefaultForForums is requested or GetMultiDefaultForForums is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersDefaultForForums(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_defaultForForums.SortClauses=sortClauses;
			_defaultForForums.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SupportQueueThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreads(bool forceFetch)
		{
			return GetMultiSupportQueueThreads(forceFetch, _supportQueueThreads.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SupportQueueThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreads(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSupportQueueThreads(forceFetch, _supportQueueThreads.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreads(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSupportQueueThreads(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreads(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSupportQueueThreads || forceFetch || _alwaysFetchSupportQueueThreads) && !base.IsSerializing && !base.IsDeserializing && !base.InDesignMode)
			{
				if(base.ParticipatesInTransaction)
				{
					if(!_supportQueueThreads.ParticipatesInTransaction)
					{
						base.Transaction.Add(_supportQueueThreads);
					}
				}
				_supportQueueThreads.SuppressClearInGetMulti=!forceFetch;
				if(entityFactoryToUse!=null)
				{
					_supportQueueThreads.EntityFactoryToUse = entityFactoryToUse;
				}
				_supportQueueThreads.GetMultiManyToOne(this, null, null, filter);
				_supportQueueThreads.SuppressClearInGetMulti=false;
				_alreadyFetchedSupportQueueThreads = true;
			}
			return _supportQueueThreads;
		}

		/// <summary> Sets the collection parameters for the collection for 'SupportQueueThreads'. These settings will be taken into account
		/// when the property SupportQueueThreads is requested or GetMultiSupportQueueThreads is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSupportQueueThreads(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_supportQueueThreads.SortClauses=sortClauses;
			_supportQueueThreads.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}




		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			SupportQueueDAO dao = (SupportQueueDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_defaultForForums.ActiveContext = base.ActiveContext;
			_supportQueueThreads.ActiveContext = base.ActiveContext;




		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			SupportQueueDAO dao = (SupportQueueDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			SupportQueueDAO dao = (SupportQueueDAO)CreateDAOInstance();
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
			return EntityFieldsFactory.CreateEntityFieldsObject(SD.HnD.DAL.EntityType.SupportQueueEntity);
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

			toReturn.Add("DefaultForForums", _defaultForForums);
			toReturn.Add("SupportQueueThreads", _supportQueueThreads);


			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <param name="validator">The validator object for this SupportQueueEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 queueID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			base.Validator = validator;
			InitClassMembers();
			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(queueID, prefetchPathToUse, null, null);
			base.IsNew = !wasSuccesful;

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_defaultForForums = new SD.HnD.DAL.CollectionClasses.ForumCollection(new ForumEntityFactory());
			_defaultForForums.SetContainingEntityInfo(this, "DefaultSupportQueue");
			_alwaysFetchDefaultForForums = false;
			_alreadyFetchedDefaultForForums = false;
			_supportQueueThreads = new SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection(new SupportQueueThreadEntityFactory());
			_supportQueueThreads.SetContainingEntityInfo(this, "SupportQueue");
			_alwaysFetchSupportQueueThreads = false;
			_alreadyFetchedSupportQueueThreads = false;




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

			_fieldsCustomProperties.Add("QueueID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QueueName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QueueDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrderNo", fieldHashtable);
		}
		#endregion




		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="queueID">PK value for SupportQueue which data should be fetched into this SupportQueue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 queueID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)SupportQueueFieldIndex.QueueID].ForcedCurrentValueWrite(queueID);
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
			return DAOFactory.CreateSupportQueueDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new SupportQueueEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static SupportQueueRelations Relations
		{
			get	{ return new SupportQueueRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}


		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Forum' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathDefaultForForums
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ForumCollection(),
					(IEntityRelation)GetRelationsForField("DefaultForForums")[0], (int)SD.HnD.DAL.EntityType.SupportQueueEntity, (int)SD.HnD.DAL.EntityType.ForumEntity, 0, null, null, null, "DefaultForForums", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportQueueThread' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportQueueThreads
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection(),
					(IEntityRelation)GetRelationsForField("SupportQueueThreads")[0], (int)SD.HnD.DAL.EntityType.SupportQueueEntity, (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, 0, null, null, null, "SupportQueueThreads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}




		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "SupportQueueEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return SupportQueueEntity.CustomProperties;}
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
			get { return SupportQueueEntity.FieldsCustomProperties;}
		}

		/// <summary> The QueueID property of the Entity SupportQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SupportQueue"."QueueID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 QueueID
		{
			get { return (System.Int32)GetValue((int)SupportQueueFieldIndex.QueueID, true); }
			set	{ SetValue((int)SupportQueueFieldIndex.QueueID, value, true); }
		}
		/// <summary> The QueueName property of the Entity SupportQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SupportQueue"."QueueName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String QueueName
		{
			get { return (System.String)GetValue((int)SupportQueueFieldIndex.QueueName, true); }
			set	{ SetValue((int)SupportQueueFieldIndex.QueueName, value, true); }
		}
		/// <summary> The QueueDescription property of the Entity SupportQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SupportQueue"."QueueDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String QueueDescription
		{
			get { return (System.String)GetValue((int)SupportQueueFieldIndex.QueueDescription, true); }
			set	{ SetValue((int)SupportQueueFieldIndex.QueueDescription, value, true); }
		}
		/// <summary> The OrderNo property of the Entity SupportQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SupportQueue"."OrderNo"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 OrderNo
		{
			get { return (System.Int16)GetValue((int)SupportQueueFieldIndex.OrderNo, true); }
			set	{ SetValue((int)SupportQueueFieldIndex.OrderNo, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiDefaultForForums()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ForumCollection DefaultForForums
		{
			get	{ return GetMultiDefaultForForums(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for DefaultForForums. When set to true, DefaultForForums is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time DefaultForForums is accessed. You can always execute
		/// a forced fetch by calling GetMultiDefaultForForums(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchDefaultForForums
		{
			get	{ return _alwaysFetchDefaultForForums; }
			set	{ _alwaysFetchDefaultForForums = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property DefaultForForums already has been fetched. Setting this property to false when DefaultForForums has been fetched
		/// will clear the DefaultForForums collection well. Setting this property to true while DefaultForForums hasn't been fetched disables lazy loading for DefaultForForums</summary>
		[Browsable(false)]
		public bool AlreadyFetchedDefaultForForums
		{
			get { return _alreadyFetchedDefaultForForums;}
			set 
			{
				if(_alreadyFetchedDefaultForForums && !value && (_defaultForForums != null))
				{
					_defaultForForums.Clear();
				}
				_alreadyFetchedDefaultForForums = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSupportQueueThreads()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection SupportQueueThreads
		{
			get	{ return GetMultiSupportQueueThreads(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SupportQueueThreads. When set to true, SupportQueueThreads is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportQueueThreads is accessed. You can always execute
		/// a forced fetch by calling GetMultiSupportQueueThreads(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportQueueThreads
		{
			get	{ return _alwaysFetchSupportQueueThreads; }
			set	{ _alwaysFetchSupportQueueThreads = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property SupportQueueThreads already has been fetched. Setting this property to false when SupportQueueThreads has been fetched
		/// will clear the SupportQueueThreads collection well. Setting this property to true while SupportQueueThreads hasn't been fetched disables lazy loading for SupportQueueThreads</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportQueueThreads
		{
			get { return _alreadyFetchedSupportQueueThreads;}
			set 
			{
				if(_alreadyFetchedSupportQueueThreads && !value && (_supportQueueThreads != null))
				{
					_supportQueueThreads.Clear();
				}
				_alreadyFetchedSupportQueueThreads = value;
			}
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
			get { return (int)SD.HnD.DAL.EntityType.SupportQueueEntity; }
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
