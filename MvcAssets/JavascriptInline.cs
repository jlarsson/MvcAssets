namespace MvcAssets
{
    public class JavascriptInline : AssetBase, IJavascriptInline
    {
        #region IJavascriptInline Members

        public string Inline { get; set; }

        #endregion
    }
}