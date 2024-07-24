using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Health;
using Code.Components.States;
using Code.Config;
using Leopotam.Ecs;

namespace Code.Systems.Spawn
{
	internal sealed class SpawnEnemySystem : RunInStateSystem<PlayState>
	{
		private readonly EcsFilter<SpawnSignal> _spawnSignal;
		private readonly EnemyConfig _enemyConfig;
		private readonly IPool _pool;
		
		protected override void Execute()		
		{
			foreach (var sdx in _spawnSignal)
			{
				ref var spawnPoint = ref _spawnSignal.Get1(sdx).Value;
				var enemy = _pool.GetEntity().GetValueOrDefault();
				if (enemy != default)
				{
					ref var enemyTransform = ref enemy.Get<TransformComponent>();
					enemyTransform.Value.position = spawnPoint.position;
					enemy.Get<NavMeshComponent>().Value.enabled = true;
					enemy.Get<HealthPoint>().Value = _enemyConfig.InitialHealth;
				}
			}
		}
	}
}