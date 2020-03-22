using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Tests {
    public class TestUiSliderChangeEventSystem : IEcsRunSystem {
        readonly EcsFilter<EcsUiSliderChangeEvent> _sliderChangeEvents = null;

        void IEcsRunSystem.Run () {
            foreach (var idx in _sliderChangeEvents) {
                ref var data = ref _sliderChangeEvents.Get1 (idx);
                Debug.LogFormat (data.Sender, "Slider changed: {0}", data.Value);
            }
        }
    }
}