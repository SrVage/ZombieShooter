using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.EnemyNavigation
{
	internal sealed class CountNavigationTimerSystem : IEcsRunSystem
	{
		private const float NavigationDelay = 1f;
		private readonly EcsFilter<NavigationTimer> _timer;
		private readonly EcsWorld _world;
		
		public void Run()
		{
			if (_timer.IsEmpty()) 
				_world.NewEntity().Get<NavigationTimer>().Value = NavigationDelay;
			foreach (var tdx in _timer)
			{
				ref var timer = ref _timer.Get1(tdx).Value;
				timer -= Time.deltaTime;
				if (timer <= 0)
				{
					_timer.GetEntity(tdx).Destroy();
				}
			}
		}
	}
}