using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class TestUiTmpInputEventSystem : IEcsRunSystem {
        readonly EcsFilter<EcsUiTmpInputChangeEvent> _inputChangeEvents = null;
        readonly EcsFilter<EcsUiTmpInputEndEvent> _inputEndEvents = null;

        public void Run () {
            foreach (var idx in _inputChangeEvents) {
                ref var data = ref _inputChangeEvents.Get1 (idx);
                Debug.LogFormat (data.Sender, "TmpInput changed: {0}", data.Value);
            }
            foreach (var idx in _inputEndEvents) {
                ref var data = ref _inputEndEvents.Get1 (idx);
                Debug.LogFormat (data.Sender, "TmpInput end: {0}", data.Value);
            }
        }
    }
}