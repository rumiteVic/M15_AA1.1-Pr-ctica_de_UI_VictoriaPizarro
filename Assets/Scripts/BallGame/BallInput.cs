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

    public JoystickVirtual joy;
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
        //Si no se mueve el joystick se permite moverse con wasd
        if(joy.input.x == 0 || joy.input.y == 0)
        {
            controller.Move(move);
        }
        //Si se mueve el joystick se pasa este valor
        else
        {
            controller.Move(joy.input);
        }
        
        
        //Miramos si le da a la tecla de saltar y se envia a que salte en ballController
        if (inputActions.Player.Jump.WasPressedThisFrame())
        {
            controller.Jump();
        }
    }
}
