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
            for (var i = 0; i < _enterEvents.EntitiesCount; i++) {
                var data = _world.GetComponent<EcsUiEnterEvent> (_enterEvents.Entities[i]);
                Debug.Log ("Cursor enter!", data.Sender);
            }
            for (var i = 0; i < _exitEvents.EntitiesCount; i++) {
                var data = _world.GetComponent<EcsUiExitEvent> (_exitEvents.Entities[i]);
                Debug.Log ("Cursor exit!", data.Sender);
            }
        }
    }
}