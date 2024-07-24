using Code.Abstract;
using Code.Components.Enemy;
using Code.Components.Shooting;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Shooting
{
	internal sealed class PlayerShootSystem : IEcsRunSystem, IEcsInitSystem
	{
		private readonly PlayerConfig _playerConfig;
		private readonly EcsFilter<ShootingCooldown> _cooldown;
		private readonly EcsWorld _world;
		private Vector3 _screenCenter;
		private Camera _camera;

		public void Init()
		{
			_screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			_camera = Camera.main;
		}

		public void Run()
		{
			if (!_cooldown.IsEmpty())
				return;
			Ray ray = _camera.ScreenPointToRay(_screenCenter);
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
					_world.NewEntity().Get<ShootingCooldown>().Timer = _playerConfig.ShootingCooldown;
				}
				
			}
		}
	}
}