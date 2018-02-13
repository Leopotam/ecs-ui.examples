using System.Collections.Generic;
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

        public override void RunReact (List<int> entities) {
            foreach (var entity in _scrollViewEvents.Entities) {
                var data = _world.GetComponent<EcsUiScrollViewEvent> (entity);
                Debug.LogFormat (data.Sender, "ScrollView changed: {0}", data.Value);
            }
        }
    }
}