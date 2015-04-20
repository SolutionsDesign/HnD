///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.2
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.Common;
using SD.HnD.DAL.DaoClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.HelperClasses
{
	/// <summary>Specific implementation of the Transaction class. The constructor will take care of the creation of the physical transaction and the opening of the connection. The transaction object is ready to use as soon as the constructor succeeds.</summary>
	public partial class Transaction : TransactionBase
	{
		/// <summary>CTor. Will read the connection string from an external source. Opens connection, class</summary>
		/// <param name="transactionIsolationLevel">IsolationLevel to use in the transaction</param>
		/// <param name="name">The name of the transaction to use.</param>
		public Transaction(IsolationLevel transactionIsolationLevel, string name):base(transactionIsolationLevel, name)
		{
		}
		
		/// <summary>CTor.</summary>
		/// <param name="transactionIsolationLevel">IsolationLevel to use in the transaction</param>
		/// <param name="name">The name of the transaction to use.</param>
		/// <param name="connectionString">Connection string to use in this transaction</param>
		public Transaction(IsolationLevel transactionIsolationLevel, string name, string connectionString):base(transactionIsolationLevel, name, connectionString)
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
