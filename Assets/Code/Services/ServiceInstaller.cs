using Code.Abstract.Interfaces;
using Code.Services.States;
using Leopotam.Ecs;
using Zenject;
using PlayState = Code.Components.States.PlayState;

namespace Code.Services
{
	public class ServiceInstaller : MonoInstaller<ServiceInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<EcsWorld>().FromInstance(new EcsWorld());
			Container.Bind<ILoadLevel>().To<LoadLevelService>().AsSingle();
			Container.Bind<ICreatePlayer>().To<CreatePlayerService>().AsSingle();
			Container.Bind<IInitEnemies>().To<InitEnemiesService>().AsSingle();
			Container.Bind<IPool>().To<EnemyPool>().AsSingle();
			Container.BindInterfacesTo<DisplayPlayerStatsService>().AsSingle();
			Container.BindInterfacesTo<DisplayStatesScreen>().AsSingle();
			Container.Bind<IStateMachine>().To<StateMachine>().AsSingle().NonLazy();
			Container.Bind<IPlayerDeath>().To<PlayerDeathService>().AsSingle();
		}
	}
}