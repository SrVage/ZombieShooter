using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Animation
{
	internal sealed class PlayerAnimationSystem : IEcsRunSystem
	{
		private const float MinimalSpeed = 0.1f;
		private readonly EcsFilter<RigidBodyComponent, AnimatorComponent> _animator;
		private static readonly int _isMoving = Animator.StringToHash("IsMoving");
		private static readonly int _death = Animator.StringToHash("Death");
		
		public void Run()
		{
			foreach (var adx in _animator)
			{
				ref var rigidbody = ref _animator.Get1(adx).Value;
				ref var animator = ref _animator.Get2(adx).Value;
				animator.SetBool(_isMoving, rigidbody.velocity.sqrMagnitude > MinimalSpeed);
			}
		}
	}
}