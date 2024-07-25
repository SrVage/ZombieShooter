using System;

namespace Code.Abstract.Interfaces
{
	public interface IDisplayHud
	{
		event Action ShowPlayEvent;
		event Action HidePlayEvent;
		void ShowPlay();
		void HidePlay();
	}
}