using Code.Components;
using Code.Components.Shooting;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Animation
{
	internal sealed class EnemyHitSystem : IEcsRunSystem
	{
		private readonly EcsFilter<AnimatorComponent, WoundTag> _animator;
		private static readonly int _hit = Animator.StringToHash("Hit");
		
		public void Run()
		{
			foreach (var adx in _animator)
			{
				ref var animator = ref _animator.Get1(adx);
				animator.Value.SetTrigger(_hit);
			}
		}
	}
}