using System;

namespace MvcAssets
{
    public class AssetsWithFilter : IAssets
    {
        private readonly Action<IAsset> _filter;
        private readonly IAssets _inner;

        public AssetsWithFilter(IAssets inner, Action<IAsset> filter)
        {
            _inner = inner;
            _filter = filter;
        }

        #region IHtmlAssets Members

        public IAssets JsLink(IJavascriptLink link)
        {
            _filter(link);
            _inner.JsLink(link);
            return this;
        }

        public IAssets JsInline(IJavascriptInline inline)
        {
            _filter(inline);
            _inner.JsInline(inline);
            return this;
        }

        public IAssets CssLink(ICssLink link)
        {
            _filter(link);
            _inner.CssLink(link);
            return this;
        }

        public IAssets CssInline(ICssInline inline)
        {
            _filter(inline);
            _inner.CssInline(inline);
            return this;
        }

        public IAssets JsDomReady(IJavascriptInline inline)
        {
            _filter(inline);
            _inner.JsDomReady(inline);
            return this;
        }

        #endregion
    }
}