using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.States;
using Leopotam.Ecs;

namespace Code.Systems.Restart
{
	internal sealed class BackEnemyToPoolSystem : IEcsRunSystem
	{
		private readonly IPool _pool;
		private readonly EcsFilter<NavMeshComponent, EnemyTag>.Exclude<InPoolTag> _enemy;
		private readonly EcsFilter<LoseState, EnterState> _signal;
		
		public void Run()
		{
			if (_signal.IsEmpty())
				return;
			foreach (var edx in _enemy)
			{
				ref var navMesh = ref _enemy.Get1(edx);
				navMesh.Value.enabled = false;
				_pool.ReturnToPool(_enemy.GetEntity(edx));
			}
		}
	}
}