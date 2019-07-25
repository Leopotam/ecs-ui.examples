using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiEnterExitEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiEnterEvent> _enterEvents = null;
        EcsFilter<EcsUiExitEvent> _exitEvents = null;

        public void Run () {
            foreach (var idx in _enterEvents) {
                var data = _enterEvents.Components1[idx];
                Debug.Log ("Cursor enter!", data.Sender);
            }
            foreach (var idx in _exitEvents) {
                var data = _exitEvents.Components1[idx];
                Debug.Log ("Cursor exit!", data.Sender);
            }
        }
    }
}