using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Content;
using Unity.Entities.Serialization;
using Unity.Mathematics;
using UnityEngine;

public struct EntityPrefabImportReference : IComponentData
{
    public EntityPrefabReference Reference;
    public PrefabConfig PrefabConfig;
}

public struct PrefabConfig
{
    public FixedString64Bytes Name;
    public float3 Position;
    public float3 Rotation;
}

public struct RoomConfigTag: IComponentData
{}

public struct GameObjectImportReference : IComponentData
{
    public WeakObjectReference<GameObject> GameObjectReference;
    public WeakObjectReference<Mesh> MeshReference;
    public WeakObjectReference<Material> MaterialReference;
    public WeakObjectReference<Texture> TextureReference;
    public WeakObjectReference<Shader> ShaderReference;
}

#if !UNITY_DISABLE_MANAGED_COMPONENTS
public class GameObjectLoading : IComponentData
{
    public GameObject GameObjectPrefabInstance;
    public GameObject MeshGameObjectInstance;
    public GameObject MaterialGameObjectInstance;
    public GameObject TextureGameObjectInstance;
    public Shader ShaderInstance;
    public PrefabConfig PrefabConfig;
}
public class ImportEntityLoading : IComponentData
{
    public Entity Entity;
    public Entity Instance;
    public PrefabConfig PrefabConfig;
}
#endif

public struct RequestImportUnload : IComponentData
{ }
public struct RequestImportLoad : IComponentData
{ }