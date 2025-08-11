using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickListener : MonoBehaviour
{
    /// <summary>
    /// This method is called by the <c>InputManager</c> when a <c>GameObject<c> with a <c>OnClickListener</c> is clicked on.
    /// </summary>
    public void Click()
    {
        Debug.Log("Click on " + gameObject.name + " registered");
        JavaScriptAPI.DebugAlert("Click on " + gameObject.name + " registered");
    }
}
