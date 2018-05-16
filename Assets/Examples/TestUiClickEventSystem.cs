using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
#if !LEOECS_DISABLE_INJECT
    [EcsInject]
#endif
    public class TestUiClickEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiClickEvent> _clickEvents = null;

#if LEOECS_DISABLE_INJECT
        public TestUiClickEventSystem (EcsWorld world) {
            _clickEvents = world.GetFilter<EcsFilter<EcsUiClickEvent>> ();
        }
#endif

        void IEcsRunSystem.Run () {
            for (var i = 0; i < _clickEvents.EntitiesCount; i++) {
                var data = _clickEvents.Components1[i];
                Debug.Log ("Im clicked!", data.Sender);
            }
        }
    }
}