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
    public Transform aimTransform;

    Vector3 camMiddle;
    Vector3 forwardPoint;
    // Update is called once per frame
    override public void Start()
    {
        base.Start();
        cam = this.GetComponentInChildren<Camera>();

        PlayerEvents.onWeaponSwap += weaponSwapped;
    }
    void Update()
    {
        camMiddle = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        forwardPoint = camMiddle + Camera.main.transform.forward * characterEquipment.firstWeapon.effectiveRange;

        aimTransform.position = forwardPoint;
        aimTransform.LookAt(this.gameObject.transform);

        reduceAimSize(Time.deltaTime);
        Vector3 p = forwardPoint + aimTransform.transform.up * dispersion;
        //D
        Debug.DrawRay(camMiddle, p - camMiddle, Color.black);
        Crosshair.instance.drawCrosshairFromWorldPoint(p);
        drawDebugLines();
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
        float thirdsDispersion = dispersion / 3;
        float perSecond = thirdsDispersion / aimTime;
        if (dispersion < 0)
            dispersion = 0;

        if(dispersion < distDispersion)
        {
            dispersion = Mathf.MoveTowards(dispersion, distDispersion, perSecond * Time.deltaTime);
        }
        else
        {
            dispersion = Mathf.MoveTowards(dispersion, distDispersion, perSecond * Time.deltaTime);
        }


        float currAimRadius = Mathf.Lerp(this.minimumDispersionRadius, this.maximumDispersionRadius, dispersion);
    }

    public void Shoot(Weapon weapon)
    {
        if (weapon.currentClip <= 0)
            return;
        if (characterEquipment.isInAnimState("Reload") || characterEquipment.isInAnimState("Pullout"))
            return;
        if (weapon.currRateOfFire > 0)
            return;
        characterEquipment.setAnimationTrigger("Fire");

        Vector3 target = CalculateTarget(weapon.effectiveRange, dispersion);

        weapon.ShootGun();
        dispersion += weapon.aimDispersionAfterShot;

        PlayerEvents.triggerOnFire();

        //Spawning bullet
        Shoot(target);
    }

    public override Vector3 getBulletSpawnPos()
    {
        if (bulletSpawnPos)
        {
            return bulletSpawnPos.transform.position;
        }
        Debug.Log("No spawn bullet point");
        return Camera.main.transform.position;
    }

    private void drawDebugLines()
    {
        Debug.DrawRay(camMiddle, forwardPoint - camMiddle, Color.green);
        Debug.DrawRay(forwardPoint, aimTransform.transform.up * dispersion, Color.green);
        Debug.DrawRay(forwardPoint, -aimTransform.transform.up * dispersion, Color.green);
        Debug.DrawRay(forwardPoint, aimTransform.transform.right * dispersion, Color.green);
        Debug.DrawRay(forwardPoint, -aimTransform.transform.right * dispersion, Color.green);
    }
    private Vector3 CalculateTarget(float effectiveRange, float dispersion)
    {
        Debug.DrawRay(camMiddle, forwardPoint - camMiddle, Color.blue, 10f, true);
        Debug.DrawRay(forwardPoint, aimTransform.transform.up * dispersion, Color.blue, 10f, true);
        Debug.DrawRay(forwardPoint, -aimTransform.transform.up * dispersion, Color.blue, 10f, true);
        Debug.DrawRay(forwardPoint, aimTransform.transform.right * dispersion, Color.blue, 10f, true);
        Debug.DrawRay(forwardPoint, -aimTransform.transform.right * dispersion, Color.blue, 10f, true);

        Vector2 rand = UnityEngine.Random.insideUnitCircle * dispersion;
        Vector3 x = aimTransform.transform.up * rand.y;
        Vector3 y = aimTransform.transform.right * rand.x;

        Debug.DrawRay(forwardPoint, x+y, Color.red, 10f, true);

        return forwardPoint + x + y;
    }

    override public GameObject SpawnBullet(Weapon weapon, Vector3 origin, Vector3 target)
    {
        GameObject go = base.SpawnBullet(weapon, origin, target);

        return go;
    }
}
