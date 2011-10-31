using System.Collections.Generic;

namespace WebAssets
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