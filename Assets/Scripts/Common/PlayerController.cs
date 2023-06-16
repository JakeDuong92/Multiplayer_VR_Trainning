using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed                 = 1f;
    private float rotationSpeed             = 100f;
    private OVRInput.Axis2D rotationAxis = OVRInput.Axis2D.SecondaryThumbstick;
    private OVRInput.Axis2D moveAxis = OVRInput.Axis2D.PrimaryThumbstick;

    //public Transform lookTarget;
    //public Vector3 posStart;
    //public Vector3 posPlayer;
    //public Vector3 camDistance;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        //camDistance = lookTarget.position - transform.position;
    }
    void Update()
    {
        PlayerMove();
        //PlayerRotate();

        //FollowTarget();
    }

    void PlayerMove()
    {
        Vector2 moveInput = OVRInput.Get(moveAxis);

        // Calculate movement direction based on thumbstick input
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        movement *= moveSpeed * Time.deltaTime;
        Debug.Log($"X: {movement.x}, Y : {movement.y}, Z : {movement.z}");
        // Update the object's position
        //transform.position += movement;

        // Set animation parameters
        if (moveInput.y > 0f)
        {
            animator.SetFloat("animMove", 1f);
        }
        else if (moveInput.y == 0f)
        {
            animator.SetFloat("animMove", 0f);
        }
        else
        {
            animator.SetFloat("animMove", -1f);
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
    public void FollowTarget()
    {
        //transform.position = lookTarget.position - lookTarget.rotation * camDistance;
        //transform.LookAt(lookTarget);
    }

}
