using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPesonControl : MonoBehaviour
{
    
    [SerializeField] CharacterController _controller;
    public float moveSpeed = 15f;
    public float jumpForse = 5f;

    //groundChek
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //CharacterPhisics
    public float gravity = - 9.81f;
    Vector3 velocity;
    public bool pause;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if (!pause)
        {

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForse * -2 * gravity);
            }

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;

            _controller.Move(move * moveSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            _controller.Move(velocity * Time.deltaTime);
        }
    }
}
