using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingBehaviour : MonoBehaviour
{
    bool Interact;
    SpriteRenderer sr;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Interact == true)
        {
            sr.enabled = !sr.enabled;
        }
    }

    //check if player is by the object
    void OnTriggerEnter2D(Collider2D target)
    {
        Interact = true;
    }

    void OnTriggerExit2D(Collider2D target)
    {
        Interact = false;
    }
}