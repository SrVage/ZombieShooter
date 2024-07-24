using Leopotam.Ecs;
using UnityEngine;

namespace Code.Components.Enemy
{
	public struct EnemyAttackSignal : IEcsIgnoreInFilter
	{
		private readonly EcsFilter<AnimatorComponent, EnemyAttackSignal> _animator;
		private static readonly int _hit = Animator.StringToHash("Attack");
		
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