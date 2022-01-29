using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public static Inventory instance;

    void Start()
    {
        instance = this;    
    }

}
