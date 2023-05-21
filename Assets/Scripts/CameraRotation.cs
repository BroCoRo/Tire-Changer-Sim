using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float CameraRotateSpeed; 
    public Camera MainCamera;
    private float maxRightRotationAngle = 0.90f;
    private float maxLeftRotationAngle = 0.35f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, CameraRotateSpeed * Time.deltaTime, 0);
        if (MainCamera.transform.rotation.y >= maxRightRotationAngle)
        {

            CameraRotateSpeed = CameraRotateSpeed * -1;
           
        }
        else if (MainCamera.transform.rotation.y <= maxLeftRotationAngle)
        {
            CameraRotateSpeed = CameraRotateSpeed * -1;
        }
    }
}
