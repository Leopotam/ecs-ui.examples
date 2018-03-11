using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    public class TestUiDragEventSystem : IEcsRunSystem {
        [EcsWorld]
        EcsWorld _world;

        [EcsFilterInclude (typeof (EcsUiBeginDragEvent))]
        EcsFilter _beginDragEvents;

        [EcsFilterInclude (typeof (EcsUiDragEvent))]
        EcsFilter _dragEvents;

        [EcsFilterInclude (typeof (EcsUiEndDragEvent))]
        EcsFilter _endDragEvents;

        public void Run () {
            for (var i = 0; i < _beginDragEvents.EntitiesCount; i++) {
                var data = _world.GetComponent<EcsUiBeginDragEvent> (_beginDragEvents.Entities[i]);
                Debug.Log ("Drag started!", data.Sender);
            }
            for (var i = 0; i < _dragEvents.EntitiesCount; i++) {
                var data = _world.GetComponent<EcsUiDragEvent> (_dragEvents.Entities[i]);
                data.Sender.transform.localPosition += (Vector3) data.Delta;
            }
            for (var i = 0; i < _endDragEvents.EntitiesCount; i++) {
                var data = _world.GetComponent<EcsUiEndDragEvent> (_endDragEvents.Entities[i]);
                Debug.Log ("Drag stopped!", data.Sender);
            }
        }
    }
}