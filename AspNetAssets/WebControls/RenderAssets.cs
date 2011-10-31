using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetAssets.WebControls
{
    public class RenderAssets : WebControl
    {
        public RenderAssets()
        {
            Section = string.Empty;
        }

        public string Section { get; set; }
        protected override void Render(HtmlTextWriter writer)
        {
            var assets = AspNetAssets.Current;
            if (assets != null)
            {
                assets.RenderSection(Section, writer);
            }
        }
    }
}