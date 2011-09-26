using System.Web.Mvc;
using System.Web.Routing;
using MvcAssets;
using MvcAssets.AjaxMin;
using MvcAssets.Compress;

namespace MvcAssetsDemo.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            GlobalFilters.Filters.Add(new MvcAssetsAttribute());

            MvcAssets.MvcAssets.Factory = context => new Assets()
                                                         {
                                                             LinkResolver = new VirtualPathLinkResolver(context),
                                                             Compressor = new AjaxMinCompressor()
                                                                              {
                                                                                  LinkResolver =
                                                                                      new VirtualPathLinkResolver(
                                                                                      context),
                                                                                  VirtualCachePath = "~/cache/",
                                                                              }
                                                         };
        }
    }
}