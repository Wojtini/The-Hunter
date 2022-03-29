using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModifiers : MonoBehaviour
{
    public List<Modifier> modifiers = new List<Modifier>();

    void Update()
    {
        for (int i = modifiers.Count - 1; i >= 0; i--)
        {
            Modifier modifier = modifiers[i];
            if (modifier.timed)
            {
                modifier.currentTime -= Time.deltaTime;
                if (modifier.currentTime <= 0)
                {
                    modifiers.RemoveAt(i);
                }
            }
        }
    }

    public void addModifier(Modifier modifierToAdd)
    {
        foreach (Modifier modifier in modifiers)
        {
            if (modifier.title.Equals(modifierToAdd.title))
            {
                if (modifier.stackable)
                {
                    modifier.stacks += 1;
                }
                modifier.currentTime = modifier.durationTime;
                return;
            }
        }

        Modifier newMod = Instantiate(modifierToAdd);
        newMod.currentTime = newMod.durationTime;
        modifiers.Add(newMod);
    }

    public void removeModifier(Modifier modifierToDelete)
    {
        foreach (Modifier modifier in modifiers)
        {
            if (modifier.title == modifierToDelete.title)
            {
                modifiers.Remove(modifier);
                return;
            }
        }
    }

    public List<AimingModifier> getAimingModifiers()
    {
        List<AimingModifier> result = new List<AimingModifier>();
        
        foreach(Modifier modifier in modifiers)
        {
            if(modifier is AimingModifier)
            {
                result.Add((AimingModifier)modifier);
            }
        }

        return result;
    }
}
