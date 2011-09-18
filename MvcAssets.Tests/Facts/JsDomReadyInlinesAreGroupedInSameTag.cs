using NUnit.Framework;

namespace MvcAssets.Tests.Facts
{
    [TestFixture]
    public class JsDomReadyInlinesAreGroupedInSameTag : MarkupFixtureBase
    {
        protected override void DefineAssets(IAssets assets)
        {
            assets
                .JsDomReady("var x = 0;")
                .JsDomReady("alert(x);")
                .JsDomReady("x = 1;");
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
    jQuery(document).ready(function () {
        var x = 0;
        alert(x);
        x = 1;
    });
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