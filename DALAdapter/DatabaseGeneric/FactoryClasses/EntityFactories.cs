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
using System.Collections.Generic;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2<TEntity> : EntityFactoryCore2
		where TEntity : EntityBase2, IEntity2
	{
		private readonly SD.HnD.DALAdapter.EntityType _typeOfEntity;
		private readonly bool _isInHierarchy;
		
		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <param name="isInHierarchy">If true, the entity of this factory is in an inheritance hierarchy, false otherwise</param>
		public EntityFactoryBase2(string entityName, SD.HnD.DALAdapter.EntityType typeOfEntity, bool isInHierarchy) : base(entityName)
		{
			_typeOfEntity = typeOfEntity;
			_isInHierarchy = isInHierarchy;
		}
		
		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields2 object for the entity to create.</summary>
		/// <returns>Empty IEntityFields2 object.</returns>
		public override IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(_typeOfEntity);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.Create((SD.HnD.DALAdapter.EntityType)entityTypeValue);
		}

		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <param name="objectAlias">The object alias to use for the elements in the relations.</param>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetHierarchyRelations(this.ForEntityName, objectAlias);
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			IEntityFactory2 toReturn = (IEntityFactory2)InheritanceInfoProviderSingleton.GetInstance().GetEntityFactory(this.ForEntityName, fieldValues, entityFieldStartIndexesPerEntity);
			if(toReturn == null)
			{
				toReturn = this;
			}
			return toReturn;
		}
		
		/// <summary>Gets a predicateexpression which filters on the entity with type belonging to this factory.</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <param name="objectAlias">The object alias to use for the predicate(s).</param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if the belonging entity isn't a hierarchical type.</returns>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);
		}
						
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity which this factory belongs to.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<TEntity>(this);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields2 object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields2 CreateHierarchyFields() 
		{
			return _isInHierarchy ? new EntityFields2(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields(this.ForEntityName), InheritanceInfoProviderSingleton.GetInstance(), null) : base.CreateHierarchyFields();
		}
	}

	/// <summary>Factory to create new, empty ActionRightEntity objects.</summary>
	[Serializable]
	public partial class ActionRightEntityFactory : EntityFactoryBase2<ActionRightEntity> {
		/// <summary>CTor</summary>
		public ActionRightEntityFactory() : base("ActionRightEntity", SD.HnD.DALAdapter.EntityType.ActionRightEntity, false) { }
		
		/// <summary>Creates a new ActionRightEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ActionRightEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActionRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty AttachmentEntity objects.</summary>
	[Serializable]
	public partial class AttachmentEntityFactory : EntityFactoryBase2<AttachmentEntity> {
		/// <summary>CTor</summary>
		public AttachmentEntityFactory() : base("AttachmentEntity", SD.HnD.DALAdapter.EntityType.AttachmentEntity, false) { }
		
		/// <summary>Creates a new AttachmentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AttachmentEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAttachmentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty AuditActionEntity objects.</summary>
	[Serializable]
	public partial class AuditActionEntityFactory : EntityFactoryBase2<AuditActionEntity> {
		/// <summary>CTor</summary>
		public AuditActionEntityFactory() : base("AuditActionEntity", SD.HnD.DALAdapter.EntityType.AuditActionEntity, false) { }
		
		/// <summary>Creates a new AuditActionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AuditActionEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditActionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty AuditDataCoreEntity objects.</summary>
	[Serializable]
	public partial class AuditDataCoreEntityFactory : EntityFactoryBase2<AuditDataCoreEntity> {
		/// <summary>CTor</summary>
		public AuditDataCoreEntityFactory() : base("AuditDataCoreEntity", SD.HnD.DALAdapter.EntityType.AuditDataCoreEntity, true) { }
		
		/// <summary>Creates a new AuditDataCoreEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AuditDataCoreEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataCoreUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty AuditDataMessageRelatedEntity objects.</summary>
	[Serializable]
	public partial class AuditDataMessageRelatedEntityFactory : EntityFactoryBase2<AuditDataMessageRelatedEntity> {
		/// <summary>CTor</summary>
		public AuditDataMessageRelatedEntityFactory() : base("AuditDataMessageRelatedEntity", SD.HnD.DALAdapter.EntityType.AuditDataMessageRelatedEntity, true) { }
		
		/// <summary>Creates a new AuditDataMessageRelatedEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AuditDataMessageRelatedEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataMessageRelatedUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty AuditDataThreadRelatedEntity objects.</summary>
	[Serializable]
	public partial class AuditDataThreadRelatedEntityFactory : EntityFactoryBase2<AuditDataThreadRelatedEntity> {
		/// <summary>CTor</summary>
		public AuditDataThreadRelatedEntityFactory() : base("AuditDataThreadRelatedEntity", SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity, true) { }
		
		/// <summary>Creates a new AuditDataThreadRelatedEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AuditDataThreadRelatedEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataThreadRelatedUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty BookmarkEntity objects.</summary>
	[Serializable]
	public partial class BookmarkEntityFactory : EntityFactoryBase2<BookmarkEntity> {
		/// <summary>CTor</summary>
		public BookmarkEntityFactory() : base("BookmarkEntity", SD.HnD.DALAdapter.EntityType.BookmarkEntity, false) { }
		
		/// <summary>Creates a new BookmarkEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BookmarkEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBookmarkUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty ForumEntity objects.</summary>
	[Serializable]
	public partial class ForumEntityFactory : EntityFactoryBase2<ForumEntity> {
		/// <summary>CTor</summary>
		public ForumEntityFactory() : base("ForumEntity", SD.HnD.DALAdapter.EntityType.ForumEntity, false) { }
		
		/// <summary>Creates a new ForumEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ForumEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewForumUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty ForumRoleForumActionRightEntity objects.</summary>
	[Serializable]
	public partial class ForumRoleForumActionRightEntityFactory : EntityFactoryBase2<ForumRoleForumActionRightEntity> {
		/// <summary>CTor</summary>
		public ForumRoleForumActionRightEntityFactory() : base("ForumRoleForumActionRightEntity", SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, false) { }
		
		/// <summary>Creates a new ForumRoleForumActionRightEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ForumRoleForumActionRightEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewForumRoleForumActionRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty IPBanEntity objects.</summary>
	[Serializable]
	public partial class IPBanEntityFactory : EntityFactoryBase2<IPBanEntity> {
		/// <summary>CTor</summary>
		public IPBanEntityFactory() : base("IPBanEntity", SD.HnD.DALAdapter.EntityType.IPBanEntity, false) { }
		
		/// <summary>Creates a new IPBanEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new IPBanEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewIPBanUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty MessageEntity objects.</summary>
	[Serializable]
	public partial class MessageEntityFactory : EntityFactoryBase2<MessageEntity> {
		/// <summary>CTor</summary>
		public MessageEntityFactory() : base("MessageEntity", SD.HnD.DALAdapter.EntityType.MessageEntity, false) { }
		
		/// <summary>Creates a new MessageEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new MessageEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMessageUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty RoleEntity objects.</summary>
	[Serializable]
	public partial class RoleEntityFactory : EntityFactoryBase2<RoleEntity> {
		/// <summary>CTor</summary>
		public RoleEntityFactory() : base("RoleEntity", SD.HnD.DALAdapter.EntityType.RoleEntity, false) { }
		
		/// <summary>Creates a new RoleEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RoleEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty RoleAuditActionEntity objects.</summary>
	[Serializable]
	public partial class RoleAuditActionEntityFactory : EntityFactoryBase2<RoleAuditActionEntity> {
		/// <summary>CTor</summary>
		public RoleAuditActionEntityFactory() : base("RoleAuditActionEntity", SD.HnD.DALAdapter.EntityType.RoleAuditActionEntity, false) { }
		
		/// <summary>Creates a new RoleAuditActionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RoleAuditActionEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleAuditActionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty RoleSystemActionRightEntity objects.</summary>
	[Serializable]
	public partial class RoleSystemActionRightEntityFactory : EntityFactoryBase2<RoleSystemActionRightEntity> {
		/// <summary>CTor</summary>
		public RoleSystemActionRightEntityFactory() : base("RoleSystemActionRightEntity", SD.HnD.DALAdapter.EntityType.RoleSystemActionRightEntity, false) { }
		
		/// <summary>Creates a new RoleSystemActionRightEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RoleSystemActionRightEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleSystemActionRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty RoleUserEntity objects.</summary>
	[Serializable]
	public partial class RoleUserEntityFactory : EntityFactoryBase2<RoleUserEntity> {
		/// <summary>CTor</summary>
		public RoleUserEntityFactory() : base("RoleUserEntity", SD.HnD.DALAdapter.EntityType.RoleUserEntity, false) { }
		
		/// <summary>Creates a new RoleUserEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RoleUserEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleUserUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty SectionEntity objects.</summary>
	[Serializable]
	public partial class SectionEntityFactory : EntityFactoryBase2<SectionEntity> {
		/// <summary>CTor</summary>
		public SectionEntityFactory() : base("SectionEntity", SD.HnD.DALAdapter.EntityType.SectionEntity, false) { }
		
		/// <summary>Creates a new SectionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SectionEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSectionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty SupportQueueEntity objects.</summary>
	[Serializable]
	public partial class SupportQueueEntityFactory : EntityFactoryBase2<SupportQueueEntity> {
		/// <summary>CTor</summary>
		public SupportQueueEntityFactory() : base("SupportQueueEntity", SD.HnD.DALAdapter.EntityType.SupportQueueEntity, false) { }
		
		/// <summary>Creates a new SupportQueueEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SupportQueueEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportQueueUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty SupportQueueThreadEntity objects.</summary>
	[Serializable]
	public partial class SupportQueueThreadEntityFactory : EntityFactoryBase2<SupportQueueThreadEntity> {
		/// <summary>CTor</summary>
		public SupportQueueThreadEntityFactory() : base("SupportQueueThreadEntity", SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, false) { }
		
		/// <summary>Creates a new SupportQueueThreadEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SupportQueueThreadEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportQueueThreadUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty SystemDataEntity objects.</summary>
	[Serializable]
	public partial class SystemDataEntityFactory : EntityFactoryBase2<SystemDataEntity> {
		/// <summary>CTor</summary>
		public SystemDataEntityFactory() : base("SystemDataEntity", SD.HnD.DALAdapter.EntityType.SystemDataEntity, false) { }
		
		/// <summary>Creates a new SystemDataEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SystemDataEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSystemDataUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty ThreadEntity objects.</summary>
	[Serializable]
	public partial class ThreadEntityFactory : EntityFactoryBase2<ThreadEntity> {
		/// <summary>CTor</summary>
		public ThreadEntityFactory() : base("ThreadEntity", SD.HnD.DALAdapter.EntityType.ThreadEntity, false) { }
		
		/// <summary>Creates a new ThreadEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ThreadEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThreadUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty ThreadSubscriptionEntity objects.</summary>
	[Serializable]
	public partial class ThreadSubscriptionEntityFactory : EntityFactoryBase2<ThreadSubscriptionEntity> {
		/// <summary>CTor</summary>
		public ThreadSubscriptionEntityFactory() : base("ThreadSubscriptionEntity", SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity, false) { }
		
		/// <summary>Creates a new ThreadSubscriptionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ThreadSubscriptionEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThreadSubscriptionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty UserEntity objects.</summary>
	[Serializable]
	public partial class UserEntityFactory : EntityFactoryBase2<UserEntity> {
		/// <summary>CTor</summary>
		public UserEntityFactory() : base("UserEntity", SD.HnD.DALAdapter.EntityType.UserEntity, false) { }
		
		/// <summary>Creates a new UserEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty UserTitleEntity objects.</summary>
	[Serializable]
	public partial class UserTitleEntityFactory : EntityFactoryBase2<UserTitleEntity> {
		/// <summary>CTor</summary>
		public UserTitleEntityFactory() : base("UserTitleEntity", SD.HnD.DALAdapter.EntityType.UserTitleEntity, false) { }
		
		/// <summary>Creates a new UserTitleEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserTitleEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserTitleUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(SD.HnD.DALAdapter.EntityType entityTypeToCreate)
		{
			IEntityFactory2 factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case SD.HnD.DALAdapter.EntityType.ActionRightEntity:
					factoryToUse = new ActionRightEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.AttachmentEntity:
					factoryToUse = new AttachmentEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.AuditActionEntity:
					factoryToUse = new AuditActionEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.AuditDataCoreEntity:
					factoryToUse = new AuditDataCoreEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.AuditDataMessageRelatedEntity:
					factoryToUse = new AuditDataMessageRelatedEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity:
					factoryToUse = new AuditDataThreadRelatedEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.BookmarkEntity:
					factoryToUse = new BookmarkEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.ForumEntity:
					factoryToUse = new ForumEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity:
					factoryToUse = new ForumRoleForumActionRightEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.IPBanEntity:
					factoryToUse = new IPBanEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.MessageEntity:
					factoryToUse = new MessageEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.RoleEntity:
					factoryToUse = new RoleEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.RoleAuditActionEntity:
					factoryToUse = new RoleAuditActionEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.RoleSystemActionRightEntity:
					factoryToUse = new RoleSystemActionRightEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.RoleUserEntity:
					factoryToUse = new RoleUserEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.SectionEntity:
					factoryToUse = new SectionEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.SupportQueueEntity:
					factoryToUse = new SupportQueueEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity:
					factoryToUse = new SupportQueueThreadEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.SystemDataEntity:
					factoryToUse = new SystemDataEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.ThreadEntity:
					factoryToUse = new ThreadEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity:
					factoryToUse = new ThreadSubscriptionEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.UserEntity:
					factoryToUse = new UserEntityFactory();
					break;
				case SD.HnD.DALAdapter.EntityType.UserTitleEntity:
					factoryToUse = new UserTitleEntityFactory();
					break;
			}
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
		
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			Array entityTypeValues = Enum.GetValues(typeof(SD.HnD.DALAdapter.EntityType));
			foreach(int entityTypeValue in entityTypeValues)
			{
				IEntity2 dummy = GeneralEntityFactory.Create((SD.HnD.DALAdapter.EntityType)entityTypeValue);
				_factoryPerType.Add(dummy.GetType(), dummy.GetEntityFactory());
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity)
		{
			IEntityFactory2 toReturn = null;
			_factoryPerType.TryGetValue(typeOfEntity, out toReturn);
			return toReturn;
		}

		/// <summary>Gets the factory of the entity with the SD.HnD.DALAdapter.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(SD.HnD.DALAdapter.EntityType typeOfEntity)
		{
			return GetFactory(GeneralEntityFactory.Create(typeOfEntity).GetType());
		}
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the SD.HnD.DALAdapter.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue)
		{
			return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue);
		}
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity)
		{
			return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity);
		}

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields)
		{
			return new ResultsetFields(numberOfFields);
		}
		
		/// <summary>Obtains the inheritance info provider instance from the singleton </summary>
		/// <returns>The singleton instance of the inheritance info provider</returns>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}


		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand)
		{
			return new DynamicRelation(leftOperand);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperand">The right operand.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperand">The right operand.</param>
		/// <param name="aliasLeftOperand">The alias of the left operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, string aliasLeftOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, aliasLeftOperand, onClause);
		}


		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperandEntityName">Name of the entity which is used as the left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasLeftOperand">The alias of the left operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), leftOperandEntityName, false), joinType, (SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasLeftOperand">The alias of the left operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the SD.HnD.DALAdapter.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue)
		{
			return EntityFactoryFactory.GetFactory((SD.HnD.DALAdapter.EntityType)entityTypeValue);
		}

		/// <summary>Implementation of the routine which gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity)
		{
			return EntityFactoryFactory.GetFactory(typeOfEntity);
		}

	}
}
