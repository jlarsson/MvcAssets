namespace MvcAssets
{
    public interface IAsset
    {
        int? Priority { get; set; }
        AssetPlacement? Placement { get; set; }
    }
}