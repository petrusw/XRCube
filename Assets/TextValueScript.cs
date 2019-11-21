using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextValueScript : MonoBehaviour
{
    [SerializeField] private Text sliderText;
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    private void OnEnable()
    {
        slider.onValueChanged.AddListener(ChangeValue);
        ChangeValue(slider.value );
    }
    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }


    private void ChangeValue(float value)
    {
        sliderText.text = value.ToString();
    }
}
