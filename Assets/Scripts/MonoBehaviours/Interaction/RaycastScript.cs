using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastScript : MonoBehaviour
{
    //public UnityEvent OnRaycastHit;

    private Interactable currentInteractable;   // The interactable that is currently being headed towards.
    private Vector3 destinationPosition;        // The position that is currently being headed towards, this is the interactionLocation of the currentInteractable if it is not null.
    private bool handleInput = true;            // Whether input is currently being handled.
    private WaitForSeconds inputHoldWait;       // The WaitForSeconds used to make the user wait before input is handled again.
    private Interactable hitObject;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    public LayerMask myLayerMaskInteractable;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Draw Ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        //Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            //ray = new Ray(mainCamera.ScreenToWorldPoint(Input.mousePosition), mainCamera.transform.forward);
            ray = new Ray(transform.position, mousePos - transform.position);
            //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            Debug.Log("Firing");
            //Debug.DrawRay(mainCamera.ScreenToWorldPoint(Input.mousePosition), mainCamera.transform.forward);
            Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

            if (Physics.Raycast(ray, out hit, 100f, myLayerMaskInteractable))
            {
                Debug.Log("Hit Something");
 
                if (hit.collider.gameObject.GetComponent<Interactable>() != null)
                {
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                }

                //if (hit.transform == transform)
                //{
                //    Debug.Log("Click " + name);
                //    //Debug.Log(hit.transform.name);
                //    //hit.transform.GetComponent<Renderer>().material.color = Color.red;
                //    OnRaycastHit?.Invoke();

                //}
            }
        }
    }

    public void OnInteractableClick(Interactable interactable)
    {
        Debug.Log("Click");

        // If the handle input flag is set to false then do nothing.
        if (!handleInput)
            return;

        // Store the interactble that was clicked on.
        currentInteractable = interactable;
        currentInteractable.Interact();

        // Set the destination to the interaction location of the interactable.
        // destinationPosition = currentInteractable.interactionLocation.position;

        // Set the destination of the nav mesh agent to the found destination position and start the nav mesh agent going.
        //agent.SetDestination(destinationPosition);
        //agent.isStopped = false;
    }
}
