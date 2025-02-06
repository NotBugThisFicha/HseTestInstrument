using System;
using Unity.Entities;
using Unity.Entities.Content;
using Unity.Entities.Serialization;
using UnityEngine;


public class ImportPrefabsAuthoring : MonoBehaviour
{
    [SerializeField] private EntityPrefabReference RoomPrefab;
    [SerializeField] private EntityPrefabReference Interactive;

    
    private class ImportPrefabsBaker : Baker<ImportPrefabsAuthoring>
    {
        public override void Bake(ImportPrefabsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new EntityPrefabImportReference(){Reference = authoring.RoomPrefab});
            AddComponent(entity, new RequestImportLoad());
           
           // AddComponent(entity, new GameObjectReference() { ConfigReference = authoring.Interactive});
            /*
            if (authoring.Interactive.Length > 0)
            {
                DynamicBuffer<ImportInteractivePrefab> buffer = AddBuffer<ImportInteractivePrefab>(entity);
                foreach (var reference in authoring.Interactive) {
                    buffer.Add(new ImportInteractivePrefab() {EntityPrefab = reference});
                }
            }
            */
        }
    }
}
