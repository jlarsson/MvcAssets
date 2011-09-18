namespace MvcAssets
{
    public class AssetSource : IAssetSource
    {
        #region ILinkAssetSource Members

        public string Url { get; set; }

        public string PhysicalPath { get; set; }

        #endregion
    }
}