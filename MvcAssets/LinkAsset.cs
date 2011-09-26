namespace MvcAssets
{
    public class LinkAsset : ILinkAsset
    {
        #region ILinkAsset Members

        public string Link { get; set; }

        public int? Priority { get; set; }

        public AssetPlacement? Placement { get; set; }

        #endregion
    }
}