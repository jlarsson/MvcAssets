namespace MvcAssets
{
    public interface IHtmlAssetLinkResolver
    {
        string Resolve(IHtmlLinkAsset link);
    }
}