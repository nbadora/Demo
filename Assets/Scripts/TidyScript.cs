using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroying projectiles after 5 seconds after spawned
public class TidyScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}
