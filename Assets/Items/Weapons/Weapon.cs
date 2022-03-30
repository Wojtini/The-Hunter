using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Items/New Weapon", order = 1)]
public class Weapon : Item
{
    public int minDamage;
    public int maxDamage;
    public int currentClip;
    public int clipSize;
    public float bulletSpeed;

    public float aimDispersionAfterShot;
    public float minimumDispersion;
    public float maximumDispersion;
    public float fullAimTime;
    
    public float effectiveRange;

    public DamageTypes damageType;

    public AudioClip shootSFX;

    public GameObject bullet;
}
