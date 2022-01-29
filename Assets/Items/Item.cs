using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Items/New Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite logo;
    public GameObject gameObjectRepresentation;

}
