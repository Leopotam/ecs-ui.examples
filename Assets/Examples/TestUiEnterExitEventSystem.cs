using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class TestUiEnterExitEventSystem : IEcsRunSystem {
        readonly EcsFilter<EcsUiEnterEvent> _enterEvents = null;
        readonly EcsFilter<EcsUiExitEvent> _exitEvents = null;

        public void Run () {
            foreach (var idx in _enterEvents) {
                ref var data = ref _enterEvents.Get1 (idx);
                Debug.Log ("Cursor enter!", data.Sender);
            }
            foreach (var idx in _exitEvents) {
                ref var data = ref _exitEvents.Get1 (idx);
                Debug.Log ("Cursor exit!", data.Sender);
            }
        }
    }
}