namespace MvcAssets
{
    public class CssInline : ICssInline
    {
        #region ICssInline Members

        public string Inline { get; set; }

        public int? Priority { get; set; }

        public AssetPlacement? Placement { get; set; }

        #endregion
    }
}