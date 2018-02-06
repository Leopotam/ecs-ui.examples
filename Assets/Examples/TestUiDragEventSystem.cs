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

        public EcsRunSystemType GetRunSystemType () {
            return EcsRunSystemType.Update;
        }

        public void Run () {
            foreach (var entity in _beginDragEvents.Entities) {
                var data = _world.GetComponent<EcsUiBeginDragEvent> (entity);
                Debug.Log ("Drag started!", data.Sender);
            }
            foreach (var entity in _dragEvents.Entities) {
                var data = _world.GetComponent<EcsUiDragEvent> (entity);
                data.Sender.transform.localPosition += (Vector3) data.Delta;
            }
            foreach (var entity in _endDragEvents.Entities) {
                var data = _world.GetComponent<EcsUiEndDragEvent> (entity);
                Debug.Log ("Drag stopped!", data.Sender);
            }
        }
    }
}