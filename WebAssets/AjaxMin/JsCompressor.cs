using Microsoft.Ajax.Utilities;

namespace WebAssets.AjaxMin
{
    public class JsCompressor : CompressorBase
    {
        private readonly AjaxMinCompressor _compressor;

        public JsCompressor(AjaxMinCompressor compressor)
        {
            _compressor = compressor;
        }

        protected override string CompressedExtension
        {
            get { return ".min.js"; }
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
            var minified = minifier.MinifyJavaScript(source);
            if (minifier.Errors.Count > 0)
            {
                return source;
            }
            return minified;
        }
    }
}