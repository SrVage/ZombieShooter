using Code.Abstract.Interfaces;
using Code.Components.Health;
using Code.Components.Shooting;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Shooting
{
	internal sealed class ShootHandleSystem : RunInStateSystem<PlayState>
	{
		private readonly EcsFilter<ShootSignal> _shootSignal;
		
		protected override void Execute()		
		{
			foreach (var sdx in _shootSignal)
			{
				ref var entity = ref _shootSignal.Get1(sdx).Value;
				ref var collider = ref _shootSignal.Get1(sdx).Collider;
				if (collider as BoxCollider)
				{
					AimWasBody(entity);
				}
				else if (collider as SphereCollider)
				{
					AimWasHead(entity);
				}
			}
		}

		private static void AimWasHead(EcsEntity entity)
		{
			entity.Get<DeathTag>();
			entity.Get<HeadshotTag>();
		}

		private static void AimWasBody(EcsEntity entity)
		{
			ref var hp = ref entity.Get<HealthPoint>().Value;
			hp-= 20;
			if (hp <= 0)
			{
				entity.Get<DeathTag>();
			}
			else
			{
				entity.Get<WoundTag>();
			}
		}
	}
}