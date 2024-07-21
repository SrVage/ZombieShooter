using System;
using Code.Abstract.Interfaces;
using Code.Config;
using Leopotam.Ecs;
using Zenject;
using Object = UnityEngine.Object;

namespace Code.Services
{
	internal sealed class InitEnemiesService : IInitEnemies
	{
		private readonly IPool _enemyPool;
		private readonly EnemyConfig _config;
		private readonly EcsWorld _world;

		[Inject]
		public InitEnemiesService(IPool enemyPool, EnemyConfig config, EcsWorld world)
		{
			_enemyPool = enemyPool;
			_config = config;
			_world = world;
		}

		public void InitEnemies()
		{
			for (int i = 0; i < _config.MaxEnemyCount; i++)
			{
				var entity = Object.Instantiate(_config.EnemyPrefab).Init(_world);
				_enemyPool.ReturnToPool(entity);
			}
		}
	}
}