using Gallery.Source.Data;
using Gallery.Source.Game;
using Gallery.Source.InputManagement;
using UnityEngine;
using Zenject;

namespace Gallery.Source.UI
{
    public class GalleryScreen : MonoBehaviour
    {
        [SerializeField] private RectTransform _containerForImages;
      
        private IConfigsProvider _configsProvider;
        private IUIFactory _uiFactory;
        private IGameProvider _gameProvider;
        private IMobileInput _mobileInput;

        [Inject]
        public void Construct(IGameProvider gameProvider, IConfigsProvider configsProvider, IUIFactory uiFactory,
            IMobileInput mobileInput)
        {
            _configsProvider = configsProvider;
            _uiFactory = uiFactory;
            _gameProvider = gameProvider;
            _mobileInput = mobileInput;
        }

        private void Awake()
        {
            CreatePreImagesViews();
            SubscribeOnEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private async void CreatePreImagesViews()
        {
            for (int i = 1; i < _configsProvider.GalleryConfig.ImagesCount + 1; i++)
            {
                IImageView imageView = await _uiFactory.CreateImageView(_containerForImages);
                imageView.ImageName = $"{i}";
            }
        }
        
        private void BackToMenu()
        {
            _gameProvider.Value.SwitchState<MenuState>();
        }
        
        private void SubscribeOnEvents()
        {
            _mobileInput.OnRightSwipe += BackToMenu;
            _mobileInput.OnBackButtonClicked += BackToMenu;
        }
        
        private void UnsubscribeEvents()
        {
            _mobileInput.OnRightSwipe -= BackToMenu;
            _mobileInput.OnBackButtonClicked -= BackToMenu;
        }
    }
}
