using Unity.Entities;
using Unity.Mathematics;

namespace HSE.Components.Transform
{
    public struct FollowTarget : IComponentData
    {
        public float3 Offset;
        public Entity TargetEntity;
    }
    public struct FollowEnable : IComponentData { }
}
