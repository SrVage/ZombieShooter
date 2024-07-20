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
		private readonly EcsWorld _world;

		public LoadState(IStateMachine stateMachine, ILoadLevel loadLevel, ICreatePlayer createPlayer, EcsWorld world)
		{
			_stateMachine = stateMachine;
			_loadLevel = loadLevel;
			_createPlayer = createPlayer;
			_world = world;
		}
		
		public async void Enter()
		{
			Debug.Log("Enter to load state");
			await Task.Yield();
			_loadLevel.LoadLevel();
			_createPlayer.CreatePlayer();
			var entity = _world.NewEntity();
			entity.Get<InitialState>();
			entity.Get<EnterState>();
		}

		public void Exit()
		{
			
		}
	}
}