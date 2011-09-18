namespace MvcAssets
{
    public class JavascriptInline : HtmlAssetBase, IJavascriptInline
    {
        #region IJavascriptInline Members

        public string Inline { get; set; }

        #endregion
    }
}