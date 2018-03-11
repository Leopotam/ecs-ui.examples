using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    public class TestUiInputEventSystem : IEcsRunSystem {
        [EcsWorld]
        EcsWorld _world;

        [EcsFilterInclude (typeof (EcsUiInputChangeEvent))]
        EcsFilter _inputChangeEvents;

        [EcsFilterInclude (typeof (EcsUiInputEndEvent))]
        EcsFilter _inputEndEvents;

        public void Run () {
            for (var i = 0; i < _inputChangeEvents.EntitiesCount; i++) {
                var data = _world.GetComponent<EcsUiInputChangeEvent> (_inputChangeEvents.Entities[i]);
                Debug.LogFormat (data.Sender, "Input changed: {0}", data.Value);
            }
            for (var i = 0; i < _inputEndEvents.EntitiesCount; i++) {
                var data = _world.GetComponent<EcsUiInputEndEvent> (_inputEndEvents.Entities[i]);
                Debug.LogFormat (data.Sender, "Input end: {0}", data.Value);
            }
        }
    }
}