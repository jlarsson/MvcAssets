using System.Collections.Generic;

namespace WebAssets
{
    public interface ICompressor
    {
        IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources);
        IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources);
    }
}