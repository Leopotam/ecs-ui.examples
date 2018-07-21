using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
#if !LEOECS_DISABLE_INJECT
    [EcsInject]
#endif
    public class TestUiScrollViewEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiScrollViewEvent> _scrollViewEvents = null;

#if LEOECS_DISABLE_INJECT
        public TestUiScrollViewEventSystem (EcsWorld world) {
            _scrollViewEvents = world.GetFilter<EcsFilter<EcsUiScrollViewEvent>> ();
        }
#endif

        void IEcsRunSystem.Run () {
            for (var i = 0; i < _scrollViewEvents.EntitiesCount; i++) {
                var data = _scrollViewEvents.Components1[i];
                Debug.LogFormat (data.Sender, "ScrollView changed: {0}", data.Value);
            }
        }
    }
}