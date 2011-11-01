using System.Web.UI;
using WebAssets;

namespace AspNetAssets.WebControls
{
    public class StyleAsset : AssetControlBase, INamingContainer
    {
        [TemplateContainer(typeof (StyleAsset))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public new ITemplate Style { get; set; }

        protected override ITemplate GetInlineTemplate()
        {
            return Style;
        }

        protected override void RegisterInline(IAspNetAssets assets, string inline)
        {
            assets.CssInline(new CssInline {Inline = inline, Section = Section, Priority = Priority});
        }

        protected override void RegisterLink(IAspNetAssets assets, string link)
        {
            assets.CssLink(new CssLink {Link = link, Section = Section, Priority = Priority});
        }
    }
}