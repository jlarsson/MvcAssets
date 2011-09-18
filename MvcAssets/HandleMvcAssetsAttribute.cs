using System.Web.Mvc;

namespace MvcAssets
{
    public class HandleMvcAssetsAttribute : ActionFilterAttribute
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

        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    var assets = filterContext.HttpContext.Assets();
        //    if (assets != null)
        //    {
        //        filterContext.Result = assets.HookActionResult(filterContext.Result);
        //    }
        //    base.OnResultExecuting(filterContext);
        //}
    }
}