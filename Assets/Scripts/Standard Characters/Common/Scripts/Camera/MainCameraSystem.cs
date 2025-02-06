using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;

[UpdateInGroup(typeof(PresentationSystemGroup))]
public partial struct MainCameraSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<MainEntityCamera>();
        state.RequireForUpdate<NetworkStreamInGame>();
    }
    public void OnUpdate(ref SystemState state)
    {
        
        if (MainGameObjectCamera.Instance != null)
        {
            foreach ((RefRO<MainEntityCamera> mainEntityCamera, Entity entity) in SystemAPI.Query<RefRO<MainEntityCamera>>().WithAll<GhostOwnerIsLocal>().WithEntityAccess())
            {
                LocalToWorld targetLocalToWorld = SystemAPI.GetComponent<LocalToWorld>(entity);
                MainGameObjectCamera.Instance.transform.SetPositionAndRotation(targetLocalToWorld.Position, targetLocalToWorld.Rotation);
            }
       
        }
    }
}