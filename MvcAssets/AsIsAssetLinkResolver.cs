namespace MvcAssets
{
    public class AsIsAssetLinkResolver : IAssetLinkResolver
    {
        #region IAssetLinkResolver Members

        public IAssetSource Resolve(ILinkAsset link)
        {
            return new AssetSource
                       {
                           Url = link.Link
                       };
        }

        #endregion
    }
}