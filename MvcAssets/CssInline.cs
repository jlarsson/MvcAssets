namespace MvcAssets
{
    public class CssInline : ICssInline
    {
        #region ICssInline Members

        public string Inline { get; set; }

        public int? Priority { get; set; }

        public HtmlAssetPlacement? Placement { get; set; }

        #endregion
    }
}