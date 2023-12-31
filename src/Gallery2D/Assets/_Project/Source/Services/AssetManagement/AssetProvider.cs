using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Gallery.Source.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _assetHandles = new();

        public async Task<T> LoadAssetAsync<T>(string assetName) where T : class
        {
            if (_assetHandles.TryGetValue(assetName, out AsyncOperationHandle handle))
                return (T) handle.Result;

            _assetHandles[assetName] = Addressables.LoadAssetAsync<T>(assetName);

            await _assetHandles[assetName].Task;

            if (_assetHandles[assetName].Status == AsyncOperationStatus.Failed)
                throw new InvalidOperationException($"Failed to get asset for name {assetName}.");

            return (T) _assetHandles[assetName].Result;
        }

        public void ReleaseAsset(string assetName)
        {
            if (_assetHandles.TryGetValue(assetName, out AsyncOperationHandle handle) == false)
                return;

            _assetHandles.Remove(assetName);

            Addressables.Release(handle);
        }
    }
}
