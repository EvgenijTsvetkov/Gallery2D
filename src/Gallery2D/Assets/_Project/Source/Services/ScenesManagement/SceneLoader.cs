using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Gallery.Source.ScenesManagement
{
    public class SceneLoader : ISceneLoader
    {
        private readonly Dictionary<string, AsyncOperationHandle<SceneInstance>> _sceneHandles = new();
        public float Progress { get; private set; }

        public async Task Load(string sceneKey, LoadSceneMode sceneMode)
        {
            _sceneHandles[sceneKey] = Addressables.LoadSceneAsync(sceneKey, sceneMode);

            await _sceneHandles[sceneKey].Task;
            
            while (_sceneHandles[sceneKey].PercentComplete < 1 && _sceneHandles[sceneKey].IsDone == false)
            {
                Progress = _sceneHandles[sceneKey].PercentComplete;
                await Task.Yield();
            }
        }

        public void Unload(string sceneKey)
        {
            Addressables.UnloadSceneAsync(_sceneHandles[sceneKey]);
        }
    }
}
