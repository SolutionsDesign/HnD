///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
#if !CEDesktop
using System;
using System.Data;
using System.Data.Common;
using System.EnterpriseServices;
using SD.HnD.DAL.DaoClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.HelperClasses
{
	/// <summary>Specific implementation of the TransactionComPlus class. The constructor will take care of the creation of the physical transaction and the opening of the connection. It will require a COM+ transaction.</summary>
	[MustRunInClientContext(true)]
	[Transaction(TransactionOption.Required)]
	public partial class TransactionComPlus : TransactionComPlusBase
	{
		/// <summary>CTor</summary>
		public TransactionComPlus()
		{
		}
		
		/// <summary>Creates a new DbConnection instance which will be used by all elements using this ITransaction instance. Reads ConnectionString from .config file.</summary>
		/// <returns>new DbConnection instance</returns>
		protected override DbConnection CreateConnection()
		{
			return new CommonDaoBase().CreateConnection();
		}

		/// <summary>Creates a new DbConnection instance which will be used by all elements using this ITransaction instance</summary>
		/// <param name="connectionStringToUse">Connection string to use</param>
		/// <returns>new DbConnection instance</returns>
		protected override DbConnection CreateConnection(string connectionStringToUse)
		{
			return new CommonDaoBase().CreateConnection(connectionStringToUse);
		}


		#region Included Code

		#endregion
	}
}
#endif