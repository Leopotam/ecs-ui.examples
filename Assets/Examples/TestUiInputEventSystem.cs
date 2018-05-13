using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiInputEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiInputChangeEvent> _inputChangeEvents = null;

        EcsFilter<EcsUiInputEndEvent> _inputEndEvents = null;

        public void Run () {
            for (var i = 0; i < _inputChangeEvents.EntitiesCount; i++) {
                var data = _inputChangeEvents.Components1[i];
                Debug.LogFormat (data.Sender, "Input changed: {0}", data.Value);
            }
            for (var i = 0; i < _inputEndEvents.EntitiesCount; i++) {
                var data = _inputEndEvents.Components1[i];
                Debug.LogFormat (data.Sender, "Input end: {0}", data.Value);
            }
        }
    }
}