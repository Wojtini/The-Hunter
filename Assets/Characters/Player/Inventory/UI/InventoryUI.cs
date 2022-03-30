using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject itemEntry;
    public GameObject panel;
    public static InventoryUI instance;
    // Update is called once per frame
    private void Start()
    {
        instance = this;
        panel.gameObject.SetActive(false);
    }
    public void ToggleInventory()
    {
        panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        UpdateInventoryView();
    }

    public void UpdateInventoryView()
    {
        DestroyAllChildren();
        foreach(Item item in Inventory.instance.getAllItems())
        {
            ItemEntry entry = Instantiate(itemEntry, panel.transform).GetComponentInChildren<ItemEntry>();
            entry.setItem(item);
        }
    }

    private void DestroyAllChildren()
    {
        foreach(Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
