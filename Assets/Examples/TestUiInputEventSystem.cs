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
            foreach (var entity in _inputChangeEvents.Entities) {
                var data = _world.GetComponent<EcsUiInputChangeEvent> (entity);
                Debug.LogFormat (data.Sender, "Input changed: {0}", data.Value);
            }
            foreach (var entity in _inputEndEvents.Entities) {
                var data = _world.GetComponent<EcsUiInputEndEvent> (entity);
                Debug.LogFormat (data.Sender, "Input end: {0}", data.Value);
            }
        }
    }
}