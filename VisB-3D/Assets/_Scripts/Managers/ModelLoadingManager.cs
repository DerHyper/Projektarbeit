using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GLTFast;
using Unity.VisualScripting;
using UnityEngine;

public class ModelLoadingManager : MonoBehaviour
{
    public static ModelLoadingManager instance;
    [SerializeField]
    private Transform modelParent;
    [SerializeField]
    private bool loadDebugModelFromDisk = false;
    [SerializeField]
    private string debugModelUri = "";
    // private GLTFast.GltfAsset gltfAsset;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // InitGltfAsset();

#if UNITY_EDITOR
        if (loadDebugModelFromDisk)
        {
            LoadModelFromUri(debugModelUri);
        }
#endif
    }

    // private void InitGltfAsset()
    // {
    //     GltfAsset gltf = gameObject.GetComponent<GLTFast.GltfAsset>();
    //     gltfAsset = gltf != null ? gltf : gameObject.AddComponent<GLTFast.GltfAsset>();
    // }

    public async Task<bool> LoadModelFromUri(string uri)
    {
        var gltf = new GltfImport();
        var settings = new ImportSettings {
            GenerateMipMaps = true,
            AnisotropicFilterLevel = 3,
            NodeNameMethod = NameImportMethod.OriginalUnique
        };
        // Load the glTF and pass along the settings
        bool success = await gltf.Load(uri, settings);

        if (success) {
            await gltf.InstantiateMainSceneAsync(modelParent);
            return true;
        }
        else {
            Debug.LogError("Loading glTF failed!");
            return false;
        }
    }

    public void InitModelObjects()
    {
        AddStateUpdaterRecursively(modelParent);
    }

    private void AddStateUpdaterRecursively(Transform parent)
    {
        parent.gameObject.AddComponent<StateUpdater>();
        foreach (Transform child in parent)
        {
            AddStateUpdaterRecursively(child);
        }
    }
}
