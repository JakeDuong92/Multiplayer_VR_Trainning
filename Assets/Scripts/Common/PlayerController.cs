using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed                 = 1f;
    private float rotationSpeed             = 100f;
    private OVRInput.Axis2D rotationAxis    = OVRInput.Axis2D.SecondaryThumbstick;
    private OVRInput.Axis2D moveAxis        = OVRInput.Axis2D.PrimaryThumbstick;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void PlayerMove()
    {
        Vector2 moveInput = OVRInput.Get(moveAxis);

        // Calculate movement direction based on thumbstick input
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        movement *= moveSpeed * Time.deltaTime;

        // Update the object's position
        transform.position += movement;

        // Set animation parameters
        if (moveInput.magnitude > 0)
        {
            animator.SetBool("MoveSpeed", true);
        }
        else
        {
            animator.SetBool("MoveSpeed", false);
        }
        
    }

    void PlayerRotate()
    {
        Vector2 rotateInput = OVRInput.Get(rotationAxis);

        // Calculate rotation angle based on thumbstick input
        float rotationAngle = rotateInput.x * rotationSpeed * Time.deltaTime;

        // Rotate the object around the Y-axis
        transform.Rotate(0f, rotationAngle, 0f);
    }

    void Update()
    {
        PlayerMove();
        PlayerRotate();
    }
}
