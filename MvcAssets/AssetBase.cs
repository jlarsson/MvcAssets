namespace MvcAssets
{
    public abstract class AssetBase : IAsset
    {
        #region IHtmlAsset Members

        public int? Priority { get; set; }

        public AssetPlacement? Placement { get; set; }

        #endregion
    }
}