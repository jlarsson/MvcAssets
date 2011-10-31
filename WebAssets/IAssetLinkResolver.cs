namespace WebAssets
{
    public interface IAssetLinkResolver
    {
        IAssetSource Resolve(ILinkAsset link);
    }
}