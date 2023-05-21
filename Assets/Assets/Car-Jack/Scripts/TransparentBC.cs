using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentBC : MonoBehaviour
{
    public GameObject transparentJack;
    public GameObject transparentBC;
    public GameObject transparentExtendedBC;
    public GameObject compressedJack;
    public GameObject extendedJack;
    public GameObject car;

    Vector3 newCarPosition = new Vector3(0, 0.10f, 0);
    Vector3 newCarRotation = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {
        // change this to the condition within the UI, or when we want to show the user where to put the jack
        // When we have that, change the set object to true, and maybe add sound effects
        transparentJack.SetActive(true);
        compressedJack.SetActive(false);
        extendedJack.SetActive(false);
        transparentExtendedBC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                Debug.Log("This is getting hit");
                // this is to make sure the user clicked the collider box, and will display the real 
                if (hitInfo.transform.gameObject.tag == "TransparentBC")
                {
                    if (hitInfo.transform.gameObject.tag == "TransparentBC" && compressedJack.activeInHierarchy == true)
                    {
                        // Make the compressed jack active false, translate the car so that is it jacked up, and set the extended jack
                        // to be active
                        compressedJack.SetActive(false);
                        extendedJack.SetActive(true);

                        transparentExtendedBC.SetActive(true);
                        transparentBC.transform.position = new Vector3(100, 0, 0);

                        car.transform.eulerAngles = newCarRotation;
                        car.transform.position = newCarPosition;


                    }
                    else if (hitInfo.transform.gameObject.tag == "TransparentBC" && transparentJack.activeInHierarchy == true)
                    {
                        transparentJack.SetActive(false);
                        compressedJack.SetActive(true);
                    }

                }
                else if (hitInfo.transform.gameObject.tag == "TransparentExtendedBC")
                {
                    // This will need a condition about all the new lug nuts being put on the donut

                    extendedJack.SetActive(false);
                    transparentExtendedBC.SetActive(false);
                    compressedJack.SetActive(true);
                    transparentBC.transform.position = new Vector3(-0.838f, 0.071f, -0.652f);
                    car.transform.eulerAngles = new Vector3(0, 0, 0);
                    car.transform.position = new Vector3(0, 0, 0);
                }
            }  
        }
    }
}