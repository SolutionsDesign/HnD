using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Xsl;
using SD.HnD.BL;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.Utility;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace V1ToV3Converter
{
	/// <summary>
	/// Simple tool which converts a v1 database to a v3 database. It uses the UBB parser of the old HnD version and updated xlst templates to convert
	/// the UBB to markdown. The Markdown is then replacing the UBB in the DB.
	/// It performs the following tasks:
	/// 	- Convert all stored messages from UBB to Markdown.
	/// 	- Convert all thread welcome texts from UBB to Markdown
	/// 	- Convert all messages from UBB to Markdown.
	/// 	- Convert all thread memo's from UBB to Markdown
	/// 	- Strips all user signatures
	/// 	- Convert the user password storage from MD5 hash to a salted string containing old MD5 Hash which is then encrypted. 
	/// </summary>
	public class Program
	{
		private static ParserData _parserData;
		private static RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
		private const int BATCHSIZE = 1000;

		static async Task Main(string[] args)
		{
			// The generated code is a netstandard variant, so we have to use the RuntimeConfiguration class.
			RuntimeConfiguration.AddConnectionString("Main.ConnectionString.SQL Server (SqlClient)", 
													 ConfigurationManager.AppSettings["Main.ConnectionString.SQL Server (SqlClient)"]);
			RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c =>
																		 {
																			 c.AddCatalogNameOverwrite("HnD", ConfigurationManager.AppSettings["DestinationCatalog"]);
																			 c.AddDbProviderFactory(typeof(SqlClientFactory));
																		 });
		
			try
			{
				LoadXsltTemplates();
				ConvertForumWelcomeTexts();
				ConvertThreadMemos();
				ConvertUsers();
				await ConvertMessages();
			}
			catch(Exception ex)
			{
				DisplayException(ex);
			}
		}

		private static void ConvertForumWelcomeTexts()
		{
			Console.WriteLine("Converting forum welcome texts. Republishing header texts as well.");
			var qf = new QueryFactory();
			using(var adapter = new DataAccessAdapter())
			{
				var forums = adapter.FetchQuery(qf.Forum);
				foreach(ForumEntity f in forums)
				{
					string parserLog;
					string messageAsXml;
					bool errorsOccurred;
					string convertedText = TextParser.TransformUBBMessageStringToHTML(f.NewThreadWelcomeText, _parserData, out parserLog, out errorsOccurred, out messageAsXml);
					if(errorsOccurred)
					{
						Console.WriteLine("\nERRORS: {0}", parserLog);
						Console.WriteLine("ForumID: {0}\nForum welcome text:\n{1}--------------\n", f.ForumID, f.NewThreadWelcomeText);
						f.NewThreadWelcomeText = string.Empty;
						f.NewThreadWelcomeTextAsHTML = string.Empty;
					}
					else
					{
						// html decode, so any &lt; etc. are converted back to the regular characters. 
						f.NewThreadWelcomeText = HttpUtility.HtmlDecode(convertedText);
						f.NewThreadWelcomeTextAsHTML = HnDGeneralUtils.TransformMarkdownToHtml(f.NewThreadWelcomeText, new Dictionary<string, string>(), 
																							   new Dictionary<string, string>());
					}
				}
				Console.Write("\tPersisting forums...");
				adapter.SaveEntityCollection(forums);
				Console.WriteLine("DONE!");
			}
			Console.WriteLine("DONE");
		}


		private static void ConvertThreadMemos()
		{
			Console.WriteLine("Converting thread memos. ");
			var qf = new QueryFactory();
			using(var adapter = new DataAccessAdapter())
			{
				var totalNumberOfThreads = adapter.FetchScalar<int>(qf.Thread.Select(Functions.CountRow()));
				var numberOfBatches = (totalNumberOfThreads / BATCHSIZE) + 1;
				Console.WriteLine("Total # of threads to process: {0}. Using batch size: {1}", numberOfBatches, BATCHSIZE);
				var q = qf.Thread.OrderBy(ThreadFields.ThreadID.Ascending());
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "Converting UBB to Markdown");
				adapter.KeepTrackOfTransactionParticipants = false;
				try
				{
					var threads = new EntityCollection<ThreadEntity>();
					for(int batchNo = 1; batchNo <= numberOfBatches; batchNo++)
					{
						threads.Clear();
						Console.WriteLine("Batch {0} of {1}", batchNo, numberOfBatches);
						q.Page(batchNo, BATCHSIZE);
						Console.Write("\tFetching threads...");
						adapter.FetchQuery(q, threads);
						Console.WriteLine("DONE. Threads fetched: {0}", threads.Count);
						Console.Write("\tParsing memos on threads...");
						foreach(var thread in threads)
						{
							var toConvert = thread.Memo;
							if(string.IsNullOrWhiteSpace(toConvert))
							{
								continue;
							}
							// replace CRLF with <space><space>CRLF, as the markdown parser will otherwise collide it with the previous lines which we don't want
							toConvert = toConvert.Replace(Environment.NewLine, "  " + Environment.NewLine);
							string parserLog;
							string messageAsXml;
							bool errorsOccurred;
							string convertedText = TextParser.TransformUBBMessageStringToHTML(toConvert, _parserData, out parserLog, out errorsOccurred, out messageAsXml);
							if(errorsOccurred)
							{
								Console.WriteLine("\nERRORS: {0}", parserLog);
								Console.WriteLine("ThreadID: {0}\nThread memo as text:\n{1}--------------\n", thread.ThreadID, thread.Memo);
							}
							else
							{
								// html decode, so any &lt; etc. are converted back to the regular characters. 
								thread.Memo = HttpUtility.HtmlDecode(convertedText);
							}

						}
						Console.WriteLine("DONE");
						Console.Write("\tPersisting batch...");
						adapter.SaveEntityCollection(threads);
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


		private static void ConvertUsers()
		{
			// as in the new version we'll just use plain text, we'll reset all signatures to the empty string and users have to type in their signatures again. 
			Console.WriteLine("Converting users.");
			using(var adapter = new DataAccessAdapter())
			{
				Console.WriteLine("\tResetting all signature texts with 1 statement.");
				var updater = new UserEntity() {Signature = string.Empty};
				Console.Write("\t\tUpdating users...");
				var result = adapter.UpdateEntitiesDirectly(updater, null);
				Console.WriteLine("\tDONE. Users updated: {0}", result);
				
				Console.WriteLine("\n\tRehashing passwords with PBKDF2...");
				var allUsers = (EntityCollection<UserEntity>)adapter.FetchQuery(new QueryFactory().User);
				Console.WriteLine("\t\tNumber of users to process: {0}", allUsers.Count);
				int count = 0;
				foreach(var user in allUsers)
				{
					count++;
					user.Password = HnDGeneralUtils.HashPassword(user.Password, performPreMD5Hashing:false);
					if(count % 500 == 0)
					{
						Console.WriteLine("\t\tRehashed {0} users", count);
					}
				}

				Console.WriteLine("\t\tDONE rehashing, persisting entities in batches to database");
				adapter.BatchSize = 150;
				adapter.SaveEntityCollection(allUsers);
				Console.WriteLine("\tDONE rehashing passwords");
				
				Console.WriteLine("DONE converting users.");
			}
		}


		private static async Task ConvertMessages()
		{
			// display total amount of messages to process
			int totalNumberOfMessages = await MessageGuiHelper.GetTotalNumberOfMessagesAsync();
			Console.WriteLine("Total # of messages to process: {0}. Using batch size: {1}", totalNumberOfMessages, BATCHSIZE);
			var numberOfBatches = (totalNumberOfMessages/BATCHSIZE)+1;
			var qf = new QueryFactory();
			var q = qf.Message.OrderBy(MessageFields.MessageID.Ascending())
							  .Exclude(MessageFields.MessageTextAsHTML);
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "Converting UBB to Markdown").ConfigureAwait(false);
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
								// html decode, so any &lt; etc. are converted back to the regular characters. 
								message.MessageText = HttpUtility.HtmlDecode(convertedText);
							}
						}
						Console.WriteLine("DONE");
						Console.Write("\tPersisting batch...");
						await adapter.SaveEntityCollectionAsync(messages).ConfigureAwait(false);
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
			_parserData.MessageStyle.Load("ubb_message.xsl");
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
