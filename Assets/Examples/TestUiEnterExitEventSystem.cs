using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    public class TestUiEnterExitEventSystem : IEcsRunSystem {
        [EcsWorld]
        EcsWorld _world;

        [EcsFilterInclude (typeof (EcsUiEnterEvent))]
        EcsFilter _enterEvents;

        [EcsFilterInclude (typeof (EcsUiExitEvent))]
        EcsFilter _exitEvents;

        public void Run () {
            foreach (var entity in _enterEvents.Entities) {
                var data = _world.GetComponent<EcsUiEnterEvent> (entity);
                Debug.Log ("Cursor enter!", data.Sender);
            }
            foreach (var entity in _exitEvents.Entities) {
                var data = _world.GetComponent<EcsUiExitEvent> (entity);
                Debug.Log ("Cursor exit!", data.Sender);
            }
        }
    }
}