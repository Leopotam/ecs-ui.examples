using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiEnterExitEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiEnterEvent> _enterEvents = null;

        EcsFilter<EcsUiExitEvent> _exitEvents = null;

        public void Run () {
            for (var i = 0; i < _enterEvents.EntitiesCount; i++) {
                var data = _enterEvents.Components1[i];
                Debug.Log ("Cursor enter!", data.Sender);
            }
            for (var i = 0; i < _exitEvents.EntitiesCount; i++) {
                var data = _exitEvents.Components1[i];
                Debug.Log ("Cursor exit!", data.Sender);
            }
        }
    }
}