using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class WebSocketManager : MonoBehaviour
{
    public static WebSocketManager instance;
    private const string INIT_PREFIX = "Init: ";
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

    /// <summary>
    /// Calls the ConnectWS function in the JavaScript plugin unity_to_js_plugin.jslib to connect to a WebSocket server.
    /// </summary>
    [DllImport("__Internal")]
    public static extern void ConnectWS(string url);

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        string url = "ws://localhost:8081";
        ConnectWS(url);
#endif
    }

    public void OnWebSocketOpen()
    {
        Debug.Log("WebSocket connection established.");
        ObjectManager.instance.IncPosition();
    }
    
    public void OnWebSocketMessage(string message)
    {
        Debug.Log("Message from server: " + message);

        if (message.StartsWith(INIT_PREFIX))
        {
            string modelUri = message.Substring(INIT_PREFIX.Length);
            GameManager.instance.LoadModel(modelUri);
        }
        
        ObjectManager.instance.ShowText(message);
        ObjectManager.instance.UpdateVisualization(message);
    }
}
