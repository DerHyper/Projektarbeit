using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class JavaScriptAPI
{
    /// <summary>
    /// Debug method for checking if Unity can call JS. Has a method with the same name in the index.html file.
    /// </summary>
    [DllImport("__Internal")]
    public static extern void DebugAlert(string str);
}
