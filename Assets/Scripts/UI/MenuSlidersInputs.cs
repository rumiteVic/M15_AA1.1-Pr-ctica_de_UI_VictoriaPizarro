using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuSlidersInputs : MonoBehaviour
{
    public RectTransform menu;
    public Slider scaleSlid;
    float inputValue;

    public RectTransform safeZone;
    public Slider safeHor;
    public Slider safeVer;

    Vector2 oriSafSize;
    float safeX;
    float safeY;

    public CameraInput cameraInput;
    float sensibilityInput;
    public Slider camSen;

    public TMP_InputField inputScale;
    public TMP_InputField inputHori;
    public TMP_InputField inputVert;
    public TMP_InputField inputSens;

    void Start()
    {
        inputValue = scaleSlid.value;
        oriSafSize = safeZone.sizeDelta;
        safeX = safeHor.value;
        safeY = safeVer.value;
        camSen.value = sensibilityInput;
        sensibilityInput = cameraInput.sensibility;
        ApplyScale();
        ApplySafeScale();
    }

    //Slider del Scale
    public void OnSliderScale(float value){
        inputValue = value;
        ApplyScale();
    }
    //Botones del scale se incrementa con el valor que le demos a value (en el propio boton, el inspector)
    public void IncreaseScale(float value){
        inputValue += value;
        ApplyScale();
    }
    //Se aplica la escala teniendo de referencia los valores minimos y maximos del slider
    //Luego se pasa ese valor al slider y se aplica la escala
    //También se le pasa ese valor al inputText (de cada uno de ellos)
    public void ApplyScale(){
        inputValue = Mathf.Clamp(inputValue, scaleSlid.minValue, scaleSlid.maxValue);
        scaleSlid.value = inputValue;
        menu.localScale = new Vector3(inputValue, inputValue, 1f);
        inputScale.text = inputValue.ToString();
    }
    //Se lee el valor del inputText se pasa ese valor a un float, si se puede, se aplica
    //Y si no, no se pone (en el resto se hace lo mismo pero cada uno con su valor y sus sliders, botones e inputsText)
    public void ReadScale(string texto){
        if(float.TryParse(texto, out float numero)){
            inputValue = numero;
            ApplyScale();
        }
        else{
            return;
        }
    }

    //Safe Zone Horizontal
    public void OnSliderSafeHorizontal(float value){
        safeX = value;
        ApplySafeScale();
    }

    public void IncreaseSafeHor(float value){
        safeX += value;
        ApplySafeScale();
    }

    public void ReadSafeHor(string texto){
        if(float.TryParse(texto, out float numero)){
            safeX = numero;
            ApplySafeScale();
        }
        else{
            return;
        }
    }

    public void ApplySafeScale(){
        safeX = Mathf.Clamp(safeX, safeHor.minValue, safeHor.maxValue);
        safeY = Mathf.Clamp(safeY, safeVer.minValue, safeVer.maxValue);
        safeHor.value = safeX;
        safeVer.value = safeY;
        safeZone.sizeDelta = new Vector2(oriSafSize.x * safeX, oriSafSize.y * safeY);
        inputHori.text = safeX.ToString();
        inputVert.text = safeY.ToString();
    }

    //Safe Zone Vertical
    public void OnSliderSafeVertical(float value){
        safeY = value;
        ApplySafeScale();
    }
    
    public void IncreaseSafeVer(float value){
        safeY += value;
        ApplySafeScale();
    }

    public void ReadSafeVer(string texto){
        if(float.TryParse(texto, out float numero)){
            safeY = numero;
            ApplySafeScale();
        }
        else{
            return;
        }
    }

    //Sensibility camera
    public void OnSliderSensibility(float value){
        sensibilityInput = value;
        ApplySensi();
    }

    public void OnIncreaseSensi(float value){
        sensibilityInput += value;
        ApplySensi();
    }

    public void ApplySensi(){
        sensibilityInput = Mathf.Clamp(sensibilityInput, camSen.minValue, camSen.maxValue);
        camSen.value = sensibilityInput;
        cameraInput.sensibility = sensibilityInput;
        inputSens.text = sensibilityInput.ToString();
    }

     public void ReadSensibility(string texto){
        if(float.TryParse(texto, out float numero)){
            sensibilityInput = numero;
            ApplySensi();
        }
        else{
            return;
        }
    }
}
