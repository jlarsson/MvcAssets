using Microsoft.Ajax.Utilities;

namespace MvcAssets.AjaxMin
{
    public class CssCompressor : CompressorBase
    {
        private readonly AjaxMinCompressor _compressor;

        public CssCompressor(AjaxMinCompressor compressor)
        {
            _compressor = compressor;
        }

        protected override string CompressedExtension
        {
            get { return ".min.css"; }
        }

        protected override string VirtualCachePath
        {
            get { return _compressor.VirtualCachePath; }
        }

        protected override IAssetLinkResolver LinkResolver
        {
            get { return _compressor.LinkResolver; }
        }

        protected override string Compress(string source)
        {
            var minifier = new Minifier();
            var minified = minifier.MinifyStyleSheet(source);
            if (minifier.Errors.Count > 0)
            {
                return source;
            }
            return minified;
        }
    }
}