using System;
using Unity.Entities;
using Unity.Entities.Content;
using Unity.Entities.Serialization;
using UnityEngine;

public class MeshRefSample : MonoBehaviour
{
    public WeakObjectReference<Mesh> mesh;
    public WeakObjectReference<Material> material;
    class MeshRefSampleBaker : Baker<MeshRefSample>
    {
        public override void Bake(MeshRefSample authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new MeshComponentData { mesh = authoring.mesh, material = authoring.material});
        }
    }
}

public struct MeshComponentData : IComponentData
{
    public bool startedLoad;
    public WeakObjectReference<Mesh> mesh;
    public WeakObjectReference<Material> material;
}
