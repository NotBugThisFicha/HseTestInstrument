using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent]
public struct ThirdPersonPlayer : IComponentData
{
    [GhostField] public Entity ControlledCharacter;
    [GhostField] public Entity ControlledCamera;
    [GhostField] public FixedString32Bytes UserName;
}

[Serializable]
public struct ThirdPersonPlayerInputs : IInputComponentData
{
    public float2 MoveInput;
    public float2 CameraLookInput;
    [GhostField(Quantization = 100)] public float3 RayOrigin;
    [GhostField(Quantization = 100)] public float3 RayPoint;

    [GhostField(Quantization = 1000)] public float CameraZoomInput;

    public InputEvent LefClickPressed;
    public InputEvent JumpPressed;
}
