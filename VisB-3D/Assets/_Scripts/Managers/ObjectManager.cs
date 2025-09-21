using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public GameObject myObject;
    public TMP_Text debugText;

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
        debugText.text = text;
    }
}
