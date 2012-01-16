using MvcAssets.AjaxMin;
using WebAssets;

namespace MvcAssets.Combine
{
    public class CssCombiner : CompressorBase
    {
        private readonly Combiner _combiner;

        public CssCombiner(Combiner combiner)
        {
            _combiner = combiner;
        }

        protected override string CompressedExtension
        {
            get { return ".combined.css"; }
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