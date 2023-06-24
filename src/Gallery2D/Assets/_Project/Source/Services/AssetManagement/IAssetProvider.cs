using System.Threading.Tasks;

namespace Gallery.Source.AssetManagement
{
    public interface IAssetProvider
    {
        Task<T> LoadAssetAsync<T>(string assetName) where T: class;
        void ReleaseAsset(string assetName);
    }
}