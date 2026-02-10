using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Dropdown cameraDropdown;

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

    void Start()
    {
        cameraDropdown.onValueChanged.AddListener(OnCameraDropdownChanged);
    }

    public void TogglePanel(GameObject panel)
    {
        bool isActive = panel.activeSelf;
        panel.SetActive(!isActive);
    }

    public void SetDropdownOptions(TMP_Dropdown dropdown, List<string> options, string selectedOption = null)
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
        int selectedIndex = options.IndexOf(selectedOption);
        dropdown.value = selectedIndex;
    }

    public void OnCameraDropdownChanged(int index)
    {
        if (index < 0 || index >= cameraDropdown.options.Count) return;

        string selectedCameraName = cameraDropdown.options[index].text;
        CameraManager.instance.SetActiveCamera(selectedCameraName);
    }
}
