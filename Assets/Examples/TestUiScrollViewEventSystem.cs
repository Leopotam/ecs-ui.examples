using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiScrollViewEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiScrollViewEvent> _scrollViewEvents = null;

        void IEcsRunSystem.Run () {
            foreach (var idx in _scrollViewEvents) {
                var data = _scrollViewEvents.Components1[idx];
                Debug.LogFormat (data.Sender, "ScrollView changed: {0}", data.Value);
            }
        }
    }
}