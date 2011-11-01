using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetAssets.WebControls
{
    [PersistChildren(true)]
    [ParseChildren(true)]
    public abstract class AssetControlBase : WebControl
    {
        protected AssetControlBase()
        {
            Section = string.Empty;
            Src = string.Empty;
        }

        public string Section { get; set; }
        public int? Priority { get; set; }
        public string Src { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var assets = AspNetAssets.EnsureCurrentAssets();
            if (!string.IsNullOrEmpty(Src))
            {
                RegisterLink(assets, Src);
            }

            var inlineTemplate = GetInlineTemplate();
            if (inlineTemplate != null)
            {
                using (var textWriter = new StringWriter())
                {
                    using (var htmlTextWriter = new HtmlTextWriter(textWriter))
                    {
                        var control = new Control();
                        inlineTemplate.InstantiateIn(control);
                        control.RenderControl(htmlTextWriter);
                    }
                    var inline = textWriter.ToString();
                    if (!string.IsNullOrEmpty(inline.Trim()))
                    {
                        RegisterInline(assets, inline);
                    }
                }
            }
        }

        protected abstract ITemplate GetInlineTemplate();

        protected abstract void RegisterInline(IAspNetAssets assets, string inline);

        protected abstract void RegisterLink(IAspNetAssets assets, string link);

        protected override void Render(HtmlTextWriter writer)
        {
        }
    }
}