using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public static Inventory instance;
    public GameObject ItemPickUpPrefab;

    void Start()
    {
        instance = this;    
    }


    public void addItem(Item item)
    {
        items.Add(item);
        //InventoryUI.instance.UpdateInventoryView();
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
        //InventoryUI.instance.UpdateInventoryView();
    }

    public List<Item> getAllItems()
    {
        return items;
    }

    public void dropItem(Item item)
    {
        items.Remove(item);
        //InventoryUI.instance.UpdateInventoryView();
        GameObject go = Instantiate(ItemPickUpPrefab);
        go.GetComponent<ItemPickUp>().setItem(item);
        go.transform.position = transform.position + transform.forward;
    }
}
