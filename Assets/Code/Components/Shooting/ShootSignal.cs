using Leopotam.Ecs;
using UnityEngine;

namespace Code.Components.Shooting
{
	public struct ShootSignal
	{
		public EcsEntity Value;
		public Collider Collider;
	}
}