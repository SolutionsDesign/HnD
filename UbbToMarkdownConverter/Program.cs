using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using SD.HnD.BL;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.Utility;
using SD.Tools.OrmProfiler.Interceptor;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace UbbToMarkdownConverter
{
	/// <summary>
	/// Simple tool which converts all stored messages from UBB to Markdown. It uses the UBB parser of the old HnD version and updated xlst templates to convert
	/// the UBB to markdown. The Markdown is then replacing the UBB in the DB. 
	/// </summary>
	public class Program
	{
		private static ParserData _parserData = new ParserData();
		private const int BATCHSIZE = 1000;

		static void Main(string[] args)
		{
			InterceptorCore.Initialize("UbbToMarkdownConverter");
			try
			{
				LoadXsltTemplates();
				PerformTestConversion();

				//ConvertUsers();
				//ConvertMessages();
			}
			catch(Exception ex)
			{
				DisplayException(ex);
			}
		}

		private static void PerformTestConversion()
		{
			string messageText = @"[quote nick=""Otis""]Hmm. That's a weird one. Will check it out.[/quote]

erere
fdfd[quote nick=""Foo""]
blabla
[/quote]
fd
dfd[quote]lameness[/quote]dfdfd

[code] Public Shared Function Km_sfSub_Categories_SelectAll(ByRef iErrorCode As System.Int32) As DataTable
			' create parameters
			Dim parameters() As SqlParameter = New SqlParameter(1 - 1) {}

			parameters(0) = new SqlParameter(""@iErrorCode"", SqlDbType.Int, 0, ParameterDirection.InputOutput, True, 10, 0, """",  DataRowVersion.Current, New System.Int32())
			' Call the stored proc.
			Dim toReturn As New DataTable(""Km_sfSub_Categories_SelectAll"")
			Dim hasSucceeded As Boolean = DbUtils.CallRetrievalStoredProcedure(""km_sfSub_Categories_SelectAll"", parameters, toReturn)
			iErrorCode = CType(parameters[0].Value, System.Int32)
			Return toReturn
		End Function[/code]

Perhaps the sproc? Here is one of them that is causing trouble.

[code] ---------------------------------------------------------------------------------
-- Stored procedure that will select all rows from the table 'sfSub_Categories'
-- Returns: @iErrorCode int
---------------------------------------------------------------------------------
ALTER PROCEDURE dbo.km_sfSub_Categories_SelectAll
	@iErrorCode int OUTPUT
AS
SET NOCOUNT ON
-- SELECT all rows from the table.
SELECT
	[subcatID],
	[subcatCategoryId],
	[subcatName],
	[subcatDescription],
	[subcatImage],
	[subcatIsActive],
	[CatHierarchy],
	[Depth],
	[HasProds],
	[bottom],
	[upsize_ts]
FROM [dbo].[sfSub_Categories]
ORDER BY 
	[subcatID] ASC
-- Get the Error Code for the statement just executed.
SELECT @iErrorCode=@@ERROR[/code]
";

			string parserLog;
			string messageAsXml;
			bool errorsOccurred;
			string convertedText = TextParser.TransformUBBMessageStringToHTML(messageText, _parserData, out parserLog, out errorsOccurred, out messageAsXml);
			Console.WriteLine(convertedText);
		}

		private static void ConvertUsers()
		{
			// display total amount of messages to process
			Console.WriteLine("Converting users. Done in 1 set");
			var qf = new QueryFactory();
			var q = qf.User.OrderBy(UserFields.UserID.Ascending())
							  .Exclude(UserFields.SignatureAsHTML);
			using(var adapter = new DataAccessAdapter())
			{
				// fetch all users in 1 go, as the set is small enough
				Console.Write("\tFetching users...");
				var users = adapter.FetchQuery(q, new EntityCollection<UserEntity>());
				Console.WriteLine("DONE. Users fetched: {0}", users.Count);
				Console.Write("\tParsing signatures...");
				var maxLengthSignature = UserFields.Signature.MaxLength;
				foreach(var user in users)
				{
					if(string.IsNullOrEmpty(user.Signature))
					{
						continue;
					}
					var signature = TextParser.TransformSignatureUBBStringToHTML(user.Signature, _parserData);
					if(signature.Length > maxLengthSignature)
					{
						Console.WriteLine("Overflow on signature for user: {0} (ID: {1}). Reset", user.NickName, user.UserID);
						signature = string.Empty;
					}
					user.Signature = signature;
				}
				Console.WriteLine("DONE");
				Console.Write("\tPersisting batch...");
				// save a collection is an implicit transaction so no need to open one explicitly.
				adapter.SaveEntityCollection(users);
				Console.WriteLine("DONE\n");
			}
		}
		

		private static void ConvertMessages()
		{
			// display total amount of messages to process
			int totalNumberOfMessages = MessageGuiHelper.GetTotalNumberOfMessages();
			Console.WriteLine("Total # of messages to process: {0}. Using batch size: {1}", totalNumberOfMessages, BATCHSIZE);
			var numberOfBatches = (totalNumberOfMessages/BATCHSIZE)+1;
			var qf = new QueryFactory();
			var q = qf.Message.OrderBy(MessageFields.MessageID.Ascending())
							  .Exclude(MessageFields.MessageTextAsHTML, MessageFields.MessageTextAsXml);
			using(var adapter = new DataAccessAdapter())
			{
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "Converting UBB to Markdown");
				adapter.KeepTrackOfTransactionParticipants = false;
				try
				{
					var messages = new EntityCollection<MessageEntity>();
					for(int batchNo = 1; batchNo <= numberOfBatches; batchNo++)
					{
						messages.Clear();
						Console.WriteLine("Batch {0} of {1}", batchNo, numberOfBatches);
						q.Page(batchNo, BATCHSIZE);
						Console.Write("\tFetching messages...");
						adapter.FetchQuery(q, messages);
						Console.WriteLine("DONE. Messages fetched: {0}", messages.Count);
						Console.Write("\tParsing messages...");
						foreach(var message in messages)
						{
							string parserLog;
							string messageAsXml;
							bool errorsOccurred;
							string convertedText = TextParser.TransformUBBMessageStringToHTML(message.MessageText, _parserData, out parserLog, out errorsOccurred, out messageAsXml);
							if(errorsOccurred)
							{
								Console.WriteLine("\nERRORS: {0}", parserLog);
								Console.WriteLine("MessageID: {0}\nMessage as text:\n{1}--------------\n", message.MessageID, message.MessageText);
							}
							else
							{
								message.MessageText = convertedText;
							}
						}
						Console.WriteLine("DONE");
						Console.Write("\tPersisting batch...");
						adapter.SaveEntityCollection(messages);
						Console.WriteLine("DONE\n");
					}
					adapter.Commit();
				}
				catch
				{
					adapter.Rollback();
					throw;
				}
			}
		}


		private static void LoadXsltTemplates()
		{
			Console.Write("Loading Xslt templates...");
			_parserData.MessageStyle = new XslCompiledTransform();
			_parserData.SignatureStyle = new XslCompiledTransform();
			_parserData.MessageStyle.Load("ubb_message.xsl");
			_parserData.SignatureStyle.Load("ubb_signature.xsl");
			Console.WriteLine("DONE");
		}

		private static void DisplayException(Exception ex)
		{
			if(ex == null)
			{
				Console.WriteLine("<null>");
				return;
			}
			Console.WriteLine("Exception: {0}", ex.GetType().FullName);
			Console.WriteLine("Message: {0}", ex.Message);
			Console.WriteLine("Stacktrace:\n{0}", ex.StackTrace);
			Console.WriteLine("Inner exception:");
			DisplayException(ex.InnerException);
		}
	}
}
