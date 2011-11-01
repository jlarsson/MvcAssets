using System.Web.UI;
using WebAssets;

namespace AspNetAssets.WebControls
{
    public class ScriptAsset : AssetControlBase, INamingContainer
    {
        [TemplateContainer(typeof (ScriptAsset))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Script { get; set; }

        protected override ITemplate GetInlineTemplate()
        {
            return Script;
        }

        protected override void RegisterInline(IAspNetAssets assets, string inline)
        {
            assets.JsInline(new JavascriptInline {Inline = inline, Section = Section, Priority = Priority});
        }

        protected override void RegisterLink(IAspNetAssets assets, string link)
        {
            assets.JsLink(new JavascriptLink {Link = link, Section = Section, Priority = Priority});
        }
    }
}