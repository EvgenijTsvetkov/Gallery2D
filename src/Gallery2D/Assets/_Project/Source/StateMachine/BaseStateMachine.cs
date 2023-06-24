using System;
using System.Collections.Generic;

namespace Gallery.Source.StateMachine
{
    public class BaseStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IBaseState> _states = new(3);
       
        public IBaseState CurrentBaseState { get; private set; }
        
        public void SwitchState<TState>() where TState : class, IState
        {
            CurrentBaseState?.Exit();
            
            TState newState = GetState<TState>();
            CurrentBaseState = newState;
            
            newState.Enter();
        }
        
        public void SwitchState<TState, T0>(T0 arg0) where TState : class, IStateWithOneParam<T0>
        {
            CurrentBaseState?.Exit();

            TState newState = GetState<TState>();
            CurrentBaseState = newState;

            newState.Enter(arg0);
        }

        protected void AddState(IBaseState baseState)
        {
            if (baseState == null)
                throw new ArgumentNullException($"Argument state doesn't exist");

            _states.Add(baseState.GetType(), baseState);
        }

        private TState GetState<TState>() where TState : class, IBaseState
        {
            if(_states.ContainsKey(typeof(TState)) == false)
                throw new InvalidOperationException($"Cannot find {typeof(TState)}. " +
                                                    "Add it when creating a state machine");
            
            return _states[typeof(TState)] as TState;
        }
    }
}