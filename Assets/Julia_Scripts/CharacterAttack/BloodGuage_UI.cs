using UnityEngine;
using UnityEngine.UI;

public class BloodGuage_UI : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBlood(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    
    public void SetBlood(float value)
    {
        slider.value = value;
    }

    
}
