using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float jumpForce = 0.2f;
    private float gravity = -9.81f;
    private bool isGrounded = true;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");

        isGrounded = controller.isGrounded;
        //if (isGrounded && velocity.y < 0)
        //{
        //    Debug.Log(isGrounded && velocity.y < 0);
        //    velocity.y = -2f;
        //}

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 movement = transform.forward * horizontal + transform.right * -vertical;
        movement.y = velocity.y;

        controller.Move(movement * speed * Time.deltaTime);
    }
}