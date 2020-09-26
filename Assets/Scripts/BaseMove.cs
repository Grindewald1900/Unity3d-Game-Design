using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform transGroudChecker;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public float gravity = -20f;
    public float jumpHeight = 3f;
    public float playerSpeed = 5f;
    
    private bool _isGrounded;
    private Vector3 _velocity;
    private Vector3 _movement;

    // Update is called once per frame
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transGroudChecker.position, groundDistance, groundMask);
        _movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        _velocity.y = _isGrounded ? 0f : _velocity.y + gravity * Time.deltaTime;

        if (Input.GetButton("Jump"))
        {
            _velocity.y = 5f;
        }
        controller.Move(_velocity * Time.deltaTime + _movement * playerSpeed / 100);
        // controller.Move();
    }
}
