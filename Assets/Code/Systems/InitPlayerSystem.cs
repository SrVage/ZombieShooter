using Code.Components;
using Code.Components.States;
using Leopotam.Ecs;

namespace Code.Systems
{
	internal sealed class InitPlayerSystem : IEcsRunSystem
	{
		private readonly EcsFilter<InitialState, EnterState> _signal;
		private readonly EcsFilter<TransformComponent, PlayerTag, NeedInitialTag> _player;
		private readonly EcsFilter<TransformComponent, PlayerTag, SpawnPointTag> _spawnPoint;
		
		public void Run()
		{
			if (_signal.IsEmpty())
				return;

			foreach (var pdx in _player)
			{
				ref var transform = ref _player.Get1(pdx).Value;
				foreach (var sdx in _spawnPoint)
				{
					ref var spawnPoint = ref _spawnPoint.Get1(sdx).Value;
					transform.position = spawnPoint.position;
					break;
				}
				_player.GetEntity(pdx).Del<NeedInitialTag>();
			}
		}
	}
}