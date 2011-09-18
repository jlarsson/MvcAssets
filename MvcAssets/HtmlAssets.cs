using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MvcAssets
{
    public class HtmlAssets : IMvcHtmlAssets
    {
        private readonly IAssetCollection<ICssInline> _cssInlines =
            new AssetCollection<ICssInline>(new InlineEqualityComparer<ICssInline>());

        private readonly IAssetCollection<ICssLink> _cssLinks =
            new AssetCollection<ICssLink>(new LinkEqualityComparer<ICssLink>());

        private readonly IAssetCollection<IJavascriptInline> _domreadyInlines =
            new AssetCollection<IJavascriptInline>(new InlineEqualityComparer<IJavascriptInline>());

        private readonly IAssetCollection<IJavascriptInline> _javascriptInlines =
            new AssetCollection<IJavascriptInline>(new InlineEqualityComparer<IJavascriptInline>());

        private readonly IAssetCollection<IJavascriptLink> _javascriptLinks =
            new AssetCollection<IJavascriptLink>(new LinkEqualityComparer<IJavascriptLink>());

        public HtmlAssetPlacement DefaultPlacement { get; set; }
        public int DefaultPriority { get; set; }
        public IHtmlAssetLinkResolver LinkResolver { get; set; }

        #region IMvcHtmlAssets Members

        public IHtmlAssets JsLink(IJavascriptLink link)
        {
            _javascriptLinks.Add(link);
            return this;
        }

        public IHtmlAssets JsInline(IJavascriptInline inline)
        {
            _javascriptInlines.Add(inline);
            return this;
        }

        public IHtmlAssets CssLink(ICssLink link)
        {
            _cssLinks.Add(link);
            return this;
        }

        public IHtmlAssets CssInline(ICssInline inline)
        {
            _cssInlines.Add(inline);
            return this;
        }

        public IHtmlAssets JsDomReady(IJavascriptInline inline)
        {
            _domreadyInlines.Add(inline);
            return this;
        }

        public ActionResult HookActionResult(ActionResult result)
        {
            if (result is ViewResult)
            {
                return new AssetViewResult(result as ViewResult, this);
            }
            return result;
        }

        #endregion

        public void RewriteOutput(string content, TextWriter output)
        {
            var byPlacement = new
                                  {
                                      LinkResolver,
                                      CssInlines = _cssInlines.ToLookup(a => a.GetPlacement(DefaultPlacement)),
                                      CssLinks = _cssLinks.ToLookup(a => a.GetPlacement(DefaultPlacement)),
                                      JavascriptInlines =
                                          _javascriptInlines.ToLookup(a => a.GetPlacement(DefaultPlacement)),
                                      JavscriptLinks = _javascriptLinks.ToLookup(a => a.GetPlacement(DefaultPlacement)),
                                      DomReadyInlines = _domreadyInlines.ToLookup(a => a.GetPlacement(DefaultPlacement))
                                  };

            var headInjector = new HeaderAssetsInjector
                                   {
                                       LinkResolver = LinkResolver,
                                       CssInlines = byPlacement.CssInlines[HtmlAssetPlacement.Header],
                                       CssLinks = byPlacement.CssLinks[HtmlAssetPlacement.Header],
                                       JavascriptInlines = byPlacement.JavascriptInlines[HtmlAssetPlacement.Header],
                                       JavascriptLinks = byPlacement.JavscriptLinks[HtmlAssetPlacement.Header],
                                       DomReadyInlines = byPlacement.DomReadyInlines[HtmlAssetPlacement.Header]
                                   };

            var footerInjector = new FooterAssetsInjector
                                     {
                                         LinkResolver = LinkResolver,
                                         CssInlines = byPlacement.CssInlines[HtmlAssetPlacement.Footer],
                                         CssLinks = byPlacement.CssLinks[HtmlAssetPlacement.Footer],
                                         JavascriptInlines = byPlacement.JavascriptInlines[HtmlAssetPlacement.Footer],
                                         JavascriptLinks = byPlacement.JavscriptLinks[HtmlAssetPlacement.Footer],
                                         DomReadyInlines = byPlacement.DomReadyInlines[HtmlAssetPlacement.Footer]
                                     };

            output.Write(headInjector.InjectAssets(footerInjector.InjectAssets(content)));
        }

        #region Nested type: InlineEqualityComparer

        private class InlineEqualityComparer<T> : IEqualityComparer<T> where T : IHtmlInlineAsset
        {
            #region IEqualityComparer<T> Members

            public bool Equals(T x, T y)
            {
                return Equals(x.Inline, y.Inline);
            }

            public int GetHashCode(T obj)
            {
                return obj.Inline.GetHashCode();
            }

            #endregion
        }

        #endregion

        #region Nested type: LinkEqualityComparer

        private class LinkEqualityComparer<T> : IEqualityComparer<T> where T : IHtmlLinkAsset
        {
            private static readonly IEqualityComparer<string> Comparer = StringComparer.OrdinalIgnoreCase;

            #region IEqualityComparer<T> Members

            public bool Equals(T x, T y)
            {
                return Comparer.Equals(x.Link, y.Link);
            }

            public int GetHashCode(T obj)
            {
                return Comparer.GetHashCode(obj.Link);
            }

            #endregion
        }

        #endregion

        public override string ToString()
        {
            // We return an empty string case someone refers to Html.Assets() in a write statement
            // Example (razor): @Html.Assets.JsInclude(...)
            return string.Empty;
        }
    }
}