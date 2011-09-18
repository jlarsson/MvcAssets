namespace MvcAssets
{
    public class CssLink : ICssLink
    {
        public string Link { get; set; }

        public int? Priority { get; set; }

        public HtmlAssetPlacement? Placement { get; set; }
    }
}