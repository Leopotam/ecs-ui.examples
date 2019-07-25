using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiInputEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiInputChangeEvent> _inputChangeEvents = null;
        EcsFilter<EcsUiInputEndEvent> _inputEndEvents = null;

        public void Run () {
            foreach (var idx in _inputChangeEvents) {
                var data = _inputChangeEvents.Components1[idx];
                Debug.LogFormat (data.Sender, "Input changed: {0}", data.Value);
            }
            foreach (var idx in _inputEndEvents) {
                var data = _inputEndEvents.Components1[idx];
                Debug.LogFormat (data.Sender, "Input end: {0}", data.Value);
            }
        }
    }
}