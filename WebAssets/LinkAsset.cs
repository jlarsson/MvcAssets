namespace WebAssets
{
    public class LinkAsset : AssetBase, ILinkAsset
    {
        #region ILinkAsset Members

        public string Link { get; set; }

        #endregion
    }
}