namespace MvcAssets
{
    public interface IAssets
    {
        IAssets JsLink(IJavascriptLink link);
        IAssets JsInline(IJavascriptInline inline);
        IAssets CssLink(ICssLink link);
        IAssets CssInline(ICssInline inline);
        IAssets JsDomReady(IJavascriptInline inline);
    }
}