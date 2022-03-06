using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgPupUp : WorldUI
{
    public Text text;
    public float lifetime = 3f;
    public float speed = 10f;

    public void setText(string text)
    {
        Debug.Log(text);
        this.text.text = text;
    }

    protected override void Update()
    {
        base.Update();
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(this.gameObject);
        }
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
