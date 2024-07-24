using Code.Abstract;
using Code.Components;
using Code.Components.Enemy;
using Code.Components.Shooting;
using Code.Components.States;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Shooting
{
	internal sealed class PlayerShootSystem : RunInStateSystem<PlayState>, IEcsInitSystem
	{
		private const float StartPointOffset = 3;
		private readonly PlayerConfig _playerConfig;
		private readonly EcsFilter<PlayerTag, AttackCooldown> _cooldown;
		private readonly EcsFilter<PlayerTag, RechargeTimer> _rechargeTimer;
		private readonly EcsFilter<PlayerTag> _player;
		private readonly EcsWorld _world;
		private Vector3 _screenCenter;
		private Camera _camera;

		public void Init()
		{
			_screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			_camera = Camera.main;
		}

		protected override void Execute()		
		{
			if (!_cooldown.IsEmpty() || !_rechargeTimer.IsEmpty())
				return;
			Ray ray = _camera.ScreenPointToRay(_screenCenter);
			ray.origin += ray.direction*StartPointOffset;
			if (Physics.Raycast(ray, out RaycastHit hit, _playerConfig.ShootingDistance))
			{
				GameObject hitObject = hit.collider.gameObject;
				if (hitObject.TryGetComponent(out EntityRef entityRef))
				{
					if (entityRef.Entity.Has<DeathTimer>())
					{
						return;
					}
					ref var shootSignal = ref _world.NewEntity().Get<ShootSignal>();
					shootSignal.Value = entityRef.Entity;
					shootSignal.Collider = hit.collider;
					foreach (var pdx in _player)
					{
						_player.GetEntity(pdx).Get<AttackCooldown>().Timer = _playerConfig.ShootingCooldown;
						break;
					}
				}
			}
		}
	}
}