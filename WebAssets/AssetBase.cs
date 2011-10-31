namespace WebAssets
{
    public abstract class AssetBase : IAsset
    {
        protected AssetBase()
        {
            Section = string.Empty;
        }

        #region IAsset Members

        public int? Priority { get; set; }

        public string Section { get; set; }

        #endregion
    }
}