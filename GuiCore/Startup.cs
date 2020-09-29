/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SD.HnD.BL;
using SD.HnD.Gui.Classes;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses.Contrib;
#if DEBUG
using SD.Tools.OrmProfiler.Interceptor;
#endif 

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
			services.AddControllersWithViews(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
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

			app.Use(async (context, next) =>
					{
						await next();

						if(context.Response.StatusCode == 404 && !context.Response.HasStarted)
						{
							//Re-execute the request so the user gets the error page
							string originalPath = context.Request.Path.Value;
							context.Items["originalPath"] = originalPath;
							context.Request.Path = "/Error/404";

							// call next in pipeline
							await next();
						}
					});

			// If the database is empty, we have to redirect to the initialization page.  
			app.Use(async (context, next) =>
					{
						await Startup.RedirectToInitIfRequired(context);

						// call next in pipeline
						await next();
					});

			app.UseRouting();
			app.UseResponseCaching();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseIPFilter();
			app.UseSession();

			// own middleware function to initialize session if required. 
			app.Use(async (context, next) =>
					{
						await Startup.InitializeSessionIfRequiredAsync(context);

						await Startup.LogOutIfNeeded(context);

						// call next in pipeline
						await next();
					});

			// last element added to the chain.
			app.UseEndpoints(endpoints => RegisterRoutes(endpoints));

			// HnD one-time configuration now we now the environment.  
			HnDConfiguration.Current.LoadStaticData(env.WebRootPath, env.ContentRootPath);
		}


		private static async Task RedirectToInitIfRequired(HttpContext context)
		{
			// check if there's an anonymous user in the database
			var anonymous = await UserGuiHelper.GetUserAsync(0); // use hardcoded 0 id. This also makes sure a misconfigured db isn't used further.
			if(anonymous == null)
			{
				// database is empty 
				context.Request.Path = ApplicationAdapter.GetVirtualRoot() + "Admin/Init";
			}
			else
			{
				if(anonymous.NickName != "Anonymous")
				{
					// Misconfigured.
					context.Request.Path = ApplicationAdapter.GetVirtualRoot() + "Error/1337";
				}
			}
		}


		private static async Task LogOutIfNeeded(HttpContext context)
		{
			if(context.User.Identity.IsAuthenticated)
			{
				string nickName = context.User.Identity.Name;

				// if the user has to be logged out by force, do that now
				if(ApplicationAdapter.UserHasToBeLoggedOutByForce(nickName))
				{
					await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
					context.Session.Clear();
					context.Response.Redirect(ApplicationAdapter.GetVirtualRoot());
					ApplicationAdapter.RemoveUserFromListToBeLoggedOutByForce(nickName);
				}
			}
		}


		private static Task InitializeSessionIfRequiredAsync(HttpContext context)
		{
			if(context?.Session == null)
			{
				return Task.CompletedTask;
			}

			if(context.Session.GetInt32(SessionKeys.SessionInitialized) == 1)
			{
				// initialized
				return Task.CompletedTask;
			}

			return context.Session.InitializeAsync(context);
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
			if(!string.IsNullOrEmpty(connectionString)!)
			{
				RuntimeConfiguration.AddConnectionString("Main.ConnectionString.SQL Server (SqlClient)", connectionString);
			}

			foreach(var kvp in llblgenProConfig.ConnectionStrings)
			{
				RuntimeConfiguration.AddConnectionString(kvp.Key, kvp.Value);
			}

			var factoryType = typeof(Microsoft.Data.SqlClient.SqlClientFactory);
#if DEBUG
			// only intercept queries using the profiler in debug builds. 
			factoryType = InterceptorCore.Initialize("HnD", factoryType);
#endif					
			RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c =>
																		 {
																			 c.AddDbProviderFactory(factoryType)
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
			routes.MapControllerRoute("ViewThreadOldRedirect", "Thread/Old/", new {controller = "Thread", action = "IndexOldVersion", pageNo = 1});
			routes.MapControllerRoute("RssForumOldRedirect", "RssForum/Old/", new {controller = "RssForum", action = "IndexOldVersion"});
			routes.MapControllerRoute("MessageOldGotoRedirect", "Message/OldGoto/", new {controller = "Message", action = "GotoOldVersion"});

			// Only map the routes that are different than the default (which is at the end of the list). All routes not defined explicitly
			// will match with the default {controller}/{action}/{id?}.

			// Account 
			routes.MapControllerRoute("SpecifyNewPassword", "Account/SpecifyNewPassword/{tokenId}", new {controller = "Account", action = "SpecifyNewPassword"});
			routes.MapControllerRoute("EditProfile", "Account/Edit/", new {controller = "Account", action = "EditProfile"});
			routes.MapControllerRoute("ViewMyThreads", "Account/Threads/{pageNo}", new {controller = "Account", action = "Threads", pageNo = 1});

			// Thread
			routes.MapControllerRoute("ViewThread", "Thread/{threadId}/{pageNo}", new {controller = "Thread", action = "Index", pageNo = 1});
			routes.MapControllerRoute("ToggleMarkAsDone", "Thread/ToggleMarkAsDone/{threadId}/{pageNo}", new {controller = "Thread", action = "ToggleMarkAsDone", pageNo = 1});
			routes.MapControllerRoute("AddThread", "Thread/Add/{forumId}", new {controller = "Thread", action = "Add"});
			routes.MapControllerRoute("MoveThread", "Thread/Move/{threadId}", new {controller = "Thread", action = "Move", pageNo = 1});
			routes.MapControllerRoute("EditThreadProperties", "Thread/EditProperties/{threadId}", new {controller = "Thread", action = "EditProperties", pageNo = 1});

			// Forum
			routes.MapControllerRoute("ViewForum", "Forum/{forumId}/{pageNo}", new {controller = "Forum", action = "Index", pageNo = 1});

			// RssForum
			routes.MapControllerRoute("RssForum", "RssForum/{forumId}", new {controller = "RssForum", action = "Index"});

			// SupportQueue
			routes.MapControllerRoute("MoveToQueue", "SupportQueue/MoveToQueue/{threadId}/{pageNo}", new {controller = "SupportQueue", action = "MoveToQueue", pageNo = 1});
			routes.MapControllerRoute("ClaimThread", "SupportQueue/ClaimThread/{threadId}/{pageNo}", new {controller = "SupportQueue", action = "ClaimThread", pageNo = 1});
			routes.MapControllerRoute("ReleaseThread", "SupportQueue/ReleaseThread/{threadId}/{pageNo}", new {controller = "SupportQueue", action = "ReleaseThread", pageNo = 1});
			routes.MapControllerRoute("EditMemo", "SupportQueue/EditMemo/{threadId}/{pageNo}", new {controller = "SupportQueue", action = "EditMemo", pageNo = 1});

			// Message
			routes.MapControllerRoute("AddMessage", "Message/Add/{threadId}/{messageIdToQuote}", new {controller = "Message", action = "Add", messageIdToQuote = 0});

			// Attachment
			routes.MapControllerRoute("DeleteAttachment", "Attachment/Delete/{messageId}/{attachmentId}", new {controller = "Attachment", action = "Delete"});
			routes.MapControllerRoute("ToggleApproval", "Attachment/ToggleApproval/{messageId}/{attachmentId}", new {controller = "Attachment", action = "ToggleApproval"});
			routes.MapControllerRoute("GetAttachment", "Attachment/Get/{messageId}/{attachmentId}", new {controller = "Attachment", action = "Get"});
			routes.MapControllerRoute("AddAttachment", "Attachment/Add/{messageId}", new {controller = "Attachment", action = "Add"});

			// Search
			routes.MapControllerRoute("SearchAll", "Search/SearchAll/{searchParameters}", new {controller = "Search", action = "SearchAll"});
			routes.MapControllerRoute("SearchForum", "Search/SearchForum/{forumId}/{searchParameters}", new {controller = "Search", action = "SearchForum"});
			routes.MapControllerRoute("SearchResults", "Search/Results/{pageNo}", new {controller = "Search", action = "Results", pageNo = 1});
			routes.MapControllerRoute("SearchUnattended", "SearchUnattended/", new {controller = "Search", action = "SearchUnattended"});
			routes.MapControllerRoute("SearchAdvanced", "Search/SearchAdvanced/", new {controller = "Search", action = "SearchAdvanced"});
			routes.MapControllerRoute("SearchAdvancedUI", "Search", new {controller = "Search", action = "AdvancedSearch"});

			// User
			routes.MapControllerRoute("UserProfile", "User/{userId}", new {controller = "User", action = "ViewProfile"});

			// Error
			routes.MapControllerRoute("ErrorHandler", "Error/{errorCode}", new {controller = "Error", action = "HandleErrorCode"});

			// Admin
			routes.MapControllerRoute("InitializeSystem", "Admin/Init", new {controller = "SystemAdmin", action = "Init"});
			routes.MapControllerRoute("EditSystemParameters", "Admin/SystemParameters", new {controller = "SystemAdmin", action = "SystemParameters"});
			routes.MapControllerRoute("ReparseMessages", "Admin/ReparseMessages", new {controller = "SystemAdmin", action = "ReparseMessages"});
			routes.MapControllerRoute("GetSupportQueues", "Admin/GetSupportQueues", new {controller = "SupportQueueAdmin", action = "GetSupportQueues"});
			routes.MapControllerRoute("ManageSupportQueues", "Admin/ManageSupportQueues", new {controller = "SupportQueueAdmin", action = "ManageSupportQueues"});
			routes.MapControllerRoute("UpdateSupportQueue", "Admin/UpdateSupportQueue", new {controller = "SupportQueueAdmin", action = "UpdateSupportQueue"});
			routes.MapControllerRoute("InsertSupportQueue", "Admin/InsertSupportQueue", new {controller = "SupportQueueAdmin", action = "InsertSupportQueue"});
			routes.MapControllerRoute("DeleteSupportQueue", "Admin/DeleteSupportQueue/{queueId}", new {controller = "SupportQueueAdmin", action = "DeleteSupportQueue", queueId = 0});
			routes.MapControllerRoute("GetSections", "Admin/GetSections", new {controller = "SectionAdmin", action = "GetSections"});
			routes.MapControllerRoute("ManageSections", "Admin/ManageSections", new {controller = "SectionAdmin", action = "ManageSections"});
			routes.MapControllerRoute("UpdateSection", "Admin/UpdateSection", new {controller = "SectionAdmin", action = "UpdateSection"});
			routes.MapControllerRoute("InsertSection", "Admin/InsertSection", new {controller = "SectionAdmin", action = "InsertSection"});
			routes.MapControllerRoute("DeleteSection", "Admin/DeleteSection/{sectionId}", new {controller = "SectionAdmin", action = "DeleteSection", sectionId = 0});
			routes.MapControllerRoute("GetForums", "Admin/GetForums", new {controller = "ForumAdmin", action = "GetForums"});
			routes.MapControllerRoute("ManageForums", "Admin/ManageForums", new {controller = "ForumAdmin", action = "ManageForums"});
			routes.MapControllerRoute("AddForum", "Admin/AddForum", new {controller = "ForumAdmin", action = "AddForum"});
			routes.MapControllerRoute("EditForum", "Admin/EditForum/{forumId}", new {controller = "ForumAdmin", action = "EditForum", forumId = 0});
			routes.MapControllerRoute("DeleteForum", "Admin/DeleteForum/{forumId}", new {controller = "ForumAdmin", action = "DeleteForum", forumId = 0});
			routes.MapControllerRoute("BanUnbanUser", "Admin/BanUnbanUser", new {controller = "UserAdmin", action = "BanUnbanUser"});
			routes.MapControllerRoute("DeleteUser", "Admin/DeleteUser", new {controller = "UserAdmin", action = "DeleteUser"});
			routes.MapControllerRoute("EditUserInfo", "Admin/EditUserInfo", new {controller = "UserAdmin", action = "EditUserInfo"});
			routes.MapControllerRoute("ShowAuditInfoUser", "Admin/ShowAuditInfoUser", new {controller = "UserAdmin", action = "ShowAuditInfoUser"});
			routes.MapControllerRoute("GetIPBans", "Admin/GetIPBans", new {controller = "SecurityAdmin", action = "GetIPBans"});
			routes.MapControllerRoute("ManageIPBans", "Admin/ManageIPBans", new {controller = "SecurityAdmin", action = "ManageIPBans"});
			routes.MapControllerRoute("UpdateIPBan", "Admin/UpdateIPBan", new {controller = "SecurityAdmin", action = "UpdateIPBan"});
			routes.MapControllerRoute("InsertIPBan", "Admin/InsertIPBan", new {controller = "SecurityAdmin", action = "InsertIPBan"});
			routes.MapControllerRoute("DeleteIPBan", "Admin/DeleteIPBan/{ipBanId}", new {controller = "SecurityAdmin", action = "DeleteIPBan", ipBanId = 0});
			routes.MapControllerRoute("GetRoles", "Admin/GetRoles", new {controller = "SecurityAdmin", action = "GetRoles"});
			routes.MapControllerRoute("ManageRoles", "Admin/ManageRoles", new {controller = "SecurityAdmin", action = "ManageRoles"});
			routes.MapControllerRoute("AddRole", "Admin/AddRole", new {controller = "SecurityAdmin", action = "AddRole"});
			routes.MapControllerRoute("EditRole", "Admin/EditRole/{roleId}", new {controller = "SecurityAdmin", action = "EditRole", roleId = 0});
			routes.MapControllerRoute("DeleteRole", "Admin/DeleteRole/{roleId}", new {controller = "SecurityAdmin", action = "DeleteRole", roleId = 0});
			routes.MapControllerRoute("ManageRoleRights", "Admin/ManageRoleRights", new {controller = "SecurityAdmin", action = "ManageRoleRights"});
			routes.MapControllerRoute("ManageRightsForForum", "Admin/ManageRightsForForum", new {controller = "SecurityAdmin", action = "ManageRightsForForum"});
			routes.MapControllerRoute("GetActionRights", "Admin/GetActionRights", new {controller = "SecurityAdmin", action = "GetActionRights"});
			routes.MapControllerRoute("ManageUsersPerRole", "Admin/ManageUsersPerRole", new {controller = "SecurityAdmin", action = "ManageUsersPerRole"});
			routes.MapControllerRoute("GetUsersInRole", "Admin/GetUsersInRole/{roleId}", new {controller = "SecurityAdmin", action = "GetUsersInRole", roleId = 0});
			routes.MapControllerRoute("RemoveUserFromRole", "Admin/RemoveUserFromRole", new {controller = "SecurityAdmin", action = "RemoveUserFromRole", roleId = 0, userId = -1});
			routes.MapControllerRoute("AddUsersToRole", "Admin/AddUsersToRole/{roleId}", new {controller = "UserAdmin", action = "AddUsersToRole", roleId = 0});

			// The last route, which will be used to map most routes to {controller}/{action}/{id?}.  
			routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
		}
	}
}