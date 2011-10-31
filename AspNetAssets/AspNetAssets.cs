using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebAssets;

namespace AspNetAssets
{
    public class AspNetAssets : IAspNetAssets
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

        public AspNetAssets()
        {
            Compressor = new NullCompressor();
            LinkResolver = new VirtualPathLinkResolver(HttpContext.Current);
        }

        public ICompressor Compressor { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }

        public static IAspNetAssets Current
        {
            get { return HttpContext.Current.Items[typeof (IAspNetAssets)] as IAspNetAssets; }
            set { HttpContext.Current.Items[typeof (IAspNetAssets)] = value; }
        }

        #region IAspNetAssets Members

        public IAspNetAssets JsLink(IJavascriptLink link)
        {
            _javascriptLinks.Add(link);
            return this;
        }

        public IAspNetAssets JsInline(IJavascriptInline inline)
        {
            _javascriptInlines.Add(inline);
            return this;
        }

        public IAspNetAssets CssLink(ICssLink link)
        {
            _cssLinks.Add(link);
            return this;
        }

        public IAspNetAssets CssInline(ICssInline inline)
        {
            _cssInlines.Add(inline);
            return this;
        }

        public IAspNetAssets JsDomReady(IJavascriptInline inline)
        {
            _domreadyInlines.Add(inline);
            return this;
        }

        public void RenderSection(string section, TextWriter output)
        {
            var writer = new AssetsWriter
                             {
                                 Compressor = Compressor,
                                 LinkResolver = LinkResolver,
                                 CssInlines = _cssInlines.Where(a => Equals(section, a.Section)),
                                 CssLinks = _cssLinks.Where(a => Equals(section, a.Section)),
                                 JavascriptInlines =
                                     _javascriptInlines.Where(a => Equals(section, a.Section)),
                                 JavascriptLinks =
                                     _javascriptLinks.Where(a => Equals(section, a.Section)),
                                 DomReadyInlines =
                                     _domreadyInlines.Where(a => Equals(section, a.Section))
                             };
            writer.Write(output);
        }

        #endregion

        public static IAspNetAssets EnsureCurrentAssets()
        {
            var assets = Current;
            if (assets == null)
            {
                assets = new AspNetAssets();
                Current = assets;
            }
            return assets;
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