using UnityEngine;

public class UI_Canvas : MonoBehaviour
{

    public GameObject menu;
    public GameObject menuLista;

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ShowMenu(){
        menu.SetActive(true);
        menuLista.SetActive(false);
    }

    public void ShowListas(){
        menu.SetActive(false);
        menuLista.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHiddenMenu(){
        bool isOpen = animator.GetBool("move");
        animator.SetBool("move", !isOpen);
    }
}
