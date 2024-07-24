using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Shooting;
using Code.Config;
using Leopotam.Ecs;

namespace Code.Systems.Shooting
{
	internal sealed class RechargeBulletSystem : IEcsRunSystem
	{
		private readonly IDisplayPlayerAmmo _displayPlayerAmmo;
		private readonly PlayerConfig _playerConfig;
		private readonly EcsFilter<BulletCount, RechargeTimer>.Exclude<FinishTimerTag> _timer;
		private readonly EcsFilter<BulletCount, RechargeTimer, FinishTimerTag> _bullet;

		public void Run()
		{
			DisplayTimer();
			DisplayRechargeTime();
		}

		private void DisplayRechargeTime()
		{
			foreach (var bdx in _bullet)
			{
				_displayPlayerAmmo.ChangeAmmo(_timer.Get1(bdx).Value);
			}
		}

		private void DisplayTimer()
		{
			foreach (var tdx in _timer)
			{
				_displayPlayerAmmo.ChangeAmmo(_timer.Get2(tdx).Timer);
			}
		}
	}
}