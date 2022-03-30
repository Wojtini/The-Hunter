using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ItemPickUp : Interactable
{
    public Item item;
    public Text nameDisplay;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (!item)
        {
            Debug.Log("Cannot spawn item pick up. No item assigned " + this);
            return;
        }
        if (item.gameObjectRepresentation)
        {
            Instantiate(item.gameObjectRepresentation, transform);
            return;
        }
        Debug.Log("Cannot spawn item pick up. Item " + item + "has no representation");
        Destroy(this.gameObject);
    }

    public void setItem(Item item)
    {
        this.item = item;
        nameDisplay.text = item.itemName;
    }

    public override void OnDrawGizmos()
    {
        string displayName = "ERROR No pickup";
        if (item)
        {
            displayName = item.itemName;
        }
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Handles.Label(transform.position, "Pickup - " + displayName);
    }

    public override void Interact()
    {
        Inventory.instance.addItem(item);
        Destroy(this.gameObject);
    }
}
