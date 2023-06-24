namespace Gallery.Source.StateMachine
{
    public interface IStateWithOneParam<T0> : IBaseState
    {
        void Enter(T0 arg0);
    }
}