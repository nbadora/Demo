using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that lets the player spawn and shoot projectiles in the direction the player is facing

public class ShootingScript : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 2000f;

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.AddForce(shotPos.forward * shotForce);
        } 
    }
}
