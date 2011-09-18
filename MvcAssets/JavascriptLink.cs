namespace MvcAssets
{
    public class JavascriptLink : IJavascriptLink
    {
        #region IJavascriptLink Members

        public string Link { get; set; }

        public int? Priority { get; set; }

        public HtmlAssetPlacement? Placement { get; set; }

        #endregion
    }
}