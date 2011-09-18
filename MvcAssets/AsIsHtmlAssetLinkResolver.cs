namespace MvcAssets
{
    public class AsIsHtmlAssetLinkResolver : IHtmlAssetLinkResolver
    {
        #region IHtmlAssetLinkResolver Members

        public string Resolve(IHtmlLinkAsset link)
        {
            return link.Link;
        }

        #endregion
    }
}