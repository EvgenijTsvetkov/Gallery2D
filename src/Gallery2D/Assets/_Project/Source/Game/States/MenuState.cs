using Gallery.Source.Data.Constant;
using Gallery.Source.ScenesManagement;
using Gallery.Source.StateMachine;
using Gallery.Source.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Screen = UnityEngine.Device.Screen;

namespace Gallery.Source.Game
{
    public class MenuState : GameState, IState
    {
        public MenuState(IGameProvider gameProvider, ISceneLoader sceneLoader, IUIProvider uiProvider) 
            : base(gameProvider, sceneLoader, uiProvider)
        {
        }
        
        public async void Enter()
        {
            SetOrientation();

            await LoadScene(AddressableNames.LoadingScreen);
            await LoadScene(AddressableNames.Menu, LoadSceneMode.Additive);
            
            UnloadScene(AddressableNames.LoadingScreen);
        }

        private void SetOrientation()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
