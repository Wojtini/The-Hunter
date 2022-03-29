using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public Weapon firstWeapon;
    public Weapon secondWeapon;

    virtual public void SwapWeapons()
    {
        Weapon temp = firstWeapon;
        firstWeapon = secondWeapon;
        secondWeapon = temp;

        UIManager.instance.UpdateWeaponPanel(firstWeapon, secondWeapon);
    }
}
