using UnityEngine;
using Unity.Entities;

namespace HSE.Test
{

    public struct TestFollower: IComponentData { }

    public class TestCubeFollowAuthoring : MonoBehaviour
    {
        public class Baker : Baker<TestCubeFollowAuthoring>
        {

            public override void Bake(TestCubeFollowAuthoring authoring)
            {
                var ent = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(ent, new TestFollower());
            }
        }
    }
}
