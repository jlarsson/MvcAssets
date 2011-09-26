using System.Collections.Generic;

namespace MvcAssets
{
    public class NullCompressor : ICompressor
    {
        #region ICompressor Members

        public IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources)
        {
            return sources;
        }

        public IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources)
        {
            return sources;
        }

        #endregion
    }
}