using System.Collections.Generic;
using System.Linq;

namespace WebAssets.Combine
{
    public class Combiner : ICompressor
    {
        private readonly CssCombiner _cssCombiner;
        private readonly JsCombiner _jsCombiner;

        public Combiner()
        {
            _jsCombiner = new JsCombiner(this);
            _cssCombiner = new CssCombiner(this);
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
            if (CombineJs)
            {
                var s = sources.ToArray();
                return s.Length == 1 ? s : _jsCombiner.Compress(s);
            }
            return sources;
        }

        public IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources)
        {
            if (CombineCss)
            {
                var s = sources.ToArray();
                return s.Length == 1 ? s : _cssCombiner.Compress(s);
            }
            return sources;
        }

        #endregion
    }
}