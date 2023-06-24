using System.Threading.Tasks;
using Gallery.Source.Data;
using Gallery.Source.Extensions;
using UnityEngine;
using UnityEngine.Networking;

namespace Gallery.Source.NetworkManagement
{
    public class ImageDownloader : IImageDownloader
    {
        private readonly IConfigsProvider _configsProvider;

        public ImageDownloader(IConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
        }

        public async Task<Texture2D> Load(string imageName)
        {
            var fullPath = $"{_configsProvider.GalleryConfig.PathForDownload}{imageName}.jpg";
            using UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(fullPath);

            UnityWebRequest.Result result = await webRequest.SendWebRequest();

            if (result == UnityWebRequest.Result.Success == false)
            {
                Debug.LogError($"Failed to load texture path: {fullPath}");

                return Texture2D.whiteTexture;
            }

            var handler = webRequest.downloadHandler as DownloadHandlerTexture;

            return handler.texture;
        }
    }
}
