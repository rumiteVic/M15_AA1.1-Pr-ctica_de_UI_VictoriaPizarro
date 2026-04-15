using UnityEngine;

public class UIController : MonoBehaviour
{
    //Permite destruir (borrar) un objeto creado en la lista
    public void DeleteObject(GameObject obj)
    {
        Destroy(obj);
    }
}
