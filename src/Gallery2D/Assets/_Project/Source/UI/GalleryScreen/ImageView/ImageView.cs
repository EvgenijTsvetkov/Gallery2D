using System;
using Gallery.Source.Data.Constant;
using Gallery.Source.Game;
using Gallery.Source.NetworkManagement;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gallery.Source.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class ImageView : MonoBehaviour, IImageView
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _imageName;
        [SerializeField] private RectBoundsDetector _rectBoundsDetector;
        [SerializeField] private ClickHandler _clickHandler;
       
        private IImageDownloader _imageDownloader;
        private RectTransform _selfTransform;
        private IGameProvider _gameProvider;

        public string ImageName
        {
            get => _imageName.text;
            set => _imageName.text = value;
        }
        
        public RectTransform SelfTransform => _selfTransform;

        [Inject]
        public void Construct(IGameProvider gameProvider, IImageDownloader imageDownloader)
        {
            _gameProvider = gameProvider;
            _imageDownloader = imageDownloader;
        }

        private void Awake()
        {
            _selfTransform = GetComponent<RectTransform>();

            SubscribeOnEvents();
            DisableBehaviourFor(_rectBoundsDetector);
            DisableBehaviourFor(_clickHandler);
        }

        private void Start()
        {
            EnableBehaviourFor(_rectBoundsDetector);
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void ClickHandler()
        {
            _gameProvider.Value.SwitchState<ViewState, string>(ImageName);
        }

        private async void ScreenBoundsContainHandler()
        {
            _rectBoundsDetector.enabled = false;
            _rectBoundsDetector.OnScreenBoundsContainRect -= ScreenBoundsContainHandler;

            if (ImageName.IsEmpty())
                return;

            Texture2D texture2D = await _imageDownloader.Load(ImageName);
         
            if (_image == null)
                return;
            
            _image.sprite = CreateSprite(texture2D);
            
            EnableBehaviourFor(_clickHandler);
        }

        private Sprite CreateSprite(Texture2D texture)
        {
            int with = texture.width;
            int height = texture.height;
            
            return Sprite.Create(texture, new Rect(0, 0, with, height), new Vector2(with / 2f, height / 2f));
        }

        private void SubscribeOnEvents()
        {
            _clickHandler.OnClick += ClickHandler;
            _rectBoundsDetector.OnScreenBoundsContainRect += ScreenBoundsContainHandler;
        }
        
        private void UnsubscribeEvents()
        {
            _clickHandler.OnClick -= ClickHandler;
            _rectBoundsDetector.OnScreenBoundsContainRect -= ScreenBoundsContainHandler;
        }
        
        private void EnableBehaviourFor<T>(T behaviour) where T : MonoBehaviour
        {
            behaviour.enabled = true;
        }

        private void DisableBehaviourFor<T>(T behaviour) where T : MonoBehaviour
        {
            behaviour.enabled = false;
        }
    }
}
