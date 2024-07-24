using Code.Abstract.Interfaces;
using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Enemy
{
	internal sealed class ReturnToPoolSystem : IEcsRunSystem
	{
		private readonly IPool _pool;
		private readonly EcsFilter<DeathTimer> _timer;
		
		public void Run()
		{
			foreach (var tdx in _timer)
			{
				ref var timer = ref _timer.Get1(tdx);
				timer.Timer -= Time.deltaTime;
				if (timer.Timer <= 0)
				{
					var entity = _timer.GetEntity(tdx);
					entity.Del<DeathTimer>();
					_pool.ReturnToPool(entity);
				}
			}
		}
	}
}