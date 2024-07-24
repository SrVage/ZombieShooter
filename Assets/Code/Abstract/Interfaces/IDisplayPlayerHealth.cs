using System;

namespace Code.Abstract.Interfaces
{
	public interface IDisplayPlayerHealth
	{
		event Action<float> ChangePlayerHealth;
		void ChangeHealth(float health);
	}
}