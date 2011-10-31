using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebAssets;

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

        public ICompressor Compressor { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }

        public Assets()
        {
            Compressor = new NullCompressor();
        }

        #region IMvcAssets Members

        public MvcHtmlString Render()
        {
            return AssetsMarkupHook.GetMarkupForSection(string.Empty);
        }

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
            var startIndex = 0;
            var renderedSections = new HashSet<string>();
            foreach (var section in AssetsMarkupHook.GetSections(content))
            {
                output.Write(content.Substring(startIndex, section.Position-startIndex));

                if (renderedSections.Add(section.Section))
                {
                    var writer = new AssetsWriter()
                                     {
                                         Compressor = Compressor,
                                         LinkResolver = LinkResolver,
                                         CssInlines = _cssInlines.Where(a => section.Section.Equals(a.Section)),
                                         CssLinks = _cssLinks.Where(a => section.Section.Equals(a.Section)),
                                         JavascriptInlines =
                                             _javascriptInlines.Where(a => section.Section.Equals(a.Section)),
                                         JavascriptLinks =
                                             _javascriptLinks.Where(a => section.Section.Equals(a.Section)),
                                         DomReadyInlines =
                                             _domreadyInlines.Where(a => section.Section.Equals(a.Section))
                                     };
                    writer.Write(output);
                }


                startIndex = section.Position + section.Length;
            }
            if (startIndex < content.Length)
            {
                output.Write(content.Substring(startIndex));
            }
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