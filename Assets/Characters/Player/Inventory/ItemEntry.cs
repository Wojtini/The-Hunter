using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEntry : MonoBehaviour
{
    public Text itemName;
    
    public void setItem(Item item)
    {
        itemName.text = item.itemName;
    }
}
