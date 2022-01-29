using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootRandomiser : MonoBehaviour
{
    public static shootRandomiser instance;
    public GameObject shootPicker;
    private void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    public Ray getRandomShoot()
    {
        float maxDist = Crosshair.instance.currentRadius;
        Vector3 test = Random.insideUnitCircle * maxDist;

        // do debugowania
        shootPicker.transform.localPosition = test;

        return Camera.main.ScreenPointToRay(test + new Vector3(Screen.width / 2, Screen.height / 2, 1f));
    }
}
