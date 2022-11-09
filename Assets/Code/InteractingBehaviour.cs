using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingBehaviour : MonoBehaviour
{
    bool interact;
    SpriteRenderer sr;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && interact == true)
        {
            sr.enabled = !sr.enabled;
        }
    }

    //check if player is by the object
    void OnTriggerEnter2D(Collider2D target)
    {
        interact = true;
    }

    void OnTriggerExit2D(Collider2D target)
    {
        interact = false;
    }
}