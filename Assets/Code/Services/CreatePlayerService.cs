using Cinemachine;
using Code.Abstract.Interfaces;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Code.Services
{
	internal sealed class CreatePlayerService : ICreatePlayer
	{
		private readonly PlayerConfig _playerConfig;
		private readonly EcsWorld _world;
		private readonly CinemachineVirtualCamera _virtualCamera;

		[Inject]
		public CreatePlayerService(PlayerConfig playerConfig, EcsWorld world, CinemachineVirtualCamera virtualCamera)
		{
			_playerConfig = playerConfig;
			_world = world;
			_virtualCamera = virtualCamera;
		}
		
		public void CreatePlayer()
		{
			var player = Object.Instantiate(_playerConfig.PlayerPrefab);
			player.Init(_world);
			_virtualCamera.Follow = player.transform;
		}
	}
}