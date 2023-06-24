using Gallery.Source.StateMachine;

namespace Gallery.Source.Game
{
    public class GameStateMachine : BaseStateMachine, IGame
    {
        public GameStateMachine(IBaseState[] states)
        {
            foreach (var state in states) 
                AddState(state);
        }
    }
}