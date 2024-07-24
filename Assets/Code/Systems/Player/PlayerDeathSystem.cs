using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Enemy;
using Code.Components.Health;
using Code.Components.States;
using Leopotam.Ecs;

namespace Code.Systems.Player
{
	internal sealed class PlayerDeathSystem : RunInStateSystem<PlayState>
	{
		private readonly IPlayerDeath _playerDeath;
		private readonly EcsFilter<HealthPoint, PlayerTag> _player;
		private readonly EcsFilter<EnemyAttackSignal> _signal;
		protected override void Execute()
		{
			if (_signal.IsEmpty())
				return;
			foreach (var pdx in _player)
			{
				ref var hp = ref _player.Get1(pdx);
				if (hp.Value <= 0)
				{
					_playerDeath.Death();
				}
			}
		}
	}
}