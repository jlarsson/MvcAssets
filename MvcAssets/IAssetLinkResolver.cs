namespace MvcAssets
{
    public interface IAssetLinkResolver
    {
        IAssetSource Resolve(ILinkAsset link);
    }
}