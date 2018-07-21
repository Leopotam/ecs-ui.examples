using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
#if !LEOECS_DISABLE_INJECT
    [EcsInject]
#endif
    public class TestUiEnterExitEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiEnterEvent> _enterEvents = null;

        EcsFilter<EcsUiExitEvent> _exitEvents = null;

#if LEOECS_DISABLE_INJECT
        public TestUiEnterExitEventSystem (EcsWorld world) {
            _enterEvents = world.GetFilter<EcsFilter<EcsUiEnterEvent>> ();
            _exitEvents = world.GetFilter<EcsFilter<EcsUiExitEvent>> ();
        }
#endif

        public void Run () {
            for (var i = 0; i < _enterEvents.EntitiesCount; i++) {
                var data = _enterEvents.Components1[i];
                Debug.Log ("Cursor enter!", data.Sender);
            }
            for (var i = 0; i < _exitEvents.EntitiesCount; i++) {
                var data = _exitEvents.Components1[i];
                Debug.Log ("Cursor exit!", data.Sender);
            }
        }
    }
}