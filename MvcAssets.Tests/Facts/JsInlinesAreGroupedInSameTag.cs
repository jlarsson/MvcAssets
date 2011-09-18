using NUnit.Framework;

namespace MvcAssets.Tests.Facts
{
    [TestFixture]
    public class JsInlinesAreGroupedInSameTag : MarkupFixtureBase
    {
        protected override void DefineAssets(IAssets assets)
        {
            assets
                .JsInline("var x = 0;")
                .JsInline("alert(x);")
                .JsInline("x = 1;");
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

<script type=""text/javascript"">
    var x = 0;
    alert(x);
    x = 1;
</script>

    </head>
    <body>
        body content
    </body>
</html>
";
        }
    }
}