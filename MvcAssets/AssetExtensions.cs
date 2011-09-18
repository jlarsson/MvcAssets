namespace MvcAssets
{
    public static class AssetExtensions
    {
        public static int GetPriority(this IAsset asset, int @default)
        {
            return asset.Priority.HasValue ? asset.Priority.Value : @default;
        }

        public static AssetPlacement GetPlacement(this IAsset asset, AssetPlacement @default)
        {
            return asset.Placement.HasValue ? asset.Placement.Value : @default;
        }
    }
}