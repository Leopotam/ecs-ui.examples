using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiDragEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiBeginDragEvent> _beginDragEvents = null;

        EcsFilter<EcsUiDragEvent> _dragEvents = null;

        EcsFilter<EcsUiEndDragEvent> _endDragEvents = null;

        public void Run () {
            for (var i = 0; i < _beginDragEvents.EntitiesCount; i++) {
                var data = _beginDragEvents.Components1[i];
                Debug.Log ("Drag started!", data.Sender);
            }
            for (var i = 0; i < _dragEvents.EntitiesCount; i++) {
                var data = _dragEvents.Components1[i];
                data.Sender.transform.localPosition += (Vector3) data.Delta;
            }
            for (var i = 0; i < _endDragEvents.EntitiesCount; i++) {
                var data = _endDragEvents.Components1[i];
                Debug.Log ("Drag stopped!", data.Sender);
            }
        }
    }
}