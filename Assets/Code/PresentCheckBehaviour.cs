using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCheckBehaviour : MonoBehaviour
{
    SpriteRenderer sr;
    InteractingBehaviour ibc;

    public bool Interact;
    public bool HasPresent;

    GameBehaviour gb;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();

        //getting InteractingBehaviour Component
        ibc = gameObject.GetComponent<InteractingBehaviour>();

        //getting the player behaviour script
        GameObject GameObject = GameObject.Find("GameObject");
        gb = GameObject.GetComponent<GameBehaviour>();
    }

    //If player is by the object and mouse is clicked
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Interact == true)
        {
            sr.enabled = !sr.enabled;
            Debug.Log("sp check");

            if (HasPresent == true)
            {
                Debug.Log("if has present is true check");
                gb.PresentFound();
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
    }
}
