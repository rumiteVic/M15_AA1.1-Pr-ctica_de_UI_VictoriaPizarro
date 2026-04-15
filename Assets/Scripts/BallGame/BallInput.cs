using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BallController))]
public class BallInput : MonoBehaviour
{
    //Se pone el inputSystem para poder usarlo aqui
    public InputSystem inputActions;

    BallController controller;
    public Vector2 move;
    private void Start()
    {
        controller = GetComponent<BallController>();
        inputActions = new InputSystem();
        inputActions.Player.Enable();
    }
    void Update()
    {
        //Se lee el inputActions de Move (WASD y joystick)
        move = inputActions.Player.Move.ReadValue<Vector2>();
        //Le pasamos el valor al ballController
        controller.Move(move);
        //Miramos si le da a la tecla de saltar y se envia a que salte en ballController
        if (inputActions.Player.Jump.WasPressedThisFrame())
        {
            controller.Jump();
        }
    }
}
