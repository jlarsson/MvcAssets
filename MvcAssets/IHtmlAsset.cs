namespace MvcAssets
{
    public interface IHtmlAsset
    {
        int? Priority { get; set; }
        HtmlAssetPlacement? Placement { get; set; }
    }
}