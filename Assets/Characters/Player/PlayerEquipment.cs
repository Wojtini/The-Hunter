using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEquipment : CharacterEquipment
{
    public static PlayerEquipment instance;
    public GameObject weaponPivot;
    private PlayerAiming playerAiming;

    override protected void Start()
    {
        playerAiming = GetComponent<PlayerAiming>();
        instance = this;
        refreshWeaponModel();
        base.Start();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapWeapons();
        }
    }

    override public void SwapWeapons()
    {
        base.SwapWeapons();
        playerAiming.weaponSwapped();
        refreshWeaponModel();
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
        for(int i=0;i< weaponPivot.transform.childCount; i++)
        {
            DestroyImmediate(weaponPivot.transform.GetChild(i).gameObject);
        }
        GameObject go = Instantiate(this.firstWeapon.gameObjectRepresentation, weaponPivot.transform, false);
        weaponAnimator = go.GetComponent<Animator>();
    }

    

}
