using System.Web.Mvc;

namespace MvcAssets
{
    public interface IMvcHtmlAssets : IHtmlAssets
    {
        ActionResult HookActionResult(ActionResult result);
    }
}