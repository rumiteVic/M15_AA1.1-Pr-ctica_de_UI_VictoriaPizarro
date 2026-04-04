using UnityEngine;
using UnityEngine.EventSystems;
public class MenuEscalable : MonoBehaviour, IDragHandler
{
    
    public RectTransform menuW;
    public float minWidth = 182f;
    public float maxWidth = 350f;
    float newWidth = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newWidth = menuW.sizeDelta.x;
    }

    public void OnDrag(PointerEventData data){
        newWidth = menuW.sizeDelta.x + data.delta.x;
        newWidth = Mathf.Clamp(newWidth, minWidth, maxWidth);

        menuW.sizeDelta = new Vector2(newWidth, menuW.sizeDelta.y);
    }
}
