using System.Web;

namespace MvcAssets
{
    public static class HttpContextBaseExtensions
    {
        private static readonly object Key = new {Key = "HttpContextBase.Assets"};

        public static IMvcHtmlAssets TryGetAssets(this HttpContextBase httpContext)
        {
            return httpContext.Items[Key] as IMvcHtmlAssets;
        }

        public static IMvcHtmlAssets Assets(this HttpContextBase httpContext)
        {
            var assets = httpContext.Items[Key] as IMvcHtmlAssets;
            if (assets == null)
            {
                assets = new HtmlAssets();
                httpContext.Items[Key] = assets;
            }
            return assets;
        }
    }
}