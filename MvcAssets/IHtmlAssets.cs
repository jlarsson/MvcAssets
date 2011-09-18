namespace MvcAssets
{
    public interface IHtmlAssets
    {
        IHtmlAssets JsLink(IJavascriptLink link);
        IHtmlAssets JsInline(IJavascriptInline inline);
        IHtmlAssets CssLink(ICssLink link);
        IHtmlAssets CssInline(ICssInline inline);
        IHtmlAssets JsDomReady(IJavascriptInline inline);
    }
}