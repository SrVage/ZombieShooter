using Code.Abstract.Interfaces;
using Zenject;
using LoseState = Code.Services.States.LoseState;

namespace Code.Services
{
	internal sealed class PlayerDeathService : IPlayerDeath
	{
		private readonly IStateMachine _stateMachine;

		[Inject]
		public PlayerDeathService(IStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}
		
		public void Death()
		{
			_stateMachine.EnterState<LoseState>();
		}
	}
}