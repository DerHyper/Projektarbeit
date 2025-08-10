using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        CheckClick();
    }

    private void CheckClick()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        if (!GetOnClickListener(out OnClickListener target))
        {
            return;
        }

        target.Click();
    }

    private bool GetOnClickListener(out OnClickListener onClickListener)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            onClickListener = null;
            return false;
        }

        if (raycastHit.collider.gameObject.TryGetComponent(out onClickListener))
        {
            return true;
        }

        if (FindOnClickListenerInParents(raycastHit.collider.gameObject.transform, out onClickListener))
        {
            return true;
        }

        onClickListener = null;
        return false;    
    }

/// <summary>
/// Recursivly searches for a <c>OnClickListener</c> component in the parents of given transform.
/// </summary>
/// <param name="target">Transform thats parents will be searched thou.</param>
/// <param name="onClickListener">The <c>OnClickListener</c> found in a parent objects.</param>
/// <returns>True if a <c>OnClickListener</c> was found.</returns>
    private bool FindOnClickListenerInParents(Transform target, out OnClickListener onClickListener)
    {
        Transform parent = target.parent;
        if (parent == null)
        {
            onClickListener = null;
            return false;
        }

        if (parent.gameObject.TryGetComponent(out onClickListener))
        {
            return true;
        }

        return FindOnClickListenerInParents(target, out onClickListener);
    }
}
