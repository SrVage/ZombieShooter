using UnityEngine;
using Zenject;

namespace Code.Config
{
	public class ConfigInstaller : MonoInstaller<ConfigInstaller>
	{
		[SerializeField] private LevelConfig _levelConfig;
		public override void InstallBindings()
		{
			Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
		}
	}
}