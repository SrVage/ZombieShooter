using Code.Components;
using Code.Components.Enemy;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Animation
{
	internal sealed class AnimationEnemyAttackSystem : RunInStateSystem<PlayState>
	{
		private readonly EcsFilter<AnimatorComponent, EnemyAttackSignal> _animator;
		private static readonly int _attack = Animator.StringToHash("Attack");
		
		protected override void Execute()		
		{
			foreach (var adx in _animator)
			{
				ref var animator = ref _animator.Get1(adx);
				animator.Value.SetTrigger(_attack);
			}
		}
	}
}