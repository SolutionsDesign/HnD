using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SD.HnD.Gui.Classes;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses.Contrib;

namespace SD.HnD.Gui
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			// First we need to configure LLBLGen Pro
			ConfigureLLBLGenPro(services);
			// Then we can configure HnD as it needs the database.
			ConfigureHnD(services);
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => RegisterRoutes(endpoints));
			
			// HnD one-time configuration now we now the environment...
			HnDConfiguration.Current.LoadStaticData(env.WebRootPath, env.ContentRootPath);
		}


		private void ConfigureHnD(IServiceCollection services)
		{
			var hndConfig = new HnDConfiguration();
			this.Configuration.Bind("HnD", hndConfig);
			hndConfig.Sanitize();
			// controllers which want to have it injected can do so
			services.AddSingleton(hndConfig);
			if(hndConfig.ResultsetCacheConfiguration != null)
			{
				// For now we'll  use the default MemoryCache which is configured through the config file.
				CacheController.RegisterCache(string.Empty, 
											  new MemoryCachedResultsetCache("HnDResultsetCache", hndConfig.ResultsetCacheConfiguration.ToNameValueCollection()));
			}
		}


		private void ConfigureLLBLGenPro(IServiceCollection services)
		{
			var llblgenProConfig = new LLBLGenProConfiguration();
			this.Configuration.Bind("LLBLGenPro", llblgenProConfig);
			llblgenProConfig.Sanitize();
			var connectionString = this.Configuration.GetConnectionString("Main.ConnectionString.SQL Server (SqlClient)");
			RuntimeConfiguration.AddConnectionString("Main.ConnectionString.SQL Server (SqlClient)", 
													 connectionString);
			RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c=>
																		 {
																			 c.AddDbProviderFactory(typeof(Microsoft.Data.SqlClient.SqlClientFactory))
																			  .SetDefaultCompatibilityLevel(llblgenProConfig.SqlServerCompatibilityAsEnum);
																			 foreach(var kvp in llblgenProConfig.CatalogNameOverwrites)
																			 {
																				 c.AddCatalogNameOverwrite(kvp.Key, kvp.Value);
																			 }
																		 });
		}
		
		
		private static void RegisterRoutes(IEndpointRouteBuilder routes)
		{
			routes.MapControllerRoute(name:"ToggleMarkAsDone", pattern:"{controller=Thread}/{action=ToggleMarkAsDone}/{id?}/{pageNo=1}");
			routes.MapControllerRoute(name:"ToggleBookmark", pattern:"{controller=Thread}/{action=ToggleBookmark}/{id?}");
			routes.MapControllerRoute(name:"ToggleSubscribe", pattern:"{controller=Thread}/{action=ToggleSubscribe}/{id?}");
			routes.MapControllerRoute(name:"MoveThread", pattern:"{controller=Thread}/{action=Move}/{id?}");
			routes.MapControllerRoute(name:"DeleteThread", pattern:"{controller=Thread}/{action=Delete}/{id?}");
			routes.MapControllerRoute(name:"EditThreadProperties", pattern:"{controller=Thread}/{action=EditProperties}/{id?}");
			routes.MapControllerRoute(name:"AddThread", pattern:"{controller=Thread}/{action=Add}/{forumId?}");
			routes.MapControllerRoute(name:"ViewActiveThreads", pattern:"{controller=Thread}/{action=Active}");

			// set this one beneath all other Thread/ routes as otherwise {id?} will match with the action... WebDev, never a dull moment!
			routes.MapControllerRoute(name:"ViewThread", pattern:"{controller=Thread}/{action=Index}/{id?}/{pageNo=1}");

			routes.MapControllerRoute(name:"ViewForum", pattern:"{controller=Forum}/{action=Index}/{id?}/{pageNo=1}");
			routes.MapControllerRoute(name:"RssForum", pattern:"{controller=RssForum}/{action=Index}/{id?}");

			routes.MapControllerRoute(name:"MoveToQueue", pattern:"{controller=SupportQueue}/{action=MoveToQueue}/{id?}/{pageNo=1}");
			routes.MapControllerRoute(name:"ClaimThread", pattern:"{controller=SupportQueue}/{action=ClaimThread}/{id?}/{pageNo=1}");
			routes.MapControllerRoute(name:"ReleaseThread", pattern:"{controller=SupportQueue}/{action=ReleaseThread}/{id?}/{pageNo=1}");
			routes.MapControllerRoute(name:"EditMemo", pattern:"{controller=SupportQueue}/{action=EditMemo/{id?}/{pageNo=1}");
			routes.MapControllerRoute(name:"ListOfSupportQueues", pattern:"{controller=SupportQueues}/{action=Index}");
			routes.MapControllerRoute(name:"UpdateSupportQueues", pattern:"{controller=SupportQueues}/{action=UpdateQueues}");

			routes.MapControllerRoute(name:"DeleteMessage", pattern:"{controller=Message}/{action=Delete}/{id?}");
			routes.MapControllerRoute(name:"EditMessage", pattern:"{controller=Message}/{action=Edit}/{id?}");
			routes.MapControllerRoute(name:"GotoMessage", pattern:"{controller=Message}/{action=Goto}/{id?}");
			routes.MapControllerRoute(name:"AddMessage", pattern:"{controller=Message}/{action=Add}/{threadId?}/{messageIdToQuote=0}");

			routes.MapControllerRoute(name:"DeleteAttachment", pattern:"{controller=Attachment}/{action=Delete}/{messageId?}/{attachmentId?}");
			routes.MapControllerRoute(name:"ToggleApproval", pattern:"{controller=Attachment}/{action=ToggleApproval}/{messageId?}/{attachmentId?}");
			routes.MapControllerRoute(name:"GetAttachment", pattern:"{controller=Attachment}/{action=Get}/{messageId?}/{attachmentId?}");
			routes.MapControllerRoute(name:"AddAttachment", pattern:"{controller=Attachment}/{action=Add}/{messageId?}");
			routes.MapControllerRoute(name:"GetUnapproved", pattern:"{controller=Attachment}/{action=Unapproved}");

			routes.MapControllerRoute(name:"SearchAll", pattern:"{controller=Search}/{action=SearchAll}/{searchParameters?}");
			routes.MapControllerRoute(name:"SearchForum", pattern:"{controller=Search}/{action=SearchForum}/{forumId?}/{searchParameters?}");
			routes.MapControllerRoute(name:"SearchResults", pattern:"{controller=Search}/{action=Results}/{pageNo?}");
			routes.MapControllerRoute(name:"SearchAdvanced", pattern:"{controller=Search}/{action=SearchAdvanced}");
			routes.MapControllerRoute(name:"SearchAdvancedUI", pattern:"{controller=Search}/{action=AdvancedSearch}");
			routes.MapControllerRoute(name:"SearchUnattended", pattern:"{controller=Search}/{action=SearchUnattended}");
			routes.MapControllerRoute(name:"ViewIgnoredSearchWords", pattern:"{controller=Search}/{action=IgnoredSearchWords}");

			routes.MapControllerRoute(name:"ListOfForums", pattern:"{controller=Section}/{action=Forums}/{id?}");

			routes.MapControllerRoute(name:"EditBookmarks", pattern:"{controller=Account}/{action=Bookmarks}");
			routes.MapControllerRoute(name:"UpdateBookmarks", pattern:"{controller=Account}/{action=UpdateBookmarks}");

			routes.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
		}

		#region Properties
		public IConfiguration Configuration { get; }
		#endregion
	}
}