using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEntry : MonoBehaviour
{
    public Item item;
    public Text itemName;
    
    public void setItem(Item item)
    {
        itemName.text = item.itemName;
        this.item = item;
    }
}
