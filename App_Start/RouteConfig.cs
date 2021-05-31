using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hoc_ASP.NET_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var route = routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional},
                new[] { "Hoc_ASP.NET_MVC.Areas.Admin.Controllers"}
            );
            route.DataTokens["area"] = "Admin";
        }
    }
}
