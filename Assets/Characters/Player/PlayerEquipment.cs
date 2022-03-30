using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : CharacterEquipment
{
    public static PlayerEquipment instance;

    override protected void Start()
    {
        instance = this;
        base.Start();
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
