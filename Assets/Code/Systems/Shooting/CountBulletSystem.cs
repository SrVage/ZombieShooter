using Code.Abstract.Interfaces;
using Code.Components.Shooting;
using Code.Components.States;
using Code.Config;
using Leopotam.Ecs;

namespace Code.Systems.Shooting
{
	internal sealed class CountBulletSystem : RunInStateSystem<PlayState>
	{
		private readonly IDisplayPlayerAmmo _displayPlayerAmmo;
		private readonly PlayerConfig _playerConfig;
		private readonly EcsFilter<ShootSignal> _signal;
		private readonly EcsFilter<BulletCount> _player;

		protected override void Execute()		
		{
			if (_signal.IsEmpty())
				return;
			foreach (var pdx in _player)
			{
				ref var bulletCount = ref _player.Get1(pdx).Value;
				bulletCount--;
				_displayPlayerAmmo.ChangeAmmo(bulletCount);
				if (bulletCount <= 0)
				{
					bulletCount = _player.Get1(pdx).MaxBulletCount;
					_player.GetEntity(pdx).Get<RechargeTimer>().Timer = _playerConfig.RechargeTime;
				}
			}
		}
	}
}