using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiDragEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiBeginDragEvent> _beginDragEvents = null;
        EcsFilter<EcsUiDragEvent> _dragEvents = null;
        EcsFilter<EcsUiEndDragEvent> _endDragEvents = null;

        public void Run () {
            foreach (var idx in _beginDragEvents) {
                var data = _beginDragEvents.Components1[idx];
                Debug.Log ("Drag started!", data.Sender);
            }
            foreach (var idx in _dragEvents) {
                var data = _dragEvents.Components1[idx];
                data.Sender.transform.localPosition += (Vector3) data.Delta;
            }
            foreach (var idx in _endDragEvents) {
                var data = _endDragEvents.Components1[idx];
                Debug.Log ("Drag stopped!", data.Sender);
            }
        }
    }
}