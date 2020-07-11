using LowercaseDashedRouting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MikeUpjohnWebPortfolioV2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(new LowercaseDashedRoute("about-me/",
                new RouteValueDictionary(
                    new { controller = "About", action = "Index" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("technologies/",
                new RouteValueDictionary(
                    new { controller = "Technologies", action = "Index" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("contact-me/",
                new RouteValueDictionary(
                    new { controller = "Contact", action = "Index" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("projects/page-{page}",
                new RouteValueDictionary(
                    new { controller = "Projects", action = "Index"}),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("projects/{year}/{month}/{title}",
                new RouteValueDictionary(
                    new { controller = "Projects", action = "View" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("projects/",
                new RouteValueDictionary(
                    new { controller = "Projects", action = "Index" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("blog/page-{page}",
                new RouteValueDictionary(
                    new { controller = "Blog", action = "Index" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("blog/{year}/{month}/{title}",
                new RouteValueDictionary(
                    new { controller = "Blog", action = "View" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("blog/",
                new RouteValueDictionary(
                    new { controller = "Blog", action = "Index" }),
                    new DashedRouteHandler()
                )
            );

            routes.Add(new LowercaseDashedRoute("{controller}/{action}/",
                new RouteValueDictionary(
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
                    new DashedRouteHandler()
                )
            );

            //routes.Add(new LowercaseDashedRoute("{controller}/{action}/page-{page}",
            //    new RouteValueDictionary(
            //        new { controller = "Home", action = "Index", page = UrlParameter.Optional }),
            //        new DashedRouteHandler()
            //    )
            //);

            
        }
    }
}
