using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    public Vector3 destination;
    public float speed = 60;
    public int damage = 1;

    public float lifetime = 15f;

    public GameObject pS;
    public LayerMask IgnoreMe;

    public AudioClip hitSfx;
    public GameObject audioSource;

    private Vector3 previousPosition;
    private void Start()
    {
        previousPosition = this.transform.position;
    }
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //Check if can raycast from previous position into current one
        RaycastHit hit;
        if (Physics.Raycast(previousPosition, transform.position - previousPosition, out hit, Vector3.Distance(transform.position, previousPosition)))
        {
            hitObject(hit.transform.gameObject);
        }
        previousPosition = this.transform.position;

        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(this);
        }
    }

    public void setDestination(Vector3 newDestination)
    {
        transform.LookAt(newDestination);

    }

    public void setStatistics(Weapon weapon)
    {
        this.speed = weapon.bulletSpeed;
        this.damage = Random.Range(weapon.minDamage, weapon.maxDamage);
    }

    void hitObject(GameObject go)
    {
        SpawnHitProjectile();
        SpawnAudioSource();

        Damagable hit = go.gameObject.GetComponent<Damagable>();
        if (hit)
        {
            hit.damage(this.damage);
        }

        Destroy(this.gameObject);
    }

    void SpawnAudioSource()
    {
        GameObject a = Instantiate(audioSource);
        a.transform.position = this.transform.position;
        a.GetComponent<AudioSource>().PlayOneShot(hitSfx);
        Destroy(a, 2f);
    }

    void SpawnHitProjectile()
    {
        GameObject a = Instantiate(pS);
        a.transform.position = this.transform.position;
        a.transform.rotation = this.transform.rotation;
        a.GetComponentInChildren<VisualEffect>().Play();
        Destroy(a, 2f);
    }
}
