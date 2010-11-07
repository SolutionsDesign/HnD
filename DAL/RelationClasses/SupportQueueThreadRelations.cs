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
using System.Collections;
using System.Collections.Generic;
using SD.HnD.DAL;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: SupportQueueThread. </summary>
	public partial class SupportQueueThreadRelations
	{
		/// <summary>CTor</summary>
		public SupportQueueThreadRelations()
		{
		}

		/// <summary>Gets all relations of the SupportQueueThreadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.ThreadEntityUsingThreadID);
			toReturn.Add(this.SupportQueueEntityUsingQueueID);
			toReturn.Add(this.UserEntityUsingClaimedByUserID);
			toReturn.Add(this.UserEntityUsingPlacedInQueueByUserID);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and ThreadEntity over the 1:1 relation they have, using the relation between the fields:
		/// SupportQueueThread.ThreadID - Thread.ThreadID
		/// </summary>
		public virtual IEntityRelation ThreadEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "Thread", false);




				relation.AddEntityFieldPair(ThreadFields.ThreadID, SupportQueueThreadFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and SupportQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// SupportQueueThread.QueueID - SupportQueue.QueueID
		/// </summary>
		public virtual IEntityRelation SupportQueueEntityUsingQueueID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SupportQueue", false);
				relation.AddEntityFieldPair(SupportQueueFields.QueueID, SupportQueueThreadFields.QueueID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// SupportQueueThread.ClaimedByUserID - User.UserID
		/// </summary>
		public virtual IEntityRelation UserEntityUsingClaimedByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ClaimedByUser", false);
				relation.AddEntityFieldPair(UserFields.UserID, SupportQueueThreadFields.ClaimedByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SupportQueueThreadEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// SupportQueueThread.PlacedInQueueByUserID - User.UserID
		/// </summary>
		public virtual IEntityRelation UserEntityUsingPlacedInQueueByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PlacedInQueueByUser", false);
				relation.AddEntityFieldPair(UserFields.UserID, SupportQueueThreadFields.PlacedInQueueByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", true);
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
}
