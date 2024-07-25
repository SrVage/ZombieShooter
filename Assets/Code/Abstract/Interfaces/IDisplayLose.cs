using System;

namespace Code.Abstract.Interfaces
{
	public interface IDisplayLose
	{
		event Action ShowLoseEvent;
		event Action HideLoseEvent;
		void ShowLose();
		void HideLose();
		void InitRestartAction(Action action);
		void Restart();
	}
}