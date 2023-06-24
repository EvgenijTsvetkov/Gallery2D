using Gallery.Source.Game;
using Gallery.Source.InputManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gallery.Source.UI
{
    public class ViewScreen : MonoBehaviour, IViewScreen
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _imageName;
        [SerializeField] private Button _backButton;
    
        private IGameProvider _gameProvider;
        private IMobileInput _mobileInput;

        public Image Image => _image;
        public TMP_Text ImageName => _imageName;

        [Inject]
        public void Construct(IGameProvider gameProvider, IMobileInput mobileInput)
        {
            _gameProvider = gameProvider;
            _mobileInput = mobileInput;
        }
        
        private void Awake()
        {
            SubscribeOnEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void BackToGallery()
        {
            _gameProvider.Value.SwitchState<GalleryState>();
        }

        private void SubscribeOnEvents()
        {
            _backButton.onClick.AddListener(BackToGallery);
            
            _mobileInput.OnRightSwipe += BackToGallery;
            _mobileInput.OnBackButtonClicked += BackToGallery;
        }

        private void UnsubscribeEvents()
        {
            _backButton.onClick.RemoveListener(BackToGallery);
            
            _mobileInput.OnRightSwipe -= BackToGallery;
            _mobileInput.OnBackButtonClicked -= BackToGallery;
        }
    }
}