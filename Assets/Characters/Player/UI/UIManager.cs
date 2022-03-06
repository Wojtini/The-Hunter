using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private WeaponPanel weaponPanel;

    public void Start()
    {
        weaponPanel = this.GetComponentInChildren<WeaponPanel>();
        instance = this;
    }

    public void UpdateWeaponPanel(Weapon prim, Weapon sec)
    {
        weaponPanel.primarySlot.setWeapon(prim);
        weaponPanel.secondarySlot.setWeapon(sec);
    }
}
