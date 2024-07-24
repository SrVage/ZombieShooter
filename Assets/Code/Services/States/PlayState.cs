using System.Threading.Tasks;
using Code.Abstract.Interfaces;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Services.States
{
	public class PlayState : IState
	{
		private readonly IStateMachine _stateMachine;
		private readonly EcsWorld _world;
		private EcsEntity _state;

		public PlayState(IStateMachine stateMachine, EcsWorld world)
		{
			_stateMachine = stateMachine;
			_world = world;
		}
		
		public void Enter()
		{
			Debug.Log("Enter to play state");
			_state = _world.NewEntity();
			_state.Get<Components.States.PlayState>();
			_state.Get<EnterState>();
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