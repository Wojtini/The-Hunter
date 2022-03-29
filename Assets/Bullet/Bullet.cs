using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 destination;
    public float speed = 60;
    public int damage = 1;
    public DamageTypes damageType;
    private LineRenderer lineRenderer;

    public float lifetime = 15f;

    public GameObject pS;
    private Vector3[] destinations = new Vector3[2];
    public LayerMask IgnoreMe;

    public AudioClip hitSfx;
    public GameObject audioSource;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        destinations[0] = this.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ~IgnoreMe))
        {
            destinations[1] = hit.point;
            //Debug.Log(hit.transform.gameObject);
        }


        if (lineRenderer.enabled)
        {
            lineRenderer.SetPositions(destinations);
        }

        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(this);
        }
    }

    public void setDestination(Vector3 newDestination)
    {
        transform.LookAt(newDestination);

        destinations[1] = newDestination;
    }

    public void setStatistics(Weapon weapon)
    {
        this.speed = weapon.bulletSpeed;
        this.damage = Random.Range(weapon.minDamage, weapon.maxDamage);
        this.damageType = weapon.damageType;
    }

    void OnTriggerEnter(Collider collision)
    {
        SpawnHitProjectile();
        SpawnAudioSource();

        Damagable hit = collision.gameObject.GetComponent<Damagable>();
        if (hit)
        {
            hit.damage(this.damage, this.damageType);
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
        a.GetComponent<ParticleSystem>().Play();
        Destroy(a, 2f);
    }

    public void toggleLaser(bool toggle)
    {
        lineRenderer.enabled = toggle;
    }
}
