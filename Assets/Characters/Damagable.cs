using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int currHealth = 1;
    public int maxHealth = 1;

    public int currArmor = 1;
    public int maxArmor = 1;
    public ArmorTypes armorType = ArmorTypes.Kevlar;


    public GameObject hitNotifaction;
    public void damage(int damage, DamageTypes damageType)
    {
        //Object.Instantiate(this.hitNotifaction, this.transform);

        damage = dealDamageToArmor(damage, damageType);

        if(damage != 0)
        {
            dealDamageToHealth(damage, damageType);
            if (currHealth <= 0)
            {
                Die();
            }
        }
    }

    private int dealDamageToArmor(int damage, DamageTypes damageType)
    {
        if (currArmor == 0)
        {
            return damage;
        }
        float modifier = TypesCalculator.getModifier(damageType, this.armorType);
        damage = (int)(damage * modifier);
        currArmor -= damage;
        //za duzo zadalismy trzeba oddac reszte obrazen dalej
        if(currArmor < 0)
        {
            int leftOutDamage = -currArmor;
            currArmor = 0;
            return leftOutDamage;
        }
        //armor ponad 0 dalej mozna bic
        return 0;
    }

    private void dealDamageToHealth(int damage, DamageTypes damageType)
    {
        float modifier = TypesCalculator.getModifier(damageType, ArmorTypes.NoArmor);
        damage = (int)(damage * modifier);
        currHealth -= damage;
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
