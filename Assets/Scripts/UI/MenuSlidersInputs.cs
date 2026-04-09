using UnityEngine;
using UnityEngine.UI;

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

    //Scale
    public void OnSliderScale(float value){
        inputValue = value;
        ApplyScale();
    }

    public void IncreaseScale(float value){
        inputValue += value;
        ApplyScale();
    }

    public void ApplyScale(){
        inputValue = Mathf.Clamp(inputValue, scaleSlid.minValue, scaleSlid.maxValue);
        scaleSlid.value = inputValue;
        menu.localScale = new Vector3(inputValue, inputValue, 1f);
    }

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
