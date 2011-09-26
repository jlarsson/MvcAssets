namespace MvcAssets
{
    public class AssetSource : IAssetSource
    {
        #region IAssetSource Members

        public string Url { get; set; }

        public string PhysicalPath { get; set; }

        #endregion
    }
}