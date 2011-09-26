namespace MvcAssets
{
    public class CssLink : ICssLink
    {
        #region ICssLink Members

        public string Link { get; set; }

        public int? Priority { get; set; }

        public AssetPlacement? Placement { get; set; }

        #endregion
    }
}