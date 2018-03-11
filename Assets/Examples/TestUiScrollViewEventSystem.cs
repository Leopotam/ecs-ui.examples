using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Tests {
    public class TestUiScrollViewEventSystem : EcsReactSystem {
        [EcsWorld]
        EcsWorld _world;

        [EcsFilterInclude (typeof (EcsUiScrollViewEvent))]
        EcsFilter _scrollViewEvents;

        public override EcsFilter GetReactFilter () {
            return _scrollViewEvents;
        }

        public override EcsReactSystemType GetReactSystemType () {
            return EcsReactSystemType.OnAdd;
        }

        public override void RunReact (int[] entities, int count) {
            for (var i = 0; i < count; i++) {
                var data = _world.GetComponent<EcsUiScrollViewEvent> (entities[i]);
                Debug.LogFormat (data.Sender, "ScrollView changed: {0}", data.Value);
            }
        }
    }
}