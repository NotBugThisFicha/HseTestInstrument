
using System;
using Unity.Entities.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractivePrefabsConfig", menuName ="Interactive/Prefabs")]
public class InteractivePrefabsConfig : ScriptableObject
{

	[Serializable]
	public class Config
	{
		public string Name;
		public Vector3 Position;
		public EntityPrefabReference entityPrefab;
	}

	public Config[] config;
}