namespace WebAssets
{
    public class InlineAsset : AssetBase, IInlineAsset
    {
        #region IInlineAsset Members

        public string Inline { get; set; }

        #endregion
    }
}