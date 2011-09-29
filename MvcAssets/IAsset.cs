namespace MvcAssets
{
    public interface IAsset
    {
        int? Priority { get; set; }
        string Section { get; set; }
    }
}