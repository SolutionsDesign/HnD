﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.9.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
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
		private readonly bool _isInHierarchy;

		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <param name="isInHierarchy">If true, the entity of this factory is in an inheritance hierarchy, false otherwise</param>
		public EntityFactoryBase2(string entityName, SD.HnD.DALAdapter.EntityType typeOfEntity, bool isInHierarchy) : base(entityName, (int)typeOfEntity)
		{
			_isInHierarchy = isInHierarchy;
		}
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateFields() { return ModelInfoProviderSingleton.GetInstance().GetEntityFields(this.ForEntityName); }
		
		/// <inheritdoc/>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue) {	return GeneralEntityFactory.Create((SD.HnD.DALAdapter.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) { return ModelInfoProviderSingleton.GetInstance().GetHierarchyRelations(this.ForEntityName, objectAlias); }

		/// <inheritdoc/>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			return (IEntityFactory2)ModelInfoProviderSingleton.GetInstance().GetEntityFactory(this.ForEntityName, fieldValues, entityFieldStartIndexesPerEntity) ?? this;
		}
		
		/// <inheritdoc/>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) {	return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);	}
						
		/// <inheritdoc/>
		public override IEntityCollection2 CreateEntityCollection()	{ return new EntityCollection<TEntity>(this); }
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateHierarchyFields() 
		{
			return _isInHierarchy ? new EntityFields2(ModelInfoProviderSingleton.GetInstance().GetHierarchyFields(this.ForEntityName), ModelInfoProviderSingleton.GetInstance(), null) : base.CreateHierarchyFields();
		}
		
		/// <inheritdoc/>
		protected override Type ForEntityType { get { return typeof(TEntity); } }
	}

	/// <summary>Factory to create new, empty ActionRightEntity objects.</summary>
	[Serializable]
	public partial class ActionRightEntityFactory : EntityFactoryBase2<ActionRightEntity> 
	{
		/// <summary>CTor</summary>
		public ActionRightEntityFactory() : base("ActionRightEntity", SD.HnD.DALAdapter.EntityType.ActionRightEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ActionRightEntity(fields); }
	}

	/// <summary>Factory to create new, empty AttachmentEntity objects.</summary>
	[Serializable]
	public partial class AttachmentEntityFactory : EntityFactoryBase2<AttachmentEntity> 
	{
		/// <summary>CTor</summary>
		public AttachmentEntityFactory() : base("AttachmentEntity", SD.HnD.DALAdapter.EntityType.AttachmentEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AttachmentEntity(fields); }
	}

	/// <summary>Factory to create new, empty AuditActionEntity objects.</summary>
	[Serializable]
	public partial class AuditActionEntityFactory : EntityFactoryBase2<AuditActionEntity> 
	{
		/// <summary>CTor</summary>
		public AuditActionEntityFactory() : base("AuditActionEntity", SD.HnD.DALAdapter.EntityType.AuditActionEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AuditActionEntity(fields); }
	}

	/// <summary>Factory to create new, empty AuditDataCoreEntity objects.</summary>
	[Serializable]
	public partial class AuditDataCoreEntityFactory : EntityFactoryBase2<AuditDataCoreEntity> 
	{
		/// <summary>CTor</summary>
		public AuditDataCoreEntityFactory() : base("AuditDataCoreEntity", SD.HnD.DALAdapter.EntityType.AuditDataCoreEntity, true) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AuditDataCoreEntity(fields); }
	}

	/// <summary>Factory to create new, empty AuditDataMessageRelatedEntity objects.</summary>
	[Serializable]
	public partial class AuditDataMessageRelatedEntityFactory : EntityFactoryBase2<AuditDataMessageRelatedEntity> 
	{
		/// <summary>CTor</summary>
		public AuditDataMessageRelatedEntityFactory() : base("AuditDataMessageRelatedEntity", SD.HnD.DALAdapter.EntityType.AuditDataMessageRelatedEntity, true) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AuditDataMessageRelatedEntity(fields); }
	}

	/// <summary>Factory to create new, empty AuditDataThreadRelatedEntity objects.</summary>
	[Serializable]
	public partial class AuditDataThreadRelatedEntityFactory : EntityFactoryBase2<AuditDataThreadRelatedEntity> 
	{
		/// <summary>CTor</summary>
		public AuditDataThreadRelatedEntityFactory() : base("AuditDataThreadRelatedEntity", SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity, true) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AuditDataThreadRelatedEntity(fields); }
	}

	/// <summary>Factory to create new, empty BookmarkEntity objects.</summary>
	[Serializable]
	public partial class BookmarkEntityFactory : EntityFactoryBase2<BookmarkEntity> 
	{
		/// <summary>CTor</summary>
		public BookmarkEntityFactory() : base("BookmarkEntity", SD.HnD.DALAdapter.EntityType.BookmarkEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new BookmarkEntity(fields); }
	}

	/// <summary>Factory to create new, empty ForumEntity objects.</summary>
	[Serializable]
	public partial class ForumEntityFactory : EntityFactoryBase2<ForumEntity> 
	{
		/// <summary>CTor</summary>
		public ForumEntityFactory() : base("ForumEntity", SD.HnD.DALAdapter.EntityType.ForumEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ForumEntity(fields); }
	}

	/// <summary>Factory to create new, empty ForumRoleForumActionRightEntity objects.</summary>
	[Serializable]
	public partial class ForumRoleForumActionRightEntityFactory : EntityFactoryBase2<ForumRoleForumActionRightEntity> 
	{
		/// <summary>CTor</summary>
		public ForumRoleForumActionRightEntityFactory() : base("ForumRoleForumActionRightEntity", SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ForumRoleForumActionRightEntity(fields); }
	}

	/// <summary>Factory to create new, empty IPBanEntity objects.</summary>
	[Serializable]
	public partial class IPBanEntityFactory : EntityFactoryBase2<IPBanEntity> 
	{
		/// <summary>CTor</summary>
		public IPBanEntityFactory() : base("IPBanEntity", SD.HnD.DALAdapter.EntityType.IPBanEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new IPBanEntity(fields); }
	}

	/// <summary>Factory to create new, empty MessageEntity objects.</summary>
	[Serializable]
	public partial class MessageEntityFactory : EntityFactoryBase2<MessageEntity> 
	{
		/// <summary>CTor</summary>
		public MessageEntityFactory() : base("MessageEntity", SD.HnD.DALAdapter.EntityType.MessageEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new MessageEntity(fields); }
	}

	/// <summary>Factory to create new, empty PasswordResetTokenEntity objects.</summary>
	[Serializable]
	public partial class PasswordResetTokenEntityFactory : EntityFactoryBase2<PasswordResetTokenEntity> 
	{
		/// <summary>CTor</summary>
		public PasswordResetTokenEntityFactory() : base("PasswordResetTokenEntity", SD.HnD.DALAdapter.EntityType.PasswordResetTokenEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new PasswordResetTokenEntity(fields); }
	}

	/// <summary>Factory to create new, empty RoleEntity objects.</summary>
	[Serializable]
	public partial class RoleEntityFactory : EntityFactoryBase2<RoleEntity> 
	{
		/// <summary>CTor</summary>
		public RoleEntityFactory() : base("RoleEntity", SD.HnD.DALAdapter.EntityType.RoleEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new RoleEntity(fields); }
	}

	/// <summary>Factory to create new, empty RoleAuditActionEntity objects.</summary>
	[Serializable]
	public partial class RoleAuditActionEntityFactory : EntityFactoryBase2<RoleAuditActionEntity> 
	{
		/// <summary>CTor</summary>
		public RoleAuditActionEntityFactory() : base("RoleAuditActionEntity", SD.HnD.DALAdapter.EntityType.RoleAuditActionEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new RoleAuditActionEntity(fields); }
	}

	/// <summary>Factory to create new, empty RoleSystemActionRightEntity objects.</summary>
	[Serializable]
	public partial class RoleSystemActionRightEntityFactory : EntityFactoryBase2<RoleSystemActionRightEntity> 
	{
		/// <summary>CTor</summary>
		public RoleSystemActionRightEntityFactory() : base("RoleSystemActionRightEntity", SD.HnD.DALAdapter.EntityType.RoleSystemActionRightEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new RoleSystemActionRightEntity(fields); }
	}

	/// <summary>Factory to create new, empty RoleUserEntity objects.</summary>
	[Serializable]
	public partial class RoleUserEntityFactory : EntityFactoryBase2<RoleUserEntity> 
	{
		/// <summary>CTor</summary>
		public RoleUserEntityFactory() : base("RoleUserEntity", SD.HnD.DALAdapter.EntityType.RoleUserEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new RoleUserEntity(fields); }
	}

	/// <summary>Factory to create new, empty SectionEntity objects.</summary>
	[Serializable]
	public partial class SectionEntityFactory : EntityFactoryBase2<SectionEntity> 
	{
		/// <summary>CTor</summary>
		public SectionEntityFactory() : base("SectionEntity", SD.HnD.DALAdapter.EntityType.SectionEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new SectionEntity(fields); }
	}

	/// <summary>Factory to create new, empty SupportQueueEntity objects.</summary>
	[Serializable]
	public partial class SupportQueueEntityFactory : EntityFactoryBase2<SupportQueueEntity> 
	{
		/// <summary>CTor</summary>
		public SupportQueueEntityFactory() : base("SupportQueueEntity", SD.HnD.DALAdapter.EntityType.SupportQueueEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new SupportQueueEntity(fields); }
	}

	/// <summary>Factory to create new, empty SupportQueueThreadEntity objects.</summary>
	[Serializable]
	public partial class SupportQueueThreadEntityFactory : EntityFactoryBase2<SupportQueueThreadEntity> 
	{
		/// <summary>CTor</summary>
		public SupportQueueThreadEntityFactory() : base("SupportQueueThreadEntity", SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new SupportQueueThreadEntity(fields); }
	}

	/// <summary>Factory to create new, empty SystemDataEntity objects.</summary>
	[Serializable]
	public partial class SystemDataEntityFactory : EntityFactoryBase2<SystemDataEntity> 
	{
		/// <summary>CTor</summary>
		public SystemDataEntityFactory() : base("SystemDataEntity", SD.HnD.DALAdapter.EntityType.SystemDataEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new SystemDataEntity(fields); }
	}

	/// <summary>Factory to create new, empty ThreadEntity objects.</summary>
	[Serializable]
	public partial class ThreadEntityFactory : EntityFactoryBase2<ThreadEntity> 
	{
		/// <summary>CTor</summary>
		public ThreadEntityFactory() : base("ThreadEntity", SD.HnD.DALAdapter.EntityType.ThreadEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ThreadEntity(fields); }
	}

	/// <summary>Factory to create new, empty ThreadStatisticsEntity objects.</summary>
	[Serializable]
	public partial class ThreadStatisticsEntityFactory : EntityFactoryBase2<ThreadStatisticsEntity> 
	{
		/// <summary>CTor</summary>
		public ThreadStatisticsEntityFactory() : base("ThreadStatisticsEntity", SD.HnD.DALAdapter.EntityType.ThreadStatisticsEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ThreadStatisticsEntity(fields); }
	}

	/// <summary>Factory to create new, empty ThreadSubscriptionEntity objects.</summary>
	[Serializable]
	public partial class ThreadSubscriptionEntityFactory : EntityFactoryBase2<ThreadSubscriptionEntity> 
	{
		/// <summary>CTor</summary>
		public ThreadSubscriptionEntityFactory() : base("ThreadSubscriptionEntity", SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ThreadSubscriptionEntity(fields); }
	}

	/// <summary>Factory to create new, empty UserEntity objects.</summary>
	[Serializable]
	public partial class UserEntityFactory : EntityFactoryBase2<UserEntity> 
	{
		/// <summary>CTor</summary>
		public UserEntityFactory() : base("UserEntity", SD.HnD.DALAdapter.EntityType.UserEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new UserEntity(fields); }
	}

	/// <summary>Factory to create new, empty UserTitleEntity objects.</summary>
	[Serializable]
	public partial class UserTitleEntityFactory : EntityFactoryBase2<UserTitleEntity> 
	{
		/// <summary>CTor</summary>
		public UserTitleEntityFactory() : base("UserTitleEntity", SD.HnD.DALAdapter.EntityType.UserTitleEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new UserTitleEntity(fields); }
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
			var factoryToUse = EntityFactoryFactory.GetFactory(entityTypeToCreate);
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
			foreach(int entityTypeValue in Enum.GetValues(typeof(SD.HnD.DALAdapter.EntityType)))
			{
				var factory = GetFactory((SD.HnD.DALAdapter.EntityType)entityTypeValue);
				_factoryPerType.Add(factory.ForEntityType ?? factory.Create().GetType(), factory);
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity) { return _factoryPerType.GetValue(typeOfEntity); }

		/// <summary>Gets the factory of the entity with the SD.HnD.DALAdapter.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(SD.HnD.DALAdapter.EntityType typeOfEntity)
		{
			switch(typeOfEntity)
			{
				case SD.HnD.DALAdapter.EntityType.ActionRightEntity:
					return new ActionRightEntityFactory();
				case SD.HnD.DALAdapter.EntityType.AttachmentEntity:
					return new AttachmentEntityFactory();
				case SD.HnD.DALAdapter.EntityType.AuditActionEntity:
					return new AuditActionEntityFactory();
				case SD.HnD.DALAdapter.EntityType.AuditDataCoreEntity:
					return new AuditDataCoreEntityFactory();
				case SD.HnD.DALAdapter.EntityType.AuditDataMessageRelatedEntity:
					return new AuditDataMessageRelatedEntityFactory();
				case SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity:
					return new AuditDataThreadRelatedEntityFactory();
				case SD.HnD.DALAdapter.EntityType.BookmarkEntity:
					return new BookmarkEntityFactory();
				case SD.HnD.DALAdapter.EntityType.ForumEntity:
					return new ForumEntityFactory();
				case SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity:
					return new ForumRoleForumActionRightEntityFactory();
				case SD.HnD.DALAdapter.EntityType.IPBanEntity:
					return new IPBanEntityFactory();
				case SD.HnD.DALAdapter.EntityType.MessageEntity:
					return new MessageEntityFactory();
				case SD.HnD.DALAdapter.EntityType.PasswordResetTokenEntity:
					return new PasswordResetTokenEntityFactory();
				case SD.HnD.DALAdapter.EntityType.RoleEntity:
					return new RoleEntityFactory();
				case SD.HnD.DALAdapter.EntityType.RoleAuditActionEntity:
					return new RoleAuditActionEntityFactory();
				case SD.HnD.DALAdapter.EntityType.RoleSystemActionRightEntity:
					return new RoleSystemActionRightEntityFactory();
				case SD.HnD.DALAdapter.EntityType.RoleUserEntity:
					return new RoleUserEntityFactory();
				case SD.HnD.DALAdapter.EntityType.SectionEntity:
					return new SectionEntityFactory();
				case SD.HnD.DALAdapter.EntityType.SupportQueueEntity:
					return new SupportQueueEntityFactory();
				case SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity:
					return new SupportQueueThreadEntityFactory();
				case SD.HnD.DALAdapter.EntityType.SystemDataEntity:
					return new SystemDataEntityFactory();
				case SD.HnD.DALAdapter.EntityType.ThreadEntity:
					return new ThreadEntityFactory();
				case SD.HnD.DALAdapter.EntityType.ThreadStatisticsEntity:
					return new ThreadStatisticsEntityFactory();
				case SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity:
					return new ThreadSubscriptionEntityFactory();
				case SD.HnD.DALAdapter.EntityType.UserEntity:
					return new UserEntityFactory();
				case SD.HnD.DALAdapter.EntityType.UserTitleEntity:
					return new UserTitleEntityFactory();
				default:
					return null;
			}
		}
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the SD.HnD.DALAdapter.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue) { return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue); }
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity) { return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity); }

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields) { return new ResultsetFields(numberOfFields); }
		
		/// <inheritdoc/>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance() { return ModelInfoProviderSingleton.GetInstance(); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand) { return new DynamicRelation(leftOperand); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, string aliasLeftOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, aliasLeftOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), leftOperandEntityName, false), joinType, (SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (SD.HnD.DALAdapter.EntityType)Enum.Parse(typeof(SD.HnD.DALAdapter.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue) { return EntityFactoryFactory.GetFactory((SD.HnD.DALAdapter.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity) { return EntityFactoryFactory.GetFactory(typeOfEntity);	}

	}
}
