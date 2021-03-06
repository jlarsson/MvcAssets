using WebAssets;

namespace MvcAssets
{
    public static class AssetExtensions
    {
        public static int GetPriority(this IAsset asset, int @default)
        {
            return asset.Priority.HasValue ? asset.Priority.Value : @default;
        }
    }
}