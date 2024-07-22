using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Spawn
{
	internal sealed class CountSpawnTimerSystem : IEcsRunSystem
	{
		private readonly EcsFilter<SpawnTimer, TransformComponent> _spawnTimer;
		private readonly EcsWorld _world;
		
		public void Run()
		{
			foreach (var sdx in _spawnTimer)
			{
				ref var timer = ref _spawnTimer.Get1(sdx).Value;
				timer -= Time.deltaTime;
				if (timer <= 0)
				{
					timer = _spawnTimer.Get1(sdx).MaxTime;
					ref var spawnSignal = ref _world.NewEntity().Get<SpawnSignal>();
					spawnSignal.Value = _spawnTimer.Get2(sdx).Value;
				}
			}
		}
	}
}