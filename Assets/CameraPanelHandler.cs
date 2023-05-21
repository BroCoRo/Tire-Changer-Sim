using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPanelHandler : MonoBehaviour
{
    public GameObject panel;
    public Image buttonImage;
    public Sprite openImage;
    public Sprite closeImage;

    public void LoadNewPanel()
    {
        if (panel != null && panel.activeSelf == false)
        {
            panel.SetActive(true);
            buttonImage.sprite = closeImage;
        }
        else
        {
            panel.SetActive(false);
            buttonImage.sprite = openImage;
        }
    }
}
