using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public class TableSwitcherAuthoring : MonoBehaviour
{
    public Material[] materials;

    public class Baker : Baker<TableSwitcherAuthoring>
    {

        public override void Bake(TableSwitcherAuthoring authoring)
        {
            MaterialChanger component = new MaterialChanger();
            component.materials = authoring.materials;
            var entity = GetEntity(TransformUsageFlags.Renderable);
            AddComponentObject(entity, component);
            AddComponent(entity, new Counter { maxCount = (uint)authoring.materials.Length });
        }
    }
}

public class MaterialChanger : IComponentData
{
    public Material[] materials;
}

[GhostComponent]
public struct Counter: IComponentData
{
    [GhostField] public uint count;
    public uint currentCount;
    public uint maxCount;
}

