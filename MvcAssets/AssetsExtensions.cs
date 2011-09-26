namespace MvcAssets
{
    public static class AssetsExtensions
    {
        public static IAssets WithPriority(this IAssets assets, int priority)
        {
            return new AssetsWithFilter(assets, asset =>
                                                    {
                                                        if (!asset.Priority.HasValue)
                                                        {
                                                            asset.Priority = priority;
                                                        }
                                                    });
        }

        public static IAssets WithHeaderPlacement(this IAssets assets)
        {
            return assets.WithPlacement(AssetPlacement.Header);
        }

        public static IAssets WithFooterPlacement(this IAssets assets)
        {
            return assets.WithPlacement(AssetPlacement.Footer);
        }

        public static IAssets WithPlacement(this IAssets assets, AssetPlacement placement)
        {
            return new AssetsWithFilter(assets, asset =>
                                                    {
                                                        if (!asset.Placement.HasValue)
                                                        {
                                                            asset.Placement = placement;
                                                        }
                                                    });
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