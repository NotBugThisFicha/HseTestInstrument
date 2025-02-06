using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.CharacterController;
using Unity.NetCode;

[Serializable]
public struct ThirdPersonCharacterComponent : IComponentData
{
    public float RotationSharpness;
    public float GroundMaxSpeed;
    public float GroundedMovementSharpness;
    public float AirAcceleration;
    public float AirMaxSpeed;
    public float AirDrag;
    public float JumpSpeed;
    public float3 Gravity;
    public bool PreventAirAccelerationAgainstUngroundedHits;
    public BasicStepAndSlopeHandlingParameters StepAndSlopeHandling;
}

[Serializable]
public struct ThirdPersonCharacterControl : IComponentData
{
    public float2 MoveInput;
    public float3 MoveVector;
    public bool Jump;
    [GhostField] public byte OnGround;
    [GhostField] public NetworkTick JumpStart;
    public quaternion RotPlayer;
    public quaternion RotCam;
    public float Pitch;
    public float Yaw;
}
