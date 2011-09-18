using System.Collections.Generic;

namespace MvcAssets
{
    public class NullCompressor : ICompressor
    {
        public IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources)
        {
            return sources;
        }

        public IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources)
        {
            return sources;
        }
    }
}