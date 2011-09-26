using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MvcAssets
{
    public class Assets : IMvcAssets
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

        public AssetPlacement DefaultPlacement { get; set; }
        public int DefaultPriority { get; set; }
        public ICompressor Compressor { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }

        #region IMvcAssets Members

        public IAssets JsLink(IJavascriptLink link)
        {
            _javascriptLinks.Add(link);
            return this;
        }

        public IAssets JsInline(IJavascriptInline inline)
        {
            _javascriptInlines.Add(inline);
            return this;
        }

        public IAssets CssLink(ICssLink link)
        {
            _cssLinks.Add(link);
            return this;
        }

        public IAssets CssInline(ICssInline inline)
        {
            _cssInlines.Add(inline);
            return this;
        }

        public IAssets JsDomReady(IJavascriptInline inline)
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
                                       Compressor = Compressor,
                                       LinkResolver = LinkResolver,
                                       CssInlines = byPlacement.CssInlines[AssetPlacement.Header],
                                       CssLinks = byPlacement.CssLinks[AssetPlacement.Header],
                                       JavascriptInlines = byPlacement.JavascriptInlines[AssetPlacement.Header],
                                       JavascriptLinks = byPlacement.JavscriptLinks[AssetPlacement.Header],
                                       DomReadyInlines = byPlacement.DomReadyInlines[AssetPlacement.Header]
                                   };

            var footerInjector = new FooterAssetsInjector
                                     {
                                         Compressor = Compressor,
                                         LinkResolver = LinkResolver,
                                         CssInlines = byPlacement.CssInlines[AssetPlacement.Footer],
                                         CssLinks = byPlacement.CssLinks[AssetPlacement.Footer],
                                         JavascriptInlines = byPlacement.JavascriptInlines[AssetPlacement.Footer],
                                         JavascriptLinks = byPlacement.JavscriptLinks[AssetPlacement.Footer],
                                         DomReadyInlines = byPlacement.DomReadyInlines[AssetPlacement.Footer]
                                     };

            output.Write(headInjector.InjectAssets(footerInjector.InjectAssets(content)));
        }

        public override string ToString()
        {
            // We return an empty string case someone refers to Html.Assets() in a write statement
            // Example (razor): @Html.Assets.JsInclude(...)
            return string.Empty;
        }

        #region Nested type: InlineEqualityComparer

        private class InlineEqualityComparer<T> : IEqualityComparer<T> where T : IInlineAsset
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

        private class LinkEqualityComparer<T> : IEqualityComparer<T> where T : ILinkAsset
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
    }
}