using System.Collections.Generic;

namespace MvcAssets
{
    public interface ICompressor
    {
        IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources);
        IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources);
    }
}