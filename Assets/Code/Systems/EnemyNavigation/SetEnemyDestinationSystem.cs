using Code.Components;
using Code.Components.Enemy;
using Code.Components.States;
using Leopotam.Ecs;

namespace Code.Systems.EnemyNavigation
{
	internal sealed class SetEnemyDestinationSystem : RunInStateSystem<PlayState>
	{
		private readonly EcsFilter<TransformComponent, PlayerTag> _playerTag;
		private readonly EcsFilter<NavMeshComponent>.Exclude<InPoolTag, DeathTimer> _enemy;
		private readonly EcsFilter<NavigationTimer, FinishTimerTag> _timer;
		
		protected override void Execute()		
		{
			if (_timer.IsEmpty())
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