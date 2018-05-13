using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiClickEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiClickEvent> _clickEvents = null;

        void IEcsRunSystem.Run () {
            for (var i = 0; i < _clickEvents.EntitiesCount; i++) {
                var data = _clickEvents.Components1[i];
                Debug.Log ("Im clicked!", data.Sender);
            }
        }
    }
}