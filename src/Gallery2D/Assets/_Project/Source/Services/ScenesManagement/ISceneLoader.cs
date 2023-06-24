using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Gallery.Source.ScenesManagement
{
    public interface ISceneLoader
    {
        float Progress { get; }

        Task Load(string sceneKey, LoadSceneMode sceneMode);
        void Unload(string sceneKey);
    }
}