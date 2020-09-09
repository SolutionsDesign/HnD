using System;
using System.Linq;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using SD.HnD.Gui.Classes;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses.Contrib;
using SD.Tools.OrmProfiler.Interceptor;

namespace SD.HnD.Gui
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDistributedMemoryCache();
			services.AddSession();
			services.AddControllersWithViews(options=>options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddMemoryCache();
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
					.AddCookie(options =>
							   {
								   options.LoginPath = "/Account/Login";
								   options.LogoutPath = "/Account/Logout";
								   options.Cookie.Name = "HnDAuthenticationCookie";
							   });
			services.AddResponseCaching();
			// First we need to configure LLBLGen Pro
			ConfigureLLBLGenPro(services);
			// Then we can configure HnD as it needs the database.
			ConfigureHnD(services);
		}


		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// all configured methods are ran at every request
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error/500");
			}

			// Rewrite webforms urls from old versions to urls for this version. We do that using a redirect and not a rewrite, as
			// these urls should be replaced, so we need the client to know about the new url in the address bar (if applicable).
			// One thing to understand is that the regex is only applied on the *path* of the URL. If you include query elements in the regex,
			// it won't match. This requires the specific controller actions we've added to deal with the query arguments. 
			var redirectOptions = new RewriteOptions()
								  .AddRedirect("^default.aspx", "Home", (int)HttpStatusCode.PermanentRedirect)
								  .AddRedirect("^[gG]oto[mM]essage.aspx(.*)", "Message/OldGoto/$1", (int)HttpStatusCode.PermanentRedirect)
								  .AddRedirect("^[rR]ss[fF]orum.aspx(.*)", "RssForum/Old/$1", (int)HttpStatusCode.PermanentRedirect)
								  .AddRedirect("^[mM]essages.aspx(.*)", "Thread/Old/$1", (int)HttpStatusCode.PermanentRedirect)
								  .AddRedirect("^[sS]earch[uU]nattended.aspx(.*)", "SearchUnattended/$1", (int)HttpStatusCode.PermanentRedirect);
			app.UseRewriter(redirectOptions);
			
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			
			app.Use(async (ctx, next) =>
					{
						await next();

						if(ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
						{
							//Re-execute the request so the user gets the error page
							string originalPath = ctx.Request.Path.Value;
							ctx.Items["originalPath"] = originalPath;
							ctx.Request.Path = "/Error/404";
							await next();
						}
					});
			
			app.UseRouting();
			app.UseResponseCaching();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseSession();
			// own middleware function to initialize session if required. 
			app.Use(async (context, next) =>
					{
						Startup.InitializeSessionIfRequired(context);

						// call next in pipeline
						await next();
					});

			// last element added to the chain.
			app.UseEndpoints(endpoints => RegisterRoutes(endpoints));

			// HnD one-time configuration now we now the environment.  
			HnDConfiguration.Current.LoadStaticData(env.WebRootPath, env.ContentRootPath);
		}


		private static void InitializeSessionIfRequired(HttpContext context)
		{
			if(context?.Session == null)
			{
				return;
			}

			if(context.Session.GetInt32(SessionKeys.SessionInitialized)==1)
			{
				// initialized
				return;
			}

			context.Session.Initialize(context);
		}


		private void ConfigureHnD(IServiceCollection services)
		{
			var hndConfig = new HnDConfiguration();
			_configuration.Bind("HnD", hndConfig);
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
			_configuration.Bind("LLBLGenPro", llblgenProConfig);
			llblgenProConfig.Sanitize();
			var connectionString = _configuration.GetConnectionString("Main.ConnectionString.SQL Server (SqlClient)");
			RuntimeConfiguration.AddConnectionString("Main.ConnectionString.SQL Server (SqlClient)", connectionString);
			foreach(var kvp in llblgenProConfig.ConnectionStrings)
			{
				RuntimeConfiguration.AddConnectionString(kvp.Key, kvp.Value);
			}

			RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c=>
																		 {
																			 c.AddDbProviderFactory(InterceptorCore.Initialize("HnD", 
																								    typeof(Microsoft.Data.SqlClient.SqlClientFactory)))
																			  .SetDefaultCompatibilityLevel(llblgenProConfig.SqlServerCompatibilityAsEnum);
																			 foreach(var kvp in llblgenProConfig.CatalogNameOverwrites)
																			 {
																				 c.AddCatalogNameOverwrite(kvp.Key, kvp.Value);
																			 }
																		 });
		}
		
		
		private static void RegisterRoutes(IEndpointRouteBuilder routes)
		{
			// old version -> new version routes which require special routing data. 
			routes.MapControllerRoute("ViewThreadOldRedirect", "Thread/Old/", new {controller="Thread", action="IndexOldVersion", pageNo=1});
			routes.MapControllerRoute("RssForumOldRedirect", "RssForum/Old/", new {controller="RssForum", action="IndexOldVersion"});
			routes.MapControllerRoute("MessageOldGotoRedirect", "Message/OldGoto/", new {controller="Message", action="GotoOldVersion"});
			
			// Only map the routes that are different than the default (which is at the end of the list). All routes not defined explicitly
			// will match with the default {controller}/{action}/{id?}.
			
			// Account 
			routes.MapControllerRoute("SpecifyNewPassword", "Account/SpecifyNewPassword/{tokenID}", new {controller="Account", action="SpecifyNewPassword"});
			routes.MapControllerRoute("EditProfile", "Account/Edit/", new {controller = "Account", action = "EditProfile"});
			routes.MapControllerRoute("ViewMyThreads", "Account/Threads/{pageNo}", new {controller = "Account", action = "Threads", pageNo = 1});
			
			// Thread
			routes.MapControllerRoute("ViewThread", "Thread/{id}/{pageNo}", new {controller="Thread", action="Index", pageNo=1});
			routes.MapControllerRoute("ToggleMarkAsDone", "Thread/ToggleMarkAsDone/{id}/{pageNo}", new {controller="Thread", action="ToggleMarkAsDone", pageNo=1});
			routes.MapControllerRoute("AddThread", "Thread/Add/{forumId}", new {controller="Thread", action="Add"});

			// Forum
			routes.MapControllerRoute("ViewForum", "Forum/{id}/{pageNo}", new {controller="Forum", action="Index", pageNo=1});
			
			// RssForum
			routes.MapControllerRoute("RssForum", "RssForum/{id}", new {controller="RssForum", action="Index"});

			// SupportQueue
			routes.MapControllerRoute("MoveToQueue", "SupportQueue/MoveToQueue/{id}/{pageNo}", new {controller="SupportQueue", action="MoveToQueue", pageNo=1});
			routes.MapControllerRoute("ClaimThread", "SupportQueue/ClaimThread/{id}/{pageNo}", new {controller="SupportQueue", action="ClaimThread", pageNo=1});
			routes.MapControllerRoute("ReleaseThread", "SupportQueue/ReleaseThread/{id}/{pageNo}", new {controller="SupportQueue", action="ReleaseThread", pageNo=1});
			routes.MapControllerRoute("EditMemo", "SupportQueue/EditMemo/{id}/{pageNo}", new {controller="SupportQueue", action="EditMemo", pageNo=1});

			// Message
			routes.MapControllerRoute("AddMessage", "Message/Add/{threadId}/{messageIdToQuote}", new {controller="Message", action="Add", messageIdToQuote=0});

			// Attachment
			routes.MapControllerRoute("DeleteAttachment", "Attachment/Delete/{messageId}/{attachmentId}", new {controller="Attachment", action="Delete"});
			routes.MapControllerRoute("ToggleApproval", "Attachment/ToggleApproval/{messageId}/{attachmentId}", new {controller="Attachment", action="ToggleApproval"});
			routes.MapControllerRoute("GetAttachment", "Attachment/Get/{messageId}/{attachmentId}", new {controller="Attachment", action="Get"});
			routes.MapControllerRoute("AddAttachment", "Attachment/Add/{messageId}", new {controller="Attachment", action="Add"});

			// Search
			routes.MapControllerRoute("SearchAll", "Search/SearchAll/{searchParameters}", new {controller="Search", action="SearchAll"});
			routes.MapControllerRoute("SearchForum", "Search/SearchForum/{forumId}/{searchParameters}", new {controller="Search", action="SearchForum"});
			routes.MapControllerRoute("SearchResults", "Search/Results/{pageNo}", new {controller="Search", action="Results", pageNo=1});
			routes.MapControllerRoute("SearchUnattended", "SearchUnattended/", new {controller="Search", action="SearchUnattended"});
			routes.MapControllerRoute("SearchAdvanced", "Search/SearchAdvanced/", new {controller = "Search", action = "SearchAdvanced"});
			routes.MapControllerRoute("SearchAdvancedUI", "Search", new {controller = "Search", action = "AdvancedSearch"});
			
			// User
			routes.MapControllerRoute("UserProfile", "User/{id}", new {controller = "User", action = "ViewProfile"});
			
			// Error
			routes.MapControllerRoute("ErrorHandler", "Error/{errorCode}", new {controller = "Error", action = "HandleErrorCode"});
			
			// Admin
			routes.MapControllerRoute("EditSystemParameters", "Admin/SystemParameters", new {controller = "SystemAdmin", action = "SystemParameters"});
			routes.MapControllerRoute("ReparseMessages", "Admin/ReparseMessages", new {controller = "SystemAdmin", action = "ReparseMessages"});
			routes.MapControllerRoute("GetSupportQueues", "Admin/GetSupportQueues", new {controller = "SupportQueueAdmin", action = "GetSupportQueues"});
			routes.MapControllerRoute("ManageSupportQueues", "Admin/ManageSupportQueues", new {controller = "SupportQueueAdmin", action = "ManageSupportQueues"});
			routes.MapControllerRoute("UpdateSupportQueue", "Admin/UpdateSupportQueue", new {controller = "SupportQueueAdmin", action = "UpdateSupportQueue"});
			routes.MapControllerRoute("InsertSupportQueue", "Admin/InsertSupportQueue", new {controller = "SupportQueueAdmin", action = "InsertSupportQueue"});
			routes.MapControllerRoute("DeleteSupportQueue", "Admin/DeleteSupportQueue/{id}", new {controller = "SupportQueueAdmin", action = "DeleteSupportQueue", id =0});
			routes.MapControllerRoute("GetSections", "Admin/GetSections", new {controller = "SectionAdmin", action = "GetSections"});
			routes.MapControllerRoute("ManageSections", "Admin/ManageSections", new {controller = "SectionAdmin", action = "ManageSections"});
			routes.MapControllerRoute("UpdateSection", "Admin/UpdateSection", new {controller = "SectionAdmin", action = "UpdateSection"});
			routes.MapControllerRoute("InsertSection", "Admin/InsertSection", new {controller = "SectionAdmin", action = "InsertSection"});
			routes.MapControllerRoute("DeleteSection", "Admin/DeleteSection/{id}", new {controller = "SectionAdmin", action = "DeleteSection", id =0});
			routes.MapControllerRoute("GetForums", "Admin/GetForums", new {controller = "ForumAdmin", action = "GetForums"});
			routes.MapControllerRoute("ManageForums", "Admin/ManageForums", new {controller = "ForumAdmin", action = "ManageForums"});
			routes.MapControllerRoute("AddForum", "Admin/AddForum", new {controller = "ForumAdmin", action = "AddForum"});
			routes.MapControllerRoute("EditForum", "Admin/EditForum/{id}", new {controller = "ForumAdmin", action = "EditForum", id=0});
			routes.MapControllerRoute("DeleteForum", "Admin/DeleteForum/{id}", new {controller = "ForumAdmin", action = "DeleteForum", id=0});
			routes.MapControllerRoute("BanUnbanUser", "Admin/BanUnbanUser", new {controller = "UserAdmin", action = "BanUnbanUser"});
			routes.MapControllerRoute("DeleteUser", "Admin/DeleteUser", new {controller = "UserAdmin", action = "DeleteUser"});
			routes.MapControllerRoute("EditUserInfo", "Admin/EditUserInfo", new {controller = "UserAdmin", action = "EditUserInfo"});
			routes.MapControllerRoute("ShowAuditInfoUser", "Admin/ShowAuditInfoUser", new {controller = "UserAdmin", action = "ShowAuditInfoUser"});
			routes.MapControllerRoute("GetIPBans", "Admin/GetIPBans", new {controller = "SecurityAdmin", action = "GetIPBans"});
			routes.MapControllerRoute("ManageIPBans", "Admin/ManageIPBans", new {controller = "SecurityAdmin", action = "ManageIPBans"});
			routes.MapControllerRoute("UpdateIPBan", "Admin/UpdateIPBan", new {controller = "SecurityAdmin", action = "UpdateIPBan"});
			routes.MapControllerRoute("InsertIPBan", "Admin/InsertIPBan", new {controller = "SecurityAdmin", action = "InsertIPBan"});
			routes.MapControllerRoute("DeleteIPBan", "Admin/DeleteIPBan/{id}", new {controller = "SecurityAdmin", action = "DeleteIPBan", id =0});
			routes.MapControllerRoute("GetRoles", "Admin/GetRoles", new {controller = "SecurityAdmin", action = "GetRoles"});
			routes.MapControllerRoute("ManageRoles", "Admin/ManageRoles", new {controller = "SecurityAdmin", action = "ManageRoles"});
			routes.MapControllerRoute("AddRole", "Admin/AddRole", new {controller = "SecurityAdmin", action = "AddRole"});
			routes.MapControllerRoute("EditRole", "Admin/EditRole/{id}", new {controller = "SecurityAdmin", action = "EditRole", id=0});
			routes.MapControllerRoute("DeleteRole", "Admin/DeleteRole/{id}", new {controller = "SecurityAdmin", action = "DeleteRole", id =0});
			routes.MapControllerRoute("ManageRoleRights", "Admin/ManageRoleRights", new {controller = "SecurityAdmin", action = "ManageRoleRights"});
			routes.MapControllerRoute("ManageRightsForForum", "Admin/ManageRightsForForum", new {controller = "SecurityAdmin", action = "ManageRightsForForum"});
			routes.MapControllerRoute("GetActionRights", "Admin/GetActionRights", new {controller = "SecurityAdmin", action = "GetActionRights"});
			routes.MapControllerRoute("ManageUsersPerRole", "Admin/ManageUsersPerRole", new {controller = "SecurityAdmin", action = "ManageUsersPerRole"});
			routes.MapControllerRoute("GetUsersInRole", "Admin/GetUsersInRole/{id}", new {controller = "SecurityAdmin", action = "GetUsersInRole", id=0});
			routes.MapControllerRoute("RemoveUserFromRole", "Admin/RemoveUserFromRole", new {controller = "SecurityAdmin", action = "RemoveUserFromRole", roleID=0, userID=-1});
			routes.MapControllerRoute("AddUsersToRole", "Admin/AddUsersToRole/{id}", new {controller = "SecurityAdmin", action = "AddUsersToRole", id=0});
			
			// The last route, which will be used to map most routes to {controller}/{action}/{id?}.  
			routes.MapControllerRoute( "default",  "{controller=Home}/{action=Index}/{id?}");
		}
	}
}