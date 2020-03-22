using Leopotam.Ecs.Ui.Systems;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class Startup : MonoBehaviour {
        [SerializeField] EcsUiEmitter _uiEmitter = null;

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
                .Add (new TestUiClickEventSystem ())
                .Add (new TestUiDragEventSystem ())
                .Add (new TestUiEnterExitEventSystem ())
                .Add (new TestUiSliderChangeEventSystem ())
                .Add (new TestUiTmpInputEventSystem ())
                .Add (new TestUiScrollViewEventSystem ())
                .InjectUi (_uiEmitter)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDisable () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}