using System;
using System.Web.Mvc;

namespace MvcAssets
{
    public class AssetsWithFilter : IAssets
    {
        private readonly IAssets _inner;

        public AssetsWithFilter(IAssets inner)
        {
            _inner = inner;
            AssetHook = a => { };
            RenderHook = a => a.Render();
        }

        public Action<IAsset> AssetHook { get; set; }
        public Func<IAssets, MvcHtmlString> RenderHook { get; set; }

        #region IAssets Members

        public MvcHtmlString Render()
        {
            return RenderHook(_inner);
        }

        public IAssets JsLink(IJavascriptLink link)
        {
            AssetHook(link);
            _inner.JsLink(link);
            return this;
        }

        public IAssets JsInline(IJavascriptInline inline)
        {
            AssetHook(inline);
            _inner.JsInline(inline);
            return this;
        }

        public IAssets CssLink(ICssLink link)
        {
            AssetHook(link);
            _inner.CssLink(link);
            return this;
        }

        public IAssets CssInline(ICssInline inline)
        {
            AssetHook(inline);
            _inner.CssInline(inline);
            return this;
        }

        public IAssets JsDomReady(IJavascriptInline inline)
        {
            AssetHook(inline);
            _inner.JsDomReady(inline);
            return this;
        }

        #endregion
    }
}