using Leopotam.Ecs.Ui.Systems;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class Startup : MonoBehaviour {
        [SerializeField]
        EcsUiEmitter _uiEmitter = null;

        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);

#if UNITY_EDITOR
            UnityIntegration.EcsWorldObserver.Create (_world);
            UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif

            _systems
                .Add (_uiEmitter)
                .Add (new TestUiClickEventSystem ())
                .Add (new TestUiDragEventSystem ())
                .Add (new TestUiEnterExitEventSystem ())
                .Add (new TestUiInputEventSystem ())
                .Add (new TestUiScrollViewEventSystem ())
                .Initialize ();
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