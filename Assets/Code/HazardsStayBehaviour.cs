using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsStayBehaviour : MonoBehaviour
{
    public bool interact;

    HazardMeterBehaviour hmb;

    AudioSource sound;

    private void Start()
    {
        GameObject HazardMeter = GameObject.Find("HazardFill");
        hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();

        sound = gameObject.GetComponent<AudioSource>();
    }

    //Investigate: If player is by the object and E is pressed
    private void Update()
    {
        Vector2 campos = Camera.main.transform.position;

        if (Input.GetKeyDown(KeyCode.Mouse0) && interact == true)
        {
            hmb.HazardInc();
            sound.enabled = !sound.enabled;
            Destroy(this);
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
