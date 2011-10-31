using System.Web;
using WebAssets;

namespace AspNetAssets
{
    public class VirtualPathLinkResolver : IAssetLinkResolver
    {
        private readonly HttpContext _context;

        public VirtualPathLinkResolver(HttpContext context)
        {
            _context = context;
        }

        #region IAssetLinkResolver Members

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
                return new AssetSource
                           {
                               Url = mapped,
                               PhysicalPath = _context.Request.MapPath(RemoveQueryString(mapped))
                           };
            }
            if (url.Contains("://"))
            {
                return new AssetSource
                           {
                               Url = url,
                               PhysicalPath = string.Empty
                           };
            }
            return new AssetSource
                       {
                           Url = url,
                           PhysicalPath = _context.Request.MapPath(RemoveQueryString(url))
                       };
        }

        private string RemoveQueryString(string url)
        {
            var qs = url.IndexOf('?');
            return qs < 0 ? url : url.Substring(0, qs);
        }

        #endregion
    }
}