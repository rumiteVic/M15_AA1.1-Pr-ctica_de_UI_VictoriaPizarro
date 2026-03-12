using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BallController))]
public class BallInput : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputAction m_moveAction;
    private InputAction m_jumpAction;
    BallController controller;
    private void Start()
    {
        controller = GetComponent<BallController>();
    }
    void Update()
    {

    }
}
