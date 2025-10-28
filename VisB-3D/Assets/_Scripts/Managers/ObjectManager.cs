using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public GameObject myObject;
    public TMP_InputField messageOutputField;
    public TMP_InputField debugMessageInputField;

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

    public void IncPosition()
    {
        myObject.transform.position += new Vector3(1, 0, 0);
    }

    public void ShowText(string text)
    {
        messageOutputField.text = text;
    }

    public void UpdateVisualization(string data)
    {
        VisB3DDto dto = MessageParser.MessageToState(data);
        ShowText("Received " + dto.objectStates.Count + " objects:" + data);
    }
}
