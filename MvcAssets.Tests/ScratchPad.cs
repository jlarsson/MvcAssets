using System;
using NUnit.Framework;

namespace MvcAssets.Tests
{
    [TestFixture]
    public class ScratchPad
    {
        [Test]
        public void Test()
        {
            var assets = new Assets
                             {
                                 LinkResolver = new AsIsAssetLinkResolver()
                             };

            assets
                .WithFooterPlacement()
                .CssLink("/styles/s1.css")
                .CssLink("/styles/s1.css")
                .CssInline("body {background: white}")
                .JsLink("/scripts/jquery.min.js")
                .JsLink("/scripts/jquery.min.js")
                .CssInline("body {background: white}")
                .JsInline("var X = {};")
                .JsDomReady("alert(1);")
                ;


            assets.RewriteOutput("<html><head><title>sample</title></head><body></body></html>", Console.Out);
        }
    }
}