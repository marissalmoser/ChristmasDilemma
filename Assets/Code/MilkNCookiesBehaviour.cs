using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkNCookiesBehaviour : MonoBehaviour
{
    private bool interact;

    HazardMeterBehaviour Hmb;

    private void Start()
    {
        //getting the HazardMeterBehaviour script
        GameObject HazardMeter = GameObject.Find("HazardFill");
        Hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();
        Hmb.MnC = false;
    }

    //If player is by the object and E is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && interact == true)
        {
            Hmb.MnC = true;
            Destroy(gameObject);
            //play sound
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
