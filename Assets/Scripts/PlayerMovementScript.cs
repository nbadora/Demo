using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Moving the character forward, backwards and sideways based on arrow keys or awsd keys.
// Jumping when pressing space.

public class PlayerMovementScript : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 12.0f;
    public float gravity = 20.0f;

    private Vector3 moveDir = Vector3.zero;
    private Camera camera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Changing the rotation of the camera 
        transform.rotation = camera.transform.rotation;

        if (characterController.isGrounded)
        {
            // If grounded recalculate movement direction

            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed;
            moveDir = transform.TransformDirection(moveDir);

            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }

        // Applying gravity
        moveDir.y -= gravity * Time.deltaTime;

        characterController.Move(moveDir * Time.deltaTime);
    }
}
