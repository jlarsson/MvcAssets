using System.Collections.Generic;

namespace MvcAssets
{
    public interface IAssetCollection<T> : IEnumerable<T> where T : IAsset
    {
        bool Add(T asset);
    }
}