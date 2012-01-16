using System.Collections.Generic;
using System.Linq;

namespace WebAssets.Combine
{
    public class Combiner: ICompressor
    {
        private readonly JsCombiner _jsCombiner;
        private readonly CssCombiner _cssCombiner;
        public string VirtualCachePath { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }

        public Combiner()
        {
            _jsCombiner = new JsCombiner(this);
            _cssCombiner = new CssCombiner(this);
        }

        public IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources)
        {
            var s = sources.ToArray();
            return s.Length == 1 ? s : _jsCombiner.Compress(s);
        }

        public IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources)
        {
            var s = sources.ToArray();
            return s.Length == 1 ? s : _cssCombiner.Compress(s);
        }
    }
}
