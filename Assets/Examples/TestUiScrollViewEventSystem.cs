using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiScrollViewEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiScrollViewEvent> _scrollViewEvents = null;

        void IEcsRunSystem.Run () {
            for (var i = 0; i < _scrollViewEvents.EntitiesCount; i++) {
                var data = _scrollViewEvents.Components1[i];
                Debug.LogFormat (data.Sender, "ScrollView changed: {0}", data.Value);
            }
        }
    }
}