using System.Web.UI;
using WebAssets;

namespace AspNetAssets.WebControls
{
    public class StartupScriptAsset : AssetControlBase, INamingContainer
    {
        [TemplateContainer(typeof (StartupScriptAsset))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Script { get; set; }

        protected override ITemplate GetInlineTemplate()
        {
            return Script;
        }

        protected override void RegisterInline(IAspNetAssets assets, string inline)
        {
            assets.JsDomReady(new JavascriptInline {Inline = inline, Section = Section, Priority = Priority});
        }

        protected override void RegisterLink(IAspNetAssets assets, string link)
        {
            //throw new System.NotImplementedException();
        }
    }
}