using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Manager for loading and providing access to predefined resources like materials.
/// </summary>
public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance;
    /// <summary>
    /// Name of the predefined transparent material in the Resources folder. Used when setting colors with transparency.
    /// </summary>
    public Material transparentMaterial;
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