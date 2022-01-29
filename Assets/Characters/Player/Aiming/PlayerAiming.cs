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
    void Update()
    {
        playerEquipment = GetComponent<PlayerEquipment>();
        cam = this.GetComponentInChildren<Camera>();
        reduceAimSize(Time.deltaTime);
        Crosshair.instance.setCurrentRadius(currAimSize);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(10);
        }
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

    public void Shoot(float effectiveRange)
    {
        RaycastHit hit;
        RaycastHit hit2;
        //Debug.Log(laserStart);

        Vector3 camMiddle = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        Ray randomPoint = shootRandomiser.instance.getRandomShoot();
        Vector3 randomPointVec = randomPoint.origin;


        //Gdzie gracz chcial celowac (perfect shoot)
        Debug.DrawRay(camMiddle, cam.transform.forward * 30, Color.green, 10f, true);

        //Strzal bezposrednio z wylosowanego punktu
        // if hit the shoot from middle to hit

            
        Debug.DrawRay(randomPoint.origin, randomPoint.direction * effectiveRange, Color.red, 10f, true);

        Vector3 randomPointTarget = (randomPoint.direction) * effectiveRange + randomPoint.origin;

        SpawnBullet(randomPointTarget);

        if (Physics.Raycast(randomPoint, out hit))
        {

            //Debug.DrawRay(randomPoint.origin, randomPoint.direction * effectiveRange, Color.yellow, 10f, true);
            Ray ray2 = new Ray(camMiddle, hit.point - camMiddle);

            if (Physics.Raycast(ray2, out hit2))
            {
                //Debug.DrawRay(camMiddle, hit2.point - camMiddle, Color.blue, 10f, true);
            }
            Transform objectHit = hit.transform;
        }
    }

    private void SpawnBullet(Vector3 target)
    {
        GameObject go = Instantiate(bullet);
        go.transform.position = Camera.main.transform.position;
        go.GetComponent<Bullet>().setDestination(target);
        go.GetComponent<Bullet>().setStatistics(playerEquipment.firstWeapon);
    }
}
