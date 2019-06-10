using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script added to an object allows it to be interacted with

public class HoldScript : MonoBehaviour, IInteractionableScript
{
    public void StartInteraction(GameObject o)
    {
        // Moving the object to the destined holding position
        transform.parent = o.transform.Find("holdPos");        
    }

    public void StopInteraction(GameObject o)
    {
        // Letting the ball go
        transform.parent = null;        
    }
}
