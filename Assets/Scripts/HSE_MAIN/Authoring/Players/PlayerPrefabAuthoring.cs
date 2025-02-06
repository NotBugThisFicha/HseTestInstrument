using Unity.Entities;
using UnityEngine;

namespace HSE.Authoring.Players
{
    public struct PlayerPrefab : IComponentData
    {
        public Entity Player, Character, Camera;
    
    }
    public class PlayerPrefabAuthoring : MonoBehaviour
    {
        public GameObject Player, Character, Camera;    

        class Baker : Baker<PlayerPrefabAuthoring>
        {       
            public override void Bake(PlayerPrefabAuthoring authoring)
            {
                AddComponent(GetEntity(TransformUsageFlags.Dynamic), new PlayerPrefab
                {
                    Player = GetEntity(authoring.Player, TransformUsageFlags.Dynamic),
                    Character = GetEntity(authoring.Character, TransformUsageFlags.Dynamic),
                    Camera = GetEntity(authoring.Camera, TransformUsageFlags.Dynamic),
                });
            }
        }
    }
}