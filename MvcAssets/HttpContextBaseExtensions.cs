using System.Web;

namespace MvcAssets
{
    public static class HttpContextBaseExtensions
    {
        private static readonly object Key = new {Key = "HttpContextBase.Assets"};

        public static IMvcAssets TryGetAssets(this HttpContextBase httpContext)
        {
            return httpContext.Items[Key] as IMvcAssets;
        }

        public static IMvcAssets Assets(this HttpContextBase httpContext)
        {
            var assets = httpContext.Items[Key] as IMvcAssets;
            if (assets == null)
            {
                assets = MvcAssets.Factory(httpContext);
                httpContext.Items[Key] = assets;
            }
            return assets;
        }
    }
}