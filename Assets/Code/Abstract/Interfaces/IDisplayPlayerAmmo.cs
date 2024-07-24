using System;

namespace Code.Abstract.Interfaces
{
	public interface IDisplayPlayerAmmo
	{
		event Action<string> ChangePlayerAmmo;
		void ChangeAmmo(int ammo);
		void ChangeAmmo(float time);
	}
}