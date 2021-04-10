using Lab5B.CustomRouteConstraint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Lab5B
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("EmailConstraint", typeof(EmailConstraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);

            //  routes.MapMvcAttributeRoutes();

           
            routes.MapRoute(
               name: "A",
               url: "{controller}/{action}"
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}"
            );
        }
    }
}
