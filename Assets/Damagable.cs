using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int currHealth = 0;
    public int maxHealth = 1;

    public GameObject hitNotifaction;
    public void Update()
    {
        if (currHealth <= 0)
        {
            Die();
        }
    }
    public void hit(int damage)
    {
        Object.Instantiate(this.hitNotifaction, this.transform);
    }

    public void heal(int amount)
    {
        currHealth = Mathf.Clamp(currHealth + amount, 0, maxHealth);
    }

    virtual public void Die()
    {
        Debug.Log(this + " died");
        //zniszcz obiekt
    }
}
