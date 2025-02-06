using System.Collections;
using System.Collections.Generic;
using Unity.Entities.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateInteractivData", fileName = "EntityPrefab")]
public class EntityPrefabsSO : ScriptableObject
{
    public GameObject[] References;
}
