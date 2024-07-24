using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Enemy;
using Code.Components.Shooting;
using Code.Components.States;
using Code.Config;
using Code.Systems.Animation;
using Code.Systems.Enemy;
using Code.Systems.EnemyNavigation;
using Code.Systems.Input;
using Code.Systems.Move;
using Code.Systems.Shooting;
using Code.Systems.Spawn;
using Code.Systems.Timers;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Code.Systems {
    sealed class EcsStartup : MonoBehaviour {
        [Inject] EcsWorld _world;
        [Inject] private IPool _pool;
        [Inject] private EnemyConfig _enemyConfig;
        [Inject] private PlayerConfig _playerConfig;
        EcsSystems _systems;

        void Start () {
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new InitPlayerSystem())
                
                .Add(new InputSystem())
                
                .Add(new MoveSystem())
                .Add(new RotateSystem())
                .Add(new WalkAnimationSystem<RigidBodyComponent, PlayerTag, Rigidbody>())
                .Add(new WalkAnimationSystem<NavMeshComponent, EnemyTag, NavMeshAgent>())
                
                .Add(new CountSpawnTimerSystem())
                .Add(new SpawnEnemySystem())
                .Add(new ChangeSpawnSpeedSystem())
                
                .Add(new CountTimerWithStartValueSystem<NavigationTimer>(1f))
                .Add(new SetEnemyDestinationSystem())
                
                .Add(new PlayerShootSystem())
                .Add(new ShootHandleSystem())
                
                .Add(new DeathAnimationSystem())
                .Add(new DeathHandleSystem())
                .Add(new ReturnToPoolSystem())
                
                .Add(new CountTimerSystem<ShootingCooldown>())
                
                .OneFrame<EnterState> ()
                .OneFrame<SpawnSignal>()
                .OneFrame<ShootSignal>()
                
                .Inject (_pool)
                .Inject(_enemyConfig)
                .Inject(_playerConfig)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}