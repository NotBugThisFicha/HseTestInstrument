using System;
using Unity.Entities.Serialization;
using UnityEngine;

[Serializable]
public class Interactiv
{
    public string Name;
    public Vector3 Position;
    public EntityPrefabReference PrefabReference;
}
