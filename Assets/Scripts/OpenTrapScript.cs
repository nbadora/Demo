using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that allows rotating the "trap door" so it "opens"

public class OpenTrapScript : MonoBehaviour
{    
    public float rotSpeed = 60f;
    public Transform edgePivotPoint;
    public GameObject trap;
    public float max_rot = 90;

    private float act_rot = 0;
    private float rotation;
    private bool triggered = false;

    // Triggered when pushing the switch
    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    private void Update()
    {
        if (triggered && act_rot < max_rot)
        {
            // Calculating angle per second
            rotation = rotSpeed * Time.deltaTime;
            // Rotation trap
            trap.transform.RotateAround(edgePivotPoint.position, -trap.transform.right, rotation);
            // Changing actual rotation 
            act_rot += rotation;
        }
    }
}