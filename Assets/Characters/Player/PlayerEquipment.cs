using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public Weapon firstWeapon;
    public Weapon secondWeapon;
    private PlayerAiming playerAiming;

    void Start()
    {
        playerAiming = GetComponent<PlayerAiming>();    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapWeapons();
        }
    }

    private void SwapWeapons()
    {
        Weapon temp = firstWeapon;
        firstWeapon = secondWeapon;
        secondWeapon = temp;
        playerAiming.doMaxAimSize();
    }
}
