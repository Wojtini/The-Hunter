using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private GameObject player;
    public float requireDistance = 2f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(player.transform.position,transform.position) <= requireDistance)
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
    
    }
}
