namespace Gallery.Source.StateMachine
{
    public interface IStateMachine
    {
        void SwitchState<TState>() where TState : class, IState;
        void SwitchState<TState, T0>(T0 arg0) where TState : class, IStateWithOneParam<T0>;
    }
}