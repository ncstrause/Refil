using System.Web.Mvc;
using System.Web.Routing;

namespace RefilWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Ignore("Content/*");

            routes.MapMvcAttributeRoutes();
        }
    }
}
