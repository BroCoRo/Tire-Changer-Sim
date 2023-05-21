using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAngleButtonHandler : MonoBehaviour
{
    public Camera wheelCamera;
    public Camera carjackCamera;
    public Camera wholeCarCamera;
    public Camera trunkCamera;

    public Camera cameraToActivate;
  
    public void SwitchCameras()
    {
        wheelCamera.gameObject.SetActive(false);
        carjackCamera.gameObject.SetActive(false);
        wholeCarCamera.gameObject.SetActive(false);
        trunkCamera.gameObject.SetActive(false);

        cameraToActivate.gameObject.SetActive(true);       
    }
}
