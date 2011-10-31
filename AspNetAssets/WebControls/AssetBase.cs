using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetAssets.WebControls
{
    [PersistChildren(true)]
    [ParseChildren(false)]
    public abstract class AssetBase : WebControl
    {
        public string Section { get; set; }
        public int? Priority { get; set; }
        public string Src { get; set; }

        protected AssetBase()
        {
            Section = string.Empty;
            Src = string.Empty;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            IAspNetAssets assets = AspNetAssets.EnsureCurrentAssets();
            if (!string.IsNullOrEmpty(Src))
            {
                RegisterLink(assets, Src);
            }

            // Collect the inline content
            using (var textWriter = new StringWriter())
            {
                using (var htmlTextWriter = new HtmlTextWriter(textWriter))
                {
                    foreach (var control in Controls.OfType<Control>())
                    {
                        control.RenderControl(htmlTextWriter);
                    }
                }
                var inline = textWriter.ToString().Trim();
                if (!string.IsNullOrEmpty(inline))
                {
                    RegisterInline(assets, inline);
                }
            }
        }

        protected abstract void RegisterInline(IAspNetAssets assets, string inline);

        protected abstract void RegisterLink(IAspNetAssets assets, string link);

        protected override void Render(HtmlTextWriter writer)
        {
        }
    }
}
