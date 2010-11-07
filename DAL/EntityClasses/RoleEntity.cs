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

	/// <summary>
	/// Entity class which represents the entity 'Role'. <br/>
	/// This class is used for Business Logic or for framework extension code. 
	/// </summary>
	[Serializable]
	public partial class RoleEntity : RoleEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Constructors
		/// <summary>
		/// CTor
		/// </summary>
		public RoleEntity():base()
		{
		}

	
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		public RoleEntity(System.Int32 roleID):
			base(roleID)
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public RoleEntity(System.Int32 roleID, IPrefetchPath prefetchPathToUse):
			base(roleID, prefetchPathToUse)
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="validator">The custom validator object for this RoleEntity</param>
		public RoleEntity(System.Int32 roleID, IValidator validator):
			base(roleID, validator)
		{
		}
	
		
		/// <summary>
		/// Private CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected RoleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		#endregion

		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included Code

		#endregion
	}
}
