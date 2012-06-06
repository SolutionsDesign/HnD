///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using SD.HnD.DAL;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Bookmark. </summary>
	public partial class BookmarkRelations
	{
		/// <summary>CTor</summary>
		public BookmarkRelations()
		{
		}

		/// <summary>Gets all relations of the BookmarkEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ThreadEntityUsingThreadID);
			toReturn.Add(this.UserEntityUsingUserID);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between BookmarkEntity and ThreadEntity over the m:1 relation they have, using the relation between the fields:
		/// Bookmark.ThreadID - Thread.ThreadID
		/// </summary>
		public virtual IEntityRelation ThreadEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Thread", false);
				relation.AddEntityFieldPair(ThreadFields.ThreadID, BookmarkFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BookmarkEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between BookmarkEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Bookmark.UserID - User.UserID
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "User", false);
				relation.AddEntityFieldPair(UserFields.UserID, BookmarkFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BookmarkEntity", true);
				return relation;
			}
		}
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticBookmarkRelations
	{
		internal static readonly IEntityRelation ThreadEntityUsingThreadIDStatic = new BookmarkRelations().ThreadEntityUsingThreadID;
		internal static readonly IEntityRelation UserEntityUsingUserIDStatic = new BookmarkRelations().UserEntityUsingUserID;

		/// <summary>CTor</summary>
		static StaticBookmarkRelations()
		{
		}
	}
}
