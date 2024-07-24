using Code.Components;
using Code.Components.Enemy;
using Leopotam.Ecs;

namespace Code.Systems.EnemyNavigation
{
	internal sealed class SetEnemyDestinationSystem : IEcsRunSystem
	{
		private readonly EcsFilter<TransformComponent, PlayerTag> _playerTag;
		private readonly EcsFilter<NavMeshComponent>.Exclude<InPoolTag, DeathTimer> _enemy;
		private readonly EcsFilter<NavigationTimer> _timer;
		
		public void Run()
		{
			if (!_timer.IsEmpty())
				return;
			foreach (var pdx in _playerTag)
			{
				ref var playerTransform = ref _playerTag.Get1(pdx);
				foreach (var edx in _enemy)
				{
					ref var agent = ref _enemy.Get1(edx);
					agent.Value.SetDestination(playerTransform.Value.position);
				}
			}
		}
	}
}