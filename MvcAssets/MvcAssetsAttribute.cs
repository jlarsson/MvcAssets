using System.Web.Mvc;

namespace MvcAssets
{
    public class MvcAssetsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var assets = filterContext.HttpContext.Assets();
            if (assets != null)
            {
                filterContext.Result = assets.HookActionResult(filterContext.Result);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}