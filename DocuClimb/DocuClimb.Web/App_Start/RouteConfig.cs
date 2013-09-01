using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DocuClimb.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Climber",
                url: "{controller}/{action}",
                defaults: new { controller = "Climber", action = "List"}
            );

            routes.MapRoute(
                name: "Climb",
                url: "{controller}/{action}",
                defaults: new { controller = "Climb", action = "List"}
            );
        }
    }
}