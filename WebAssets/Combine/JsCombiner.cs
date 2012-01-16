using WebAssets.AjaxMin;

namespace WebAssets.Combine
{
    public class JsCombiner : CompressorBase
    {
        private readonly Combiner _combiner;

        public JsCombiner(Combiner combiner)
        {
            _combiner = combiner;
        }

        protected override string CompressedExtension
        {
            get { return ".combined.js"; }
        }

        protected override string VirtualCachePath
        {
            get { return _combiner.VirtualCachePath; }
        }

        protected override IAssetLinkResolver LinkResolver
        {
            get { return _combiner.LinkResolver; }
        }

        protected override string Compress(string source)
        {
            return source;
        }
    }
}