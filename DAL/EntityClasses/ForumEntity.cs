///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'Forum'. This class is used for Business Logic or for framework extension code.</summary>
	[Serializable]
	public partial class ForumEntity : ForumEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		/// <summary>CTor</summary>
		public ForumEntity():base()
		{
		}

		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		public ForumEntity(System.Int32 forumID):
			base(forumID)
		{
		}

		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ForumEntity(System.Int32 forumID, IPrefetchPath prefetchPathToUse):
			base(forumID, prefetchPathToUse)
		{
		}

		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="validator">The custom validator object for this ForumEntity</param>
		public ForumEntity(System.Int32 forumID, IValidator validator):
			base(forumID, validator)
		{
		}
		
		/// <summary>CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included Code

		#endregion
	}
}
