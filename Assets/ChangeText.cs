using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI TipOne;
    public TextMeshProUGUI TipTwo;
    public TextMeshProUGUI TipThree;
    public TextMeshProUGUI TipFour; 
    public TextMeshProUGUI TipFive;
    public TextMeshProUGUI TipSix;
    public TextMeshProUGUI TipSeven;
    public TextMeshProUGUI TipEight;
    public TextMeshProUGUI TipNine;
    public TextMeshProUGUI TipTen;
    public TextMeshProUGUI TipEleven;
    public TextMeshProUGUI TipTwelve;
    public Slider Slider;
    private float IncrementAmount = 0.25f;


    // Start is called before the first frame update
    void Start()
    {   
        TipOne = GetComponentInParent<TextMeshProUGUI>(TipOne);
        TipOne.enabled = true;
        TipTwo.enabled = false;
        TipThree.enabled = false;
        TipFour.enabled = false;
        TipFive.enabled = false;
        TipSix.enabled = false;
        TipSeven.enabled = false;
        TipEight.enabled = false;
        TipNine.enabled = false;
        TipTen.enabled = false;
        TipEleven.enabled = false;
  
    }

    // Update is called once per frame
    void Update()
    {
        // tip 1 chaning to 2 
        if (TipOne.enabled && (Input.GetKeyDown(KeyCode.Alpha0)))
        {
            TipOne.enabled = false;
            TipTwo.enabled = true;                 
        }
        // tip 2 changing to 3
        else if (TipTwo.enabled && (Input.GetKeyDown(KeyCode.Alpha1)))
        {
            TipTwo.enabled = false;
            TipThree.enabled = true;
        }
        // tip 3 chaning to 4
        else if (TipThree.enabled && (Input.GetKeyDown(KeyCode.Alpha2)))
        {
            TipThree.enabled = false;
            TipFour.enabled = true;
            Slider.value += IncrementAmount;
        }
        // tip 4 chaning to 5
        else if (TipFour.enabled && (Input.GetKeyDown(KeyCode.Alpha3)))
        {
            TipFour.enabled = false;
            TipFive.enabled = true;
        }
        // tip 5 chaning to 6
        else if (TipFive.enabled && (Input.GetKeyDown(KeyCode.Alpha4)))
        {
            TipFive.enabled = false;
            TipSix.enabled = true;
        }
        // tip 6 chaning to 7
        else if (TipSix.enabled && (Input.GetKeyDown(KeyCode.Alpha5)))
        {
            TipSix.enabled = false;
            TipSeven.enabled = true;
            Slider.value += IncrementAmount;
        }
        // tip 7 chaning to 8
        else if (TipSeven.enabled && (Input.GetKeyDown(KeyCode.Alpha6)))
        {
            TipSeven.enabled = false;
            TipEight.enabled = true;
        }
        // tip 8 chaning to 9
        else if (TipEight.enabled && (Input.GetKeyDown(KeyCode.Alpha7)))
        {
            TipEight.enabled = false;
            TipNine.enabled = true;
        }
        // tip 9 chaning to 10
        else if (TipNine.enabled && (Input.GetKeyDown(KeyCode.Alpha8)))
        {
            TipNine.enabled = false;
            TipTen.enabled = true;
            Slider.value += IncrementAmount;
        }
        // tip 10 chaning to 11
        else if (TipTen.enabled && (Input.GetKeyDown(KeyCode.Alpha9)))
        {
            TipTen.enabled = false;
            TipEleven.enabled = true;
            Slider.value += IncrementAmount;
        }
        // tip 11 chaning to 1
        else if (TipEleven.enabled && (Input.GetKeyDown(KeyCode.Q)))
        {
            TipEleven.enabled = false;
            TipOne.enabled = true;
        }
    }
}


