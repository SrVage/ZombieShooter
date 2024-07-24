using Code.Components.States;
using Code.Systems.Input.Component;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Systems.Input
{
	internal sealed class InputSystem : RunInStateSystem<PlayState>, IEcsInitSystem
	{
		private InputAction _moveAction;
		private InputAction _rotateAction;
		private Vector2 _moveDirection;
		private Vector2 _rotateDirection;
		private readonly EcsWorld _world;
		private readonly EcsFilter<MoveInput, RotateInput> _input;

		public void Init()
		{
			_moveAction = new InputAction("move", binding: "<Gamepad>/leftStick");
			_moveAction.AddCompositeBinding("Dpad")
				.With("Up", binding: "<Keyboard>/w")
				.With("Down", binding: "<Keyboard>/s")
				.With("Left", binding: "<Keyboard>/a")
				.With("Right", binding: "<Keyboard>/d");
			_moveAction.performed += context => { _moveDirection = context.ReadValue<Vector2>(); };
			_moveAction.started += context => { _moveDirection = context.ReadValue<Vector2>(); };
			_moveAction.canceled += context => { _moveDirection = context.ReadValue<Vector2>(); };
			_moveAction.Enable();

			var inputEntity = _world.NewEntity();
				inputEntity.Get<MoveInput>();
			
			_rotateAction = new InputAction("rotate", binding: "<Gamepad>/rightStick");
			_rotateAction.performed += context => { _rotateDirection = context.ReadValue<Vector2>(); };
			_rotateAction.started += context => { _rotateDirection = context.ReadValue<Vector2>(); };
			_rotateAction.canceled += context => { _rotateDirection = context.ReadValue<Vector2>(); };
			_rotateAction.Enable();

			inputEntity.Get<RotateInput>();
		}

		protected override void Execute()		
		{
			foreach (var idx in _input)
			{
				ref var move = ref _input.Get1(idx);
				move.Value = _moveDirection;
				
				ref var rotate = ref _input.Get2(idx);
				rotate.Value = _rotateDirection;
			}
		}
	}
}