using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    bool trunkOpen = false;
    bool opening = false;
    bool closing = false;

    // Update is called once per frame
    void Update()
    {
        //if the user presses the t key the trunk will open or close
        if (Input.GetKeyUp(KeyCode.T))
        {
            //open if trunk closed
            if(!trunkOpen)
            {
                opening = true;
            }
            //close if trunk open
            else
            {
                closing = true;
            }
        }

        //This will allow the trunk to smoothly open until it reaches its fully open point
        if(opening) 
        {
            transform.Rotate(new Vector3(0, 0, 1));//rotate forwards

            //open the trunk by rotating until it reachs a z rotation of 67 then stop rotating
            if (Mathf.Round(transform.eulerAngles.z) == 67)
            {
                transform.Rotate(new Vector3(0, 0, -1));//stop rotation at
                opening = false; //trunk is no longer opening - it reached its stop point
                trunkOpen = true; //the trunk is open
            }
        }
        //This will allow the trunk to smoothly close until it reaches its fully closed point
        else if (closing)
        {
            transform.Rotate(new Vector3(0, 0, -1));//rotate backwards

            //open the trunk by rotating backwards until it reachs a z rotation of 0 then stop rotating
            if (Mathf.Round(transform.eulerAngles.z) == 0)
            {
                transform.Rotate(new Vector3(0, 0, -2));//stop rotation at
                closing = false; //trunk is no longer closing - it reached its stop point
                trunkOpen = false; //the trunk is closed
            }
        }
       
    }
}
