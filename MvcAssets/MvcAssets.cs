using System;
using System.Web;

namespace MvcAssets
{
    public static class MvcAssets
    {
        public static Func<HttpContextBase, IMvcHtmlAssets> Factory { get; set; }

        static MvcAssets()
        {
            Factory = context => new HtmlAssets()
                                {
                                    LinkResolver = new VirtualPathLinkResolver(context)
                                };
        }
    }
}