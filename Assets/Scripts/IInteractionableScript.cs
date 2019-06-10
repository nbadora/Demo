using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface script. Made for interacting with items - specifically picking them up

public interface IInteractionableScript
{
    void StartInteraction(GameObject o);
    void StopInteraction(GameObject o);
}