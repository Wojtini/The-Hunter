using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    public float minAimSize = 5f;
    public float currAimSize = 50f;
    public float maxAimSize = 100f;

    public float aimReduceSpeed = 5f;

    public Camera cam;

    public GameObject bullet;
    public PlayerEquipment playerEquipment;
    // Update is called once per frame
    private void Start()
    {
        playerEquipment = GetComponent<PlayerEquipment>();
        cam = this.GetComponentInChildren<Camera>();
    }
    void Update()
    {
        reduceAimSize(Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(playerEquipment.firstWeapon);
        }

        Crosshair.instance.setCurrentRadius(currAimSize);
    }

    void reduceAimSize(float time)
    {
        currAimSize = currAimSize - aimReduceSpeed * time;
        currAimSize = Mathf.Clamp(currAimSize, minAimSize, maxAimSize);
    }

    public void modifyAimSize(float amount)
    {
        currAimSize += amount;
    }

    public void Shoot(Weapon weapon)
    {
        Vector3 target = CalculateTarget(weapon.effectiveRange);

        modifyAimSize(weapon.aimDispersionAfterShot);

        SpawnBullet(target);
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

    private void SpawnBullet(Vector3 target)
    {
        GameObject go = Instantiate(bullet);
        go.transform.position = Camera.main.transform.position;
        go.GetComponent<Bullet>().setDestination(target);
        go.GetComponent<Bullet>().setStatistics(playerEquipment.firstWeapon);
    }
}
