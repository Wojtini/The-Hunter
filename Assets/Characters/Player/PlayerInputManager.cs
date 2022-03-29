using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public bool canMove = true;
    public bool canLookAround = true;

    public PlayerAiming playerAiming;
    public PlayerCharacterController characterController;
    public PlayerEquipment playerEquipment;
    // Start is called before the first frame update
    void Start()
    {
        this.characterController = GetComponent<PlayerCharacterController>();
        playerAiming = GetComponent<PlayerAiming>();
        playerEquipment = GetComponent<PlayerEquipment>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
        CharacterRotation();
        UIInput();
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAiming.Shoot(playerEquipment.firstWeapon);
        }
    }

    void UIInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canLookAround = !canLookAround;
            canMove = !canMove;
            if (canLookAround)
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

    void CharacterMovement()
    {
        if (!canMove)
        {
            characterController.HandleMovement(0, 0, false);
            return;
        }
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        characterController.HandleMovement(horizontal, vertical, isRunning);
    }

    void CharacterRotation()
    {
        if (!canLookAround)
            return;
        float y = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Mouse X");
        characterController.HandleRotation(x, y);
    }

}
