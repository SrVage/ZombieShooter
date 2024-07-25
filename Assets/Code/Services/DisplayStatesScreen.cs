using System;
using Code.Abstract.Interfaces;

namespace Code.Services
{
	internal sealed class DisplayStatesScreen : IDisplayHud, IDisplayLose
	{
		private Action _restartAction;
		public event Action ShowPlayEvent;
		public event Action HidePlayEvent;
		public event Action ShowLoseEvent;
		public event Action HideLoseEvent;

		public void InitRestartAction(Action action) => 
			_restartAction = action;

		public void Restart() => 
			_restartAction?.Invoke();

		public void ShowPlay() => 
			ShowPlayEvent?.Invoke();

		public void HidePlay() => 
			HidePlayEvent?.Invoke();

		public void ShowLose() => 
			ShowLoseEvent?.Invoke();

		public void HideLose() => 
			HideLoseEvent?.Invoke();
	}
}