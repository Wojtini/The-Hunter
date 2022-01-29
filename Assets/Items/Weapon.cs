using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Items/New Weapon", order = 1)]
public class Weapon : Item
{
    public int minDamage;
    public int maxDamage;
    public int effectiveRange;
    public int bulletSpeed;
}
