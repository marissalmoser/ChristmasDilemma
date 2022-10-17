using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateCabinet : MonoBehaviour
{
    SpriteRenderer sr;
    public bool Interact;

    GameBehaviour Gb;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();

        //getting the player behaviour script
        GameObject GameObject = GameObject.Find("GameObject");
        Gb = GameObject.GetComponent<GameBehaviour>();
    }

    //If player is by the object and E is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Interact == true)
        {
            sr.enabled = !sr.enabled;

            Gb.PresentFound();
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
