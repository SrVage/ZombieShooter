using Code.Components;
using Code.Components.Enemy;
using Code.Components.Shooting;
using Code.Components.States;
using Leopotam.Ecs;

namespace Code.Systems.Enemy
{
	internal sealed class DeathHandleSystem : RunInStateSystem<PlayState>
	{
		private const float DestroyEnemyTimer = 5f;
		private readonly EcsFilter<NavMeshComponent, DeathTag> _death;
		
		protected override void Execute()		
		{
			foreach (var ddx in _death)
			{
				ref var navMesh = ref _death.Get1(ddx);
				navMesh.Value.enabled = false;
				var entity = _death.GetEntity(ddx);
				entity.Del<DeathTag>();
				entity.Del<HeadshotTag>();
				entity.Get<DeathTimer>().Timer = DestroyEnemyTimer;
			}
		}
	}
}