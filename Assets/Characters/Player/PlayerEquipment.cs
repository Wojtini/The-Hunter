using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : CharacterEquipment
{
    private PlayerAiming playerAiming;

    void Start()
    {
        playerAiming = GetComponent<PlayerAiming>();    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapWeapons();
        }
    }

    override public void SwapWeapons()
    {
        base.SwapWeapons();
    }
}
