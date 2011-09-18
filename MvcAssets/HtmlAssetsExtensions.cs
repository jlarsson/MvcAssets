namespace MvcAssets
{
    public static class HtmlAssetsExtensions
    {
        public static IHtmlAssets WithPriority(this IHtmlAssets assets, int priority)
        {
            return new HtmlAssetsWithFilter(assets, asset =>
                                                        {
                                                            if (!asset.Priority.HasValue)
                                                            {
                                                                asset.Priority = priority;
                                                            }
                                                        });
        }

        public static IHtmlAssets WithHeaderPlacement(this IHtmlAssets assets)
        {
            return assets.WithPlacement(HtmlAssetPlacement.Header);
        }

        public static IHtmlAssets WithFooterPlacement(this IHtmlAssets assets)
        {
            return assets.WithPlacement(HtmlAssetPlacement.Footer);
        }

        public static IHtmlAssets WithPlacement(this IHtmlAssets assets, HtmlAssetPlacement placement)
        {
            return new HtmlAssetsWithFilter(assets, asset =>
                                                        {
                                                            if (!asset.Placement.HasValue)
                                                            {
                                                                asset.Placement = placement;
                                                            }
                                                        });
        }


        public static IHtmlAssets JsLink(this IHtmlAssets assets, string link)
        {
            return assets.JsLink(new JavascriptLink {Link = link});
        }

        public static IHtmlAssets CssLink(this IHtmlAssets assets, string link)
        {
            return assets.CssLink(new CssLink {Link = link});
        }

        public static IHtmlAssets JsInline(this IHtmlAssets assets, string inline)
        {
            return assets.JsInline(new JavascriptInline {Inline = inline});
        }

        public static IHtmlAssets CssInline(this IHtmlAssets assets, string inline)
        {
            return assets.CssInline(new CssInline {Inline = inline});
        }

        public static IHtmlAssets JsDomReady(this IHtmlAssets assets, string inlineJavascript)
        {
            return assets.JsDomReady(new JavascriptInline {Inline = inlineJavascript});
        }
    }
}