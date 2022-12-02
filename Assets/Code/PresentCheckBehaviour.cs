using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCheckBehaviour : MonoBehaviour
{
    SpriteRenderer sr;
    InteractingBehaviour ibc;
    AudioSource sound;
    ParticleSystem ps;

    public bool Interact;
    public bool HasPresent;

    GameBehaviour gb;

    private void Start()
    {
        //getting components
        sr = gameObject.GetComponent<SpriteRenderer>();
        sound = gameObject.GetComponent<AudioSource>();
        ibc = gameObject.GetComponent<InteractingBehaviour>();
        ps = gameObject.GetComponent<ParticleSystem>();

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

            var em = ps.emission;
            em.enabled = false;

            if (HasPresent == true)
            {
                gb.PresentFound();
                sound.enabled = !sound.enabled;
                ibc.enabled = true;
                Destroy(this);
            }

            if (HasPresent == false)
            {
                ibc.enabled = true;
                Destroy(this);
            }
        }
    }

    //check if player is by the object, spawn particals
    void OnTriggerEnter2D(Collider2D target)
    {
        Interact = true;

        var em = ps.emission;
        em.enabled = true;
    }

    void OnTriggerExit2D(Collider2D target)
    {
        Interact = false;

        var em = ps.emission;
        em.enabled = false;
    }
}
