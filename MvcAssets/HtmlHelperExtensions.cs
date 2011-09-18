using System.Web.Mvc;

namespace MvcAssets
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlAssets Assets(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.HttpContext.Assets();
        }
    }
}