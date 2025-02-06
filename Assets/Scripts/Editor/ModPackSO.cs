using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using HSE.Editor.Attributes;
using Unity.Entities.Build;
using Unity.Entities.Content;
using Unity.Scenes.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSE_MAIN.Editor.Mods
{
    [CreateAssetMenu(fileName = "Modpack", menuName = "HSEMods/Modpack", order = 0)]
    public class ModPackSO : ScriptableObject
    {
#if UNITY_EDITOR
        public string Guid => guid;
        [ReadOnly] [SerializeField] [Delayed] private string guid;
        [ReadOnly] [SerializeField] [Delayed] private string buildPath;
        [ReadOnly] [SerializeField] [Delayed] private string streamingAssetsPath;
        
        //[SerializeField] private List<SceneAsset> scenes;
        //public List<SceneAsset> Scenes => scenes;

        [Button(nameof(SetBuildPath))]
        public bool setBuildPath;
        [Button(nameof(BuildSubSceneData))]
        public bool buildSubSceneData;
        [Button(nameof(PublishStreamingAssets))]
        public bool publishStreamingAssets;

        private const string mainSceneName = "GameRoom";
        public void SetBuildPath()
        {
            var buildFolder = EditorUtility.OpenFolderPanel("Select Build To Publish",
                Path.GetDirectoryName(Application.dataPath), "Builds");
 
            if (string.IsNullOrEmpty(buildFolder))
                return;
 
            buildPath           = buildFolder;
            streamingAssetsPath = $"{buildFolder}/{PlayerSettings.productName}_Data/StreamingAssets/{Guid}";
        }
        
        public void BuildSubSceneData()
        {
            var tmpBuildFolder = Path.Combine(Path.GetDirectoryName(Application.dataPath),
                $"Library\\ContentUpdateBuildDir\\{PlayerSettings.productName}");
            var instance   = DotsGlobalSettings.Instance;
            var playerGuid = instance.GetPlayerType() == DotsGlobalSettings.PlayerType.Client ? instance.GetClientGUID() : instance.GetServerGUID();
 
            if (!playerGuid.IsValid)
                throw new Exception("Invalid Player GUID");

            // dredge the sub scenes from the scenes
            var subSceneGuids = new HashSet<Unity.Entities.Hash128>();
            var mainSceneBuiltInPath = SceneManager.GetSceneByName(mainSceneName).path;
            AddSubSceneGuids(subSceneGuids, mainSceneBuiltInPath);
            //foreach (SceneAsset scene in Scenes)
            //{
            //    string scenePath = AssetDatabase.GetAssetPath(scene);
            //    //if (scenePath == mainSceneBuiltInPath)
            //    //    continue;
            //    //if (subScenesHashes.Length > 1)
            //    //    subSceneGuids.Add(subScenesHashes[subScenesHashes.Length - 1]);
            //    //else subSceneGuids.Add(subScenesHashes[0]);
            //    AddSubSceneGuids(subSceneGuids, scenePath);
            //}
 
            // build the data
            var buildTarget = EditorUserBuildSettings.activeBuildTarget;
            RemoteContentCatalogBuildUtility.BuildContent(subSceneGuids, playerGuid, buildTarget, tmpBuildFolder);
 
            // publish the data
            var publishFolder = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Builds");
            publishFolder = Path.Combine(publishFolder, $"{buildPath}-RemoteContent");
 
            RemoteContentCatalogBuildUtility.PublishContent(tmpBuildFolder, publishFolder, f => new[] { "all" }, true);
        }
 
        private void AddSubSceneGuids(HashSet<Unity.Entities.Hash128> subSceneGuids, string scenePath)
        {
            GUID sceneGuid = AssetDatabase.GUIDFromAssetPath(scenePath);
            var subScenesHashes = EditorEntityScenes.GetSubScenes(sceneGuid);
            subSceneGuids.Add(subScenesHashes[subScenesHashes.Length - 1]);
        }
        private static string PathCombine(string path1, string path2)
        {
            if (!Path.IsPathRooted(path2)) return Path.Combine(path1, path2);
 
            path2 = path2.TrimStart(Path.DirectorySeparatorChar);
            path2 = path2.TrimStart(Path.AltDirectorySeparatorChar);
 
            return Path.Combine(path1, path2);
        }
        
        public void PublishStreamingAssets()
        {
            RemoteContentCatalogBuildUtility.PublishContent(streamingAssetsPath,
                $"{buildPath}-RemoteContent",
                f => new string[] { "all" }, true);
        }
#endif
    }
}
