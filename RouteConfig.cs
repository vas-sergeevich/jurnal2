using System.Web.Mvc;
using System.Web.Routing;

namespace Pagen
{
    public class RouteConfig
    {
        #region Public methods

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Profiles",
                "{userName}",
                new {controller = "Profile", action = "ViewProfile"}
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new {controller = "Home", action = "Index"}
            );
        }

        #endregion
    }
}