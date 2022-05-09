using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 9;


    [Header("Running")]
    [SerializeField] private bool canRun = true;
    [SerializeField] private float sprintSpeed = 15;

    [Header("Jumping")]
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded;
    private bool isJumping;

    //---------------------------------------

    private float moveSpeed;
    private Vector3 moveDirection;
    private float gravity = -16f;
    private Vector3 velocity;

    private CharacterController controller;
    PhotonView view;

    //----------------------------------------
    void Awake()
    {
        view = GetComponent<PhotonView>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (view.IsMine)
        {
            Reset();
            CheckInputs();
            Movement();
            Gravity();
        }
    }

    private void CheckInputs()
    {
        // Find MoveDirection.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = transform.right * x + transform.forward * z;
        
        // Check For Sprint
        if (Input.GetKey(KeyCode.LeftShift) && canRun)
            moveSpeed = sprintSpeed;
        else
            moveSpeed = runSpeed;

        // Check for jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            isJumping = true;

    }



    private void Movement()
    {
        //Add Movement Force
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (isJumping)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

    }

    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Reset()
    {
        isJumping = false;
    }
}
