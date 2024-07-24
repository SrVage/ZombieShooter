using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Animation
{
	internal sealed class WalkAnimationSystem <T1, T2, T3> : RunInStateSystem<PlayState> where T1 : struct, IMovableComponent<T3> where T2 : struct where T3 : Component
	{
		private const float MinimalSpeed = 0.1f;
		private readonly EcsFilter<T1, AnimatorComponent, T2> _animator;
		private static readonly int _isMoving = Animator.StringToHash("IsMoving");
		
		protected override void Execute()		
		{
			foreach (var adx in _animator)
			{
				ref var movableComponent = ref _animator.Get1(adx);
				ref var animator = ref _animator.Get2(adx);
				animator.Value.SetBool(_isMoving, movableComponent.GetSpeed() > MinimalSpeed);
			}
		}
	}
}