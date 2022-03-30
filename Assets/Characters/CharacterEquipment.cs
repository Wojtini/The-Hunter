using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public Weapon firstWeapon;
    public Weapon secondWeapon;

    virtual protected void Start()
    {
        if(firstWeapon)
            firstWeapon = Instantiate(firstWeapon);
        if(secondWeapon)
            secondWeapon = Instantiate(secondWeapon);
    }
    virtual public void SwapWeapons()
    {
        Weapon temp = firstWeapon;
        firstWeapon = secondWeapon;
        secondWeapon = temp;

        UIManager.instance.UpdateWeaponPanel(firstWeapon, secondWeapon);
    }

    virtual public void reloadWeapon()
    {
        firstWeapon.currentClip = firstWeapon.clipSize;
    }
}
