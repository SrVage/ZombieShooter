using Code.Components;
using Code.Systems.Input.Component;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Move
{
	internal sealed class RotateSystem : IEcsRunSystem
	{
		private const float DeadZone = 0.05f;
		private const float RotateXSpeed = 120f;
		private const float RotateYSpeed = 2f;
		private readonly EcsFilter<TransformComponent, PlayerTag> _player;
		private readonly EcsFilter<CinemachineComponent> _camera;
		private readonly EcsFilter<RotateInput> _moveInput;
		
		public void Run()
		{
			foreach (var mdx in _moveInput)
			{
				ref var input = ref _moveInput.Get1(mdx).Value;
				if (input.sqrMagnitude > DeadZone)
				{
					foreach (var pdx in _player)
					{
						ref var player = ref _player.Get1(pdx);
						player.Value.Rotate(Vector3.up, input.x*RotateXSpeed*Time.deltaTime);
					}

					foreach (var cdx in _camera)
					{
						ref var camera = ref _camera.Get1(cdx).Composer;
						camera.m_TrackedObjectOffset = new Vector3(camera.m_TrackedObjectOffset.x,
							Mathf.Clamp(camera.m_TrackedObjectOffset.y + input.y * RotateYSpeed * Time.deltaTime, 1f, 1.8f), camera.m_TrackedObjectOffset.z);
					}
				}
			}
		}
	}
}