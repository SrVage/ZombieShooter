using Code.Components;
using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Animation
{
	internal sealed class AnimationEnemyAttackSystem : IEcsRunSystem
	{
		private readonly EcsFilter<AnimatorComponent, EnemyAttackSignal> _animator;
		private static readonly int _attack = Animator.StringToHash("Attack");
		
		public void Run()
		{
			foreach (var adx in _animator)
			{
				ref var animator = ref _animator.Get1(adx);
				animator.Value.SetTrigger(_attack);
			}
		}
	}
}