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

	/// <summary>Entity class which represents the entity 'SupportQueueThread'. This class is used for Business Logic or for framework extension code.</summary>
	[Serializable]
	public partial class SupportQueueThreadEntity : SupportQueueThreadEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		/// <summary>CTor</summary>
		public SupportQueueThreadEntity():base()
		{
		}

		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID):
			base(queueID, threadID)
		{
		}

		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID, IPrefetchPath prefetchPathToUse):
			base(queueID, threadID, prefetchPathToUse)
		{
		}

		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="validator">The custom validator object for this SupportQueueThreadEntity</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID, IValidator validator):
			base(queueID, threadID, validator)
		{
		}
		
		/// <summary>CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SupportQueueThreadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
