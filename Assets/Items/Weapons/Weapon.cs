using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Items/New Weapon", order = 1)]
public class Weapon : Item
{
    [Header("Damage")]
    public int minDamage;
    public int maxDamage;
    public DamageTypes damageType;
    [Header("Clip")]
    public int currentClip;
    public int clipSize;

    [Header("Various")]
    public GameObject bullet;
    public AudioClip shootSFX;
    public float bulletSpeed;
    public float effectiveRange;

    [Header("Aiming")]
    public float dispersion;
    public float aimDispersionAfterShot;
    public float fullAimTime;


    [Header("Animations")]
    public AnimationClip idleAnim;
    public AnimationClip fireAnim;
    public AnimationClip reloadAnim;



}
