using System.Web;

namespace MvcAssets
{
    public class VirtualPathLinkResolver : IAssetLinkResolver
    {
        private readonly HttpContextBase _context;

        public VirtualPathLinkResolver(HttpContextBase context)
        {
            _context = context;
        }

        public IAssetSource Resolve(ILinkAsset link)
        {
            var url = link.Link;
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }
            if (url[0] == '~')
            {
                var mapped = VirtualPathUtility.ToAbsolute(url, _context.Request.ApplicationPath);
                return new AssetSource()
                           {
                               Url = mapped,
                               PhysicalPath = _context.Request.MapPath(mapped)
                           };
            }
            return new AssetSource()
            {
                Url = url,
                PhysicalPath = _context.Request.MapPath(url)
            };
        }
    }
}