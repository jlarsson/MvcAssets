using System.Web;

namespace MvcAssets
{
    public class VirtualPathLinkResolver : IHtmlAssetLinkResolver
    {
        private readonly HttpContextBase _context;

        public VirtualPathLinkResolver(HttpContextBase context)
        {
            _context = context;
        }

        public string Resolve(IHtmlLinkAsset link)
        {
            var url = link.Link;
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }
            if (url[0] == '~')
            {
                return VirtualPathUtility.ToAbsolute(url, _context.Request.ApplicationPath);
            }
            return url;
        }
    }
}