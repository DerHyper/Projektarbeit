using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AppState currentState = AppState.Idle;
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

    public async void LoadModel(string uri)
    {
        SetState(AppState.LoadingModel);
        bool success = await ModelLoadingManager.instance.LoadModelFromUri(uri);
        if (success)
        {
            ModelLoadingManager.instance.InitModelObjects();
        }
        ObjectManager.instance.UpdateManagedObjects();
        SetState(AppState.Running);
    }
}
