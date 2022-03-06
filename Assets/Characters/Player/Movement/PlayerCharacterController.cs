using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacterController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public float aimJumpDispersion = 35f;
    public float walkDispersion = 1f;
    public float runningDispersion = 5f;

    public PlayerAiming playerAiming;

    public bool canMove = true;
    public bool isCrouching = false;

    public bool canRotateCamera = true;
    void Start()
    {
        playerAiming = GetComponent<PlayerAiming>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isCrouching = Input.GetButton("Crouch");



        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float yDir = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            playerAiming.modifyAimSize(aimJumpDispersion);
        }
        else
        {
            moveDirection.y = yDir;
        }

        //dispersion Calculation
        //float pom2 = characterController.isGrounded ? 0 : 1;
        //float pom = Mathf.Clamp(Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")),0,1) + pom2;
        //pom = isRunning ? pom * runningDispersion : pom * walkDispersion;

        //playerAiming.modifyAimSize(pom);


        moveDirection = isCrouching ? moveDirection * 0.5f : moveDirection;

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);


        if (canRotateCamera)
        {
            handleLooking();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canRotateCamera = !canRotateCamera;
            if (canRotateCamera)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }

    }

    private void handleLooking()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}