namespace WebAssets
{
    public interface IAssetSource
    {
        string Url { get; }
        string PhysicalPath { get; }
    }
}