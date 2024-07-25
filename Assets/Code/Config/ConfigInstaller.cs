using UnityEngine;
using Zenject;

namespace Code.Config
{
	public class ConfigInstaller : MonoInstaller<ConfigInstaller>
	{
		[SerializeField] private LevelConfig _levelConfig;
		[SerializeField] private PlayerConfig _playerConfig;
		[SerializeField] private EnemyConfig _enemyConfig;
		[SerializeField] private SoundsConfig _soundsConfig;
		public override void InstallBindings()
		{
			Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
			Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
			Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();
			Container.Bind<SoundsConfig>().FromInstance(_soundsConfig).AsSingle();
		}
	}
}