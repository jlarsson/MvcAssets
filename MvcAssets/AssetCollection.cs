using System.Collections;
using System.Collections.Generic;

namespace MvcAssets
{
    public class AssetCollection<T> : IAssetCollection<T> where T : IAsset
    {
        private readonly HashSet<T> _addedAssets;
        private readonly List<T> _assets = new List<T>();

        public AssetCollection(IEqualityComparer<T> equalityComparer)
        {
            _addedAssets = new HashSet<T>(equalityComparer);
        }

        #region IAssetCollection<T> Members

        public bool Add(T asset)
        {
            if (_addedAssets.Add(asset))
            {
                _assets.Add(asset);
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _assets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}