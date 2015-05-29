﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SD.HnD.Gui
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// This informs MVC Routing Engine to send any requests for .aspx page to the WebForms engine
			routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
			routes.IgnoreRoute("{resource}.aspx");

			routes.MapRoute("Forum", "Forum/{id}/{pageNo}", new { controller="Forum", action="Index", id = UrlParameter.Optional, pageNo=1 });
			routes.MapRoute("RssForum", "RssForum/{id}", new {controller = "RssForum", action = "Index", id = UrlParameter.Optional});

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}