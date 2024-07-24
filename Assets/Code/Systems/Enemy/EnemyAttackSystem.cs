using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Enemy;
using Code.Components.Health;
using Code.Components.Shooting;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Enemy
{
	internal sealed class EnemyAttackSystem : IEcsRunSystem
	{
		private readonly IDisplayPlayerHealth _displayPlayerHealth;
		private readonly EcsFilter<TransformComponent, HealthPoint, PlayerTag> _player;
		private readonly EcsFilter<TransformComponent, EnemyTag>.Exclude<AttackCooldown, DeathTimer> _enemy;
		
		public void Run()
		{
			foreach (var pdx in _player)
			{
				var playerPoint = _player.Get1(pdx).Value.position;
				foreach (var edx in _enemy)
				{
					ref var transform = ref _enemy.Get1(edx);
					if (Vector3.SqrMagnitude(playerPoint - transform.Value.position) < 2)
					{
						ref var hp = ref _player.Get2(pdx).Value;
						hp -= 10;
						_displayPlayerHealth.ChangeHealth(hp);
						var enemyEntity = _enemy.GetEntity(edx);
						enemyEntity.Get<AttackCooldown>().Timer = 2f;
						enemyEntity.Get<EnemyAttackSignal>();
					}
				}
			}
		}
	}
}