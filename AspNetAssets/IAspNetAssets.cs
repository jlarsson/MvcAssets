using System.IO;
using WebAssets;

namespace AspNetAssets
{
    public interface IAspNetAssets
    {
        IAspNetAssets JsLink(IJavascriptLink link);
        IAspNetAssets JsInline(IJavascriptInline inline);
        IAspNetAssets CssLink(ICssLink link);
        IAspNetAssets CssInline(ICssInline inline);
        IAspNetAssets JsDomReady(IJavascriptInline inline);
        void RenderSection(string section, TextWriter output);
    }
}