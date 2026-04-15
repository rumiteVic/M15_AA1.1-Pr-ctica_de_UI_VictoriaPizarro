using UnityEngine;
using UnityEngine.EventSystems;
public class UI_Canvas : MonoBehaviour
{

    public GameObject menu;
    public GameObject menuLista;

    public Animator animator;

    public GameObject barra;
    bool isOpen = false;
    public GameObject[] buttons;
    public int index = 0;
    int maxButtons;

    public GameObject joystick;

    public JoystickVirtual joy;

    Vector3 positionJoystickInicial;

    public GameObject botonIn;
    public GameObject otherBoton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxButtons = buttons.Length;
        positionJoystickInicial = joystick.transform.position;
    }

    //Pone visible el menu con sus parametros cambiables
    public void ShowMenu(){
        menu.SetActive(true);
        menuLista.SetActive(false);
    }

    //Pone visible el menu con una lista de cosas borrables
    public void ShowListas(){
        menu.SetActive(false);
        menuLista.SetActive(true);
    }
    //Pone visible el menu en si (con una animación) y pone el tiempo a 0
    
    public void ShowHiddenMenu(){
        isOpen = animator.GetBool("move");
        animator.SetBool("move", !isOpen);
        if(!isOpen){
            barra.SetActive(true);
            otherBoton.SetActive(true);
            botonIn.SetActive(false);
            Time.timeScale = 0f;
        }
        //Si está visible lo pone en "invisible"
        else{
            otherBoton.SetActive(false);
            botonIn.SetActive(true);
            Time.timeScale = 1f;
            barra.SetActive(false);
        }
    }
    //Permite cambiar entre la visibilidad de 3 botones (el que muestra el target, la bola y un punto intermedio)
    public void ShowAndHiddeButtons(){
        buttons[index].SetActive(false);
        index = index + 1;
        if(index >= maxButtons){
            index = 0;
        }
        buttons[index].SetActive(true);
    }

    //Permite (o no) que se pueda mover el Joystick de su sitio
    public void MovableJoystick(){
        joy.reposition = !joy.reposition;
        joystick.transform.position = positionJoystickInicial;
    }

}
