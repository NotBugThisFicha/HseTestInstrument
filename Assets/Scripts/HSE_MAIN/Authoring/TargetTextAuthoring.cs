using UnityEngine;
using Unity.Entities;
using HSE.Components;

namespace Assets.Scripts.HSE_MAIN.Authoring
{

    [DisallowMultipleComponent]
    public class TargetTextAuthoring : MonoBehaviour
    {
        public GameObject Target;
    }

    public class TargetTextGOBaker : Baker<TargetTextAuthoring>
    {
        public override void Bake(TargetTextAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new TargetText { Entity = GetEntity(authoring.Target, TransformUsageFlags.Dynamic)});
        }
    }
}
