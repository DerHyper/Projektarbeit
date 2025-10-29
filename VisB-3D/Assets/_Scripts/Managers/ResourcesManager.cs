using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance;
    public Dictionary<string,Material> predefinedMaterials = new();
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

    private void Start()
    {
        GetMaterialsFromResources().ToList().ForEach(m => predefinedMaterials.Add(m.name, m));
    }

    private static Material[] GetMaterialsFromResources()
    {
#if UNITY_EDITOR
        PlayerSettings.WebGL.useEmbeddedResources = true; // Add Resources support to WebGL
#endif
        Material[] materials = Resources.LoadAll<Material>("Materials/");
        return materials;
    }
}