using System;
using UnityEngine;

public class RemoveInstall : MonoBehaviour
{
    private float speed = 10;
    private bool removing = false;
    private bool installing = false;
    private bool lug0removed = false;
    private bool lug1removed = false;
    private bool lug2removed = false;
    private bool lug3removed = false;
    private bool lug4removed = false;
    private bool tireremoved = false;
    private bool isActive = false;
    public bool allLugNutsRemoved = false;

    //This function takes in the bolt to unscrew and the destination of where to unscrew to
    private bool unscrewLugNut(Int32 bolt, Int32 destination)
    {
        transform.GetChild(0).transform.GetChild(bolt).transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime); //Rotate around a single plane
        // transform the lug nut out to the destination at the calculated speed
        // MoveTowards(the sub lug nut of the set to move, the destination of the set to move to, the speed to move at)
        transform.GetChild(0).transform.GetChild(bolt).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.GetChild(bolt).transform.position, transform.GetChild(0).transform.GetChild(destination).transform.position, speed * Time.deltaTime / 40);
        //If the bolt has reached its destination
        if (transform.GetChild(0).transform.GetChild(bolt).transform.position == transform.GetChild(0).transform.GetChild(destination).transform.position)
        {
            //Hide the bolt
            transform.GetChild(0).transform.GetChild(bolt).gameObject.SetActive(false);
            removing = false;
            return true;
        }
        return false;
    }

    //This function takes in the bolt to screw in and the destination of where to screw in to
    private bool screwLugNut(Int32 bolt, Int32 destination)
    {
        if (!isActive)
        {
            transform.GetChild(0).transform.GetChild(bolt).gameObject.SetActive(true);
            isActive = true;
        }
        transform.GetChild(0).transform.GetChild(bolt).transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); //Rotate around a single plane
        // transform the lug nut out to the destination at the calculated speed
        // MoveTowards(the sub lug nut of the set to move, the destination of the set to move to, the speed to move at
        transform.GetChild(0).transform.GetChild(bolt).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.GetChild(bolt).transform.position, transform.GetChild(0).transform.GetChild(destination).transform.position, speed * Time.deltaTime / 40);
        //If the bolt has reached its destination
        if (transform.GetChild(0).transform.GetChild(bolt).transform.position == transform.GetChild(0).transform.GetChild(destination).transform.position)
        {
            installing = false;
            isActive = false;
            return false;
        }
        return true;
    }

    //This function takes in the tire to remove and the destination of where to remove to
    private bool removeTire(Int32 tire, Int32 destination)
    {
        // transform the tire out to the destination at the calculated speed
        // MoveTowards(the tire to move, the destination of the tire to move to, the speed to move at)
        transform.GetChild(0).transform.GetChild(tire).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.GetChild(tire).transform.position, transform.GetChild(0).transform.GetChild(destination).transform.position, speed * Time.deltaTime / 40);
        //If the bolt has reached its destination
        if (transform.GetChild(0).transform.GetChild(tire).transform.position == transform.GetChild(0).transform.GetChild(destination).transform.position)
        {
            //Hide the tire
            transform.GetChild(0).transform.GetChild(tire).gameObject.SetActive(false);
            removing = false;
            return true;
        }
        return false;
    }

    //This function takes in the tire to install and the destination to install to
    private bool installSpare(Int32 spare, Int32 destination)
    {
        if (!isActive)
        {
            transform.GetChild(spare).gameObject.SetActive(true);
            isActive = true;
        }
        // transform the tire to the destination at the calculated speed
        // MoveTowards(the tire to move, the destination to move to, with the speed to move at
        transform.GetChild(spare).transform.position = Vector3.MoveTowards(transform.GetChild(spare).transform.position, transform.GetChild(destination).transform.position, speed * Time.deltaTime / 40);
        //If the bolt has reached its destination
        if (transform.GetChild(spare).transform.position == transform.GetChild(destination).transform.position)
        {
            installing = false;
            isActive = false;
            return false;
        }
        return true;
    }

    void Start()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If the user presses L remove the lug nut
        if (Input.GetKeyUp(KeyCode.L))
        {
            removing = true;
        }

        //If the user presses R install the lug nut
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (allLugNutsRemoved)
            {
                installing = true;
            }
        }

        //If removing the lug nut determine which lug nut to remove
        if (removing && !allLugNutsRemoved)
        {
            //follow the star pattern
            if (!lug1removed) //if lug nut is not removed yet remove it
            {
                lug1removed = unscrewLugNut(1, 5);
            }
            else if (!lug4removed) //if lug nut is not removed yet remove it
            {
                lug4removed = unscrewLugNut(4, 6);
            }
            else if (!lug0removed) //if lug nut is not removed yet remove it
            {
                lug0removed = unscrewLugNut(0, 7);
            }
            else if (!lug2removed) //if lug nut is not removed yet remove it
            {
                lug2removed = unscrewLugNut(2, 8);
            }
            else if (!lug3removed) //if lug nut is not removed yet remove it
            {
                lug3removed = unscrewLugNut(3, 9);
                if (lug3removed) //Update once all lug nuts are removed 
                {
                    allLugNutsRemoved = true;
                }
            }
        }
        //If installing the lug nut determine which lug nut to screw in
        else if (installing && !tireremoved)
        {
            //follow the star pattern
            if (lug1removed) //if lug nut is not screwed in yet screw it in
            {
                lug1removed = screwLugNut(1, 10);
            }
            else if (lug4removed) //if lug nut is not screwed in yet screw it in
            {
                lug4removed = screwLugNut(4, 11);
            }
            else if (lug0removed) //if lug nut is not screwed in yet screw it in
            {
                lug0removed = screwLugNut(0, 12);
            }
            else if (lug2removed) //if lug nut is not screwed in yet screw it in
            {
                lug2removed = screwLugNut(2, 13);
            }
            else if (lug3removed) //if lug nut is not screwed in yet screw it in
            {
                lug3removed = screwLugNut(3, 14);
                if (lug3removed) //Update once all lug nuts are installed 
                {
                    allLugNutsRemoved = false;
                }
            }
        }
        else if(removing && allLugNutsRemoved)
        {
            if (!tireremoved)
            {
                tireremoved = removeTire(15, 16);
            }
        }
        else if(installing && tireremoved)
        {
            if (tireremoved)
            {
                tireremoved = installSpare(2, 1);
            }
        }
    }
}
