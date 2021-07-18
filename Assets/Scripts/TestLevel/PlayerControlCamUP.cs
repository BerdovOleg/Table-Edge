using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCamUP : MonoBehaviour
{
    public CharacterController _controller;
    public bool _chControl;

    public float speed = 9f;
    public float jumpForse = 9f;
    public float gravityScale = -9.85f;
    public float targetAngle;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //groundChek
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.9f;
    public LayerMask groundMask;
    bool _isGrounded;

    Vector3 velocity;
    public bool pause;


    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            //Ground check
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
            if (_isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            //Player Jump
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForse * -2 * gravityScale);
            }

            velocity.y += gravityScale * Time.deltaTime;
            _controller.Move(velocity * Time.deltaTime);
            //=================================================

            //Get Direction
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                //Get rotation player
                targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //Move Player
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                _controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }
    }
}
