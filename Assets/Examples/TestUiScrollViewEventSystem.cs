using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class TestUiScrollViewEventSystem : IEcsRunSystem {
        readonly EcsFilter<EcsUiScrollViewEvent> _scrollViewEvents = null;

        void IEcsRunSystem.Run () {
            foreach (var idx in _scrollViewEvents) {
                ref var data = ref _scrollViewEvents.Get1 (idx);
                Debug.LogFormat (data.Sender, "ScrollView changed: {0}", data.Value);
            }
        }
    }
}