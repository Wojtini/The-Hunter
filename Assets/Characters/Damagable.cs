using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int currHealth = 1;
    public int maxHealth = 1;

    public GameObject hitNotifaction;
    public void damage(int damage)
    {
        //Object.Instantiate(this.hitNotifaction, this.transform);
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Die();
        }
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
