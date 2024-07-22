using Code.Abstract.Interfaces;
using Code.Components;
using Leopotam.Ecs;

namespace Code.Systems.Spawn
{
	internal sealed class SpawnEnemySystem : IEcsRunSystem
	{
		private readonly EcsFilter<SpawnSignal> _spawnSignal;
		private readonly IPool _pool;
		
		public void Run()
		{
			foreach (var sdx in _spawnSignal)
			{
				ref var spawnPoint = ref _spawnSignal.Get1(sdx).Value;
				var enemy = _pool.GetEntity().GetValueOrDefault();
				if (enemy != default)
				{
					ref var enemyTransform = ref enemy.Get<TransformComponent>().Value;
					enemyTransform.position = spawnPoint.position;
				}
			}
		}
	}
}