using Leopotam.Ecs.Ui.Systems;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class Startup : MonoBehaviour {
        [SerializeField]
        EcsUiEmitter _uiEmitter;

        EcsWorld _world;

        EcsSystems _systems;

        void Start () {
            _world = new EcsWorld ();
#if UNITY_EDITOR
            UnityIntegration.EcsWorldObserver.Create (_world);
#endif
            _systems = new EcsSystems (_world);
            _systems
#if !LEOECS_DISABLE_INJECT
                .Add (_uiEmitter)
                .Add (new TestUiClickEventSystem ())
                .Add (new TestUiDragEventSystem ())
                .Add (new TestUiEnterExitEventSystem ())
                .Add (new TestUiInputEventSystem ())
                .Add (new TestUiScrollViewEventSystem ())
#else
                .Add (_uiEmitter.SetWorld (_world))
                .Add (new TestUiClickEventSystem (_world))
                .Add (new TestUiDragEventSystem (_world))
                .Add (new TestUiEnterExitEventSystem (_world))
                .Add (new TestUiInputEventSystem (_world))
                .Add (new TestUiScrollViewEventSystem (_world))
#endif
                .Initialize ();
#if UNITY_EDITOR
            UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
        }

        void Update () {
            _systems.Run ();
            _world.RemoveOneFrameComponents ();
        }

        void OnDisable () {
            _systems.Dispose ();
            _systems = null;
            _world.Dispose ();
            _world = null;
        }
    }
}