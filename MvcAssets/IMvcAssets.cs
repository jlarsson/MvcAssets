using System.Web.Mvc;

namespace MvcAssets
{
    public interface IMvcAssets : IAssets
    {
        ActionResult HookActionResult(ActionResult result);
    }
}