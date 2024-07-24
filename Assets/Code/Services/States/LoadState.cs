using System.Threading.Tasks;
using Code.Abstract.Interfaces;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Services.States
{
	public class LoadState : IState
	{
		private readonly IStateMachine _stateMachine;
		private readonly ILoadLevel _loadLevel;
		private readonly ICreatePlayer _createPlayer;
		private readonly IInitEnemies _initEnemies;
		private readonly EcsWorld _world;
		private EcsEntity _state;

		public LoadState(IStateMachine stateMachine, ILoadLevel loadLevel, ICreatePlayer createPlayer,
			IInitEnemies initEnemies, EcsWorld world)
		{
			_stateMachine = stateMachine;
			_loadLevel = loadLevel;
			_createPlayer = createPlayer;
			_initEnemies = initEnemies;
			_world = world;
		}
		
		public async void Enter()
		{
			Debug.Log("Enter to load state");
			await Task.Yield();
			_loadLevel.LoadLevel();
			_createPlayer.CreatePlayer();
			_initEnemies.InitEnemies();
			Debug.Log(_state);
			_state = _world.NewEntity();
			_state.Get<InitialState>();
			_state.Get<EnterState>();
			await Task.Yield();
			_stateMachine.EnterState<PlayState>();
		}

		public void Exit()
		{
			if (!_state.IsNull() && _state.IsAlive())
			{
				_state.Destroy();
			}
		}
	}
}