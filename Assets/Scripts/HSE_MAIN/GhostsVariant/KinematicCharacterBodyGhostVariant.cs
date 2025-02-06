using System.Collections.Generic;
using Unity.CharacterController;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace HSE.GhostsVariant
{
    public partial class DefaultVariantSystem : DefaultVariantSystemBase
    {
        protected override void RegisterDefaultVariants(Dictionary<ComponentType, Rule> defaultVariants)
        {
            defaultVariants.Add(typeof(KinematicCharacterBody), Rule.ForAll(typeof(KinematicCharacterBodyGhostVariant)));
            defaultVariants.Add(typeof(CharacterInterpolation), Rule.ForAll(typeof(CharacterInterpolationGhostVariant)));
            defaultVariants.Add(typeof(TrackedTransform), Rule.ForAll(typeof(TrackedTransformGhostVariant)));
        }
    }
    
    [GhostComponentVariation(typeof(KinematicCharacterBody))]
    [GhostComponent]
    public struct KinematicCharacterBodyGhostVariant 
    {
        [GhostField] public bool IsGrounded;
        [GhostField(Quantization = 1000)] public float3 RelativeVelocity;
        [GhostField] public Entity ParentEntity;
        [GhostField(Quantization = 1000)] public float3 ParentLocalAnchorPoint;
        [GhostField(Quantization = 1000)] public float3 ParentVelocity;
    }

    [GhostComponentVariation(typeof(CharacterInterpolation))]
    [GhostComponent(PrefabType = GhostPrefabType.PredictedClient)]
    public struct CharacterInterpolationGhostVariant
    { }
    
    [GhostComponentVariation(typeof(TrackedTransform))]
    [GhostComponent()]
    public struct TrackedTransformGhostVariant
    {
        [GhostField()]
        public RigidTransform CurrentFixedRateTransform;
    }}