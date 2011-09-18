namespace MvcAssets
{
    public abstract class HtmlAssetBase : IHtmlAsset
    {
        #region IHtmlAsset Members

        public int? Priority { get; set; }

        public HtmlAssetPlacement? Placement { get; set; }

        #endregion
    }
}