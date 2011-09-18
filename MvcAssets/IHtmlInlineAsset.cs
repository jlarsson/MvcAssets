namespace MvcAssets
{
    public interface IHtmlInlineAsset : IHtmlAsset
    {
        string Inline { get; }
    }
}