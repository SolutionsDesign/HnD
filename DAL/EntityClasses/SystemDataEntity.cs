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
	/// Entity class which represents the entity 'SystemData'. <br/>
	/// This class is used for Business Logic or for framework extension code. 
	/// </summary>
	[Serializable]
	public partial class SystemDataEntity : SystemDataEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Constructors
		/// <summary>
		/// CTor
		/// </summary>
		public SystemDataEntity():base()
		{
		}

	
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		public SystemDataEntity(System.Int32 iD):
			base(iD)
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public SystemDataEntity(System.Int32 iD, IPrefetchPath prefetchPathToUse):
			base(iD, prefetchPathToUse)
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="validator">The custom validator object for this SystemDataEntity</param>
		public SystemDataEntity(System.Int32 iD, IValidator validator):
			base(iD, validator)
		{
		}
	
		
		/// <summary>
		/// Private CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SystemDataEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
