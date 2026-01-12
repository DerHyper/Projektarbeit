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
    public StateUpdater CameraStateUpdater;
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
        UpdateManagedObjects();
    }

    public void UpdateManagedObjects()
    {
        managedObjects.Clear();
        stateObjectParent.GetComponentsInChildren<StateUpdater>().ToList().ForEach(su =>
            managedObjects.Add(su.gameObject.name, su)
        );
        managedObjects.Add(CameraStateUpdater.gameObject.name, CameraStateUpdater);
    }

    public void IncPosition()
    {
        myObject.transform.position += new Vector3(1, 0, 0);
    }

    public void ShowText(string text)
    {
        messageOutputField.text = text;
    }

/// <summary>
/// Destroy the object with the given name and remove it from managedObjects
/// </summary>
/// <param name="name"></param>
    public void DestroyObject(string name)
    {
        if (managedObjects.TryGetValue(name, out StateUpdater stateUpdater))
        {
            Destroy(stateUpdater.gameObject);
            managedObjects.Remove(name);
        }
    }

    /// <summary>
    /// Update the visualization based on incoming data
    /// </summary>
    /// <param name="data"></param>
    public void UpdateVisualization(string data)
    {
        SpecialFormManager.OnStartVisualizationUpdate();
        VisB3DDto dto = MessageParser.MessageToState(data);
        foreach (VisB3DObjectDto objDto in dto.objectStates)
        {
            SpecialFormManager.TryAddSpecialForm(objDto);
            CheckStateUpdater(objDto);
        }
    }

    /// <summary>
    /// Check if there is a StateUpdater for the object and update its state
    /// </summary>
    /// <param name="objDto"></param>
    private void CheckStateUpdater(VisB3DObjectDto objDto)
    {
        if (managedObjects.TryGetValue(objDto.name, out StateUpdater stateUpdater))
        {
            stateUpdater.UpdateState(objDto);
        }
    }
}
