using System.Collections.Generic;
using Code.Abstract.Interfaces;
using Code.Components;
using Leopotam.Ecs;

namespace Code.Services
{
	internal sealed class EnemyPool : IPool
	{
		private readonly Queue<EcsEntity> _pool;

		public EnemyPool()
		{
			_pool = new Queue<EcsEntity>(50);
		}
		
		public EcsEntity? GetEntity()
		{
			if (!_pool.TryDequeue(out EcsEntity entity)) 
				return null;
			entity.Del<InPoolTag>();
			entity.Get<GameObjectComponent>().Value.SetActive(true);
			return entity;
		}

		public void ReturnToPool(EcsEntity entity)
		{
			entity.Get<InPoolTag>();
			entity.Get<GameObjectComponent>().Value.SetActive(false);
			_pool.Enqueue(entity);
		}
	}
}