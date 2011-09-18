using System.Collections.Generic;

namespace MvcAssets
{
    public interface IAssetCollection<T> : IEnumerable<T> where T : IHtmlAsset
    {
        bool Add(T asset);
    }
}