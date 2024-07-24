using Code.Abstract.Interfaces;
using Code.Components.Health;
using Code.Components.Shooting;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Shooting
{
	internal sealed class ShootHandleSystem : IEcsRunSystem
	{
		private readonly EcsFilter<ShootSignal> _shootSignal;
		
		public void Run()
		{
			foreach (var sdx in _shootSignal)
			{
				ref var entity = ref _shootSignal.Get1(sdx).Value;
				ref var collider = ref _shootSignal.Get1(sdx).Collider;
				if (collider as BoxCollider)
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
				else if (collider as SphereCollider)
				{
					entity.Get<DeathTag>();
					entity.Get<HeadshotTag>();
				}
			}
		}
	}
}