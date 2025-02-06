using UnityEngine;
using Unity.Entities;
using Unity.NetCode;
using Unity.Collections;

namespace HSE.Authoring
{
    [GhostComponent]
    public struct TextComp: IComponentData
    {
        [GhostField] public FixedString128Bytes Value;
        [GhostField] public Entity TargetEntity;
    }

    [DisallowMultipleComponent]
    public class TextAuthoring : MonoBehaviour
    {
        public class TextBaker : Baker<TextAuthoring>
        {
            public override void Bake(TextAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<TextComp>(entity);
            }
        }
    }
}
