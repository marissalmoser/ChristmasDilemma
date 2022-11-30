using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkNCookiesBehaviour : MonoBehaviour
{
    private bool interact;

    HazardMeterBehaviour hmb;

    private void Start()
    {
        //getting the HazardMeterBehaviour script
        GameObject HazardMeter = GameObject.Find("HazardFill");
        hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();
        hmb.MnC = false;
    }

    //If player is by the object and E is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && interact == true)
        {
            hmb.MnC = true;
            Destroy(gameObject);
            //play eating sound
            hmb.MnCSymbol.SetActive(true);
            Invoke("MnCTextOff", 3f);
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
