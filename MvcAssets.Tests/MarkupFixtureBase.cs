using System;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace MvcAssets.Tests
{
    public abstract class MarkupFixtureBase
    {
        [Test]
        public void RunTest()
        {
            var assets = new Assets
                             {
                                 LinkResolver = new AsIsAssetLinkResolver()
                             };

            DefineAssets(assets);
            var writer = new StringWriter();
            assets.RewriteOutput(GetInputMarkup(), writer);
            AssertAreEquivalentMarkup(GetExpectedMarkup(), writer.ToString());
        }

        protected string RemoveWhitespace(string text)
        {
            return new Regex("\\s").Replace(text, "");
        }

        protected abstract void DefineAssets(IAssets assets);

        protected abstract string GetExpectedMarkup();
        protected abstract string GetInputMarkup();

        private void AssertAreEquivalentMarkup(string expected, string actual)
        {
            try
            {
                Assert.That(
                    RemoveWhitespace(expected)
                    ,
                    Is.EqualTo(RemoveWhitespace(actual))
                    );
            }
            catch (Exception)
            {
                Console.Out.WriteLine("# Markup Fixture failed");
                Console.Out.WriteLine("# Expected");
                Console.Out.WriteLine(expected);
                Console.Out.WriteLine("# Actual");
                Console.Out.WriteLine(actual);

                throw;
            }
        }
    }
}