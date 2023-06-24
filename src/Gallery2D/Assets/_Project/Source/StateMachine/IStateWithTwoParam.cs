namespace Gallery.Source.StateMachine
{
    public interface IStateWithTwoParam<T0, T1> : IBaseState
    {
        void Enter(T0 arg0, T1 arg1);
    }
}