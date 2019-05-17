using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Joole_MVC_Team1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Search",
               url: "Search/Search/{categoryId}/{subCategoryId}",
               new { controller = "Search", action = "Search" }
            );

            routes.MapRoute(
                name: "Cmp2Page",
                url: "ProductDetails/ProductCmp2/{id1}/{id2}",
                defaults: new { controller = "tempProductDetails", action = "ProductCompare2", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Cmp3Page",
               url: "ProductDetails/ProductCmp3/{id1}/{id2}/{id3}",
               defaults: new { controller = "tempProductDetails", action = "ProductCompare3", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional , id3 = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
