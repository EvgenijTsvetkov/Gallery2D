using Gallery.Source.UI;
using UnityEngine;
using Zenject;

namespace Gallery.Source
{
    public class GalleryScreenInstaller : MonoInstaller
    {
        [SerializeField] private GalleryScreen _galleryScreen;

        public override void InstallBindings()
        {
            Container.Inject(_galleryScreen);
        }
    }
}