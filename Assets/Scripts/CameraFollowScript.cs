using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A script that allowys camera following the player an orbiting around them

public class CameraFollowScript : MonoBehaviour
{
    public bool lookAtMe = true;
    public Vector3 newPos;
    public Transform playerTrans;
    public bool rotateAroundMe = true;
    public float rotationSpeed = 5.0f;
    [Range(0.03f, 1.0f)]
    public float smoothness = 1f;    

    private Vector3 cameraOffset;

    void Start()
    {
        // Calculate camera offset
        cameraOffset = transform.position - playerTrans.position;
    }

    void Update()
    {
        // Rotating the camera around player while moving mouse 
        if (rotateAroundMe)
        {
            Quaternion camAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffset = camAngle * cameraOffset;
        }

        // Changing the vector position so the player will move accordingly to the camera's coordinate system
        newPos = playerTrans.position + cameraOffset;
        
        // Calculating the new camera position and adding smoothness to the camera movement
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);

        // Camera rotating towards the player
        if (lookAtMe || rotateAroundMe) transform.LookAt(playerTrans);
    }
}
