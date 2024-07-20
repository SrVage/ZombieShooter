using System;
using System.Collections.Generic;
using Code.Abstract.Interfaces;
using Leopotam.Ecs;
using Zenject;

namespace Code.Services.States
{
	internal sealed class StateMachine : IStateMachine
	{
		private readonly Dictionary<Type, IState> _states;
		private IState _currentState;

		[Inject]
		public StateMachine(ILoadLevel loadLevel, ICreatePlayer createPlayer, EcsWorld world)
		{
			_states = new Dictionary<Type, IState>();
			_states.Add(typeof(LoadState), new LoadState(this, loadLevel, createPlayer, world));
			
			EnterState<LoadState>();
		}

		public void EnterState<TState>() where TState : class, IState
		{
			ChangeState<TState>().Enter();
		}
		
		private TState ChangeState<TState>() where TState : class, IState
		{
			_currentState?.Exit();
			TState state = GetState<TState>();
			_currentState = state;
			return state;
		}
		
		private TState GetState<TState>() where TState : class, IState => 
			_states[typeof(TState)] as TState;
	}
}