using Code.Components;
using Code.Components.States;
using Code.Systems.Input.Component;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Move
{
	internal sealed class MoveSystem : RunInStateSystem<PlayState>
	{
		private const float DeadZone = 0.1f;
		private const float MoveSpeed = 3f;
		private readonly EcsFilter<RigidBodyComponent, PlayerTag> _player;
		private readonly EcsFilter<MoveInput> _moveInput;
		
		protected override void Execute()		
		{
			foreach (var mdx in _moveInput)
			{
				ref var input = ref _moveInput.Get1(mdx).Value;
				if (input.sqrMagnitude > DeadZone)
				{
					foreach (var pdx in _player)
					{
						ref var player = ref _player.Get1(pdx);
						var playerTransform = player.Value.transform;
						Vector3 move = playerTransform.right * input.x + playerTransform.forward * input.y;
						player.Value.velocity = move*MoveSpeed;
					}
				}
			}
		}
	}
}