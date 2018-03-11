using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    public class TestUiClickEventSystem : EcsReactSystem {
        [EcsWorld]
        EcsWorld _world;

        [EcsFilterInclude (typeof (EcsUiClickEvent))]
        EcsFilter _clickEvents;

        public override EcsFilter GetReactFilter () {
            return _clickEvents;
        }

        public override EcsReactSystemType GetReactSystemType () {
            return EcsReactSystemType.OnAdd;
        }

        public override void RunReact (int[] entities, int count) {
            for (var i = 0; i < count; i++) {
                var data = _world.GetComponent<EcsUiClickEvent> (entities[i]);
                Debug.Log ("Im clicked!", data.Sender);
            }
        }
    }
}