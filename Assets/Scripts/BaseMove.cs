using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform transGroudChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    private bool isGrounded;
    private Vector3 velocity;
    private Vector3 _movement;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transGroudChecker.position, groundDistance, groundMask);
        _movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        
        controller.Move(_movement / 10);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
