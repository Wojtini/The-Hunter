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
    CharacterModifiers characterModifiers;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public PlayerAiming playerAiming;

    public AimingModifier walkingModifier;
    public AimingModifier runningModifier;

    public bool canRotateCamera = true;
    void Start()
    {
        playerAiming = GetComponent<PlayerAiming>();
        characterController = GetComponent<CharacterController>();
        characterModifiers = GetComponent<CharacterModifiers>();
    }

    public void HandleRotation(float x, float y)
    {
        rotationX += -y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, x * lookSpeed, 0);
    }
    public void HandleMovement(float horizontal, float vertical, bool isRunning)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);



        float curSpeedX = (isRunning ? runningSpeed : walkingSpeed) * vertical;
        float curSpeedY = (isRunning ? runningSpeed : walkingSpeed) * horizontal;
        float yDir = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if(moveDirection != Vector3.zero)
        {
            characterModifiers.addModifier(walkingModifier);
            if (isRunning)
            {
                characterModifiers.addModifier(runningModifier);
            }
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = yDir;
        }

        // Apply gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

    }
}
