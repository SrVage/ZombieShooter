using Code.Components;
using Code.Components.Shooting;
using Code.Components.States;
using Code.Config;
using Leopotam.Ecs;

namespace Code.Systems
{
	internal sealed class InitPlayerSystem : IEcsRunSystem
	{
		private readonly PlayerConfig _playerConfig;
		private readonly EcsFilter<InitialState, EnterState> _signal;
		private readonly EcsFilter<TransformComponent, PlayerTag, NeedInitialTag> _player;
		private readonly EcsFilter<TransformComponent, PlayerTag, SpawnPointTag> _spawnPoint;
		
		public void Run()
		{
			if (_signal.IsEmpty())
				return;

			foreach (var pdx in _player)
			{
				ref var transform = ref _player.Get1(pdx);
				foreach (var sdx in _spawnPoint)
				{
					ref var spawnPoint = ref _spawnPoint.Get1(sdx);
					transform.Value.position = spawnPoint.Value.position;
					break;
				}

				var playerEntity = _player.GetEntity(pdx);
				ref var bulletCount = ref playerEntity.Get<BulletCount>();
				bulletCount.MaxBulletCount = _playerConfig.MaxPlayerAmmo;
				bulletCount.Value = _playerConfig.MaxPlayerAmmo;
				playerEntity.Del<NeedInitialTag>();
			}
		}
	}
}