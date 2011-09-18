using NUnit.Framework;

namespace MvcAssets.Tests.Facts
{
    [TestFixture]
    public class AssetsCanBePrioritized : MarkupFixtureBase
    {
        protected override void DefineAssets(IHtmlAssets assets)
        {
            assets
                .CssLink("csslink.css")
                .JsLink("jslink.js")
                .CssInline("body {/**/}")
                .JsInline("var inlineJavacsript = {};")
                .JsDomReady("alert('dom ready');")
                .WithPriority(-1000)
                .CssLink("csslink-hi-prio.css")
                .JsLink("jslink-hi-prio.js")
                .CssInline("body {/*hi prio*/}")
                .JsInline("var inlineJavacsriptHiPrio = {};")
                .JsDomReady("alert('dom ready hi prio');")
                .WithPriority(1000)
                .CssLink("csslink-lo-prio.css")
                .JsLink("jslink-lo-prio.js")
                .CssInline("body {/*lo prio*/}")
                .JsInline("var inlineJavacsriptLoPrio = {};")
                .JsDomReady("alert('dom ready lo prio');")
                ;
        }

        protected override string GetInputMarkup()
        {
            return
                @"
<html>
    <head>
        <title>test</test>
        head content
    </head>
    <body>
        body content
    </body>
</html>
";
        }

        protected override string GetExpectedMarkup()
        {
            return
                @"
<html>
    <head>
        <title>test</test>
        head content

<link type=""text/css"" rel=""stylesheet"" href=""csslink-hi-prio.css"" />
<link type=""text/css"" rel=""stylesheet"" href=""csslink.css"" />
<link type=""text/css"" rel=""stylesheet"" href=""csslink-lo-prio.css"" />

<style>
    body {/*hi prio*/}
    body {/**/}
    body {/*lo prio*/}
</style>

<script type=""text/javascript"" src=""jslink-hi-prio.js""></script>
<script type=""text/javascript"" src=""jslink.js""></script>
<script type=""text/javascript"" src=""jslink-lo-prio.js""></script>

<script type=""text/javascript"">
    var inlineJavacsriptHiPrio = {};
    var inlineJavacsript = {};
    var inlineJavacsriptLoPrio = {};
</script>

<script type=""text/javascript"">
jQuery(document).ready(function () { 
alert('dom ready hi prio'); 
alert('dom ready'); 
alert('dom ready lo prio'); 
});</script>

    </head>
    <body>
        body content
    </body>
</html>
";
        }
    }
}