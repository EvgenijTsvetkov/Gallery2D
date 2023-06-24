using Gallery.Source.UI;
using UnityEngine;
using Zenject;

namespace Eatable.Source
{
    public class LoadingScreenInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void InstallBindings()
        {
            BindLoadingScreen();
        }

        private void BindLoadingScreen()
        {
            var uiProvider = Container.Resolve<IUIProvider>();
            uiProvider.LoadScreen = _loadingScreen;
        }
    }
}
