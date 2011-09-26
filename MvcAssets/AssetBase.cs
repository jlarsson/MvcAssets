namespace MvcAssets
{
    public abstract class AssetBase : IAsset
    {
        #region IAsset Members

        public int? Priority { get; set; }

        public AssetPlacement? Placement { get; set; }

        #endregion
    }
}