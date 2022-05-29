using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgPupUp : WorldUI
{
    public Text text;
    private float constSize = 0.001f;
    public float lifetime = 3f;
    public float speed = 10f;

    public void setText(string text)
    {
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

        float distance = (Camera.main.transform.position - transform.position).magnitude;
        float size = distance * constSize * Camera.main.fieldOfView;
        transform.localScale = Vector3.one * size;
        transform.forward = transform.position - Camera.main.transform.position;
    }
}
