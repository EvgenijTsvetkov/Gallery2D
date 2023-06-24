using System.Threading.Tasks;
using Gallery.Source.AssetManagement;
using Gallery.Source.Data;
using Gallery.Source.Data.Constant;
using Gallery.Source.ScenesManagement;
using Gallery.Source.StateMachine;
using Gallery.Source.UI;

namespace Gallery.Source.Game
{
    public class BootState : GameState, IState
    {
        private readonly IConfigsProvider _configsProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly IMainCameraProvider _mainCameraProvider;
        private readonly ICameraFactory _cameraFactory;

        protected BootState(IGameProvider gameProvider, ISceneLoader sceneLoader, IUIProvider uiProvider, 
            IConfigsProvider configsProvider, IAssetProvider assetProvider, IMainCameraProvider mainCameraProvider, 
            ICameraFactory cameraFactory) : base(gameProvider, sceneLoader, uiProvider)
        {
            _configsProvider = configsProvider;
            _assetProvider = assetProvider;
            _mainCameraProvider = mainCameraProvider;
            _cameraFactory = cameraFactory;
        }
        
        public async void Enter()
        {
            await LoadAssets();
            await CacheMainCamera();

            ToMenuState();
        }

        private async Task LoadAssets()
        {
            _configsProvider.GalleryConfig = await _assetProvider.LoadAssetAsync<IGalleryConfig>(AddressableNames.GalleryConfig);
        }

        private async Task CacheMainCamera()
        {
            _mainCameraProvider.Value = await _cameraFactory.Create(AddressableNames.Camera);
        }
        
        private void ToMenuState()
        {
            Game.SwitchState<MenuState>();
        } 
    }
}
