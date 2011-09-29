using System.Web.Mvc;

namespace MvcAssets
{
    public interface IAssets
    {
        MvcHtmlString Render();
        IAssets JsLink(IJavascriptLink link);
        IAssets JsInline(IJavascriptInline inline);
        IAssets CssLink(ICssLink link);
        IAssets CssInline(ICssInline inline);
        IAssets JsDomReady(IJavascriptInline inline);
    }
}