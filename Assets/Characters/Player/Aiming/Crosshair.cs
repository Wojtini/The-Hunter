using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public float currentRadius = 50f;

    public GameObject[] indicators;


    public static Crosshair instance;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        foreach (GameObject obj in indicators)
        {
            obj.transform.localPosition = obj.transform.up * currentRadius;
        }
    }

    public void setCurrentRadius(float newCurrent)
    {
        this.currentRadius = newCurrent;
    }
}
