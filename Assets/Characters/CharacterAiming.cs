using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterEquipment))]
public class CharacterAiming : MonoBehaviour
{
    protected CharacterEquipment characterEquipment;
    protected CharacterModifiers characterModifiers;
    protected AudioSource audioSource;
    public Transform bulletSpawnPos;
    virtual public void Start()
    {
        characterEquipment = GetComponent<CharacterEquipment>();
        audioSource = GetComponent<AudioSource>();
        characterModifiers = GetComponent<CharacterModifiers>();
    }

    virtual public void Shoot(Vector3 target)
    {
        Weapon weapon = characterEquipment.firstWeapon;
        Vector3 origin = getBulletSpawnPos();
        if(weapon.shootSFX)
            audioSource.PlayOneShot(weapon.shootSFX);
        SpawnBullet(weapon, origin, target);
    }

    virtual public Vector3 getBulletSpawnPos()
    {
        return bulletSpawnPos.position;
    }

    virtual public GameObject SpawnBullet(Weapon weapon, Vector3 origin,Vector3 target)
    {
        GameObject go = Instantiate(weapon.bullet);
        go.transform.position = origin;
        go.GetComponent<Bullet>().setDestination(target);
        go.GetComponent<Bullet>().setStatistics(weapon);

        return go;
        //go.GetComponent<Bullet>().toggleLaser(false);
    }

    protected Vector2 getDispersionModifiers()
    {
        float dispersionModifier = 0;
        float aimingSpeed = 0;
        List<AimingModifier> aimingModifiers = characterModifiers.getAimingModifiers();
        foreach (AimingModifier am in aimingModifiers)
        {
            dispersionModifier += am.dispersionModifier;
            aimingSpeed += am.aimingTimeModifier;
        }
        return new Vector2(dispersionModifier, aimingSpeed);
    }
}
