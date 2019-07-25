using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    [EcsInject]
    public class TestUiClickEventSystem : IEcsRunSystem {
        EcsFilter<EcsUiClickEvent> _clickEvents = null;

        void IEcsRunSystem.Run () {
            foreach (var idx in _clickEvents) {
                var data = _clickEvents.Components1[idx];
                Debug.Log ("Im clicked!", data.Sender);
            }
        }
    }
}