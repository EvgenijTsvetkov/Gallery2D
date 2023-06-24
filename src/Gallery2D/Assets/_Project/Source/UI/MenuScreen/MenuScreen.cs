using Gallery.Source.Data.Constant;
using Gallery.Source.Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gallery.Source.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _galleryButton;
       
        private IGameProvider _gameProvider;

        [Inject]
        public void Construct(IGameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }
        
        private void Awake()
        {
            SubscribeOnEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void GalleryButtonClicked()
        {
            _gameProvider.Value.SwitchState<GalleryState>();
        }
        
        private void SubscribeOnEvents()
        {
            _galleryButton.onClick.AddListener(GalleryButtonClicked);
        }

        private void UnsubscribeEvents()
        {
            _galleryButton.onClick.RemoveListener(GalleryButtonClicked);
        }
    }
}