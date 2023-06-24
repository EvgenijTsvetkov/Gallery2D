using Gallery.Source.UI;
using UnityEngine;
using Zenject;

namespace Gallery.Source
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private ViewScreen _viewScreen;

        public override void InstallBindings()
        {
            var uiProvider = Container.Resolve<IUIProvider>();
            uiProvider.ViewScreen = _viewScreen;
            
            Container.Inject(_viewScreen);
        }
    }
}
