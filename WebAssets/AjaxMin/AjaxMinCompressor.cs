using System.Collections.Generic;

namespace WebAssets.AjaxMin
{
    public class AjaxMinCompressor : ICompressor
    {
        private readonly CompressorBase _cssCompressor;
        private readonly CompressorBase _jsCompressor;

        public AjaxMinCompressor()
        {
            _jsCompressor = new JsCompressor(this);
            _cssCompressor = new CssCompressor(this);
            CombineJs = true;
            CombineCss = false;
        }

        public string VirtualCachePath { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }
        public bool CombineJs { get; set; }
        public bool CombineCss { get; set; }

        #region ICompressor Members

        public IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources)
        {
            return CombineJs ? _jsCompressor.Compress(sources) : sources;
        }

        public IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources)
        {
            return CombineCss ? _cssCompressor.Compress(sources) : sources;
        }

        #endregion
    }
}