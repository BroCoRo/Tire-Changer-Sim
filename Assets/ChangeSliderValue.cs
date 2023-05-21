using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderValue : MonoBehaviour
{
    public Slider Slider;
    public float IncrementAmount;

    public void UpdateSliderValue()
    {
        Slider.value += IncrementAmount;
    }
}
