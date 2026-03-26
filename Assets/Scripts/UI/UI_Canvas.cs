using UnityEngine;
using UnityEngine.EventSystems;
public class UI_Canvas : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public GameObject menu;
    public GameObject menuLista;

    public Animator animator;

    public RectTransform menuW;
    public float minWidth = 200f;
    public float maxWidth = 600f;
    float newWidth = 0f;

    public Vector2 barra = new Vector2(52f, 3f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newWidth = menu.sizeDelta.x;
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

    public void OnDrag(PointerEventData data){
        newWidth = menuW.sizeDelta.x + data.delta.x;
        newWidth = Mathf.Clamp(newWidth, minWidth, maxWidth);

        menuW.sizeDelta = new Vector2(newWidth, menuW.sizeDelta.y);
    }

    public void OnEndDrag(PointerEventData data)
    {
        
    }
}
