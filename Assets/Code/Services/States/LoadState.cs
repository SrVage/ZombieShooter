using System.Threading.Tasks;
using Code.Abstract.Interfaces;
using UnityEngine;

namespace Code.Services.States
{
	public class LoadState : IState
	{
		private readonly IStateMachine _stateMachine;
		private readonly ILoadLevel _loadLevel;

		public LoadState(IStateMachine stateMachine, ILoadLevel loadLevel)
		{
			_stateMachine = stateMachine;
			_loadLevel = loadLevel;
		}
		
		public async void Enter()
		{
			Debug.Log("Enter to load state");
			await Task.Delay(1000);
			_loadLevel.LoadLevel();
		}

		public void Exit()
		{
			
		}
	}
}