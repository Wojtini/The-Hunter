using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public bool canMove = true;
    public bool canLookAround = true;

    private PlayerAiming playerAiming;
    private PlayerCharacterController characterController;
    private PlayerEquipment playerEquipment;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<PlayerCharacterController>();
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
        Interactions();
    }

    Ray RayOrigin;
    RaycastHit HitInfo;
    void Interactions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(RayOrigin, out HitInfo, 30f))
            {
                Interactable interactable = HitInfo.transform.gameObject.GetComponent<Interactable>();
                if (interactable)
                {
                    Debug.Log("Interacted with " + interactable);
                    interactable.Interact();
                }
            }
        }
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAiming.Shoot(playerEquipment.firstWeapon);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            StartCoroutine(playerEquipment.reloadWeapon());

        }
    }

    void UIInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canLookAround = !canLookAround;
            canMove = !canMove;
            InventoryUI.instance.ToggleInventory();
            
            if (canLookAround)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = !canLookAround;
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
