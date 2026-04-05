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

    public JoystickVirtual joy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxButtons = buttons.Length;
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
        }
        else{
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
    }

}
