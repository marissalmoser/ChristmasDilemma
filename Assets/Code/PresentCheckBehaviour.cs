using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCheckBehaviour : MonoBehaviour
{
    SpriteRenderer sr;
    InteractingBehaviour ibc;

    public bool Interact;
    public bool HasInvestigated;
    public bool HasPresent;

    GameBehaviour Gb;
    public GameObject Lm;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();

        //getting InteractingBehaviour Component
        ibc = gameObject.GetComponent<InteractingBehaviour>();

        //getting the player behaviour script
        GameObject GameObject = GameObject.Find("GameObject");
        Gb = GameObject.GetComponent<GameBehaviour>();

        //getting the leve manager script
        GameObject LevelManage = GameObject.Find("LevelManage");
        Lm = LevelManage.GetComponent<LevelManager>();

        HasInvestigated = false;
    }

    //If player is by the object and E is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Interact == true)
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
