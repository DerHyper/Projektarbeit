using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineCamera freeCam;
    [SerializeField] private List<Camera> cameras = new List<Camera>();

    public void Awake()
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

    private void Start() {
        ModelLoadingManager.instance.OnModelLoaded += UpdateCameraList;
        ModelLoadingManager.instance.OnModelLoaded += UpdateCameraListOnUI;
    }

    private void UpdateCameraList()
    {
        cameras.Clear();
        foreach (Camera cam in FindObjectsByType(typeof(Camera), FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            cameras.Add(cam);
        }
    }

    private void UpdateCameraListOnUI()
    {
        UIManager.instance.SetDropdownOptions(
            UIManager.instance.cameraDropdown,
            cameras.ConvertAll(cam => cam.name)
        );
    }

    public void SetActiveCamera(string cameraName)
    {
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(cam.name == cameraName);
        }
    }
}
