using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{

    public delegate void Event();
    public static event Event onReload;
    public static event Event onFire;
    public static event Event onWeaponSwap;

    public static void triggerOnFire()
    {
        if(onFire != null)
        {
            onFire();
        }
    }

    public static void triggerOnWeaponSwap()
    {
        if (onWeaponSwap != null)
        {
            onWeaponSwap();
        }
    }

    public static void triggerOnReload()
    {
        if (onReload != null)
        {
            onReload();
        }
    }
}
