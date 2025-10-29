using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public GameObject myObject;
    public TMP_InputField messageOutputField;
    public GameObject stateObjectParent;
    public Dictionary<string, StateUpdater> managedObjects = new();

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

    private void Start()
    {
        stateObjectParent.GetComponentsInChildren<StateUpdater>().ToList().ForEach(su =>
            managedObjects.Add(su.gameObject.name, su)
        );
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
        foreach (VisB3DObjectDto objDto in dto.objectStates)
        {
            if (managedObjects.TryGetValue(objDto.name, out StateUpdater stateUpdater))
            {
                stateUpdater.UpdateState(objDto);
            }
        }
    }
}
