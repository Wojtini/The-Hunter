using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : CharacterAiming
{
    public float currAimSize = 50f;
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

        Crosshair.instance.setCurrentRadius(currAimSize);
    }

    void reduceAimSize(float time)
    {
        float minimumDispersion = characterEquipment.firstWeapon.minimumDispersion;
        float maximumDispersion = characterEquipment.firstWeapon.maximumDispersion;
        Vector3 MinMaxPair = getDispersionModifiers();
        minimumDispersion *= MinMaxPair.x;
        maximumDispersion *= MinMaxPair.y;
        float aimingSpeedModifier = MinMaxPair.z;


        float step = characterEquipment.firstWeapon.maximumDispersion - characterEquipment.firstWeapon.minimumDispersion;
        step /= characterEquipment.firstWeapon.fullAimTime * aimingSpeedModifier;
        currAimSize = currAimSize - step * time;
        currAimSize = Mathf.Clamp(currAimSize, minimumDispersion, maximumDispersion);
    }

    public void modifyAimSize(float amount)
    {
        currAimSize += amount;
    }

    public void Shoot(Weapon weapon)
    {
        Vector3 target = CalculateTarget(weapon.effectiveRange);
        currAimSize += characterEquipment.firstWeapon.aimDispersionAfterShot;
        base.Shoot(target);
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
