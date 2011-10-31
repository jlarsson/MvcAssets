using WebAssets;

namespace MvcAssets
{
    public static class AssetsExtensions
    {
        public static IAssets Section(this IAssets assets, string section)
        {
            return new AssetsWithFilter(assets)
                       {
                           AssetHook = asset => { asset.Section = section; },
                           RenderHook = a => AssetsMarkupHook.GetMarkupForSection(section)
                       };
        }

        public static IAssets WithPriority(this IAssets assets, int priority)
        {
            return new AssetsWithFilter(assets)
                       {
                           AssetHook = asset =>
                                             {
                                                 if (!asset.Priority.HasValue)
                                                 {
                                                     asset.Priority = priority;
                                                 }
                                             }
                       };
        }

        public static IAssets JsLink(this IAssets assets, string link)
        {
            return assets.JsLink(new JavascriptLink {Link = link});
        }

        public static IAssets CssLink(this IAssets assets, string link)
        {
            return assets.CssLink(new CssLink {Link = link});
        }

        public static IAssets JsInline(this IAssets assets, string inline)
        {
            return assets.JsInline(new JavascriptInline {Inline = inline});
        }

        public static IAssets CssInline(this IAssets assets, string inline)
        {
            return assets.CssInline(new CssInline {Inline = inline});
        }

        public static IAssets JsDomReady(this IAssets assets, string inlineJavascript)
        {
            return assets.JsDomReady(new JavascriptInline {Inline = inlineJavascript});
        }
    }
}