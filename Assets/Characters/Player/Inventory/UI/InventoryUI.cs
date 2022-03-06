using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject itemEntry;
    public GameObject panel;
    // Update is called once per frame
    private void Start()
    {
        panel.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)){
            panel.gameObject.SetActive(!panel.gameObject.activeSelf);
            UpdateInventoryView();
        }
    }

    void UpdateInventoryView()
    {
        DestroyAllChildren();
        foreach(Item item in Inventory.instance.items)
        {
            ItemEntry entry = Instantiate(itemEntry, panel.transform).GetComponent<ItemEntry>();
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
