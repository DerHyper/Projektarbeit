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
        Material current = gameObject.GetComponent<Renderer>().material;

        // Try to find predefined material first
        if (!ResourcesManager.instance.predefinedMaterials.TryGetValue(newState.material.color, out Material foundMaterial))
        {
            gameObject.GetComponent<Renderer>().SetMaterials(new List<Material> { foundMaterial });
        };

        // If not found, update the current material. This is okay since each object has its own instance of the material.
        if (UnityEngine.ColorUtility.TryParseHtmlString(newState.material.color, out Color foundColor))
        {
            current.color = foundColor; // TODO: Fix Hex to Color conversion
        }

        if (newState.material.metallic.HasValue)
        {
            current.SetFloat("_Metallic", newState.material.metallic.Value);
        }

        if (newState.material.smoothness.HasValue)
        {
            current.SetFloat("_Glossiness", newState.material.smoothness.Value);
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
