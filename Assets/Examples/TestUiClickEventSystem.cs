using System.Collections.Generic;
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

        public override EcsRunSystemType GetRunSystemType () {
            return EcsRunSystemType.Update;
        }

        public override void RunReact (List<int> entities) {
            foreach (var entity in entities) {
                var data = _world.GetComponent<EcsUiClickEvent> (entity);
                Debug.Log ("Im clicked!", data.Sender);
            }
        }
    }
}