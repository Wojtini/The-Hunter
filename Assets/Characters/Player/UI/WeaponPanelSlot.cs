using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanelSlot : MonoBehaviour
{
    public Text weaponName;
    public Text weaponDamage;
    public Text damageType;

    public void setWeapon(Weapon weapon)
    {
        this.weaponName.text = weapon.itemName;
        this.weaponDamage.text =
            weapon.minDamage.ToString() + '-' + weapon.maxDamage.ToString();
        this.damageType.text = weapon.damageType.ToString();
    }
}
