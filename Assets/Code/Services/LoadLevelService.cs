using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Code.Services
{
	internal sealed class LoadLevelService : ILoadLevel
	{
		private readonly LevelConfig _levelConfig;
		private readonly EcsWorld _world;
		private GameObject _level;

		[Inject]
		public LoadLevelService(LevelConfig levelConfig, EcsWorld world)
		{
			_levelConfig = levelConfig;
			_world = world;
		}
		
		public void LoadLevel()
		{
			_level = Object.Instantiate(_levelConfig.Prefab);
			InitializeEcsObjects();
		}

		private void InitializeEcsObjects()
		{
			var installers = _level.GetComponentsInChildren<EntityInstaller>();
			Debug.Log(installers.Length);
			foreach (var installer in installers)
			{
				installer.Init(_world);
			}
		}
	}
}