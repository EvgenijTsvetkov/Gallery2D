using Gallery.Source.StateMachine;
using Zenject;

namespace Gallery.Source.Game
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;

        public GameFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public IGame Create()
        {
            return _instantiator.Instantiate<GameStateMachine>(new object[] {CreateStates()});
        }

        private IBaseState[] CreateStates()
        {
            return new IBaseState[]
            {
                _instantiator.Instantiate<BootState>(),
                _instantiator.Instantiate<MenuState>(),
                _instantiator.Instantiate<GalleryState>(),
                _instantiator.Instantiate<ViewState>(),
            };
        }
    }
}
