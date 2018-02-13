using LeopotamGroup.Ecs.Ui.Systems;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    public class Startup : MonoBehaviour {
        [SerializeField]
        EcsUiEmitter _uiEmitter;

        EcsWorld _world;

        EcsSystems _systems;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world)
                .Add (_uiEmitter)
                .Add (new TestUiClickEventSystem ())
                .Add (new TestUiDragEventSystem ())
                .Add (new TestUiEnterExitEventSystem ())
                .Add (new TestUiInputEventSystem ())
                .Add (new TestUiScrollViewEventSystem ())
                .Add (new EcsUiCleaner ());
            _systems.Initialize ();
        }

        void Update () {
            _systems.Run ();
        }

        void OnDisable () {
            _systems.Destroy ();
            _systems = null;
            _world = null;
        }
    }
}