using System.Threading.Tasks;
using Gallery.Source.AssetManagement;
using UnityEngine;
using Zenject;

namespace Gallery.Source
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public CameraFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public async Task<Camera> Create(string cameraKey)
        {
            GameObject prefab = await _assetProvider.LoadAssetAsync<GameObject>(cameraKey);
            Camera instance = _instantiator.InstantiatePrefabForComponent<Camera>(prefab);
            
            return instance;
        }
    }
}