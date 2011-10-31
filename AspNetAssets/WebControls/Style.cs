using WebAssets;

namespace AspNetAssets.WebControls
{
    public class Style : AssetBase
    {
        protected override void RegisterInline(IAspNetAssets assets, string inline)
        {
            assets.CssInline(new CssInline() { Inline = inline, Section = Section, Priority = Priority });
        }

        protected override void RegisterLink(IAspNetAssets assets, string link)
        {
            assets.CssLink(new CssLink() { Link = link, Section = Section, Priority = Priority });
        }
    }
}