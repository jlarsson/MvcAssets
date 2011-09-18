using System;
using System.Web;

namespace MvcAssets
{
    public static class MvcAssets
    {
        public static Func<HttpContextBase, IMvcAssets> Factory { get; set; }

        static MvcAssets()
        {
            Factory = context => new Assets()
                                {
                                    Compressor = new NullCompressor(),
                                    LinkResolver = new VirtualPathLinkResolver(context)
                                };
        }
    }
}