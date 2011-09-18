using NUnit.Framework;

namespace MvcAssets.Tests.Facts
{
    [TestFixture]
    public class HeaderAssetsAreInjectedLastInHeadSection : MarkupFixtureBase
    {
        protected override void DefineAssets(IHtmlAssets assets)
        {
            assets
                .CssLink("csslink.css")
                .JsLink("jslink.js")
                .CssInline("body {/**/}")
                .JsInline("var inlineJavacsript = {};")
                .JsDomReady("alert('dom ready');");
        }

        protected override string GetExpectedMarkup()
        {
            return
                @"
<html>
    <head>
        <title>test</test>
        head content

<link type=""text/css"" rel=""stylesheet"" href=""csslink.css"" />
<style>
    body {/**/}
</style>
<script type=""text/javascript"" src=""jslink.js""></script>
<script type=""text/javascript"">
    var inlineJavacsript = {};
</script>
<script type=""text/javascript"">
    jQuery(document).ready(function () { alert('dom ready'); });
</script>

    </head>
    <body>
        body content
    </body>
</html>
";
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
    }
}