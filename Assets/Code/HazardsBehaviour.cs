using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsBehaviour : MonoBehaviour
{
    public bool interact;

    HazardMeterBehaviour hmb;

    AudioSource sound;
    SpriteRenderer sr;
    ParticleSystem ps;

    private void Start()
    {
        GameObject HazardMeter = GameObject.Find("HazardFill");
        hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();

        sound = gameObject.GetComponent<AudioSource>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    //Investigate: If player is by the object and E is pressed
    private void Update()
    {
        Vector2 campos = Camera.main.transform.position;

        if (Input.GetKeyDown(KeyCode.Mouse0) && interact == true)
        {
            hmb.HazardInc();
            sound.enabled = !sound.enabled;
            sr.enabled = !sr.enabled;
            var em = ps.emission;
            em.enabled = false;
            Destroy(this);
        }
    }

    //check if player is by the object
    void OnTriggerEnter2D(Collider2D target)
    {
        interact = true;

        var em = ps.emission;
        em.enabled = true;
    }

    void OnTriggerExit2D(Collider2D target)
    {
        interact = false;

        var em = ps.emission;
        em.enabled = false;
    }
}
