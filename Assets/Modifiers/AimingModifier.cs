using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Modifiers/New Aiming Modifier", order = 1)]
public class AimingModifier : Modifier
{
    public float minimumDispersionModifier = 1f;
    public float maximumDispersionModifier = 1f;
    public float aimingTimeModifier = 1f;
}
