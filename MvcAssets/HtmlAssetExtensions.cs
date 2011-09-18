namespace MvcAssets
{
    public static class HtmlAssetExtensions
    {
        public static int GetPriority(this IHtmlAsset asset, int @default)
        {
            return asset.Priority.HasValue ? asset.Priority.Value : @default;
        }

        public static HtmlAssetPlacement GetPlacement(this IHtmlAsset asset, HtmlAssetPlacement @default)
        {
            return asset.Placement.HasValue ? asset.Placement.Value : @default;
        }
    }
}