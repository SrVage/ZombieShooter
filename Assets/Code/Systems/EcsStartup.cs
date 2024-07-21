using Code.Components.States;
using Code.Systems.Animation;
using Code.Systems.Input;
using Code.Systems.Move;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Code.Systems {
    sealed class EcsStartup : MonoBehaviour {
        [Inject] EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add (new InitPlayerSystem())
                .Add (new InputSystem())
                .Add (new MoveSystem())
                .Add (new RotateSystem())
                .Add (new PlayerAnimationSystem())
                
                .OneFrame<EnterState> ()
                
                // .Inject (new NavMeshSupport ())
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