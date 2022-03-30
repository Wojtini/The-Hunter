using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Weapon item;
    public Text itemName;

    public void setWeapon(Weapon item)
    {
        Debug.Log("Zmieniono bron g³owna");
        PlayerEquipment.instance.firstWeapon = item;
        itemName.text = item.itemName;
        this.item = item;
    }
}
