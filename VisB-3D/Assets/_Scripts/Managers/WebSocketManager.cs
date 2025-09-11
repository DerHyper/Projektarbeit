using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSocketManager : MonoBehaviour
{
    public static WebSocketManager instance;
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


    public void OnWebSocketOpen()
    {
        Debug.Log("WebSocket connection established.");
        ObjectManager.instance.IncPosition();
    }
}
