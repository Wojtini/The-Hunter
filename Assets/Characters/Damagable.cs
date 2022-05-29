using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    public int currHealth = 1;
    public int maxHealth = 1;

    public int currArmor = 1;
    public int maxArmor = 1;


    public GameObject hitNotification;

    public Slider healthBar;
    public Slider armorBar;
    public void damage(int damage)
    {
        damage = Mathf.Min(damage, currHealth);
        currHealth -= damage;
        spawnHitNotification(damage);

        if (currHealth <= 0)
        {
            Die();
        }

        if(!healthBar || !armorBar)
        {
            return;
        }

        healthBar.value = (float)currHealth / maxHealth;
        armorBar.value = (float)currArmor / maxArmor;
    }

    private void spawnHitNotification(int damage)
    {
        GameObject hitNotification = Instantiate(this.hitNotification);
        hitNotification.transform.position = this.transform.position + Vector3.up;
        hitNotification.GetComponent<DmgPupUp>().setText(damage.ToString());
    }

    public void heal(int amount)
    {
        currHealth = Mathf.Clamp(currHealth + amount, 0, maxHealth);
    }

    virtual public void Die()
    {
        Debug.Log(this + " died");
        Destroy(this.gameObject);
    }
}
