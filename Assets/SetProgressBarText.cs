using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetProgressBarText : MonoBehaviour
{

    public TextMeshProUGUI progressBarText;
    public Slider slider;
    public Image sliderFill;

    public void UpdateText()
    {
        double currValue = Math.Round(slider.value * 100);
        progressBarText.text = currValue + "%";
        if (currValue >= 0 && currValue <= 33)
        {
            progressBarText.color = Color.red;
            sliderFill.color = Color.red;
        }
        if(currValue >= 34 && currValue <= 66)
        {
            progressBarText.color = Color.yellow;
            sliderFill.color = Color.yellow;
        }
        if (currValue >= 67)
        {
            progressBarText.color = Color.green;
            sliderFill.color = Color.green;
        }
    }
}
