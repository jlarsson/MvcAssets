using System;
using System.IO;
using System.Web.Mvc;

namespace MvcAssets
{
    public class AssetViewResult : ActionResult
    {
        private readonly HtmlAssets _assets;
        private readonly ViewResult _inner;

        public AssetViewResult(ViewResult inner, HtmlAssets assets)
        {
            _inner = inner;
            _assets = assets;
        }

        public object Model
        {
            get { return _inner.Model; }
        }

        public TempDataDictionary TempData
        {
            get { return _inner.TempData; }
            set { _inner.TempData = value; }
        }

        public IView View
        {
            get { return _inner.View; }
            set { _inner.View = value; }
        }

        public dynamic ViewBag
        {
            get { return _inner.ViewBag; }
        }

        public ViewDataDictionary ViewData
        {
            get { return _inner.ViewData; }
            set { _inner.ViewData = value; }
        }

        public ViewEngineCollection ViewEngineCollection
        {
            get { return _inner.ViewEngineCollection; }
            set { _inner.ViewEngineCollection = value; }
        }

        public string ViewName
        {
            get { return _inner.ViewName; }
            set { _inner.ViewName = value; }
        }

        public string MasterName
        {
            get { return _inner.MasterName; }
            set { _inner.MasterName = value; }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var baseOutput = context.HttpContext.Response.Output;
            var output = new StringWriter();
            try
            {
                context.HttpContext.Response.Output = output;
                _inner.ExecuteResult(context);
                context.HttpContext.Response.Output = baseOutput;

                _assets.RewriteOutput(output.ToString(), baseOutput);
            }
            catch (Exception)
            {
                context.HttpContext.Response.Output = baseOutput;
                throw;
            }
        }
    }
}