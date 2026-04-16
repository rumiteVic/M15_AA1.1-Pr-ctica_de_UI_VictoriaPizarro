using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickVirtual : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public RectTransform joystickParent;
    public RectTransform joystick;
    public RectTransform joystickGhost;
    public float maxRadius;

    public Vector2 input;


    public bool reposition = false;
    public void OnBeginDrag(PointerEventData data)
    {
        if (reposition)
        {
            joystickParent.position = data.position;
        }


        joystick.transform.position = data.position;
        joystickGhost.transform.position = data.position;
    }

    
    public void OnDrag(PointerEventData data)
    {    
        Vector3 dir = (Vector3)data.position - joystickParent.position;
        float distance = dir.magnitude;

        if (distance > maxRadius)
        {
            dir.Normalize();
            dir *= maxRadius;
        }
        joystick.transform.position = joystickParent.position + dir;
        joystickGhost.transform.position = data.position;
        input = dir / maxRadius;
    }



    public void OnEndDrag(PointerEventData data)
    {
        joystick.localPosition = Vector3.zero;
        joystickGhost.localPosition = Vector3.zero;
    }
    
}
