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

    /// <summary>
    /// Method for sending messages to a WebSocket server.
    /// </summary>
    /// <param name="messageJson">JSON String from WSMessageDto containing message type and meta infos</param>
    [DllImport("__Internal")]
    public static extern void SendWSMessage(string messageJson);
}
