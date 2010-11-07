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
using System.Collections.Generic;
using SD.HnD.DAL.HelperClasses;

using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.RelationClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase : EntityFactoryCore
	{
		private string _entityName;
		private SD.HnD.DAL.EntityType _typeOfEntity;
		
		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		public EntityFactoryBase(string entityName, SD.HnD.DAL.EntityType typeOfEntity)
		{
			_entityName = entityName;
			_typeOfEntity = typeOfEntity;
		}

		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.Create((SD.HnD.DAL.EntityType)entityTypeValue);
		}
		
		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public override IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(_typeOfEntity);
		}

		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <param name="objectAlias">The object alias to use for the elements in the relations.</param>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetHierarchyRelations(_entityName, objectAlias);
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public override IEntityFactory GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity)
		{
			IEntityFactory toReturn = (IEntityFactory)InheritanceInfoProviderSingleton.GetInstance().GetEntityFactory(_entityName, fieldValues, entityFieldStartIndexesPerEntity);
			if(toReturn == null)
			{
				toReturn = this;
			}
			return toReturn;
		}
						
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public override IEntityCollection CreateEntityCollection()
		{
			return GeneralEntityCollectionFactory.Create(_typeOfEntity);
		}
		
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public override string ForEntityName 
		{ 
			get { return _entityName; }
		}
	}
	
	/// <summary>Factory to create new, empty ActionRightEntity objects.</summary>
	[Serializable]
	public partial class ActionRightEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ActionRightEntityFactory() : base("ActionRightEntity", SD.HnD.DAL.EntityType.ActionRightEntity) { }

		/// <summary>Creates a new, empty ActionRightEntity object.</summary>
		/// <returns>A new, empty ActionRightEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ActionRightEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActionRight
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ActionRightEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActionRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty AttachmentEntity objects.</summary>
	[Serializable]
	public partial class AttachmentEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AttachmentEntityFactory() : base("AttachmentEntity", SD.HnD.DAL.EntityType.AttachmentEntity) { }

		/// <summary>Creates a new, empty AttachmentEntity object.</summary>
		/// <returns>A new, empty AttachmentEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AttachmentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAttachment
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AttachmentEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAttachmentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty AuditActionEntity objects.</summary>
	[Serializable]
	public partial class AuditActionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AuditActionEntityFactory() : base("AuditActionEntity", SD.HnD.DAL.EntityType.AuditActionEntity) { }

		/// <summary>Creates a new, empty AuditActionEntity object.</summary>
		/// <returns>A new, empty AuditActionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AuditActionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditAction
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AuditActionEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditActionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty AuditDataCoreEntity objects.</summary>
	[Serializable]
	public partial class AuditDataCoreEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AuditDataCoreEntityFactory() : base("AuditDataCoreEntity", SD.HnD.DAL.EntityType.AuditDataCoreEntity) { }

		/// <summary>Creates a new, empty AuditDataCoreEntity object.</summary>
		/// <returns>A new, empty AuditDataCoreEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AuditDataCoreEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataCore
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AuditDataCoreEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataCoreUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields CreateHierarchyFields()
		{
			return new EntityFields(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields("AuditDataCoreEntity"), InheritanceInfoProviderSingleton.GetInstance(), null);
		}
		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty AuditDataMessageRelatedEntity objects.</summary>
	[Serializable]
	public partial class AuditDataMessageRelatedEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AuditDataMessageRelatedEntityFactory() : base("AuditDataMessageRelatedEntity", SD.HnD.DAL.EntityType.AuditDataMessageRelatedEntity) { }

		/// <summary>Creates a new, empty AuditDataMessageRelatedEntity object.</summary>
		/// <returns>A new, empty AuditDataMessageRelatedEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AuditDataMessageRelatedEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataMessageRelated
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AuditDataMessageRelatedEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataMessageRelatedUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields CreateHierarchyFields()
		{
			return new EntityFields(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields("AuditDataMessageRelatedEntity"), InheritanceInfoProviderSingleton.GetInstance(), null);
		}
		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty AuditDataThreadRelatedEntity objects.</summary>
	[Serializable]
	public partial class AuditDataThreadRelatedEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AuditDataThreadRelatedEntityFactory() : base("AuditDataThreadRelatedEntity", SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity) { }

		/// <summary>Creates a new, empty AuditDataThreadRelatedEntity object.</summary>
		/// <returns>A new, empty AuditDataThreadRelatedEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AuditDataThreadRelatedEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataThreadRelated
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AuditDataThreadRelatedEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditDataThreadRelatedUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields CreateHierarchyFields()
		{
			return new EntityFields(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields("AuditDataThreadRelatedEntity"), InheritanceInfoProviderSingleton.GetInstance(), null);
		}
		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty BookmarkEntity objects.</summary>
	[Serializable]
	public partial class BookmarkEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public BookmarkEntityFactory() : base("BookmarkEntity", SD.HnD.DAL.EntityType.BookmarkEntity) { }

		/// <summary>Creates a new, empty BookmarkEntity object.</summary>
		/// <returns>A new, empty BookmarkEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new BookmarkEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBookmark
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BookmarkEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBookmarkUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ForumEntity objects.</summary>
	[Serializable]
	public partial class ForumEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ForumEntityFactory() : base("ForumEntity", SD.HnD.DAL.EntityType.ForumEntity) { }

		/// <summary>Creates a new, empty ForumEntity object.</summary>
		/// <returns>A new, empty ForumEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ForumEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewForum
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ForumEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewForumUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ForumRoleForumActionRightEntity objects.</summary>
	[Serializable]
	public partial class ForumRoleForumActionRightEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ForumRoleForumActionRightEntityFactory() : base("ForumRoleForumActionRightEntity", SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity) { }

		/// <summary>Creates a new, empty ForumRoleForumActionRightEntity object.</summary>
		/// <returns>A new, empty ForumRoleForumActionRightEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ForumRoleForumActionRightEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewForumRoleForumActionRight
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ForumRoleForumActionRightEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewForumRoleForumActionRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty IPBanEntity objects.</summary>
	[Serializable]
	public partial class IPBanEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public IPBanEntityFactory() : base("IPBanEntity", SD.HnD.DAL.EntityType.IPBanEntity) { }

		/// <summary>Creates a new, empty IPBanEntity object.</summary>
		/// <returns>A new, empty IPBanEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new IPBanEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewIPBan
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new IPBanEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewIPBanUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty MessageEntity objects.</summary>
	[Serializable]
	public partial class MessageEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public MessageEntityFactory() : base("MessageEntity", SD.HnD.DAL.EntityType.MessageEntity) { }

		/// <summary>Creates a new, empty MessageEntity object.</summary>
		/// <returns>A new, empty MessageEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new MessageEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMessage
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new MessageEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMessageUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty RoleEntity objects.</summary>
	[Serializable]
	public partial class RoleEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public RoleEntityFactory() : base("RoleEntity", SD.HnD.DAL.EntityType.RoleEntity) { }

		/// <summary>Creates a new, empty RoleEntity object.</summary>
		/// <returns>A new, empty RoleEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new RoleEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRole
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RoleEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty RoleAuditActionEntity objects.</summary>
	[Serializable]
	public partial class RoleAuditActionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public RoleAuditActionEntityFactory() : base("RoleAuditActionEntity", SD.HnD.DAL.EntityType.RoleAuditActionEntity) { }

		/// <summary>Creates a new, empty RoleAuditActionEntity object.</summary>
		/// <returns>A new, empty RoleAuditActionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new RoleAuditActionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleAuditAction
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RoleAuditActionEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleAuditActionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty RoleSystemActionRightEntity objects.</summary>
	[Serializable]
	public partial class RoleSystemActionRightEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public RoleSystemActionRightEntityFactory() : base("RoleSystemActionRightEntity", SD.HnD.DAL.EntityType.RoleSystemActionRightEntity) { }

		/// <summary>Creates a new, empty RoleSystemActionRightEntity object.</summary>
		/// <returns>A new, empty RoleSystemActionRightEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new RoleSystemActionRightEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleSystemActionRight
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RoleSystemActionRightEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleSystemActionRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty RoleUserEntity objects.</summary>
	[Serializable]
	public partial class RoleUserEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public RoleUserEntityFactory() : base("RoleUserEntity", SD.HnD.DAL.EntityType.RoleUserEntity) { }

		/// <summary>Creates a new, empty RoleUserEntity object.</summary>
		/// <returns>A new, empty RoleUserEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new RoleUserEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleUser
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RoleUserEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleUserUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SectionEntity objects.</summary>
	[Serializable]
	public partial class SectionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SectionEntityFactory() : base("SectionEntity", SD.HnD.DAL.EntityType.SectionEntity) { }

		/// <summary>Creates a new, empty SectionEntity object.</summary>
		/// <returns>A new, empty SectionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SectionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSection
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SectionEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSectionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SupportQueueEntity objects.</summary>
	[Serializable]
	public partial class SupportQueueEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SupportQueueEntityFactory() : base("SupportQueueEntity", SD.HnD.DAL.EntityType.SupportQueueEntity) { }

		/// <summary>Creates a new, empty SupportQueueEntity object.</summary>
		/// <returns>A new, empty SupportQueueEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SupportQueueEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportQueue
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SupportQueueEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportQueueUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SupportQueueThreadEntity objects.</summary>
	[Serializable]
	public partial class SupportQueueThreadEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SupportQueueThreadEntityFactory() : base("SupportQueueThreadEntity", SD.HnD.DAL.EntityType.SupportQueueThreadEntity) { }

		/// <summary>Creates a new, empty SupportQueueThreadEntity object.</summary>
		/// <returns>A new, empty SupportQueueThreadEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SupportQueueThreadEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportQueueThread
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SupportQueueThreadEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportQueueThreadUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SystemDataEntity objects.</summary>
	[Serializable]
	public partial class SystemDataEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SystemDataEntityFactory() : base("SystemDataEntity", SD.HnD.DAL.EntityType.SystemDataEntity) { }

		/// <summary>Creates a new, empty SystemDataEntity object.</summary>
		/// <returns>A new, empty SystemDataEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SystemDataEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSystemData
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SystemDataEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSystemDataUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ThreadEntity objects.</summary>
	[Serializable]
	public partial class ThreadEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ThreadEntityFactory() : base("ThreadEntity", SD.HnD.DAL.EntityType.ThreadEntity) { }

		/// <summary>Creates a new, empty ThreadEntity object.</summary>
		/// <returns>A new, empty ThreadEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ThreadEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThread
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ThreadEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThreadUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ThreadSubscriptionEntity objects.</summary>
	[Serializable]
	public partial class ThreadSubscriptionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ThreadSubscriptionEntityFactory() : base("ThreadSubscriptionEntity", SD.HnD.DAL.EntityType.ThreadSubscriptionEntity) { }

		/// <summary>Creates a new, empty ThreadSubscriptionEntity object.</summary>
		/// <returns>A new, empty ThreadSubscriptionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ThreadSubscriptionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThreadSubscription
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ThreadSubscriptionEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThreadSubscriptionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserEntity objects.</summary>
	[Serializable]
	public partial class UserEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserEntityFactory() : base("UserEntity", SD.HnD.DAL.EntityType.UserEntity) { }

		/// <summary>Creates a new, empty UserEntity object.</summary>
		/// <returns>A new, empty UserEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUser
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new UserEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserTitleEntity objects.</summary>
	[Serializable]
	public partial class UserTitleEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserTitleEntityFactory() : base("UserTitleEntity", SD.HnD.DAL.EntityType.UserTitleEntity) { }

		/// <summary>Creates a new, empty UserTitleEntity object.</summary>
		/// <returns>A new, empty UserTitleEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserTitleEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserTitle
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new UserTitleEntity instance and will set the Fields object of the new IEntity instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields object for the new IEntity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		public override IEntity Create(IEntityFields fields) {
			IEntity toReturn = Create();
			toReturn.Fields = fields;
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserTitleUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new entity collection objects</summary>
	[Serializable]
	public partial class GeneralEntityCollectionFactory
	{
		/// <summary>Creates a new entity collection</summary>
		/// <param name="typeToUse">The entity type to create the collection for.</param>
		/// <returns>A new entity collection object.</returns>
		public static IEntityCollection Create(SD.HnD.DAL.EntityType typeToUse)
		{
			switch(typeToUse)
			{
				case SD.HnD.DAL.EntityType.ActionRightEntity:
					return new ActionRightCollection();
				case SD.HnD.DAL.EntityType.AttachmentEntity:
					return new AttachmentCollection();
				case SD.HnD.DAL.EntityType.AuditActionEntity:
					return new AuditActionCollection();
				case SD.HnD.DAL.EntityType.AuditDataCoreEntity:
					return new AuditDataCoreCollection();
				case SD.HnD.DAL.EntityType.AuditDataMessageRelatedEntity:
					return new AuditDataMessageRelatedCollection();
				case SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity:
					return new AuditDataThreadRelatedCollection();
				case SD.HnD.DAL.EntityType.BookmarkEntity:
					return new BookmarkCollection();
				case SD.HnD.DAL.EntityType.ForumEntity:
					return new ForumCollection();
				case SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity:
					return new ForumRoleForumActionRightCollection();
				case SD.HnD.DAL.EntityType.IPBanEntity:
					return new IPBanCollection();
				case SD.HnD.DAL.EntityType.MessageEntity:
					return new MessageCollection();
				case SD.HnD.DAL.EntityType.RoleEntity:
					return new RoleCollection();
				case SD.HnD.DAL.EntityType.RoleAuditActionEntity:
					return new RoleAuditActionCollection();
				case SD.HnD.DAL.EntityType.RoleSystemActionRightEntity:
					return new RoleSystemActionRightCollection();
				case SD.HnD.DAL.EntityType.RoleUserEntity:
					return new RoleUserCollection();
				case SD.HnD.DAL.EntityType.SectionEntity:
					return new SectionCollection();
				case SD.HnD.DAL.EntityType.SupportQueueEntity:
					return new SupportQueueCollection();
				case SD.HnD.DAL.EntityType.SupportQueueThreadEntity:
					return new SupportQueueThreadCollection();
				case SD.HnD.DAL.EntityType.SystemDataEntity:
					return new SystemDataCollection();
				case SD.HnD.DAL.EntityType.ThreadEntity:
					return new ThreadCollection();
				case SD.HnD.DAL.EntityType.ThreadSubscriptionEntity:
					return new ThreadSubscriptionCollection();
				case SD.HnD.DAL.EntityType.UserEntity:
					return new UserCollection();
				case SD.HnD.DAL.EntityType.UserTitleEntity:
					return new UserTitleCollection();
				default:
					return null;
			}
		}		
	}
	
	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity Create(SD.HnD.DAL.EntityType entityTypeToCreate)
		{
			IEntityFactory factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case SD.HnD.DAL.EntityType.ActionRightEntity:
					factoryToUse = new ActionRightEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.AttachmentEntity:
					factoryToUse = new AttachmentEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.AuditActionEntity:
					factoryToUse = new AuditActionEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.AuditDataCoreEntity:
					factoryToUse = new AuditDataCoreEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.AuditDataMessageRelatedEntity:
					factoryToUse = new AuditDataMessageRelatedEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity:
					factoryToUse = new AuditDataThreadRelatedEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.BookmarkEntity:
					factoryToUse = new BookmarkEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.ForumEntity:
					factoryToUse = new ForumEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity:
					factoryToUse = new ForumRoleForumActionRightEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.IPBanEntity:
					factoryToUse = new IPBanEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.MessageEntity:
					factoryToUse = new MessageEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.RoleEntity:
					factoryToUse = new RoleEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.RoleAuditActionEntity:
					factoryToUse = new RoleAuditActionEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.RoleSystemActionRightEntity:
					factoryToUse = new RoleSystemActionRightEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.RoleUserEntity:
					factoryToUse = new RoleUserEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.SectionEntity:
					factoryToUse = new SectionEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.SupportQueueEntity:
					factoryToUse = new SupportQueueEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.SupportQueueThreadEntity:
					factoryToUse = new SupportQueueThreadEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.SystemDataEntity:
					factoryToUse = new SystemDataEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.ThreadEntity:
					factoryToUse = new ThreadEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.ThreadSubscriptionEntity:
					factoryToUse = new ThreadSubscriptionEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.UserEntity:
					factoryToUse = new UserEntityFactory();
					break;
				case SD.HnD.DAL.EntityType.UserTitleEntity:
					factoryToUse = new UserTitleEntityFactory();
					break;
			}
			IEntity toReturn = null;
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
#if CF
		/// <summary>Gets the factory of the entity with the SD.HnD.DAL.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(SD.HnD.DAL.EntityType typeOfEntity)
		{
			return GeneralEntityFactory.Create(typeOfEntity).GetEntityFactory();
		}
#else
		private static Dictionary<Type, IEntityFactory> _factoryPerType = new Dictionary<Type, IEntityFactory>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			Array entityTypeValues = Enum.GetValues(typeof(SD.HnD.DAL.EntityType));
			foreach(int entityTypeValue in entityTypeValues)
			{
				IEntity dummy = GeneralEntityFactory.Create((SD.HnD.DAL.EntityType)entityTypeValue);
				_factoryPerType.Add(dummy.GetType(), dummy.GetEntityFactory());
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(Type typeOfEntity)
		{
			IEntityFactory toReturn = null;
			_factoryPerType.TryGetValue(typeOfEntity, out toReturn);
			return toReturn;
		}

		/// <summary>Gets the factory of the entity with the SD.HnD.DAL.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(SD.HnD.DAL.EntityType typeOfEntity)
		{
			return GetFactory(GeneralEntityFactory.Create(typeOfEntity).GetType());
		}
#endif
	}
	
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator
	{
		/// <summary>Gets the factory of the Entity type with the SD.HnD.DAL.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory GetFactory(int entityTypeValue)
		{
			return (IEntityFactory)this.GetFactoryImpl(entityTypeValue);
		}

		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory GetFactory(Type typeOfEntity)
		{
			return (IEntityFactory)this.GetFactoryImpl(typeOfEntity);
		}

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields CreateResultsetFields(int numberOfFields)
		{
			return new ResultsetFields(numberOfFields);
		}
		
		/// <summary>Gets an instance of the TypedListDAO class to execute dynamic lists and projections.</summary>
		/// <returns>ready to use typedlistDAO</returns>
		public IDao GetTypedListDao()
		{
			return new TypedListDAO();
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
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (SD.HnD.DAL.EntityType)Enum.Parse(typeof(SD.HnD.DAL.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
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
			return new DynamicRelation((SD.HnD.DAL.EntityType)Enum.Parse(typeof(SD.HnD.DAL.EntityType), leftOperandEntityName, false), joinType, (SD.HnD.DAL.EntityType)Enum.Parse(typeof(SD.HnD.DAL.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
				
		/// <summary>Obtains the inheritance info provider instance from the singleton </summary>
		/// <returns>The singleton instance of the inheritance info provider</returns>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}

		/// <summary>Implementation of the routine which gets the factory of the Entity type with the SD.HnD.DAL.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue)
		{
			return EntityFactoryFactory.GetFactory((SD.HnD.DAL.EntityType)entityTypeValue);
		}
#if !CF		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity)
		{
			return EntityFactoryFactory.GetFactory(typeOfEntity);
		}
#endif
	}
}
