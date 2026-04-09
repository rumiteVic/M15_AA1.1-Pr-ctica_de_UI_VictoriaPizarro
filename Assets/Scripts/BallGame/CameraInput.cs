using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CameraController))]
public class CameraInput : MonoBehaviour
{
    public InputSystem inputActions;
    CameraController controller;

    Vector2 look;
    public float sensibility = 0.3f;

    public RectTransform targetImage;
    public GameObject ballImage;
    public Camera cam;

    public BallGameManager man;

    Transform actualTarget;

    public GameObject ball;
    bool oculto = false;

    public Image ballUI;
    float maxAlpha = 1f;
    float semiAlpha = 0.5f;

    public BallInput ballInput;
    void Start()
    {
        controller = GetComponent<CameraController>();
        inputActions = new InputSystem();
        inputActions.Player.Enable();
        ballImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look = inputActions.Player.Look.ReadValue<Vector2>();
        
        if(ballInput.move.x == 0 && ballInput.move.y == 0){
            controller.Rotate(look.x * sensibility);
        }

        Vector2 zooming = inputActions.Player.Scroll.ReadValue<Vector2>();
        controller.Zoom(zooming.y * sensibility);

        actualTarget = man.currentTarget;

        Vector3 screenPos = cam.WorldToScreenPoint(actualTarget.position);

        screenPos.x = Mathf.Clamp(screenPos.x, 100, Screen.width -100);
        screenPos.y = Mathf.Clamp(screenPos.y, 50, Screen.height -50);

        targetImage.position = screenPos;

        RaycastHit hit;
        Vector3 dir = ball.transform.position - cam.transform.position;
        float distancia = dir.magnitude;
        Ray rayo = new Ray(cam.transform.position, dir.normalized);
        if(Physics.Raycast(rayo, out hit, distancia)){
            if(hit.transform != ball.transform){
                oculto = true;
            }
            else{
                oculto = false;
            }
        }

        if(oculto){
            ballImage.SetActive(true);
            Vector3 ballPos = cam.WorldToScreenPoint(ball.transform.position);
            screenPos.x = ballPos.x;
            screenPos.y = ballPos.y;
            ballImage.transform.position = ballPos;
            
            if(actualTarget != ball.transform){
                ballUI.color = new Color(1f, 1f, 1f, semiAlpha);
            }
            else{
                ballUI.color = new Color(1f, 1f, 1f, maxAlpha);
            }
        }
        else{
            ballImage.SetActive(false);
        }

        
        
        
    }
}
