using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Xml.Serialization;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public InputAction clickAction;
    public bool isClickHolding = false;
    public InputAction moveAction;
    public bool isMoveHolding = false;
    public InputAction moveVerticalAction;
    public bool isMoveVerticalHolding = false;
    public Transform cameraTarget;

    public float movementAmount = 1;

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

        RegisterInputActions();
    }

    private void FixedUpdate()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (isClickHolding) HandleMouseHolding();
        if (isMoveHolding) HandleMoveHolding();
        if (isMoveVerticalHolding) HandleMoveVerticalHolding();
    }

    private void HandleMoveVerticalHolding()
    {
        var direction = moveVerticalAction.ReadValue<float>();
        Vector3 movementDirection = new Vector3(0, direction, 0) * movementAmount * Time.fixedDeltaTime;
        Debug.Log("HandleMoveVertical: " + movementDirection);
        cameraTarget.Translate(movementDirection);
    }

    private void HandleMoveHolding()
    {
        var direction = new Vector3(moveAction.ReadValue<Vector2>().x, 0, moveAction.ReadValue<Vector2>().y);
        var orientation = CameraManager.instance.freeCam.State.GetCorrectedOrientation();
        var scaledOrentation = orientation * Vector3.up;

        // var eulerOrientation = orientation.eulerAngles;
        Vector3 movementDirection = (orientation * direction) * movementAmount * Time.fixedDeltaTime;
        Debug.Log("HandleMove: " + movementDirection + " Orientation: " + scaledOrentation);
        cameraTarget.Translate(movementDirection);
    }

    private void HandleMouseHolding()
    {
        // Force mouse on screen

    }

    private void RegisterInputActions()
    {
        clickAction.Enable();
        clickAction.performed += OnClickPerformed;
        clickAction.canceled += OnClickCanceled;

        moveAction.Enable();
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;

        moveVerticalAction.Enable();
        moveVerticalAction.performed += OnMoveVerticalPerformed;
        moveVerticalAction.canceled += OnMoveVerticalCanceled;
    }

    private void OnMoveVerticalCanceled(InputAction.CallbackContext context)
    {
        isMoveVerticalHolding = false;
    }

    private void OnMoveVerticalPerformed(InputAction.CallbackContext context)
    {
        isMoveVerticalHolding = true;
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        isMoveHolding = false;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        isMoveHolding = true;
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        isClickHolding = true;
        CameraManager.instance.allowFreeCamMove(true);
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void OnClickCanceled(InputAction.CallbackContext context)
    {
        isClickHolding = false;
        CameraManager.instance.allowFreeCamMove(false);
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;

        if (TryGetOnClickListener(out OnClickListener target))
        {
            target.Click();
        }
    }

    /// <summary>
    /// Return the OnClickListener of the clicked GO or its parents
    /// </summary>
    /// <param name="onClickListener"></param>
    /// <returns></returns>
    private bool TryGetOnClickListener(out OnClickListener onClickListener)
    {
        Ray ray = CameraManager.instance.currentCam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            onClickListener = null;
            return false;
        }

        if (raycastHit.collider.gameObject.TryGetComponent(out onClickListener))
        {
            return true;
        }

        if (FindOnClickListenerInParents(raycastHit.collider.gameObject.transform, out onClickListener))
        {
            return true;
        }

        onClickListener = null;
        return false;
    }

/// <summary>
/// Recursivly searches for a <c>OnClickListener</c> component in the parents of given transform.
/// </summary>
/// <param name="target">Transform thats parents will be searched thou.</param>
/// <param name="onClickListener">The <c>OnClickListener</c> found in a parent objects.</param>
/// <returns>True if a <c>OnClickListener</c> was found.</returns>
    private bool FindOnClickListenerInParents(Transform target, out OnClickListener onClickListener)
    {
        Transform parent = target.parent;
        if (parent == null)
        {
            onClickListener = null;
            return false;
        }

        if (parent.gameObject.TryGetComponent(out onClickListener))
        {
            return true;
        }

        return FindOnClickListenerInParents(target, out onClickListener);
    }
}
