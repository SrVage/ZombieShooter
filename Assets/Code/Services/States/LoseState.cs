using System.Threading.Tasks;
using Code.Abstract.Interfaces;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Services.States
{
	public class LoseState : IState
	{
		private readonly IStateMachine _stateMachine;
		private readonly IDisplayLose _displayLose;
		private readonly EcsWorld _world;
		private EcsEntity _state;

		public LoseState(IStateMachine stateMachine, IDisplayLose displayLose, EcsWorld world)
		{
			_stateMachine = stateMachine;
			_displayLose = displayLose;
			_world = world;
			_displayLose.InitRestartAction(RestartAction);
		}

		private void RestartAction()
		{
			_stateMachine.EnterState<PlayState>();
		}

		public void Enter()
		{
			Debug.Log("Enter to lose state");
			_displayLose.ShowLose();
			_state = _world.NewEntity();
			_state.Get<Components.States.LoseState>();
			_state.Get<EnterState>();
		}

		public void Exit()
		{
			_displayLose.HideLose();
			if (!_state.IsNull() && _state.IsAlive()) 
			{
				_state.Destroy();
			}
		}
	}
}