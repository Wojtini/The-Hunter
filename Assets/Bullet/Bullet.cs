using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 destination;
    public float speed = 60;
    public int damage = 1;

    public GameObject pS;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void setDestination(Vector3 newDestination)
    {
        destination = newDestination;
        transform.LookAt(newDestination);
        enabled = true;
    }

    public void setStatistics(Weapon weapon)
    {
        this.speed = weapon.bulletSpeed;
        this.damage = Random.Range(weapon.minDamage, weapon.maxDamage);
    }

    void OnCollisionEnter(Collision collision)
    {
        SpawnHitProjectile();
        Damagable hit = collision.gameObject.GetComponent<Damagable>();
        if (hit)
        {
            hit.damage(damage);
        }

        Destroy(this.gameObject);
    }

    void SpawnHitProjectile()
    {
        GameObject a = Instantiate(pS);
        a.transform.position = this.transform.position;
        a.transform.rotation = this.transform.rotation;
        a.GetComponent<ParticleSystem>().Play();
        Destroy(a, 2f);
    }
}
