using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Items/New Weapon", order = 1)]
public class Weapon : Item
{
    public int minDamage;
    public int maxDamage;
    public float effectiveRange;
    public float bulletSpeed;
    public float aimDispersionAfterShot;
    public float aimReduceSpeed;
    public DamageTypes damageType;
}
