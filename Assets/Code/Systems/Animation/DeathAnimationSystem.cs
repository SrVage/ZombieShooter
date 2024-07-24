using Code.Components;
using Code.Components.Shooting;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Animation
{
	internal sealed class DeathAnimationSystem : IEcsRunSystem
	{
		private readonly EcsFilter<AnimatorComponent, DeathTag> _animator;
		private static readonly int _death = Animator.StringToHash("Death");
		private static readonly int _headshot = Animator.StringToHash("Headshot");
		
		public void Run()
		{
			foreach (var adx in _animator)
			{
				ref var animator = ref _animator.Get1(adx);
				animator.Value.SetTrigger(_animator.GetEntity(adx).Has<HeadshotTag>() ? _headshot : _death);
			}
		}
	}
}