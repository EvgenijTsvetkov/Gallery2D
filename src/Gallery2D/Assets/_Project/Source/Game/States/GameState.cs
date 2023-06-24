using System.Threading.Tasks;
using Gallery.Source.ScenesManagement;
using Gallery.Source.StateMachine;
using Gallery.Source.UI;
using UnityEngine.SceneManagement;

namespace Gallery.Source.Game
{
    public abstract class GameState : IBaseState
    {
        private readonly IGameProvider _gameProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIProvider _uiProvider;

        protected IGame Game => _gameProvider.Value;
        protected IUIProvider UIProvider => _uiProvider;

        protected GameState(IGameProvider gameProvider, ISceneLoader sceneLoader, IUIProvider uiProvider)
        {
            _gameProvider = gameProvider;
            _sceneLoader = sceneLoader;
            _uiProvider = uiProvider;
        }

        public virtual void Exit()
        {
        }
        
        protected async Task LoadScene(string sceneKey, LoadSceneMode sceneMode = LoadSceneMode.Single)
        {
            await _sceneLoader.Load(sceneKey, sceneMode);
            await WaitLoadingProgressBar();
            await Delay(.25f);
        }

        protected void UnloadScene(string sceneKey)
        {
            _sceneLoader.Unload(sceneKey);
        }

        private async Task WaitLoadingProgressBar()
        {
            if (_uiProvider.LoadScreen == null)
                return;

            while (_uiProvider.LoadScreen.Progress < 1)
            {
                await Task.Yield();
            }
        }

        private async Task Delay(float seconds)
        {
            await Task.Delay((int) (seconds * 1000));
        }
    }
}
