using System.IO;
using System.Web;
using System.Web.Mvc;
using MvcAssets;
using MvcAssets.AjaxMin;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.MvcAssetsPackage), "PreApplicationStart")]

namespace $rootnamespace$.App_Start
{
    public class MvcAssetsPackage
    {
        public static void PreApplicationStart()
        {
            // Allow assets in controllers
            GlobalFilters.Filters.Add(new MvcAssetsAttribute());

            // Uncomment the code below to enable asset combining and minification
            /*
            // Make sure the virtual folder ~/cache exists
            var cachePath = Path.Combine(HttpRuntime.AppDomainAppPath, "cache");
            Directory.CreateDirectory(cachePath);

            // Setup assets in every request that uses AjaxMin to minify things and then combines assets.
            MvcAssets.MvcAssets.Factory = context => new Assets()
                                                         {
                                                             LinkResolver = new VirtualPathLinkResolver(context),
                                                             Compressor = new AjaxMinCompressor()
                                                                              {
                                                                                  LinkResolver =
                                                                                      new VirtualPathLinkResolver(
                                                                                      context),
                                                                                  VirtualCachePath = "~/cache/"
                                                                              }
                                                         };
             
             */ 
        }
    }
}