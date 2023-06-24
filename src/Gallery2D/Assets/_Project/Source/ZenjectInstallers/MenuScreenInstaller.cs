using Gallery.Source.UI;
using UnityEngine;
using Zenject;

namespace Gallery.Source
{
    public class MenuScreenInstaller : MonoInstaller
    {
        [SerializeField] private MenuScreen _menuScreen;

        public override void InstallBindings()
        {
            Container.Inject(_menuScreen);
        }
    }
}