using Gallery.Source;
using Gallery.Source.AssetManagement;
using Gallery.Source.Data;
using Gallery.Source.Game;
using Gallery.Source.InputManagement;
using Gallery.Source.NetworkManagement;
using Gallery.Source.ScenesManagement;
using Gallery.Source.UI;
using UnityEngine;
using Zenject;

namespace Eatable.Source
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MobileInput _mobileInput;
        
        public override void InstallBindings()
        {
            BindGame();
            BindMainCamera();
            BindConfigsProvider();
            BindUIProvider();
            BindUIFactory();
            BindAssetProvider();
            BindSceneLoader();
            BindNetworkServices();
            BindMobileInput();
        }
        
        private void BindGame()
        {
            Container.Bind<IGameProvider>().To<GameProvider>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            
            Container.Bind<IInitializable>().To<GameRunner>().AsSingle();
        }
        
        private void BindConfigsProvider()
        {
            Container.Bind<IConfigsProvider>().To<ConfigsProvider>().AsSingle();
        }

        private void BindUIProvider()
        {
            Container.Bind<IUIProvider>().To<UIProvider>().AsSingle();
        }
        
        private void BindUIFactory()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindMainCamera()
        {
            Container.Bind<IMainCameraProvider>().To<MainCameraProvider>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
        }

        private void BindSceneLoader() 
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindNetworkServices()
        {
            Container.Bind<IImageDownloader>().To<ImageDownloader>().AsSingle();
        }
        
        private void BindMobileInput()
        {
            Container.Bind<IMobileInput>().FromInstance(_mobileInput).AsSingle();
        }
    }
}