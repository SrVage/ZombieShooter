using Code.Components;
using Code.Systems.Input.Component;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Move
{
	internal sealed class MoveSystem : IEcsRunSystem
	{
		private const float DeadZone = 0.1f;
		private const float MoveSpeed = 3f;
		private readonly EcsFilter<RigidBodyComponent, PlayerTag> _player;
		private readonly EcsFilter<MoveInput> _moveInput;
		
		public void Run()
		{
			foreach (var mdx in _moveInput)
			{
				ref var input = ref _moveInput.Get1(mdx).Value;
				if (input.sqrMagnitude > DeadZone)
				{
					foreach (var pdx in _player)
					{
						ref var player = ref _player.Get1(pdx).Value;
						Vector3 move = player.transform.right * input.x + player.transform.forward * input.y;
						//player.MovePosition(player.transform.position + move * MoveSpeed * Time.deltaTime);
						player.velocity = move*MoveSpeed;
					}
				}
			}
		}
	}
}