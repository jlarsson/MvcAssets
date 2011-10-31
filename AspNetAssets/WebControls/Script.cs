using WebAssets;

namespace AspNetAssets.WebControls
{
    public class Script : AssetBase
    {
        protected override void RegisterInline(IAspNetAssets assets, string inline)
        {
            assets.JsInline(new JavascriptInline() {Inline = inline, Section = Section, Priority = Priority});
        }

        protected override void RegisterLink(IAspNetAssets assets, string link)
        {
            assets.JsLink(new JavascriptLink() { Link = link, Section = Section, Priority = Priority });
        }
    }
}