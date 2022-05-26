using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : CharacterAiming
{
    private float maximumDispersionRadius = 400f;
    private float minimumDispersionRadius = 0f;
    public float dispersion = 0.2f;
    public float weaponSwapPenalty = 1f;
    private const float WORSENING_MODIFIER = 1.1f; // To make worsening aim faster
    public Camera cam;

    // Update is called once per frame
    override public void Start()
    {
        base.Start();
        cam = this.GetComponentInChildren<Camera>();
    }
    void Update()
    {
        reduceAimSize(Time.deltaTime);

        
    }

    internal void weaponSwapped()
    {
        dispersion = weaponSwapPenalty;
    }

    void reduceAimSize(float time)
    {
        float weaponDispersion = characterEquipment.firstWeapon.dispersion; // minimum that can be achieved (without modifiers)
        float aimTime = characterEquipment.firstWeapon.fullAimTime;
        Vector2 modifiers = getDispersionModifiers();

        float distDispersion = weaponDispersion + modifiers.x; // minimum that can be achieved with modifiers

        dispersion = Mathf.Clamp(dispersion, 0f, 1f);
        if(dispersion < distDispersion)
        {
            dispersion = Mathf.MoveTowards(dispersion, distDispersion, 1 / WORSENING_MODIFIER * Time.deltaTime);
        }
        else
        {
            dispersion = Mathf.MoveTowards(dispersion, distDispersion, 1 / aimTime * Time.deltaTime);
        }


        float currAimRadius = Mathf.Lerp(this.minimumDispersionRadius, this.maximumDispersionRadius, dispersion);
        Crosshair.instance.setCurrentRadius(currAimRadius);
    }

    public void Shoot(Weapon weapon)
    {
        if (characterEquipment.firstWeapon.currentClip <= 0)
            return;
        if (characterEquipment.isInAnimState("Reload"))
            return;
        characterEquipment.setAnimationTrigger("Fire");
        characterEquipment.firstWeapon.currentClip -= 1;
        Vector3 target = CalculateTarget(weapon.effectiveRange);
        dispersion += characterEquipment.firstWeapon.aimDispersionAfterShot;
        Shoot(target);
    }

    public override Vector3 getBulletSpawnPos()
    {
        return Camera.main.transform.position;
    }

    private Vector3 CalculateTarget(float effectiveRange)
    {

        Vector3 camMiddle = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        Ray randomPoint = shootRandomiser.instance.getRandomShoot();
        Vector3 randomPointVec = randomPoint.origin;
        Debug.DrawRay(camMiddle, cam.transform.forward * 30, Color.green, 10f, true);

        Debug.DrawRay(randomPoint.origin, randomPoint.direction * effectiveRange, Color.red, 10f, true);

        Vector3 randomPointTarget = (randomPoint.direction) * effectiveRange + randomPoint.origin;

        return randomPointTarget;
    }

    override public GameObject SpawnBullet(Weapon weapon, Vector3 origin, Vector3 target)
    {
        GameObject go = base.SpawnBullet(weapon, origin, target);
        go.GetComponent<Bullet>().toggleLaser(false);

        return go;
    }
}
