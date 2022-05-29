using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanelSlot : MonoBehaviour
{
    public Weapon weapon;

    public Text weaponName;
    public Text weaponDamage;
    public Text weaponClip;
    public Text bulletSpeed;
    public Text effectiveRange;
    public Text weaponDispersion;
    public Text aimTime;

    void Start()
    {
        PlayerEvents.onReload += updateWeapon;
        PlayerEvents.onFire += updateWeapon;
    }
    public void updateWeapon()
    {
        this.weaponName.text = "Name: " + weapon.itemName;
        this.weaponDamage.text = "Damage: " +
            weapon.minDamage.ToString() + '-' + weapon.maxDamage.ToString();

        this.weaponClip.text = "Clip: " + weapon.currentClip.ToString() + "/" + weapon.clipSize.ToString();
        this.bulletSpeed.text = "Bullet Speed: " + weapon.bulletSpeed.ToString();
        this.effectiveRange.text = "Effective Range: " + weapon.effectiveRange.ToString();
        this.weaponDispersion.text = "Weapon Dispersion: " + weapon.dispersion.ToString();
        this.aimTime.text = "Aim Time: " + weapon.fullAimTime.ToString();
    }

    public void setWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        updateWeapon();
    }
}
