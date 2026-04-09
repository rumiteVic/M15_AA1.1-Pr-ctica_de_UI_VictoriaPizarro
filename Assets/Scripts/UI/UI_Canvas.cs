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

    public void ShowMenu(){
        menu.SetActive(true);
        menuLista.SetActive(false);
    }

    public void ShowListas(){
        menu.SetActive(false);
        menuLista.SetActive(true);
    }

    public void ShowHiddenMenu(){
        isOpen = animator.GetBool("move");
        animator.SetBool("move", !isOpen);
        if(!isOpen){
            barra.SetActive(true);
            otherBoton.SetActive(true);
            botonIn.SetActive(false);
            Time.timeScale = 0f;
        }
        else{
            otherBoton.SetActive(false);
            botonIn.SetActive(true);
            Time.timeScale = 1f;
            barra.SetActive(false);
        }
    }

    public void ShowAndHiddeButtons(){
        buttons[index].SetActive(false);
        index = index + 1;
        if(index >= maxButtons){
            index = 0;
        }
        buttons[index].SetActive(true);
    }

    public void MovableJoystick(){
        joy.reposition = !joy.reposition;
        joystick.transform.position = positionJoystickInicial;
    }

}
