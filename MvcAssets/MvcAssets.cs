using System;
using System.Web;
using MvcAssets.AjaxMin;

namespace MvcAssets
{
    public static class MvcAssets
    {
        static MvcAssets()
        {
            Factory = context => new Assets
                                     {
                                         Compressor = new AjaxMinCompressor(),
                                         LinkResolver = new VirtualPathLinkResolver(context)
                                     };
        }

        public static Func<HttpContextBase, IMvcAssets> Factory { get; set; }
    }
}