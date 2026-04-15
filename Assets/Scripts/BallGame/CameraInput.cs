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

    float offset = 50f;

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
        //Se lee el valor del raton moviendose o el dedo
        Vector2 look = inputActions.Player.Look.ReadValue<Vector2>();
        //Si no se mueve la pelota entonces podemos rotar la camara (se le pasa el valor al controlador)
        if(ballInput.move.x == 0 && ballInput.move.y == 0){
            controller.Rotate(look.x * sensibility);
        }
        //Leemos el zoom del scroll del raton y se lo pasamos a la camara
        Vector2 zooming = inputActions.Player.Scroll.ReadValue<Vector2>();
        controller.Zoom(zooming.y * sensibility);

        //Obtenemos la posición del target al cual debemos de ir
        actualTarget = man.currentTarget;
        //Creamos un Vector3 que se guarda la posición del target que se la pasa
        //de posición del mundo a un punto en la pantalla
        Vector3 screenPos = cam.WorldToScreenPoint(actualTarget.position);

        //Si el target está detrás invertimos la screenPos ya que se invierte
        //Cuando está detrás
        if(screenPos.z < 0){
            screenPos *= -1;
        }
        //Ponemos un margen de como de lejos puede llegar y un mínimo
        screenPos.x = Mathf.Clamp(screenPos.x, 0, Screen.width - offset);
        screenPos.y = Mathf.Clamp(screenPos.y, 0, Screen.height - offset);
        //Aplicado los margenes se le da a la imagen esa posición "idilica"
        targetImage.position = screenPos;

        //Creamos un raycast entre la camara y la bola
        //Si choca con algo entonces se pone en true oculto que hará cosas (explicadas más abajo)
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

        //Si está oculto se activa (se pone visible) la imagen de la bola
        //Se pone en un Vector3 la posición de la bola en el mundo pasada a posición de pantalla
        //Y se le da ese valor
        //Si la camara mira a la bola directamente (la bola es el target de observacion)
        //El alpha será el máximo sino, será la mitad
        if(oculto){
            ballImage.SetActive(true);
            Vector3 ballPos = cam.WorldToScreenPoint(ball.transform.position);
            ballImage.transform.position = ballPos;
            
            if(actualTarget != ball.transform){
                ballUI.color = new Color(1f, 1f, 1f, semiAlpha);
            }
            else{
                ballUI.color = new Color(1f, 1f, 1f, maxAlpha);
            }
        }
        //Si esta visible la bola y se ve bien se oculta el ballImage
        else{
            ballImage.SetActive(false);
        }
    }
}
