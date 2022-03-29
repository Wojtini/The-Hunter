using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "Modifiers/New Modifier", order = 1)]
public class Modifier : ScriptableObject
{
    public string title;
    public string description;
    public Sprite icon;
    public bool timed;
    public float durationTime;
    public bool isBuff;
    public bool showInHud;
    [HideInInspector]
    public float currentTime;

    public bool stackable;
    [HideInInspector]
    public int stacks;
}
