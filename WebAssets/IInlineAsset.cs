namespace WebAssets
{
    public interface IInlineAsset : IAsset
    {
        string Inline { get; }
    }
}