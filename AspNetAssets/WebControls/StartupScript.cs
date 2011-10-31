using WebAssets;

namespace AspNetAssets.WebControls
{
    public class StartupScript: AssetBase
    {
        protected override void RegisterInline(IAspNetAssets assets, string inline)
        {
            assets.JsDomReady(new JavascriptInline() { Inline = inline, Section = Section, Priority = Priority });
        }

        protected override void RegisterLink(IAspNetAssets assets, string link)
        {
            //throw new System.NotImplementedException();
        }
    }
}