using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that allows raycasting and by it interacting with objects

public class RaycastScript : MonoBehaviour
{
    public GameObject holdPos;

    private GameObject pointingAt = null;
    private RaycastHit hit;
    private bool justGrabbed = false;
    private bool holding = false;

    void Start()
    {
        // Finding destined position after picking an item up
        holdPos = transform.Find("holdPos").gameObject;
    }

    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;        

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E) && !holding)
            {
                hit.collider.GetComponent<IInteractionableScript>().StartInteraction(this.gameObject);
                if (holdPos.transform.childCount>0)
                {
                    holding = true;
                    justGrabbed = true;
                }
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);           
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        
        // Letting go of the object 
        if (Input.GetKeyDown(KeyCode.E) && holding)
        {
            if (!justGrabbed)
            {
                holdPos.transform.GetChild(0).GetComponent<IInteractionableScript>().StopInteraction(this.gameObject);
                holding = false;
            }
            justGrabbed = false;
        }
    }    
}
