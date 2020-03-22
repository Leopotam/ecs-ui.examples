using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class TestUiDragEventSystem : IEcsRunSystem {
        readonly EcsFilter<EcsUiBeginDragEvent> _beginDragEvents = null;
        readonly EcsFilter<EcsUiDragEvent> _dragEvents = null;
        readonly EcsFilter<EcsUiEndDragEvent> _endDragEvents = null;

        public void Run () {
            foreach (var idx in _beginDragEvents) {
                ref var data = ref _beginDragEvents.Get1 (idx);
                Debug.Log ("Drag started!", data.Sender);
            }
            foreach (var idx in _dragEvents) {
                ref var data = ref _dragEvents.Get1 (idx);
                data.Sender.transform.localPosition += (Vector3) data.Delta;
            }
            foreach (var idx in _endDragEvents) {
                ref var data = ref _endDragEvents.Get1 (idx);
                Debug.Log ("Drag stopped!", data.Sender);
            }
        }
    }
}