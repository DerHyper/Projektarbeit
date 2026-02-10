using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AppState currentState = AppState.Idle;
    [SerializeField] public string startCamera = "Camera";
    public enum AppState
    {
        Idle,
        LoadingModel,
        Running,
        Error
    }

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

    public void SetState(AppState newState)
    {
        currentState = newState;
        Debug.Log("Game state changed to: " + newState.ToString());
    }

    public async void InitScene(string modelUri)
    {
        SetState(AppState.LoadingModel);
        LoadModel(modelUri);
        CameraManager.instance.SetActiveCamera(startCamera);
        SetState(AppState.Running);
    }

    private async void LoadModel(string uri)
    {
        bool success = await ModelLoadingManager.instance.LoadModelFromUri(uri);
        if (success)
        {
            ModelLoadingManager.instance.InitModelObjects();
        }
        ObjectManager.instance.UpdateManagedObjects();
    }
}
