using System;

namespace MvcAssets
{
    public class HtmlAssetsWithFilter : IHtmlAssets
    {
        private readonly Action<IHtmlAsset> _filter;
        private readonly IHtmlAssets _inner;

        public HtmlAssetsWithFilter(IHtmlAssets inner, Action<IHtmlAsset> filter)
        {
            _inner = inner;
            _filter = filter;
        }

        #region IHtmlAssets Members

        public IHtmlAssets JsLink(IJavascriptLink link)
        {
            _filter(link);
            _inner.JsLink(link);
            return this;
        }

        public IHtmlAssets JsInline(IJavascriptInline inline)
        {
            _filter(inline);
            _inner.JsInline(inline);
            return this;
        }

        public IHtmlAssets CssLink(ICssLink link)
        {
            _filter(link);
            _inner.CssLink(link);
            return this;
        }

        public IHtmlAssets CssInline(ICssInline inline)
        {
            _filter(inline);
            _inner.CssInline(inline);
            return this;
        }

        public IHtmlAssets JsDomReady(IJavascriptInline inline)
        {
            _filter(inline);
            _inner.JsDomReady(inline);
            return this;
        }

        #endregion
    }
}