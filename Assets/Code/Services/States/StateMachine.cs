using System;
using System.Collections.Generic;
using Code.Abstract.Interfaces;
using Code.Components.States;
using Leopotam.Ecs;
using Zenject;

namespace Code.Services.States
{
	internal sealed class StateMachine : IStateMachine
	{
		private readonly Dictionary<Type, IState> _states;
		private IState _currentState;

		[Inject]
		public StateMachine(ILoadLevel loadLevel, ICreatePlayer createPlayer, 
			IInitEnemies initEnemies, IDisplayHud displayHud,
			IDisplayLose displayLose, EcsWorld world)
		{
			_states = new Dictionary<Type, IState>();
			_states.Add(typeof(LoadState), new LoadState(this, loadLevel, createPlayer, initEnemies, world));
			_states.Add(typeof(PlayState), new PlayState(this, displayHud, world));
			_states.Add(typeof(LoseState), new LoseState(this, displayLose, world));
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