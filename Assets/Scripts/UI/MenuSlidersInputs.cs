using UnityEngine;
using UnityEngine.UI;

public class MenuSlidersInputs : MonoBehaviour
{
    public RectTransform menu;
    public Slider scaleSlid;

    private Vector2 originalSize;
    float inputValue;

    public RectTransform safeZone;
    public Slider safeHor;
    public Slider safeVer;

    Vector2 oriSafSize;
    float safeX;
    float safeY;

    void Start()
    {
        originalSize = menu.sizeDelta;
        inputValue = scaleSlid.value;
        oriSafSize = safeZone.sizeDelta;
        safeX = safeHor.value;
        safeY = safeVer.value;
    }

    public void OnSliderScale(float value){
        inputValue = Mathf.Clamp(value, scaleSlid.minValue, scaleSlid.maxValue);
        ApplyScale();
    }

    public void IncreaseScale(float value){
        inputValue += value;
        inputValue = Mathf.Clamp(inputValue, scaleSlid.minValue, scaleSlid.maxValue);
        scaleSlid.value = inputValue;
        ApplyScale();
    }

    public void ApplyScale(){
        menu.sizeDelta = originalSize * inputValue;
    }

    public OnSliderSafeHorizontal(float value){
        safeX = Mathf.Clamp(value, safeHor.minValue, safeHor.maxValue);
        ApplySafeScale();
    }

    public OnSliderSafeVertical(float value){
        safeY = Mathf.Clamp(value, safeVer.minValue, safeVer.maxValue);
        ApplySafeScale();
    }

    public void ApplySafeScale(){
        safeZone.sizeDelta = new Vector2(oriSafSize.x * safeX, oriSafSize.y * safeY);
    }
}
