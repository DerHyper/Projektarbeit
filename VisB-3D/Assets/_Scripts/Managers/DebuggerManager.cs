using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebuggerManager : MonoBehaviour
{
    public static DebuggerManager instance;

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

    public void MockDebugMessageFromInputField(TMP_InputField debugMessageInputField)
    {
        WebSocketManager.instance.OnWebSocketMessage(debugMessageInputField.text);
    }
}
