using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class TestUiClickEventSystem : IEcsRunSystem {
        readonly EcsFilter<EcsUiClickEvent> _clickEvents = null;

        void IEcsRunSystem.Run () {
            foreach (var idx in _clickEvents) {
                ref var data = ref _clickEvents.Get1 (idx);
                Debug.Log ("Im clicked!", data.Sender);
            }
        }
    }
}