using System.Collections.Generic;

namespace WebAssets
{
    public interface IAssetCollection<T> : IEnumerable<T> where T : IAsset
    {
        bool Add(T asset);
    }
}