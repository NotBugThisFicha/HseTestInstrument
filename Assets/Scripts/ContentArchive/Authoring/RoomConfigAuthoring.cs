using Unity.Entities.Serialization;
using Unity.Entities;
using UnityEngine;
using System;
using Unity.Entities.Content;

public class RoomConfigAuthoring : MonoBehaviour
{
    [SerializeField] private WeakObjectReference<GameObject> RoomPrefab;
    [SerializeField] private EntityPrefabReference[] roomConfigs;


    private class RoomConfigBaker : Baker<RoomConfigAuthoring>
    {

        public override void Bake(RoomConfigAuthoring authoring)
        {
            var entity = CreateAdditionalEntity(TransformUsageFlags.None);
            AddComponent(entity, new GameObjectImportReference() { GameObjectReference = authoring.RoomPrefab });
            AddComponent(entity, new RequestImportLoad());
            AddComponent(entity, new RoomConfigTag());

            foreach(var config in authoring.roomConfigs)
            {
                var interactivEntity = CreateAdditionalEntity(TransformUsageFlags.None);
                AddComponent(interactivEntity, new EntityPrefabImportReference() { Reference = config, PrefabConfig = new PrefabConfig() { Position = new Unity.Mathematics.float3(0, 0, 0) } });
                AddComponent(interactivEntity, new RequestImportLoad());
            }
        }
    }

    [Serializable]
    public struct InteractiveConfig
    {
        public string Name;
        public Vector3 Position;
        public EntityPrefabReference EntityPrefab;
    }
}
