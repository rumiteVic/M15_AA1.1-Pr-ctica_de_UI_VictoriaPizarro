using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(BallController))]
public class BallInput : MonoBehaviour
{
    public InputSystem inputActions;

    BallController controller;
    private void Start()
    {
        controller = GetComponent<BallController>();
        inputActions = new InputSystem();
        inputActions.Player.Enable();
    }
    void Update()
    {
        controller.Move(inputActions.Player.Move.ReadValue<Vector2>());
        if (inputActions.Player.Jump.WasPressedThisFrame())
        {
            controller.Jump();
        }
    }
}
