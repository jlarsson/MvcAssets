using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using AspNetAssets;
using WebAssets.Combine;
using AspNetAssets = AspNetAssets.AspNetAssets;

namespace AspNetAssetsDemo.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            Directory.CreateDirectory(Server.MapPath("~/cache"));
            global::AspNetAssets.AspNetAssets.Factory = context => new global::AspNetAssets.AspNetAssets()
                                                               {
                                                                   LinkResolver = new VirtualPathLinkResolver(context),
                                                                   Compressor =
                                                                       new Combiner()
                                                                           {
                                                                               VirtualCachePath = "~/cache/", 
                                                                               LinkResolver = new VirtualPathLinkResolver(context)
                                                                           }
                                                               };

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
