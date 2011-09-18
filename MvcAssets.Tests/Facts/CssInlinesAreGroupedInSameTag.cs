using NUnit.Framework;

namespace MvcAssets.Tests.Facts
{
    [TestFixture]
    public class CssInlinesAreGroupedInSameTag: MarkupFixtureBase
    {
        protected override void DefineAssets(IHtmlAssets assets)
        {
            assets
                .CssInline("html {/**/}")
                .CssInline("body {/**/}")
                .CssInline("a {/**/}");
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

<style>
    html {/**/}
    body {/**/}
    a {/**/}
</style>

    </head>
    <body>
        body content
    </body>
</html>
";
        }
    }
}