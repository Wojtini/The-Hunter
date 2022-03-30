using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    protected GameObject player;
    public float requireDistance = 4f;
    protected Canvas canvas;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        canvas = GetComponentInChildren<Canvas>();
    }

    virtual protected void Update()
    {
        if(Vector3.Distance(player.transform.position,transform.position) <= requireDistance)
        {
            canvas.gameObject.SetActive(true);
            canvas.transform.LookAt(player.transform);
            canvas.transform.Rotate(Vector3.up * 180);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public virtual void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Handles.Label(transform.position, "Interactable");
    }

    public virtual void Interact()
    {
    
    }
}
