using System.Collections.Generic;
using WebAssets;

namespace MvcAssets.AjaxMin
{
    public class AjaxMinCompressor : ICompressor
    {
        private readonly CompressorBase _cssCompressor;
        private readonly CompressorBase _jsCompressor;

        public AjaxMinCompressor()
        {
            _jsCompressor = new JsCompressor(this);
            _cssCompressor = new CssCompressor(this);
        }

        public string VirtualCachePath { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }

        #region ICompressor Members

        public IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources)
        {
            return _jsCompressor.Compress(sources);
        }

        public IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources)
        {
            return _cssCompressor.Compress(sources);
        }

        #endregion
    }
}