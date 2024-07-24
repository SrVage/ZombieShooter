using Code.Components;
using Code.Components.States;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Spawn
{
	internal sealed class ChangeSpawnSpeedSystem : RunInStateSystem<PlayState>
	{
		private const float TimerMultiply = 0.98f;
		private readonly EcsFilter<SpawnSignal> _spawnSignal;
		private readonly EcsFilter<SpawnTimer> _spawnTimer;
		
		protected override void Execute()		
		{
			if (_spawnSignal.IsEmpty())
				return;
			
			foreach (var sdx in _spawnTimer)
			{
				ref var timer = ref _spawnTimer.Get1(sdx);
				if (Mathf.Approximately(timer.Value, timer.MaxTime))
				{
					timer.MaxTime *= TimerMultiply;
				}
			}
		}
	}
}