using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEquipment : CharacterEquipment
{
    public static PlayerEquipment instance;
    public GameObject weaponPivot;
    private PlayerAiming playerAiming;
    public bool constantUpdate = false;


    override protected void Start()
    {
        playerAiming = GetComponent<PlayerAiming>();
        instance = this;
        refreshWeaponModel();
        PlayerEvents.onWeaponSwap += refreshWeaponModel;
        base.Start();
    }

    override public void SwapWeapons()
    {
        base.SwapWeapons();
        PlayerEvents.triggerOnWeaponSwap();


    }

    private void refreshWeaponModel()
    {
        for (int i = 0; i < weaponPivot.transform.childCount; i++)
        {
            Destroy(weaponPivot.transform.GetChild(i).gameObject);
        }
        GameObject go = Instantiate(this.firstWeapon.gameObjectRepresentation, weaponPivot.transform, false);
        weaponAnimator = go.GetComponent<Animator>();
    }

    void OnDrawGizmos()
    {
        if (!constantUpdate)
            return;
        for(int i=0;i< weaponPivot.transform.childCount; i++)
        {
            DestroyImmediate(weaponPivot.transform.GetChild(i).gameObject);
        }
        GameObject go = Instantiate(this.firstWeapon.gameObjectRepresentation, weaponPivot.transform, false);
        weaponAnimator = go.GetComponent<Animator>();
    }

    

}
