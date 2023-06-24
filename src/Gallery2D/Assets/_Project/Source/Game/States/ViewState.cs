using System.Threading.Tasks;
using Gallery.Source.Data.Constant;
using Gallery.Source.NetworkManagement;
using Gallery.Source.ScenesManagement;
using Gallery.Source.StateMachine;
using Gallery.Source.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Screen = UnityEngine.Device.Screen;

namespace Gallery.Source.Game
{
    public class ViewState : GameState, IStateWithOneParam<string>
    {
        private readonly IImageDownloader _imageDownloader;

        public ViewState(IGameProvider gameProvider, ISceneLoader sceneLoader, IUIProvider uiProvider, IImageDownloader imageDownloader)
            : base(gameProvider, sceneLoader, uiProvider)
        {
            _imageDownloader = imageDownloader;
        }
        
        public async void Enter(string imageName)
        {
            SetOrientation();
                
            await LoadScene(AddressableNames.LoadingScreen);
            await LoadScene(AddressableNames.View, LoadSceneMode.Additive);
            await LoadImage(imageName);
            
            UnloadScene(AddressableNames.LoadingScreen);
        }

        private async Task LoadImage(string imageName)
        {
            UIProvider.ViewScreen.Image.sprite = CreateSprite(await _imageDownloader.Load(imageName));
            UIProvider.ViewScreen.ImageName.text = imageName;
        }

        private void SetOrientation()
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
        
        private Sprite CreateSprite(Texture2D texture)
        {
            int with = texture.width;
            int height = texture.height;
            
            return Sprite.Create(texture, new Rect(0, 0, with, height), new Vector2(with / 2f, height / 2f));
        }
    }
}