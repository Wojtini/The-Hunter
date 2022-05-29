using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public Weapon firstWeapon;
    public Weapon secondWeapon;
    protected Animator weaponAnimator;
    protected bool interruptReload = false;

    virtual protected void Start()
    {
        if(firstWeapon)
            firstWeapon = Instantiate(firstWeapon);
        if(secondWeapon)
            secondWeapon = Instantiate(secondWeapon);
        UIManager.instance.UpdateWeaponPanel(firstWeapon, secondWeapon);
    }

    virtual protected void Update()
    {
        if(firstWeapon.currRateOfFire > 0)
        {
            firstWeapon.currRateOfFire -= Time.deltaTime;
        }
    }
    virtual public void SwapWeapons()
    {
        Weapon temp = firstWeapon;
        firstWeapon = secondWeapon;
        secondWeapon = temp;

        UIManager.instance.UpdateWeaponPanel(firstWeapon, secondWeapon);
    }

    public float setAnimationTrigger(string trigger)
    {
        weaponAnimator.SetTrigger(trigger);
        float time = weaponAnimator.GetCurrentAnimatorStateInfo(0).length;
        return time;
    }

    public IEnumerator reloadWeapon()
    {
        float time = setAnimationTrigger("Reload");
        interruptReload = false;
        yield return new WaitForSeconds(time);

        if (!interruptReload)
        {
            Debug.Log("Reloaded");
            firstWeapon.currentClip = firstWeapon.clipSize;
            PlayerEvents.triggerOnReload();
        }
        else
        {
            Debug.Log("Interrupted Reload");
        }
    }

    public void InterruptReload()
    {
        interruptReload = true;
    }

    public bool isInAnimState(string name)
    {
        return weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }

}
