using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateUpdater : MonoBehaviour
{

    /// <summary>
    /// Updates the visual State of the GameObject based on the provided DTO.
    /// </summary>
    /// <param name="newState"></param>
    public void UpdateState(VisB3DObjectDto newState)
    {
        UpdatePosition(newState);
        UpdateRotation(newState);
        UpdateScale(newState);
        UpdateMaterial(newState);
        UpdateActiveState(newState);
    }

    private void UpdateActiveState(VisB3DObjectDto newState)
    {
        if (newState.isActive.HasValue && gameObject.activeSelf != newState.isActive.Value)
        {
            gameObject.SetActive(newState.isActive.Value);
        }
    }

    private void UpdateMaterial(VisB3DObjectDto newState)
    {
        if (newState.material == null)
        {
            return;
        }

        Material current = gameObject.GetComponent<Renderer>().material;

        // COLOR
        UpdateColor(newState, current);
        
        // METALLIC
        if (newState.material.metallic.HasValue)
        {
            current.SetFloat("_Metallic", newState.material.metallic.Value);
        }

        // SMOOTHNESS
        if (newState.material.smoothness.HasValue)
        {
            current.SetFloat("_Glossiness", newState.material.smoothness.Value);
        }
    }

    private void UpdateColor(VisB3DObjectDto newState, Material current)
    {
        if (newState.material.color == null)
        {
            return;
        }
        // Try to find a predefined material first
        if (ResourcesManager.instance.predefinedMaterials.TryGetValue(newState.material.color, out Material foundMaterial))
        {
            gameObject.GetComponent<Renderer>().SetMaterials(new List<Material> { foundMaterial });
        }
        else if (UnityEngine.ColorUtility.TryParseHtmlString(newState.material.color, out Color foundColor))
        {
            // If not found, update the current material. This is okay since each object has its own instance of the material.
            current.color = foundColor; // TODO: Fix Hex to Color conversion
            if (foundColor.a < 1.0f)
            {
                current.SetFloat("_Mode", 3); // Transparent
                current.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                current.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                current.SetInt("_ZWrite", 0);
                current.DisableKeyword("_ALPHATEST_ON");
                current.EnableKeyword("_ALPHABLEND_ON");
                current.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                current.renderQueue = 3000;
            }
            else
            {
                current.SetFloat("_Mode", 0); // Opaque
                current.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                current.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                current.SetInt("_ZWrite", 1);
                current.DisableKeyword("_ALPHATEST_ON");
                current.DisableKeyword("_ALPHABLEND_ON");
                current.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                current.renderQueue = -1;
            }
        }
    }

    private void UpdateScale(VisB3DObjectDto newState)
    {
        Vector3 currentScale = transform.localScale;
        Vector3 newScale = newState.scale.OverrideVector3(currentScale);
        transform.localScale = newScale;
    }

    private void UpdatePosition(VisB3DObjectDto newState)
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = newState.position.OverrideVector3(currentPosition);
        transform.position = newPosition;
    }

    private void UpdateRotation(VisB3DObjectDto newState)
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        Vector3 newRotation = newState.rotation.OverrideVector3(currentRotation);
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
