using System;
using Code.Abstract.Interfaces;
using Code.Config;
using Zenject;

namespace Code.Services
{
	internal sealed class DisplayPlayerStatsService : IDisplayPlayerHealth, IDisplayPlayerAmmo
	{
		private readonly float _maxPlayerHealth;
		private readonly int _maxPlayerAmmo;
		public event Action<float> ChangePlayerHealth;
		public event Action<string> ChangePlayerAmmo;


		[Inject]
		public DisplayPlayerStatsService(PlayerConfig playerConfig)
		{
			_maxPlayerHealth = playerConfig.MaxPlayerHealth;
			_maxPlayerAmmo = playerConfig.MaxPlayerAmmo;
		}

		public void ChangeHealth(float health)
		{
			var percent = health / _maxPlayerHealth;
			ChangePlayerHealth?.Invoke(percent);
		}

		public void ChangeAmmo(int ammo)
		{
			String ammoString = string.Format($"{ammo}/{_maxPlayerAmmo}");
			ChangePlayerAmmo?.Invoke(ammoString);
		}
	}
}