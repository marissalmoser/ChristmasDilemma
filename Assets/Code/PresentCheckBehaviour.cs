using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCheckBehaviour : MonoBehaviour
{
    SpriteRenderer sr;
    InteractingBehaviour ibc;

    public bool Interact;
    public bool HasInvestigated;

    GameBehaviour Gb;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();

        //getting InteractingBehaviour Component
        ibc = gameObject.GetComponent<InteractingBehaviour>();

        //getting the player behaviour script
        GameObject GameObject = GameObject.Find("GameObject");
        Gb = GameObject.GetComponent<GameBehaviour>();

        HasInvestigated = false;
    }

    //If player is by the object and E is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Interact == true)
        {
            sr.enabled = !sr.enabled;

            if (HasInvestigated == false)
            {
                Gb.PresentCheck();
                HasInvestigated = true;
                ibc.enabled = true;
                Destroy(this);
            }
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
        HasInvestigated = false;
    }
}
