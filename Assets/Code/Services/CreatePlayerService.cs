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

		[Inject]
		public CreatePlayerService(PlayerConfig playerConfig, EcsWorld world)
		{
			_playerConfig = playerConfig;
			_world = world;
		}
		
		public void CreatePlayer()
		{
			var player = Object.Instantiate(_playerConfig.PlayerPrefab);
			player.Init(_world);
		}
	}
}