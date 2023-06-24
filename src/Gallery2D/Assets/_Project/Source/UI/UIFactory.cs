using System.Threading.Tasks;
using Gallery.Source.AssetManagement;
using Gallery.Source.Data.Constant;
using UnityEngine;
using Zenject;

namespace Gallery.Source.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        
        public async Task<IImageView> CreateImageView(RectTransform parent)
        {
            GameObject prefab = await _assetProvider.LoadAssetAsync<GameObject>(AddressableNames.ImageView);
            IImageView instance = _instantiator.InstantiatePrefabForComponent<IImageView>(prefab);
            instance.SelfTransform.SetParent(parent);
            instance.SelfTransform.localScale = Vector3.one;
            
            return instance;
        }
    }
}
