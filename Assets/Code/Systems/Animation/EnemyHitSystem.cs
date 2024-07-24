using Code.Components;
using Code.Components.Shooting;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Animation
{
	internal sealed class EnemyHitSystem : RunInStateSystem<PlayState>
	{
		private readonly EcsFilter<AnimatorComponent, WoundTag> _animator;
		private static readonly int _hit = Animator.StringToHash("Hit");
		
		protected override void Execute()		
		{
			foreach (var adx in _animator)
			{
				ref var animator = ref _animator.Get1(adx);
				animator.Value.SetTrigger(_hit);
			}
		}
	}
}