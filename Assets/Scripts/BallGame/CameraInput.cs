using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CameraController))]
public class CameraInput : MonoBehaviour
{
    public InputSystem inputActions;
    CameraController controller;
    void Start()
    {
        controller = GetComponent<CameraController>();
        inputActions = new InputSystem();
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Rotate(inputActions.Player.Look.GetControlMagnitude());
    }
}
