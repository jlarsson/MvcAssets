using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WebAssets;

namespace MvcAssets
{
    public abstract class AssetsInjectorBase
    {
        public ICompressor Compressor { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }
        public IEnumerable<ICssInline> CssInlines { get; set; }
        public IEnumerable<ICssLink> CssLinks { get; set; }
        public IEnumerable<IJavascriptInline> JavascriptInlines { get; set; }
        public IEnumerable<IJavascriptLink> JavascriptLinks { get; set; }
        public IEnumerable<IJavascriptInline> DomReadyInlines { get; set; }

        #region IAssetsInjector Members

        public abstract string InjectAssets(string markup);

        #endregion

        protected string InjectAssets(string markup, Match match)
        {
            if (match == null)
            {
                return markup;
            }

            using (var writer = new StringWriter())
            {
                writer.Write(markup.Substring(0, match.Index));


                WriteLinks(writer, @"<link type=""text/css"" rel=""stylesheet"" href=""{0}"" />",
                           Compressor.CompressCss(GetSources(CssLinks)));
                WriteInlines(writer, "<style>", "</style>", CssInlines);
                WriteLinks(writer, @"<script type=""text/javascript"" src=""{0}""></script>",
                           Compressor.CompressJavascript(GetSources(JavascriptLinks)));
                WriteInlines(writer, @"<script type=""text/javascript"">", "</script>", JavascriptInlines);

                WriteInlines(
                    writer,
                    @"<script type=""text/javascript"">jQuery(document).ready(function () {",
                    "});</script>",
                    DomReadyInlines);

                writer.Write(markup.Substring(match.Index));
                return writer.ToString();
            }
        }

        private IEnumerable<IAssetSource> GetSources(IEnumerable<ILinkAsset> links)
        {
            return from inline in links
                   group inline by inline.GetPriority(0)
                   into g
                   orderby g.Key
                   from sortedInline in g
                   let source = LinkResolver.Resolve(sortedInline)
                   where source != null
                   select source;
        }

        private void WriteLinks(TextWriter writer, string format, IEnumerable<IAssetSource> sources)
        {
            foreach (var source in sources)
            {
                writer.WriteLine(format, source.Url);
            }
        }

        private void WriteInlines(TextWriter writer, string startTag, string endTag,
                                  IEnumerable<IInlineAsset> inlines)
        {
            var sorted = from inline in inlines
                         group inline by inline.GetPriority(0)
                         into g
                         orderby g.Key
                         from sortedInline in g
                         select sortedInline;


            var startIsWritten = false;
            foreach (var inline in sorted)
            {
                if (!startIsWritten)
                {
                    startIsWritten = true;
                    writer.WriteLine(startTag);
                }
                writer.WriteLine(inline.Inline);
            }
            if (startIsWritten)
            {
                writer.WriteLine(endTag);
            }
        }
    }
}